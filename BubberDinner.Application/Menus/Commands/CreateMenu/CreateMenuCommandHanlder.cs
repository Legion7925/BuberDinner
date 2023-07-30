using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.Host.ValueObjects;
using BubberDinner.Domain.Menu;
using BubberDinner.Domain.Menu.Entities;
using ErrorOr;
using MediatR;

namespace BubberDinner.Application.Menus.Commands.CreateMenu;

public class CreateMenuCommandHanlder : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{
    private readonly IMenuRepository _menuRepository;

    public CreateMenuCommandHanlder(IMenuRepository menuRepository)
    {
        this._menuRepository = menuRepository;
    }
    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        //Create Menu
        var menu = Menu.Create(request.Name,
            request.Description,
            HostId.Create(new Guid(request.HostId)),
            request.Sections.ConvertAll(section => MenuSection.Create(
                section.Name, section.Description,
                section.Items.ConvertAll(item => MenuItem.Create(item.Name , item.Description)))));

        //Persist the Menu
        _menuRepository.Add(menu);

        //Return Menu
        return menu;
    }
}
