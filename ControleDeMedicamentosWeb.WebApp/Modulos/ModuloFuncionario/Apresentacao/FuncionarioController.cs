using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using ControleDeMedicamentosWeb.WebApp.Modulos.ModuloFuncionario.Aplicacao;
using ControleDeMedicamentosWeb.WebApp.Compartilhado.Apresentacao.Extensions;
using ControleDeMedicamentosWeb.WebApp.Modulos.ModuloFuncionario.Apresentacao;

namespace ControleDeMedicamentosWeb.WebApp.Modulos.ModuloPaciente.Apresentacao;

public class FuncionarioController(ServicoFuncionario servicoFuncionario, IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarFuncionarioDto> dtos = servicoFuncionario.SelecionarTodos();

        List<ListarFuncionarioViewModel> listarVms = mapeador.Map<List<ListarFuncionarioViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarFuncionarioViewModel cadastrarVm = new CadastrarFuncionarioViewModel(
            string.Empty,
            string.Empty,
            string.Empty
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarFuncionarioViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarFuncionarioDto dto = mapeador.Map<CadastrarFuncionarioDto>(cadastrarVm);

        Result resultado = servicoFuncionario.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }
}