using System.Collections.Generic;

namespace Hapvida.Hapvida.Assistance.Identity.Api.Infra.Data.Queries.v1.Examples.GetAll;

public sealed record GetAllQueryResponse
{
    public IReadOnlyCollection<GetAllQueryResponseDetail>? Examples { get; init; }
}