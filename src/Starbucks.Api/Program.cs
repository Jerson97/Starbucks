using Starbucks.Api.Extensions;
using Starbucks.Persistence;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;

builder.Services.AddControllers();
builder.Services.AddPersistence(builder.Configuration);


var app = builder.Build();

await app.ApplyMigration(environment);

app.MapControllers();



app.Run();
