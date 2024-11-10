using DomainDrivenDesignEShop.Domain.Orders;
using DomainDrivenDesignEShop.Domain.Products;
using MediatR;

namespace DomainDrivenDesignEShop.Application.Orders.GetOrder;

public record GetOrderQuery(OrderId OrderId) : IRequest<OrderResponse?>;