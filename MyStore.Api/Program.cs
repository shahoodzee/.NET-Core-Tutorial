using MyStore.Api.Endpoints;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapItemsEndpoints();
app.Run();
