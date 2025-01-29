using ActDigital.Store.Core.Messages;
using FluentValidation;

namespace ActDigital.Store.Sales.Application.Commands;

public class RemoveSaleCommand : Command
{
    public Guid Id { get; set; }
    
    public RemoveSaleCommand(Guid id)
    {
        Id = id;
    }
    
    public override bool IsValid()
    {
        ValidationResult = new RemoveSaleValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}

public class RemoveSaleValidation : AbstractValidator<RemoveSaleCommand>
{
    public RemoveSaleValidation()
    {
        RuleFor(c => c.Id)
            .NotNull()
            .WithMessage("Id cannot be null");
    }
}