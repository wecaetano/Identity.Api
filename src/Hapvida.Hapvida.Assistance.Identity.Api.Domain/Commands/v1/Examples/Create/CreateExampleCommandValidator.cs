using FluentValidation;

namespace Hapvida.Hapvida.Assistance.Identity.Api.Domain.Commands.v1.Examples.Create;

public sealed class CreateExampleCommandValidator : AbstractValidator<CreateExampleCommand>
{
    public CreateExampleCommandValidator()
    {
        RuleFor(x => x.CustomField)
            .NotEmpty();
    }
}