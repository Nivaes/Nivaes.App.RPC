using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Logging;

namespace Nivaes.App.RPC.Sample.Client;

public static class DatabaseStart
{
    public static async Task InitializeDatabase(string databasePath)
    {
        using var db = new DatabaseContext();
        await db.Database.EnsureCreatedAsync();

        await DatabaseMigrator.MigrateAsync(databasePath);
    }

    //public static async Task InitializeDatabase()
    //{
    //    try
    //    {
    //        await CreateDatabase().ConfigureAwait(false);
    //    }
    //    catch (DbException)
    //    {
    //        using (var db = new DatabaseContext())
    //        {
    //            await db.Database.EnsureDeletedAsync().ConfigureAwait(false);
    //        }

    //        await CreateDatabase().ConfigureAwait(false);
    //    }
    //}

    //private static async Task CreateDatabase()
    //{
    //    //try
    //    //{
    //    using var db = new DatabaseContext();

    //    //await db.Database.MigrateAsync().ConfigureAwait(false);
    //    await db.Database.EnsureCreatedAsync().ConfigureAwait(false);

    //    //}
    //    //catch (SqliteException ex) when (ex.SqliteErrorCode == SQLitePCL.raw.SQLITE_NOTADB)
    //    //{
    //    //}
    //}

    //public static async Task ResetData()
    //{
    //    using var db = new DatabaseContext();

    //    await db.Database.EnsureDeletedAsync().ConfigureAwait(false);
    //}


}

