namespace DomainDrivenDesignEShop.Domain.Orders;

public record OrderSummary(Guid Id, Guid CustomerId, decimal TotalPrice);