using BubberDinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace BubberDinner.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(string Name , string HostId, string Description, List<CreateMenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

public record CreateMenuSectionCommand(string Name, string Description, List<CreateMenuItemCommand> Items);

public record CreateMenuItemCommand(string Name, string Description);
