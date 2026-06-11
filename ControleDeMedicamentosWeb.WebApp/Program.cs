using ControleDeMedicamentosWeb.WebApp.Compartilhado.Apresentacao;
using ControleDeMedicamentosWeb.WebApp.Compartilhado.Aplicacao;
using ControleDeMedicamentosWeb.WebApp.Compartilhado.Infra;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfraRepositories();

builder.Services.AddApplicationServices();

builder.Services.AddPresentationConfig();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();
