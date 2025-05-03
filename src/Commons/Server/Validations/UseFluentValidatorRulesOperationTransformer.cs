﻿using FluentValidation;
using FluentValidation.Validators;
using Menso.Tools.Exceptions;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

// ReSharper disable once CheckNamespace
namespace Andromeda;

public class UseFluentValidatorRulesOperationTransformer : IOpenApiOperationTransformer
{
    public Task TransformAsync(OpenApiOperation operation, OpenApiOperationTransformerContext context, CancellationToken cancellationToken)
    {
        // TODO: Melhorar ideia para receber mais informações via metadata, se é body ou parameter e etc..
        
        var handlerEndpointMetadata = context.Description.ActionDescriptor.EndpointMetadata
            .OfType<HandlerDefinitionMetadata>()
            .FirstOrDefault();
        
        if(handlerEndpointMetadata is null || handlerEndpointMetadata.RequireValidation is false) return Task.CompletedTask;
        
        // 2. Try to take the validator from the context
        var validatorType = typeof(IValidator<>).MakeGenericType(handlerEndpointMetadata.RequestType);
        var validator = context.ApplicationServices.GetService(validatorType);
        Throw.When.Null(validator, $"[{GetType().FullName}] :: Validator not found for type {handlerEndpointMetadata.RequestType.FullName}");

        // 3. Try to take the validator descriptor from the context
        var validatorDescriptor = ((IValidator)validator).CreateDescriptor();
        
        // 4. Add the validator rules into the request body
        AddValidatorRulesIntoParameter(operation, validatorDescriptor);
        
        return Task.CompletedTask;
    }
    
    private static void AddValidatorRulesIntoParameter(OpenApiOperation requestBody, IValidatorDescriptor validatorDescriptor)
    {
        var apiProperties = requestBody.RequestBody.Content["application/json"].Schema.Properties;
        
        foreach (var (key, parameter) in apiProperties)
        {
            // CamelCase property name
            var name = ToPascalCase(key);
            var validationRuleProperty = BuildValidationRuleProperty(validatorDescriptor, name);
            
            parameter.MinLength = validationRuleProperty.MinLength;
            parameter.MaxLength = validationRuleProperty.MaxLength;
            parameter.Minimum = validationRuleProperty.Minimum;
            parameter.Maximum = validationRuleProperty.Maximum;
            parameter.ExclusiveMinimum = validationRuleProperty.ExclusiveMinimum;    
            parameter.ExclusiveMaximum = validationRuleProperty.ExclusiveMaximum;
            parameter.Nullable = validationRuleProperty.Nullable;
            parameter.Pattern = validationRuleProperty.Pattern;

            if (validationRuleProperty.IsEmail)
            {
                parameter.Format = "email";
            }

            if (!validationRuleProperty.Nullable)
            {
                requestBody.RequestBody.Content["application/json"].Schema.Required.Add(key);
            }
        }   
    }


    private static ValidationRuleProperty BuildValidationRuleProperty(IValidatorDescriptor validatorDescriptor, string name)
    {
        var rules = validatorDescriptor.GetRulesForMember(name);
        var validationRuleProperty = new ValidationRuleProperty();
        foreach (var validator in rules
                     .SelectMany(x => x.Components)
                     .Where(c => !c.HasCondition)
                     .Select(c => c.Validator))
        { 
            switch (validator)
            {
                case INotEmptyValidator: case INotNullValidator: 
                    validationRuleProperty.Nullable = false;
                    
                    // if validator is for string value and is not null, then set min length to 1
                    validationRuleProperty.MinLength ??= 1;
                    
                    break;
                case IMinimumLengthValidator minLengthValidator: validationRuleProperty.MinLength = minLengthValidator.Min; break;
                case IMaximumLengthValidator maxLengthValidator: validationRuleProperty.MaxLength = maxLengthValidator.Max; break;
                case ILengthValidator lengthValidator:
                    validationRuleProperty.MinLength = lengthValidator.Min;
                    validationRuleProperty.MaxLength = lengthValidator.Max;
                    break;
                case IBetweenValidator betweenValidator:
                    validationRuleProperty.Minimum = Convert.ToDecimal(betweenValidator.From);
                    validationRuleProperty.Maximum = Convert.ToDecimal(betweenValidator.To);
                    validationRuleProperty.ExclusiveMinimum = betweenValidator.Name.Contains("exclusive", StringComparison.OrdinalIgnoreCase);
                    validationRuleProperty.ExclusiveMaximum = betweenValidator.Name.Contains("exclusive", StringComparison.OrdinalIgnoreCase);
                break;
                case IComparisonValidator comparisonValidator:
                    if (comparisonValidator.Comparison == Comparison.LessThan)
                    {
                        validationRuleProperty.Maximum = Convert.ToDecimal(comparisonValidator.ValueToCompare);
                        validationRuleProperty.ExclusiveMaximum = true;
                    }
                    else if (comparisonValidator.Comparison == Comparison.LessThanOrEqual)
                    {
                        validationRuleProperty.Maximum = Convert.ToDecimal(comparisonValidator.ValueToCompare);
                        validationRuleProperty.ExclusiveMaximum = false;
                    }
                    else if (comparisonValidator.Comparison == Comparison.GreaterThan)
                    {
                        validationRuleProperty.Minimum = Convert.ToDecimal(comparisonValidator.ValueToCompare);
                        validationRuleProperty.ExclusiveMaximum = true;
                    }
                    else if (comparisonValidator.Comparison == Comparison.GreaterThanOrEqual)
                    {
                        validationRuleProperty.Minimum = Convert.ToDecimal(comparisonValidator.ValueToCompare);
                        validationRuleProperty.ExclusiveMaximum = false;
                    }
                    break;
                case IRegularExpressionValidator regexValidator: validationRuleProperty.Pattern = regexValidator.Expression; break;
                case IEmailValidator: validationRuleProperty.IsEmail = true; break;
            }
        }
        
        return validationRuleProperty;
    }
    
    private static string ToPascalCase(string? value)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;
        return char.ToUpper(value[0]) + value[1..];
        
    }

    private record ValidationRuleProperty
    {
        public bool Nullable { get; set; } = true;
        public int? MinLength { get; set; }
        public int? MaxLength { get; set; }
        public decimal? Minimum { get; set; }
        public decimal? Maximum { get; set; }
        public bool? ExclusiveMinimum { get; set; }
        public bool? ExclusiveMaximum { get; set; }
        public string? Pattern { get; set; }
        public bool IsEmail { get; set; }
        
    }
}