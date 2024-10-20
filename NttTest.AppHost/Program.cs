var builder = DistributedApplication.CreateBuilder(args);

var postgres = builder
    .AddPostgres("Database")
    .WithDataVolume()
    .WithPgAdmin();

builder.AddProject<Projects.NttTest>("ntt-test")
    .WithReference(postgres);

builder.Build().Run();
