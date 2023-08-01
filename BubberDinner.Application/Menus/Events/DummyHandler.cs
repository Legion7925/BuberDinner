using BubberDinner.Domain.MenuAggregate.Events;
using MediatR;

namespace BubberDinner.Application.Menus.Events;

public class DummyHandler : INotificationHandler<MenuCreated>
{
    public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
