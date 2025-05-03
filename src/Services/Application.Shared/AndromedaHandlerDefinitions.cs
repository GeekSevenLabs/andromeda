using Andromeda.Application.Shared.Customers.Edit;
using Andromeda.Application.Shared.Customers.Get;
using Andromeda.Application.Shared.Customers.List;
using Andromeda.Application.Shared.Customers.Remove;
using Andromeda.Application.Shared.Products.Edit;
using Andromeda.Application.Shared.Products.Get;
using Andromeda.Application.Shared.Products.List;
using Andromeda.Application.Shared.Quotations.Create;
using Andromeda.Application.Shared.Quotations.EditeItem;
using Andromeda.Application.Shared.Quotations.Get;
using Andromeda.Application.Shared.Quotations.GetItem;
using Andromeda.Application.Shared.Quotations.List;
using Andromeda.Application.Shared.Quotations.RemoveItem;
using Andromeda.Application.Shared.RawMaterials;
using Andromeda.Application.Shared.RawMaterials.Edit;
using Andromeda.Application.Shared.RawMaterials.Get;
using Andromeda.Application.Shared.RawMaterials.List;
using Andromeda.Application.Shared.RawMaterials.Remove;

namespace Andromeda.Application.Shared;

public static class AndromedaHandlerDefinitions
{
    private const string V1Base = "api/v1";
    
    public static class Customers
    {
        private const string Base = V1Base + "/customers";
        private const string Tag = nameof(Customers);

        public static readonly HandlerDefinition<EditCustomerRequest> EditCustomer = 
            HandlerDefinitionBuilder<EditCustomerRequest>
            .Create()
            .UseMapPost(Base)
            .UseRouteBuilder(_ => Base)
            .WithName("Edit Customer")
            .WithDescription("Edit a customer.")
            .WithTag(Tag)
            .RequireValidation<EditCustomerValidator>()
            .RequireAuthorization()
            .Build();

        public static readonly HandlerDefinition<GetCustomerRequest, GetCustomerResponse> GetCustomer = 
            HandlerDefinitionBuilder<GetCustomerRequest, GetCustomerResponse>
            .Create()
            .UseMapGet($"{Base}/{{Id:guid}}")
            .UseRouteBuilder(request => $"{Base}/{request.Id}")
            .WithName("Get Customer")
            .WithDescription("Get a customer.")
            .WithTag(Tag)
            .RequireValidation<GetCustomerValidator>()
            .RequireAuthorization()
            .Build();
        
        public static readonly HandlerDefinition<ListCustomersRequest, ListCustomersResponseItem[]> ListCustomers = 
            HandlerDefinitionBuilder<ListCustomersRequest, ListCustomersResponseItem[]>
            .Create()
            .UseMapGet(Base)
            .UseRouteBuilder(_ => Base)
            .WithName("List Customers")
            .WithDescription("List customers.")
            .WithTag(Tag)
            .RequireAuthorization()
            .Build();
        
        public static readonly HandlerDefinition<RemoveCustomerRequest> RemoveCustomer = HandlerDefinitionBuilder<RemoveCustomerRequest>
            .Create()
            .UseMapDelete($"{Base}/{{Id:guid}}")
            .UseRouteBuilder(request => $"{Base}/{request.Id}")
            .WithName("Remove Customer")
            .WithDescription("Remove a customer.")
            .WithTag(Tag)
            .RequireValidation<RemoveCustomerValidator>()
            .RequireAuthorization()
            .Build();
    }
    
    public static class Products
    {
        private const string Base = V1Base + "/products";
        private const string Tag = nameof(Products);
        
        public static readonly HandlerDefinition<EditProductRequest> EditProduct = HandlerDefinitionBuilder<EditProductRequest>
            .Create()
            .UseMapPost(Base)
            .UseRouteBuilder(_ => Base)
            .WithName("Edit Product")
            .WithDescription("Edit a product.")
            .WithTag(Tag)
            .RequireValidation<EditProductValidator>()
            .RequireAuthorization()
            .Build();

        public static readonly HandlerDefinition<GetProductRequest, GetProductResponse> GetProduct = HandlerDefinitionBuilder<GetProductRequest, GetProductResponse>
            .Create()
            .UseMapGet($"{Base}/{{Id:guid}}")
            .UseRouteBuilder(request => $"{Base}/{request.Id}")
            .WithName("Get Product")
            .WithDescription("Get a product.")
            .WithTag(Tag)
            .RequireValidation<GetProductValidator>()
            .RequireAuthorization()
            .Build();
        
        public static readonly HandlerDefinition<ListProductsRequest, ListProductsResponseItem[]> ListProducts = HandlerDefinitionBuilder<ListProductsRequest, ListProductsResponseItem[]>
            .Create()
            .UseMapGet(Base)
            .UseRouteBuilder(_ => Base)
            .WithName("List Products")
            .WithDescription("List products.")
            .WithTag(Tag)
            .RequireAuthorization()
            .Build();
    }
    
    public static class Quotations
    {
        private const string Base = V1Base + "/quotations";
        private const string Tag = nameof(Quotations);
        
