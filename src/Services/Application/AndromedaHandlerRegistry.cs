using Andromeda.Application.Customers.Edit;
using Andromeda.Application.Customers.Get;
using Andromeda.Application.Customers.List;
using Andromeda.Application.Customers.Remove;
using Andromeda.Application.Products.Edit;
using Andromeda.Application.Products.Get;
using Andromeda.Application.Products.List;
using Andromeda.Application.Quotations.Create;
using Andromeda.Application.Quotations.EditeItem;
using Andromeda.Application.Quotations.Get;
using Andromeda.Application.Quotations.GetItem;
using Andromeda.Application.Quotations.List;
using Andromeda.Application.Quotations.RemoveItem;
using Andromeda.Application.RawMaterials.Edit;
using Andromeda.Application.RawMaterials.Get;
using Andromeda.Application.RawMaterials.List;
using Andromeda.Application.RawMaterials.Remove;
using Andromeda.Application.Shared;
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
using Andromeda.Application.Shared.RawMaterials.Edit;
using Andromeda.Application.Shared.RawMaterials.Get;
using Andromeda.Application.Shared.RawMaterials.List;
using Andromeda.Application.Shared.RawMaterials.Remove;

namespace Andromeda.Application;

using AHD = AndromedaHandlerDefinitions;

public static class AndromedaHandlerRegistry
{
    public static void Register(IHandlerRegistry registry)
    {
        registry
            .Register<EditRawMaterialHandler, EditRawMaterialRequest>(AHD.RawMaterials.EditRawMaterial)
            .Register<GetRawMaterialHandler, GetRawMaterialRequest, GetRawMaterialResponse>(AHD.RawMaterials.GetRawMaterial)
            .Register<ListRawMaterialsHandler, ListRawMaterialsRequest, ListRawMaterialsResponseItem[]>(AHD.RawMaterials.ListRawMaterials)
            .Register<RemoveRawMaterialHandler, RemoveRawMaterialRequest>(AHD.RawMaterials.RemoveRawMaterial)
            
            .Register<EditProductHandler, EditProductRequest>(AHD.Products.EditProduct)
            .Register<GetProductHandler, GetProductRequest, GetProductResponse>(AHD.Products.GetProduct)
            .Register<ListProductsHandler, ListProductsRequest, ListProductsResponseItem[]>(AHD.Products.ListProducts)

            .Register<EditCustomerHandler, EditCustomerRequest>(AHD.Customers.EditCustomer)
            .Register<GetCustomerHandler, GetCustomerRequest, GetCustomerResponse>(AHD.Customers.GetCustomer)
            .Register<ListCustomersHandler, ListCustomersRequest, ListCustomersResponseItem[]>(AHD.Customers.ListCustomers)
            .Register<RemoveCustomerHandler, RemoveCustomerRequest>(AHD.Customers.RemoveCustomer)

            .Register<CreateQuotationHandler, CreateQuotationRequest, CreateQuotationResponse>(AHD.Quotations.CreateQuotation)
            .Register<ListQuotationsHandler, ListQuotationsRequest, ListQuotationsResponseItem[]>(AHD.Quotations.ListQuotations)
            .Register<GetQuotationHandler, GetQuotationRequest, GetQuotationResponse>(AHD.Quotations.GetQuotation)
            .Register<EditQuotationItemHandler, EditQuotationItemRequest>(AHD.Quotations.EditQuotationItem)
            .Register<RemoveQuotationItemHandler, RemoveQuotationItemRequest>(AHD.Quotations.RemoveQuotationItem)
            .Register<GetQuotationItemHandler, GetQuotationItemRequest, GetQuotationItemResponse>(AHD.Quotations.GetQuotationItem);
    }
}