using Databases;
using MediatR;
using Models.Notifications;

namespace Services;

public class SmsHandler(ProductStore store): INotificationHandler<ProductAddedNotification>
{
    public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
        await store.EventOccured(notification.Product, "Sms sent");
        await Task.CompletedTask;
    }
}