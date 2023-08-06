using BubberDinner.Application.Menus.Commands.CreateMenu;
using BubberDinner.Application.UnitTests.TestUtils;

namespace BubberDinner.Application.UnitTests.Menus.Command.TestUtils;

public class CreateMenuCommandUtils
{
    //name 
    //description
    //list of sections
    public static CreateMenuCommand CreateMenu(List<CreateMenuSectionCommand>? sections = null)
    {
        return new CreateMenuCommand(
            Constants.Menu.Name,
            Constants.Host.Id.Value.ToString()!,
            Constants.Menu.Description,
            sections ?? CreateMenuSections());
    }

    public static List<CreateMenuSectionCommand> CreateMenuSections(int sectionCount = 1 , List<CreateMenuItemCommand>? items = null)
        => Enumerable.Range(0, sectionCount)
            .Select(index => new CreateMenuSectionCommand(
                    Constants.Menu.SectionName,
                    Constants.Menu.SectionDescription,
                    items ?? CreateMenuItems()))
            .ToList();

    public static List<CreateMenuItemCommand> CreateMenuItems(int itemCount = 1)
        => Enumerable.Range(0, itemCount)
        .Select(index => new CreateMenuItemCommand(
                Constants.Menu.ItemName,
                Constants.Menu.ItemDescription))
        .ToList();
}
