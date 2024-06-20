using CapitalPlacement;
using Microsoft.Azure.Cosmos;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
builder.Services.AddAutoMapper(typeof(ProgramMappings));


builder.Services.AddSingleton((provider) =>
                {
                    var endpointUri = configuration["CosmosDbSettings:EndpointUri"];
                    var primaryKey = configuration["CosmosDbSettings:PrimaryKey"];
                    var databaseName = configuration["CosmosDbSettings:DatabaseName"];

                    var cosmosClientOptions = new CosmosClientOptions
                    {
                        ApplicationName = databaseName,
                        ConnectionMode = ConnectionMode.Gateway
                    };

                    var cosmosClient = new CosmosClient(endpointUri, primaryKey, cosmosClientOptions);

                    return cosmosClient;
                });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
