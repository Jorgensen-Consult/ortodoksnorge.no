using OrtodoksNorge.Web.Configuration;
using OrtodoksNorge.Web.Startup;

var config = new AppSettings();
var builder = WebApplication.CreateBuilder(args);
builder.AddConfigurationWithKeyvault(config);
builder.Services.AddSiteDbContext(config);


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
