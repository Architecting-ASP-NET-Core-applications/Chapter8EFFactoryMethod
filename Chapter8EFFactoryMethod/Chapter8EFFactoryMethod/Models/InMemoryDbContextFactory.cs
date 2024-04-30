﻿using Microsoft.EntityFrameworkCore;

namespace Chapter8EFFactoryMethod.Models;

public class InMemoryDbContextFactory : IDbContextFactory
{
    private readonly string databaseName;
    public InMemoryDbContextFactory(string databaseName)
        => this.databaseName = databaseName;
    public MyDbContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        optionsBuilder.UseInMemoryDatabase(databaseName);
        return new MyDbContext(optionsBuilder.Options);
    }
    public void InitializeDatabase()
    {
        // For InMemory, initialization might
        // simply be ensuring the database can be accessed
        using var context = CreateDbContext();
        // Potentially seeding data or similar setup tasks
    }
}


//public class InMemoryDbContextFactory : IDbContextFactory<MyDbContext>, IDisposable
//{
//    private readonly string connectionString;

//    public InMemoryDbContextFactory(string connectionString)
//    {
//        this.connectionString = connectionString;
//    }

//    public MyDbContext CreateDbContext()
//    {
//        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
//        optionsBuilder.UseInMemoryDatabase(connectionString);
//        return new MyDbContext(optionsBuilder.Options);
//    }

//    public void InitializeDatabase()
//    {

//    }

//    public void Dispose()
//    {

//    }
//}
