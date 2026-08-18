# Database

## Instalar dotnet-ef

Intalar dotnet-ef si no está instalado

```shell
dotnet tool install --global dotnet-ef
```

Actulizar dotnet-ef si ya está instalado

```shell
dotnet tool update --global dotnet-ef
```

## Database de servidor

Desde Nivaes.App.RPC.Sample.Server

```shell
dotnet ef migrations add InitialCreate `
	--project Nivaes.App.RPC.Sample.Server.csproj `
	--context Nivaes.App.RPC.Sample.Server.ServerDatabaseContext `
	--output-dir Sources/Database/Migrations 
```

## Database de cliente

Desde Nivaes.App.RPC.Sample.Client

```shell
 dotnet ef migrations add InitialCreate `
   --project Nivaes.App.RPC.Sample.Client.csproj `
   --context Nivaes.App.RPC.Sample.Client.DatabaseContext `
   --output-dir Sources/Database/Migrations `
   --framework net10.0 
```