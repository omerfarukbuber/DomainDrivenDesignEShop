using DomainDrivenDesignEShop.Domain.Products;

namespace DomainDrivenDesignEShop.Domain.Orders;

public class LineItem
{
    internal LineItem(LineItemId id, OrderId orderId, ProductId productId, Money price)
    {
        Price = price;
        Id = id;
        ProductId = productId;
        OrderId = orderId;
    }
    public LineItemId Id { get; private set; }
    public OrderId OrderId { get; private set; }
    public ProductId ProductId { get; private set; }
    public Money Price { get; private set; }
}