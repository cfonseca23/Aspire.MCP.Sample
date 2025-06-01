var builder = DistributedApplication.CreateBuilder(args);

var aspnetsseserver = builder
    .AddProject<Projects.McpSample_AspNetCoreSseServer>("aspnetsseserver")
    .WithExternalHttpEndpoints();
var blazorchat = builder
    .AddProject<Projects.McpSample_BlazorChat>("blazorchat")
    .WithReference(aspnetsseserver)
    .WithExternalHttpEndpoints();

builder.AddProject<Projects.McpSample_WebApplication>("mcpsample-webapplication");

builder.Build().Run();