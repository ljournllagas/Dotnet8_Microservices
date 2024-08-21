using MediatR;

namespace BuildingBlocks.CQRS;

public interface IQueryHandler<in TQUery, TResponse>
    : IRequestHandler<TQUery, TResponse>
    where TQUery : IQuery<TResponse>
    where TResponse : notnull
{
}

