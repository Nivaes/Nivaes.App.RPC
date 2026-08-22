var builder = DistributedApplication.CreateBuilder(args);

#region Database
var postgres = builder.AddPostgres("rpc-postgres", port: 5432)
                      .WithLifetime(ContainerLifetime.Persistent)
                      .WithDataVolume()
                      .WithPgAdmin();
var serverDb = postgres.AddDatabase("dbAppSample");
#endregion

#region Server
var appWebApi = builder.AddProject<Projects.Nivaes_App_Rpc_Sample_Server>("SampleServer")
                .WithHttpHealthCheck("/health")
                .WithReference(serverDb)
                .WaitFor(serverDb);
#endregion

#region Cliente
var appConsole = builder.AddProject<Projects.Nivaes_App_RPC_Sample_Console>("SampleConsole")
                .WithReference(appWebApi)
                .WaitFor(appWebApi);

#endregion

builder.Build().Run();
