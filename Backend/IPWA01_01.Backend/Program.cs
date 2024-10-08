var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
//https://dotnetcorecentral.com/blog/how-to-use-sqlite-with-dapper/
app.Run();
