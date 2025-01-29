using ActDigital.Store.Core.Messages;
using ActDigital.Store.Sales.Application.ViewModels;
using FluentValidation;

namespace ActDigital.Store.Sales.Application.Commands;

public class AddSaleCommand : Command
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int SaleNumber { get; set; }
    public DateTime? Date { get; set; }
    public Guid CustomerId { get; set; }
    public string BranchSaleMade { get; set; }
    public ICollection<ProductViewModel> Products { get; set; }
    public decimal TotalSaleAmount { get; set; }
    public bool IsActive { get; set; }
    
    public AddSaleCommand(Guid id, int saleNumber, DateTime? date, Guid customerId, string branchSaleMade, ICollection<ProductViewModel> products, decimal totalSaleAmount, bool isActive)
    {
        Id = id;
        SaleNumber = saleNumber;
        Date = date;
        CustomerId = customerId;
        BranchSaleMade = branchSaleMade;
        Products = products;
        TotalSaleAmount = totalSaleAmount;
        IsActive = isActive;
    }
    
    public override bool IsValid()
    {
        ValidationResult = new AddSaleValidation().Validate(this);
        return ValidationResult.IsValid;
    }
}

public class AddSaleValidation : AbstractValidator<AddSaleCommand>
{
    public AddSaleValidation()
    {
        RuleFor(c => c.Id)
            .NotNull()
            .WithMessage("Id cannot be null");

        RuleFor(c => c.SaleNumber)
            .NotNull()
            .GreaterThan(0)
            .WithMessage("SaleNumber must be greater than 0");

        RuleFor(c => c.Date)
            .NotNull()
            .WithMessage("Date cannot be null");

        RuleFor(c => c.CustomerId)
            .NotNull()
            .WithMessage("CustomerId cannot be null");

        RuleFor(c => c.BranchSaleMade)
            .NotNull()
            .WithMessage("BranchSaleMade cannot be null");

        RuleFor(c => c.Products)
            .NotNull()
            .WithMessage("Products cannot be null");
        
        RuleFor(c => c.Products)
            .NotNull()
            .WithMessage("Products cannot be null");
        
        RuleFor(c => c.Products)
            .NotNull()
            .WithMessage("Products cannot be null");
        
        RuleFor(c => c.IsActive)
            .NotNull()
            .WithMessage("IsActive cannot be null");
    }
}