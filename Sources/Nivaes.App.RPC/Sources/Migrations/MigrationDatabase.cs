//using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.Data.Sqlite;

//namespace Nivaes.App.RPC.Sources;

//public class MigrationDatabase
//{
//    private static async Task ApplyMigration(SqliteConnection connection, Migration migration)
//    {
//        var assembly = typeof(DatabaseMigrator).Assembly;

//        await using var stream =
//            assembly.GetManifestResourceStream(migration.ResourceName)
//            ?? throw new InvalidOperationException(
//                $"Migration '{migration.Id}' not found.");

//        using var reader = new StreamReader(stream);

//        var sql = await reader.ReadToEndAsync();

//        await using var command = connection.CreateCommand();

//        command.CommandText = sql;

//        await command.ExecuteNonQueryAsync();
//    }
//}
