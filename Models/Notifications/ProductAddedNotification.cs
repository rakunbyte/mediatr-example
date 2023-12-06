using MediatR;

namespace Models.Notifications;

public record ProductAddedNotification(Product Product) : INotification;