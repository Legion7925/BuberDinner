using BubberDinner.Domain.MenuAggregate;

namespace BubberDinner.Application.Common.Interfaces.Persistence;

public interface IMenuRepository
{
    Task AddAsync(Menu menu);    
}
