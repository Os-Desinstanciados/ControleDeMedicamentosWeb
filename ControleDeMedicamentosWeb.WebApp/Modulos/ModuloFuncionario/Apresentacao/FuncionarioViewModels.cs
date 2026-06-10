using System.ComponentModel.DataAnnotations;

namespace ControleDeMedicamentosWeb.WebApp.Modulos.ModuloFuncionario.Apresentacao;

public record ListarFuncionarioViewModel (
    Guid Id,
    string Nome,
    string Telefone,
    string Cpf
);