using AutoMapper;
using Hapvida.Hapvida.Assistance.Identity.Api.Domain.Entities.v1;

namespace Hapvida.Hapvida.Assistance.Identity.Api.Infra.Data.Queries.v1.Examples.GetAll;

public sealed class GetAllQueryProfile : Profile
{
    public GetAllQueryProfile()
    {
        CreateMap<Example, GetAllQueryResponseDetail>(MemberList.None);
    }
}