using System.Net;
using Hapvida.Core.Api.Http.Controllers;
using Hapvida.Core.Api.Http.Models;
using Hapvida.Core.Domain.Contracts;
using Hapvida.Core.Domain.Models;
using Hapvida.Hapvida.Assistance.Identity.Api.Domain.Commands.v1.Examples.Create;
using Hapvida.Hapvida.Assistance.Identity.Api.Infra.Data.Queries.v1.Examples.GetAll;

namespace Hapvida.Hapvida.Assistance.Identity.Api.Api.Controllers.v1;

[Route("api/v1/examples")]
public class ExampleController : BaseController

{
    public ExampleController(IMediator bus, IDomainContextNotifications domainNotificationContext,
        ApplicationSettings settings) : base(bus, domainNotificationContext, settings)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(Response), 200)]
    [ProducesResponseType(typeof(Response), 400)]
    public async Task<IActionResult> GetByFiltersAsync(
        CancellationToken cancellationToken)
    {
        return await ExecuteAsync(new GetAllQuery(), cancellationToken);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Response), 201)]
    [ProducesResponseType(typeof(Response), 400)]
    public async Task<IActionResult> CreateAsync(
        [FromBody] CreateExampleCommand command,
        CancellationToken cancellationToken)
    {
        return await ExecuteAsync(command,
            (int) HttpStatusCode.Created,
            cancellationToken: cancellationToken);
    }
}