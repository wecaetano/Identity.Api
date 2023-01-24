using System.Threading;
using System.Threading.Tasks;
using Hapvida.Core.Domain.Handlers;
using Hapvida.Core.Domain.Models;

namespace Hapvida.Hapvida.Assistance.Identity.Api.Infra.Data.Queries.v1.Examples.GetAll;

public sealed class GetAllQueryHandler : QueryHandler<GetAllQuery>
{
    //private readonly IMapper _mapper;
    //private readonly IRepository<Example, Guid> _repository;

    //public GetAllQueryHandler(IMapper mapper, IRepository<Example, Guid> repository)
    //{
    //    _mapper = mapper;
    //    _repository = repository;
    //}

    public override  Task<Response> Handle(GetAllQuery query, CancellationToken cancellationToken)
    {
        //var examples = await _repository.GetAllAsync(cancellationToken);

        //var response = new GetAllQueryResponse
        //{
        //    Examples = _mapper.Map<List<Example>, List<GetAllQueryResponseDetail>>(examples)
        //};

        return Task.FromResult(new Response {Content = null});
    }
}