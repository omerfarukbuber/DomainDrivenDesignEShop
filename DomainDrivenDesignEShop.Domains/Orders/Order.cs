using DomainDrivenDesignEShop.Domain.Customers;
using DomainDrivenDesignEShop.Domain.Products;

namespace DomainDrivenDesignEShop.Domain.Orders;

public class Order
{
    private Order()
    {
        
    }
    private readonly HashSet<LineItem> _lineItems = new();
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }

    public static Order Create(Customer customer)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id
        };
        return order;
    }
    public void Add(Product product)
    {
        var lineItem = new LineItem(Guid.NewGuid(), Id, product.Id, product.Price);

        _lineItems.Add(lineItem);
    }
}

public class LineItem
{
    internal LineItem(Guid id, Guid orderId, Guid productId, Money price)
    {
        Price = price;
        Id = id;
        ProductId = productId;
        OrderId = orderId;
    }
    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public Money Price { get; private set; }
}