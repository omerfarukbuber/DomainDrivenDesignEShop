using DomainDrivenDesignEShop.Domain.Orders;
using MediatR;

namespace DomainDrivenDesignEShop.Application.Orders.Create;

public record OrderCreatedEvent(OrderId OrderId) : INotification;