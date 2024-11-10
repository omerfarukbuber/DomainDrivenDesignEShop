using DomainDrivenDesignEShop.Domain.Orders;
using MediatR;

namespace DomainDrivenDesignEShop.Application.Orders.GerOrderSummary;

public record GetOrderSummaryQuery(Guid OrderId) : IRequest<OrderSummary?>;