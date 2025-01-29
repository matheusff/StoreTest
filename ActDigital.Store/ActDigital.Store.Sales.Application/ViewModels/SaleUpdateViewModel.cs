using System.ComponentModel.DataAnnotations;

namespace ActDigital.Store.Sales.Application.ViewModels;

public class SaleUpdateViewModel
{
    [Required(ErrorMessage = "The field {0} is mandatory")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "The field {0} is mandatory")]
    public int SaleNumber { get; set; }
    [Required(ErrorMessage = "The field {0} is mandatory")]
    public DateTime Date { get; set; }
    [Required(ErrorMessage = "The field {0} is mandatory")]
    public Guid CustomerId { get; set; }
    [Required(ErrorMessage = "The field {0} is mandatory")]
    public string BranchSaleMade { get; set; }
    [Required(ErrorMessage = "The field {0} is mandatory")]
    public ICollection<ProductViewModel> Products { get; set; }
    [Required(ErrorMessage = "The field {0} is mandatory")]
    public decimal TotalSaleAmount { get; set; }
    public decimal Discount { get; set; }
    
    public decimal TotalSaleAmountWithDescount =>
        TotalSaleAmount - Discount;
    
    [Required(ErrorMessage = "The field {0} is mandatory")]
    public bool IsActive { get; set; }
}