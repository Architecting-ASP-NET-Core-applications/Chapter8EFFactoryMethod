using Microsoft.EntityFrameworkCore;
namespace Chapter8EFFactoryMethod.Models;
public class MyDataService
{
    private readonly IDbContextFactory dbContextFactory;
    public MyDataService(IDbContextFactory dbContextFactory)
    {
        this.dbContextFactory = dbContextFactory;
    }
    public async Task<List<Book>> GetAllEntitiesAsync()
    {
        using var context = dbContextFactory.CreateDbContext();
        return await context.Books.ToListAsync();
    }
    public async Task AddEntityAsync(Book entity)
    {
        using var context = dbContextFactory.CreateDbContext();
        context.Books.Add(entity);
        await context.SaveChangesAsync();
    }
    public void InitializeDatabase()
    {
        using var context = dbContextFactory.CreateDbContext();
        context.Database.EnsureCreated();
    }
}