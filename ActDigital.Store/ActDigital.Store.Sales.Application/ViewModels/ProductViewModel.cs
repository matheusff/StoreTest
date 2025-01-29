namespace ActDigital.Store.Sales.Application.ViewModels;

public record ProductViewModel(Guid ProductId, int Quantity, decimal UnitPrice, bool IsActive);
