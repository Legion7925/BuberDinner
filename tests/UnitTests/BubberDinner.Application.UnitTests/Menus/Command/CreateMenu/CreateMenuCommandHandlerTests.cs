using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Application.Menus.Commands.CreateMenu;
using BubberDinner.Application.UnitTests.Menus.Command.TestUtils;
using BubberDinner.Application.UnitTests.TestUtils.Menus.Extensions;
using FluentAssertions;
using Moq;

namespace BubberDinner.Application.UnitTests.Menus.Command.CreateMenu;

public class CreateMenuCommandHandlerTests
{
    private readonly CreateMenuCommandHanlder _handler;

    private readonly Mock<IMenuRepository> _mockMenuRepository;

    public CreateMenuCommandHandlerTests()
    {
        _mockMenuRepository = new Mock<IMenuRepository>();
        _handler = new CreateMenuCommandHanlder(_mockMenuRepository.Object);
    }

    [Theory]
    [MemberData(nameof(ValidCreateMenuCommands))]
    public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
    {
        //Act
        var result = await _handler.Handle(createMenuCommand, default);

        //Assert
        result.IsError.Should().BeFalse();
        result.Value.ValidateCreatedFrom(createMenuCommand);
        _mockMenuRepository.Verify(m => m.AddAsync(result.Value), Times.Once);
    }

    public static IEnumerable<object[]> ValidCreateMenuCommands()
    {
        yield return new[] 
        { 
            CreateMenuCommandUtils.CreateMenu(
                sections: CreateMenuCommandUtils.CreateMenuSections(sectionCount:3))
        };

        yield return new[] 
        { 
            CreateMenuCommandUtils.CreateMenu(
                sections: CreateMenuCommandUtils.CreateMenuSections(sectionCount:3 , 
                items: CreateMenuCommandUtils.CreateMenuItems(itemCount: 3)))
        };
    }
}
