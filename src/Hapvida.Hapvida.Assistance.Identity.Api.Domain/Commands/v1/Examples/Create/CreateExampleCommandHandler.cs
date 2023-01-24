using System.Threading;
using System.Threading.Tasks;
using Hapvida.Core.Domain.Handlers;
using Hapvida.Core.Domain.Models;
using Hapvida.Hapvida.Assistance.Identity.Api.Domain.Entities.v1;

namespace Hapvida.Hapvida.Assistance.Identity.Api.Domain.Commands.v1.Examples.Create;

public sealed class CreateExampleCommandHandler : CommandHandler<CreateExampleCommand>
{
    //private readonly IRepository<Example, Guid> _repository;

    //public CreateExampleCommandHandler(IRepository<Example, Guid> repository)
    //{
    //    _repository = repository;
    //}

    public override  Task<Response> Handle(CreateExampleCommand command, CancellationToken cancellationToken)
    {
        var example = new Example
        {
            CustomField = command.CustomField
        };

        //await _repository.AddAsync(example, cancellationToken);

        return Task.FromResult(new Response
        {
            Content = example
        });
    }
}