namespace DomainDrivenDesignEShop.Application.Orders.GetOrder;

public record LineItemResponse(Guid LineItemId, decimal Price);