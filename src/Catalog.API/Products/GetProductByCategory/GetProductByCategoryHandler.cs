﻿namespace Catalog.API.Products.GetProductByCategory;

public record GetProductByCategoryQuery(string category) : IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<Product> Products);

internal class GetProductByCategoryQueryHandler(IDocumentSession session)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>()
                        .Where(a => a.Category.Contains(query.category))
                        .ToListAsync(cancellationToken);

        return new GetProductByCategoryResult(products);
    }
}

