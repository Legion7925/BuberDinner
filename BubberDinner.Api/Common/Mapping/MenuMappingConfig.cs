using BubberDinner.Application.Menus.Commands.CreateMenu;
using BubberDinner.Contracts.Menu;
using BubberDinner.Domain.Menu;
using Mapster;

using MenuSection = BubberDinner.Domain.Menu.Entities.MenuSection;
using MenuItem = BubberDinner.Domain.Menu.Entities.MenuItem;

namespace BubberDinner.Api.Common.Mapping;

public class MenuMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateMenuRequest request, string hostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.hostId)
            .Map(dest => dest, src => src.request);

        config.NewConfig<Menu, MenuResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.AverageRating, src => src.AverageRating.Value)
            .Map(dest => dest.HostId, src => src.HostId.Value)
            .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select(d => d.Value))
            .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select(m => m.Value));

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
