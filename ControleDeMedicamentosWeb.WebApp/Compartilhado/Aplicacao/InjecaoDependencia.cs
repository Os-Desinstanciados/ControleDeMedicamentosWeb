using ControleDeMedicamentosWeb.WebApp.Modulos.ModuloFuncionario.Aplicacao;
using ControleDeMedicamentosWeb.WebApp.Modulos.ModuloPaciente.Aplicacao;

namespace ControleDeMedicamentosWeb.WebApp.Compartilhado.Aplicacao;

public static class InjecaoDependencia
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ServicoPaciente>();
        services.AddScoped<ServicoFuncionario>();
    }
}