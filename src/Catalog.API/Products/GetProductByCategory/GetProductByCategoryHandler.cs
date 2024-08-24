namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string category) : IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<Product> Products);

internal class GetProductByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductByCategoryQueryHandler> logger)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByCategoryQueryHandler.Handle called with {@Query}", query);

        var products = await session.Query<Product>()
                        .Where(a => a.Category.Contains(query.category))
                        .ToListAsync(cancellationToken);

        return new GetProductByCategoryResult(products);
    }
}

