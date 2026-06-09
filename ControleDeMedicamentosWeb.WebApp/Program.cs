using ControleDeMedicamentosWeb.WebApp.Compartilhado.Apresentacao;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentationConfig();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();