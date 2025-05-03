namespace Andromeda;

public class HandlerDefinitionMetadata
{
    public required Type RequestType { get; init; }
    public required Type ValidatorType { get; init; }
    public required string Path { get; init; }
    public required bool RequireValidation { get; init; }
}