using System.Diagnostics;
using Nivaes.App.RPC.Sample.Client;
using Nivaes.App.RPC.Sample.Client.Database;
using Nivaes.DataTestGenerator;

namespace Nivaes.App.RPC.Sample;

internal static class Program
{
    static async Task Main(string[] args)
    {
        //await DatabaseStart.InitializeDatabase("Data Source=client.db");
        await DatabaseStart.InitializeDatabase("client.db");
        using DatabaseContext db = new DatabaseContext();

        var entityType = db.Model.FindEntityType(typeof(UserDataModel));

        Console.WriteLine($"Entity: {entityType?.Name}");

        foreach (var property in entityType!.GetProperties())
        {
            Console.WriteLine(
                $"{property.Name}: " +
                $"Shadow={property.IsShadowProperty()}, " +
                $"Clr={property.ClrType}");
        }


        await LoadUsers(db);

        Console.WriteLine("Hello, World!");
    }

    private static async Task LoadUsers(this DatabaseContext db)
    {
        var users = new List<UserDataModel>();

        for (int i = 1; i <= 1000; i++)
        {

            var contact = ContactGenerator.Instance.GenerateContact();

            var user = new UserDataModel
            {
                IdUser = Guid.NewGuid(),
                Identification = $"ID{i:00000}",
                Name = contact.SortName,
                GivenName = contact.GivenName,
                FamilyName = contact.FamilyName,
                Email = contact.Email,
                PhoneNumber = contact.TelephoneNumber
            };

            users.Add(user);

            db.Users.Add(user);
        }

        await db.Users.AddRangeAsync(users);
        await db.SaveChangesAsync();
    }
}