var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("DataBase")
    .WithDataVolume()
    .WithPgAdmin();

builder.AddProject<Projects.Presentation>("presentation")
    .WithHttpsEndpoint()
    .WithReference(postgres);

builder.Build().Run();