        public static readonly HandlerDefinition<CreateQuotationRequest, CreateQuotationResponse> CreateQuotation = HandlerDefinitionBuilder<CreateQuotationRequest, CreateQuotationResponse>
            .Create()
            .UseMapPost(Base)
            .UseRouteBuilder(_ => Base)
            .WithName("Create Quotation")
            .WithDescription("Create a quotation.")
            .WithTag(Tag)
            .RequireValidation<CreateQuotationValidator>()
            .RequireAuthorization()
            .Build();

        public static readonly HandlerDefinition<EditQuotationItemRequest> EditQuotationItem = HandlerDefinitionBuilder<EditQuotationItemRequest>
            .Create()
            .UseMapPost(Base + "/items")
            .UseRouteBuilder(_ => Base + "/items")
            .WithName("Edit Quotation Item")
            .WithDescription("Edit a quotation item.")
            .WithTag(Tag)
            .RequireValidation<EditQuotationItemValidator>()
            .RequireAuthorization()
            .Build();

        public static readonly HandlerDefinition<ListQuotationsRequest, ListQuotationsResponseItem[]> ListQuotations = HandlerDefinitionBuilder<ListQuotationsRequest, ListQuotationsResponseItem[]>
            .Create()
            .UseMapGet(Base)
            .UseRouteBuilder(_ => Base)
            .WithName("List Quotations")
            .WithDescription("List quotations.")
            .WithTag(Tag)
            .RequireAuthorization()
            .Build();
        
        public static readonly HandlerDefinition<GetQuotationRequest, GetQuotationResponse> GetQuotation = HandlerDefinitionBuilder<GetQuotationRequest, GetQuotationResponse>
            .Create()
            .UseMapGet($"{Base}/{{Id:guid}}")
            .UseRouteBuilder(request => $"{Base}/{request.Id}")
            .WithName("Get Quotation")
            .WithDescription("Get a quotation.")
            .WithTag(Tag)
            .RequireValidation<GetQuotationValidator>()
            .RequireAuthorization()
            .Build();
        
        public static readonly HandlerDefinition<GetQuotationItemRequest, GetQuotationItemResponse> GetQuotationItem = HandlerDefinitionBuilder<GetQuotationItemRequest, GetQuotationItemResponse>
            .Create()
            .UseMapGet($"{Base}/Items/{{Id:guid}}")
            .UseRouteBuilder(request => $"{Base}/Items/{request.Id}")
            .WithName("Get Quotation Item")
            .WithDescription("Get a quotation item.")
            .WithTag(Tag)
            .RequireValidation<GetQuotationItemValidator>()
            .RequireAuthorization()
            .Build();
        
        public static readonly HandlerDefinition<RemoveQuotationItemRequest> RemoveQuotationItem = HandlerDefinitionBuilder<RemoveQuotationItemRequest>
            .Create()
            .UseMapDelete($"{Base}/{{Id:guid}}/Items/{{ItemId:guid}}")
            .UseRouteBuilder(request => $"{Base}/{request.Id}/Items/{request.ItemId}")
            .WithName("Remove Quotation Item")
            .WithDescription("Remove a quotation item.")
            .WithTag(Tag)
            .RequireValidation<RemoveQuotationItemValidator>()
            .RequireAuthorization()
            .Build();
    }
    
    public static class RawMaterials
    {
        private const string Base = V1Base + "/raw-materials";
        private const string Tag = nameof(RawMaterials);
        
        public static readonly HandlerDefinition<EditRawMaterialRequest> EditRawMaterial = HandlerDefinitionBuilder<EditRawMaterialRequest>
            .Create()
            .UseMapPost(Base)
            .UseRouteBuilder(_ => Base)
            .WithName("Edit Raw Material")
            .WithDescription("Edit a raw material.")
            .WithTag(Tag)
            .RequireValidation<EditRawMaterialValidator>()
            .RequireAuthorization()
            .Build();

        public static readonly HandlerDefinition<GetRawMaterialRequest, RawMaterialDto> GetRawMaterial = HandlerDefinitionBuilder<GetRawMaterialRequest, RawMaterialDto>
            .Create()
            .UseMapGet($"{Base}/{{Id:guid}}")
            .UseRouteBuilder(request => $"{Base}/{request.Id}")
            .WithName("Get Raw Material")
            .WithDescription("Get a raw material.")
            .WithTag(Tag)
            .RequireValidation<GetRawMaterialValidator>()
            .RequireAuthorization()
            .Build();
        
        public static readonly HandlerDefinition<ListRawMaterialsRequest, RawMaterialDto[]> ListRawMaterials = HandlerDefinitionBuilder<ListRawMaterialsRequest, RawMaterialDto[]>
            .Create()
            .UseMapGet(Base)
            .UseRouteBuilder(_ => Base)
            .WithName("List Raw Materials")
            .WithDescription("List raw materials.")
            .WithTag(Tag)
            .RequireAuthorization()
            .Build();
        
        public static readonly HandlerDefinition<RemoveRawMaterialRequest> RemoveRawMaterial = HandlerDefinitionBuilder<RemoveRawMaterialRequest>
            .Create()
            .UseMapDelete($"{Base}/{{Id:guid}}")
            .UseRouteBuilder(request => $"{Base}/{request.Id}")
            .WithName("Remove Raw Material")
            .WithDescription("Remove a raw material.")
            .WithTag(Tag)
            .RequireValidation<RemoveRawMaterialValidator>()
            .RequireAuthorization()
            .Build();
    }
}