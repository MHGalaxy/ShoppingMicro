using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Core.SpecsParams;
using Catalog.Core.SpecsParams.Common;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository(ICatalogContext context) : IProductRepository
{
    public async Task<Pagination<Product>> GetAllProductsAsync(ProductSpecsParams specsParams)
    {
        //filter data
        var filterBuilder = Builders<Product>.Filter;
        var filters = filterBuilder.Empty;
        filters = CreateProductFilterDefinition(specsParams, filterBuilder, filters);

        //sort data
        var sortBuilder = Builders<Product>.Sort;
        var sort = sortBuilder.Descending(x => x.CreatedAt);
        sort = CreateProductSortDefinition(specsParams, sortBuilder, sort);

        var totalItemsCount = await context.Products.CountDocumentsAsync(filters);
        var dataList = await context.Products
            .Find(filters)
            .Sort(sort)
            .Skip(specsParams.PageSize * (specsParams.PageIndex - 1))
            .Limit(specsParams.PageSize)
            .ToListAsync();

        return new Pagination<Product>(specsParams.PageIndex, specsParams.PageSize, totalItemsCount, dataList);
    }

    public async Task<Product> GetProductByIdAsync(string id) 
        => await context.Products.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name) 
        => await context.Products.Find(x => x.Name.ToLower().Contains(name.ToLower())).ToListAsync();

    public async Task<IEnumerable<Product>> GetProductsByTypeAsync(string type) 
        => await context.Products.Find(x => x.Type.Name.ToLower().Contains(type.ToLower())).ToListAsync();

    public async Task<IEnumerable<Product>> GetProductsByTypeIdAsync(string typeId) 
        => await context.Products.Find(x => x.Type.Id == typeId).ToListAsync();

    public async Task<IEnumerable<Product>> GetProductsByBrandAsync(string brand) 
        => await context.Products.Find(x => x.Brand.Name.ToLower().Contains(brand.ToLower())).ToListAsync();

    public async Task<IEnumerable<Product>> GetProductsByBrandIdAsync(string brandId) 
        => await context.Products.Find(x => x.Brand.Id == brandId).ToListAsync();

    public async Task<Product> CreateProductAsync(Product product)
    {
        await context.Products.InsertOneAsync(product);
        return product;
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        var result = await context.Products.ReplaceOneAsync(x => x.Id == product.Id, product);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteProductAsync(string id)
    {
        var result = await context.Products.DeleteOneAsync(x => x.Id == id);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<bool> DeleteProductAsync(Product product) => await DeleteProductAsync(product.Id);

    #region Helpers

    private static FilterDefinition<Product> CreateProductFilterDefinition(
        ProductSpecsParams specsParams,
        FilterDefinitionBuilder<Product> filterBuilder,
        FilterDefinition<Product> filters)
    {
        if (!string.IsNullOrEmpty(specsParams.Search))
        {
            var productNameFilter = filterBuilder.Where(x => x.Name.ToLower().Contains(specsParams.Search.ToLower()));
            filters &= productNameFilter;
        }

        if (!string.IsNullOrEmpty(specsParams.BrandId))
        {
            var brandIdFilter = filterBuilder.Eq(x => x.Brand.Id, specsParams.BrandId);
            filters &= brandIdFilter;
        }

        if (!string.IsNullOrEmpty(specsParams.TypeId))
        {
            var typeIdFilter = filterBuilder.Eq(x => x.Type.Id, specsParams.TypeId);
            filters &= typeIdFilter;
        }

        if (!string.IsNullOrEmpty(specsParams.BrandName))
        {
            var brandNameFilter = filterBuilder.Where(x => x.Brand.Name.ToLower().Contains(specsParams.BrandName.ToLower()));
            filters &= brandNameFilter;
        }

        if (!string.IsNullOrEmpty(specsParams.TypeName))
        {
            var typeNameFilter = filterBuilder.Where(x => x.Type.Name.ToLower().Contains(specsParams.TypeName.ToLower()));
            filters &= typeNameFilter;
        }

        return filters;
    }

    private static SortDefinition<Product> CreateProductSortDefinition(
        ProductSpecsParams specsParams,
        SortDefinitionBuilder<Product> sortBuilder,
        SortDefinition<Product> sort)
    {
        if (!string.IsNullOrEmpty(specsParams.SortField))
        {
            sort = (specsParams.SortField, specsParams.SortType) switch
            {
                ("Id", SortType.Asc) => sortBuilder.Ascending(x => x.Id),
                ("Id", SortType.Desc) => sortBuilder.Descending(x => x.Id),
                ("Name", SortType.Asc) => sortBuilder.Ascending(x => x.Name),
                ("Name", SortType.Desc) => sortBuilder.Descending(x => x.Name),
                ("Price", SortType.Asc) => sortBuilder.Ascending(x => x.Price),
                ("Price", SortType.Desc) => sortBuilder.Descending(x => x.Price),
                ("CreatedAt", SortType.Asc) => sortBuilder.Ascending(x => x.CreatedAt),
                ("CreatedAt", SortType.Desc) => sortBuilder.Descending(x => x.CreatedAt),
                ("UpdatedAt", SortType.Asc) => sortBuilder.Ascending(x => x.UpdatedAt),
                ("UpdatedAt", SortType.Desc) => sortBuilder.Descending(x => x.UpdatedAt),
                _ => sort
            };
        }

        return sort;
    }

    #endregion

}
