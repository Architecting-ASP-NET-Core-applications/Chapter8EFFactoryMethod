using Microsoft.EntityFrameworkCore;

namespace Chapter8EFFactoryMethod.Models;

public class SqliteDbContextFactory : IDbContextFactory
{
    private readonly string connectionString;
    public SqliteDbContextFactory(string connectionString)
    => this.connectionString = connectionString;
    public MyDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseSqlite(connectionString);
        return new MyDbContext(optionsBuilder.Options);
    }
    public void InitializeDatabase()
    {
        using var context = CreateDbContext();
        // Ensure the database is created
        context.Database.EnsureCreated();
    }
}


//public class SqliteDbContextFactory : IDbContextFactory<MyDbContext>, IDisposable
//{
//    private readonly string connectionString;

//    public SqliteDbContextFactory(string connectionString)
//    {
//        this.connectionString = connectionString;
//    }

//    public MyDbContext CreateDbContext()
//    {
//        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
//        optionsBuilder.UseSqlite(connectionString);
//        return new MyDbContext(optionsBuilder.Options);
//    }

//    public void InitializeDatabase()
//    {
//        using var context = CreateDbContext();
//        context.Database.EnsureCreated();
//    }


//    public void Dispose()
//    {

//    }

//}


