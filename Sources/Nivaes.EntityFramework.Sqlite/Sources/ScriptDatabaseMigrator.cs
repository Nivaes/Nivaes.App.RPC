using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nivaes.EntityFrameworkCore.Sqlite;

public static class ScriptDatabaseMigrator
{
    public static async Task MigrateAsync(string databasePath, IEnumerable<VersionScriptMigration> migrations)
    {
        await using var connection =
            new SqliteConnection($"Data Source={databasePath}");

        await connection.OpenAsync();

        await EnsureHistoryTable(connection);

        var applied = await GetAppliedMigrations(connection);

        foreach (var migration in migrations)
        {
            if (applied.Contains(migration.Id))
                continue;

            await ApplyMigration(connection, migration);
        }
    }

    private static async Task EnsureHistoryTable(
        SqliteConnection connection)
    {
        await using var command = connection.CreateCommand();

        command.CommandText = """
            CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory"
            (
                "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory"
                    PRIMARY KEY,
                "ProductVersion" TEXT NOT NULL
            );
            """;

        await command.ExecuteNonQueryAsync();
    }

    private static async Task<HashSet<string>> GetAppliedMigrations(
        SqliteConnection connection)
    {
        await using var command = connection.CreateCommand();

        command.CommandText =
            """SELECT "MigrationId" FROM "__EFMigrationsHistory";""";

        var result = new HashSet<string>();

        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
            result.Add(reader.GetString(0));

        return result;
    }

    private static async Task ApplyMigration(
        SqliteConnection connection,
        VersionScriptMigration migration)
    {
        var assembly = typeof(ScriptDatabaseMigrator).Assembly;

        await using var stream =
            assembly.GetManifestResourceStream(migration.ResourceName)
            ?? throw new InvalidOperationException(
                $"Migration '{migration.Id}' not found.");

        using var reader = new StreamReader(stream);

        var sql = await reader.ReadToEndAsync();

        //await using var transaction =
        //    await connection.BeginTransactionAsync();

        //try
        //{
            await using var command = connection.CreateCommand();

            //command.Transaction = (SqliteTransaction)transaction;
            command.CommandText = sql;

            await command.ExecuteNonQueryAsync();

            //await transaction.CommitAsync();
        //}
        //catch
        //{
        //    await transaction.RollbackAsync();
        //    throw;
        //}
    }

    
}
