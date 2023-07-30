using BubberDinner.Domain.Menu;

namespace BubberDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    void Add(Menu menu);    
}
