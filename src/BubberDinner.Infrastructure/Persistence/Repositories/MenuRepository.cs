using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.MenuAggregate;
using BubberDinner.Infrastructure.Persistence;

namespace BubberDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly BubberDinnerDbContext _dbContext;

    public MenuRepository(BubberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Menu menu)
    {
        await _dbContext.AddAsync(menu);
        await _dbContext.SaveChangesAsync();
    }
}
