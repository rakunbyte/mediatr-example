using Databases;
using MediatR;
using Models.Notifications;

namespace Services;

public class EmailHandler(ProductStore store): INotificationHandler<ProductAddedNotification>
{
    public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
        await store.EventOccured(notification.Product, "Email sent");
        await Task.CompletedTask;
    }
}