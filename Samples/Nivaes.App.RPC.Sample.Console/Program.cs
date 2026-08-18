using Nivaes.App.RPC.Sample.Client;

namespace Nivaes.App.RPC.Sample;

internal class Program
{
    static async Task Main(string[] args)
    {
        await DatabaseStart.InitializeDatabase();
        using DatabaseContext db = new DatabaseContext();


        Console.WriteLine("Hello, World!");
    }
}