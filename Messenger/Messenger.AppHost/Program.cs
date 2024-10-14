var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder.AddPostgres("DataBase")
    .WithDataVolume()
    .WithPgAdmin();

builder.AddProject<Projects.Presentation>("presentation")
    .WithReference(postgres);

builder.Build().Run();
