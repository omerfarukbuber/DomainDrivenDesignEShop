using System.Windows.Input;
using DomainDrivenDesignEShop.Domain.Customers;
using MediatR;

namespace DomainDrivenDesignEShop.Application.Orders.Create;

public record CreateOrderCommand(CustomerId CustomerId) : IRequest;