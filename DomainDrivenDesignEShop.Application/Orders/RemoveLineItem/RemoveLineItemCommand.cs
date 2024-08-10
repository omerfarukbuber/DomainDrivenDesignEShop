using DomainDrivenDesignEShop.Domain.Orders;
using MediatR;

namespace DomainDrivenDesignEShop.Application.Orders.RemoveLineItem;

public record RemoveLineItemCommand(OrderId OrderId, LineItemId LineItemId) : IRequest;