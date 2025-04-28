using System.Text.Json.Serialization;
using Andromeda.Application.Shared.Customers.Edit;
using Andromeda.Application.Shared.Customers.Get;
using Andromeda.Application.Shared.Customers.List;
using Andromeda.Application.Shared.Products.Edit;
using Andromeda.Application.Shared.Products.Get;
using Andromeda.Application.Shared.Products.List;
using Andromeda.Application.Shared.Quotations.Create;
using Andromeda.Application.Shared.Quotations.EditeItem;
using Andromeda.Application.Shared.Quotations.Get;
using Andromeda.Application.Shared.Quotations.GetItem;
using Andromeda.Application.Shared.Quotations.List;
using Andromeda.Application.Shared.Quotations.RemoveItem;
using Andromeda.Application.Shared.RawMaterials.Edit;
using Andromeda.Application.Shared.RawMaterials.Get;
using Andromeda.Application.Shared.RawMaterials.List;

namespace Andromeda.Application.Shared;

[JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]

[JsonSerializable(typeof(EditRawMaterialRequest))]
[JsonSerializable(typeof(GetRawMaterialResponse))]
[JsonSerializable(typeof(ListRawMaterialsRequest))]
[JsonSerializable(typeof(ListRawMaterialsResponseItem[]))]
[JsonSerializable(typeof(ValueRequest<Guid>))]

[JsonSerializable(typeof(EditProductRequest))]
[JsonSerializable(typeof(GetProductResponse))]
[JsonSerializable(typeof(ListProductsRequest))]
[JsonSerializable(typeof(ListProductsResponseItem[]))]

[JsonSerializable(typeof(EditCustomerRequest))]
[JsonSerializable(typeof(GetCustomerResponse))]
[JsonSerializable(typeof(ListCustomersRequest))]
[JsonSerializable(typeof(ListCustomersResponseItem[]))]

[JsonSerializable(typeof(CreateQuotationRequest))]
[JsonSerializable(typeof(CreateQuotationResponse))]
[JsonSerializable(typeof(ListQuotationsResponseItem[]))]
[JsonSerializable(typeof(GetQuotationResponse))]
[JsonSerializable(typeof(EditQuotationItemRequest))]
[JsonSerializable(typeof(RemoveQuotationItemRequest))]
[JsonSerializable(typeof(GetQuotationItemResponse))]
public partial class AndromedaSerializationContext : JsonSerializerContext;