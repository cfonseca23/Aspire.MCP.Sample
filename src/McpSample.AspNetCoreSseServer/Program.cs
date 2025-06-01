using McpSample.AspNetCoreSseServer;
using ModelContextProtocol;

var builder = WebApplication.CreateBuilder(args);

// Add default services
builder.AddServiceDefaults();
builder.Services.AddProblemDetails();

// add MCP server
builder.Services
    .AddMcpServer()
    .WithHttpTransport()
    .WithToolsFromAssembly()
    .WithTools<Jokes>()
    .WithTools<WeatherTool>();
var app = builder.Build();

// Initialize default endpoints
app.MapDefaultEndpoints();
app.UseHttpsRedirection();

// map endpoints
app.MapGet("/", () => $"Hello MCP Server! {DateTime.Now}");
app.MapGet("/hello", () => $"Hello MCP Server! {DateTime.Now}");
app.MapMcp();

app.Run();
