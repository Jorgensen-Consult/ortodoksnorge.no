using OrtodoksNorge.Web.Configuration;
using OrtodoksNorge.Web.Startup;

var config = new AppSettings();
var builder = WebApplication.CreateBuilder(args);
builder.AddConfigurationWithKeyvault(config);
builder.Services.AddSiteDbContext(config);
builder.Services.AddMvc();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();
