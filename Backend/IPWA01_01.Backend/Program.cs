using IPWA01_01.Backend.DataAccess;
using IPWA01_01.Backend.DataAccess.Contracts;
using Microsoft.AspNetCore.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDataAccessController>(
    Bootstrapper.CreateDatabaseAccessControllerSqlite
    (new DatabaseConfiguration { Location = builder.Configuration.GetConnectionString("SqlitePath")}
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/Co2Verbrauch", async (IDataAccessController dataAccessController) =>
{
    try
    {
        return await Task.Run(() => dataAccessController.GetCo2Verbrauch());
    }
    catch (Exception e)
    {
        throw;
    }
})
    .WithName("/GetCo2Verbrauch")
    .WithOpenApi();


app.MapGet("/GetCo2Verbrauch/land/{land}/unternehmen/{unternehmen}",
    (string land, string unternehmen) =>
    {
        return land + " " + unternehmen;
    });





//https://dotnetcorecentral.com/blog/how-to-use-sqlite-with-dapper/
app.Run();
