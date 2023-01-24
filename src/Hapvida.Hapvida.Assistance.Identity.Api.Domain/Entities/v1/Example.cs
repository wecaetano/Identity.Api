using System;
using Hapvida.Core.Domain.Contracts;

namespace Hapvida.Hapvida.Assistance.Identity.Api.Domain.Entities.v1;

public class Example : IEntity<Guid>
{
    public Example()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.Now;
    }

    public DateTime CreatedAt { get; set; }

    public string? CustomField { get; set; }

    public Guid Id { get; set; }
}