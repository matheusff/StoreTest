using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActDigital.Store.Sales.Application.ViewModels;

public class SaleViewModel
{
    [NotMapped]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "The field SaleNumber is mandatory")]
    public int SaleNumber { get; set; }
    
    [Required(ErrorMessage = "The field Date is mandatory")]
    public DateTime? Date { get; set; }
    
    [Required(ErrorMessage = "The field CustomerId is mandatory")]
    public Guid CustomerId { get; set; }
    
    [Required(ErrorMessage = "The field BranchSaleMade is mandatory")]
    public string BranchSaleMade { get; set; }
    
    [Required(ErrorMessage = "The field Products is mandatory")]
    public ICollection<ProductViewModel> Products { get; set; }
    
    [Required(ErrorMessage = "The field TotalSaleAmount is mandatory")]
    public decimal TotalSaleAmount { get; set; }
    
    public decimal Discount { get; set; }
    
    public decimal TotalSaleAmountWithDescount =>
        TotalSaleAmount - Discount;
    
    [Required(ErrorMessage = "The field IsActive is mandatory")]
    public bool IsActive { get; set; }
}