using BubberDinner.Application.Common.Interfaces.Persistence;
using BubberDinner.Domain.Menu;
using BubberDinner.Infrastructure.Persistence;

namespace BubberDinner.Infrastructure.Persistence.Repositories;

public class MenuRepository : IMenuRepository
{
    private readonly BubberDinnerDbContext _dbContext;

    public MenuRepository(BubberDinnerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Menu menu)
    {
        _dbContext.Add(menu);
        _dbContext.SaveChanges();
    }
}
