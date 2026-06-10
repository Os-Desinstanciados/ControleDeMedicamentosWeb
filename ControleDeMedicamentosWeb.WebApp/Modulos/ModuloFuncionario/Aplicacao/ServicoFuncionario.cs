using FluentResults;
using ControleDeMedicamentosWeb.WebApp.Modulos.ModuloFuncionario.Dominio;

namespace ControleDeMedicamentosWeb.WebApp.Modulos.ModuloFuncionario.Aplicacao;

public class ServicoFuncionario
{
    private readonly IRepositorioFuncionario repositorioFuncionario;

    public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario)
    {
        this.repositorioFuncionario = repositorioFuncionario;
    }

    public Result Cadastrar(CadastrarFuncionarioDto dto)
    {
        if (ExisteFuncionarioComMesmoCPF(dto.Cpf))
            return Falha(nameof(dto.Cpf), "Já existe um funcionário com este CPF.");

        Funcionario novoFuncionario = new Funcionario(
            dto.Nome,
            dto.Telefone,
            dto.Cpf
        );

        Result resultadoValidacao = ValidarEntidade(novoFuncionario);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioFuncionario.Cadastrar(novoFuncionario);

        return Result.Ok();
    }

    public Result Editar(EditarFuncionarioDto dto)
    {
        Funcionario? funcionarioExistente = repositorioFuncionario.SelecionarPorId(dto.Id);

        if (funcionarioExistente == null)
            return Result.Fail("Paciente não encontrado.");

        if (ExisteFuncionarioComMesmoCPF(dto.Cpf))
            return Falha(nameof(dto.Cpf), "Já existe um Funcionário com este CPF.");

        Funcionario funcionarioAtualizado = new Funcionario(
            dto.Nome,
            dto.Telefone,
            dto.Cpf
        );

        Result resultadoValidacao = ValidarEntidade(funcionarioAtualizado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioFuncionario.Editar(dto.Id, funcionarioAtualizado);

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Funcionario? funcionario = repositorioFuncionario.SelecionarPorId(id);

        if (funcionario == null)
            return Result.Fail("Funcionário não encontrado.");

        repositorioFuncionario.Excluir(id);

        return Result.Ok();
    }

    public List<ListarFuncionarioDto> SelecionarTodos()
    {
        return repositorioFuncionario
            .SelecionarTodos()
            .Select(p => new ListarFuncionarioDto(
                p.Id,
                p.Nome,
                p.Telefone,
                p.Cpf
            ))
            .ToList();
    }

    public Result<DetalhesFuncionarioDto> SelecionarPorId(Guid id)
    {
        Funcionario? funcionario = repositorioFuncionario.SelecionarPorId(id);

        if (funcionario == null)
            return Result.Fail("Funcionario não encontrado.");

        return Result.Ok(new DetalhesFuncionarioDto(
            funcionario.Id,
            funcionario.Nome,
            funcionario.Telefone,
            funcionario.Cpf
        ));
    }

    private bool ExisteFuncionarioComMesmoCPF(string cpf)
    {
        return repositorioFuncionario
            .SelecionarTodos()
            .Any(p => p.Cpf == cpf);
    }

    private bool ExisteOutroFuncionarioComMesmoCPF(Guid id, string cpf)
    {
        return repositorioFuncionario
            .SelecionarTodos()
            .Any(p => p.Id != id && p.Cpf == cpf);
    }

    private static Result ValidarEntidade(Funcionario funcionario)
    {
        List<string> erros = funcionario.Validar();

        if (erros.Count == 0)
            return Result.Ok();

        return Result.Fail(new Error(erros.First()).WithMetadata("Campo", string.Empty));
    }

    private static Result Falha(string campo, string mensagem)
    {
        return Result.Fail(new Error(mensagem).WithMetadata("Campo", campo));
    }
}