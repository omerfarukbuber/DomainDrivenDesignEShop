using MediatR;
using Microsoft.Extensions.Logging;

namespace DomainDrivenDesignEShop.Application.Orders.Create;

public class CreatePaymentRequestEventHandler(ILogger<CreatePaymentRequestEventHandler> logger)
    : INotificationHandler<OrderCreatedEvent>
{
    private readonly ILogger<CreatePaymentRequestEventHandler> _logger = logger;

    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting payment request {@OrderId}", notification.OrderId);

        await Task.Delay(2000, cancellationToken);

        _logger.LogInformation("Payment request started {@OrderId}", notification.OrderId);
    }
}