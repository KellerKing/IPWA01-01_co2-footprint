using IPWA01_01.Backend.DataAccess;
using IPWA01_01.Backend.DataAccess.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(Bootstrapper.CreateDatabaseAccessControllerSqlite
    (new DatabaseConfiguration { Location = builder.Configuration.GetConnectionString("SqlitePath") }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Beispiele
//https://stackoverflow.com/questions/37365277/how-to-specify-the-port-an-asp-net-core-application-is-hosted-on
//https://medium.com/codenx/minimal-apis-in-net-8-a-simplified-approach-to-build-services-eb50df56819f


app.MapGet("/Co2Verbrauch", async (IDataAccessController dataAccessController) =>
{
    return TypedResults.Ok(dataAccessController.GetCo2Verbrauch());
})
    .WithName("GetCo2Verbrauch")
    .WithOpenApi(x => new Microsoft.OpenApi.Models.OpenApiOperation(x)
    {
        Summary = "Holt alle Eintr�ge f�r den Co2 Verbrauch",
        Description = "Liefert alle Werte f�r den Co2 Verbrauch. Id, Land, Unternehmen, Branche, Co2Verbrauch. Die Werte sind ungefiltert und Ids f�r Land und Unternehmen werden nicht zur�ckgegeben."
    });


app.MapGet("/GetCo2Verbrauch/land/{land}/unternehmen/{unternehmen}",
    async (IDataAccessController dataAccessController, string land, string unternehmen) =>
    {
        return TypedResults.Ok(dataAccessController.GetCo2VerbauchGefiltert(land, unternehmen));
    })
    .WithName("GetCo2VerbauchGefiltert")
    .WithOpenApi(x => new Microsoft.OpenApi.Models.OpenApiOperation(x)
    {
        Summary = "Liefert alle Eintr�ge f�r den Co2 Verbrauch, in denen die Texte f�r Land und Unternehmen vorhanden sind.",
        Description = "Liefert alle Werte f�r den Co2 Verbrauch. Gefiltert mit einer und Verkn�pfung nach Land und Unternehmen. Texte m�ssen nicht ausgeschrieben sein. Vergleichbar mit einem Like in Sql. Id, Land, Unternehmen, Branche, Co2Verbrauch. Die Werte sind ungefiltert und Ids f�r Land und Unternehmen werden nicht zur�ckgegeben."
    });


app.MapGet("/GetCo2Verbrauch/land/{land}",
    async (IDataAccessController dataAccessController, string land) =>
    {
        return TypedResults.Ok(dataAccessController.GetCo2VerbauchGefiltert(land, string.Empty));
    })
    .WithName("GetCo2VerbauchGefiltert")
    .WithOpenApi(x => new Microsoft.OpenApi.Models.OpenApiOperation(x)
    {
        Summary = "Liefert alle Eintr�ge f�r den Co2 Verbrauch, in denen die Texte f�r Land vorhanden sind.",
        Description = "Liefert alle Werte f�r den Co2 Verbrauch. Gefiltert mit einer und Verkn�pfung nach Land. Texte m�ssen nicht ausgeschrieben sein. Vergleichbar mit einem Like in Sql. Id, Land, Unternehmen, Branche, Co2Verbrauch. Die Werte sind ungefiltert und Ids f�r Land und Unternehmen werden nicht zur�ckgegeben."
    });


app.MapGet("/GetCo2Verbrauch/unternehmen/{unternehmen}",
    async (IDataAccessController dataAccessController, string unternehmen) =>
    {
        return TypedResults.Ok(dataAccessController.GetCo2VerbauchGefiltert(string.Empty, unternehmen));
    })
    .WithName("GetCo2VerbauchGefiltert")
    .WithOpenApi(x => new Microsoft.OpenApi.Models.OpenApiOperation(x)
    {
        Summary = "Liefert alle Eintr�ge f�r den Co2 Verbrauch, in denen die Texte f�r Unternehmen vorhanden sind.",
        Description = "Liefert alle Werte f�r den Co2 Verbrauch. Gefiltert mit einer und Verkn�pfung nach Unternehmen. Texte m�ssen nicht ausgeschrieben sein. Vergleichbar mit einem Like in Sql. Id, Land, Unternehmen, Branche, Co2Verbrauch. Die Werte sind ungefiltert und Ids f�r Land und Unternehmen werden nicht zur�ckgegeben."
    });





//https://dotnetcorecentral.com/blog/how-to-use-sqlite-with-dapper/
app.Run();
