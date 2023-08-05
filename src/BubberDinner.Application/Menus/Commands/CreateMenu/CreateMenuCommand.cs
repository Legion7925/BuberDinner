using BubberDinner.Domain.MenuAggregate;
using ErrorOr;
using MediatR;

namespace BubberDinner.Application.Menus.Commands.CreateMenu;

public record CreateMenuCommand(string Name , string HostId, string Description, List<MenuSectionCommand> Sections) : IRequest<ErrorOr<Menu>>;

public record MenuSectionCommand(string Name, string Description, List<MenuItemCommand> Items);

public record MenuItemCommand(string Name, string Description);
