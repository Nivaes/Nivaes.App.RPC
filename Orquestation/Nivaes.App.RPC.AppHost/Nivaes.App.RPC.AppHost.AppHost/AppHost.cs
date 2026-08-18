var builder = DistributedApplication.CreateBuilder(args);

#region Database
var rpcDatabase = builder.AddPostgres("rpc-postgres", port: 5432)
                      .WithLifetime(ContainerLifetime.Persistent)
                      .WithDataVolume()
                      .WithPgAdmin();
var dbApp = rpcDatabase.AddDatabase("dbAppSample");
#endregion

#region Server
var appWebApi = builder.AddProject<Projects.Nivaes_App_RPC_Sample_Server>("RPC-Sample-Server")
                .WithHttpHealthCheck("/health")
                .WithReference(rpcDatabase)
                .WaitFor(rpcDatabase);
#endregion

#region Cliente
var appConsole = builder.AddProject<Projects.Nivaes_App_RPC_Sample_Server>("RPC-Sample-Console")
                .WithReference(appWebApi)
                .WaitFor(appWebApi);

#endregion

builder.Build().Run();
