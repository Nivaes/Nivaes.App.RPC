using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Nivaes.App.RPC.Sample.Client;

public class DatabaseContext : DbContext
{
    #region Constructors
    public DatabaseContext()
     : base()
    {
    }

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
    #endregion

    #region DbSet
    public DbSet<Test1DataModel> Test1 { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Test1DataModel>(entity =>
        {
        });
    }
}