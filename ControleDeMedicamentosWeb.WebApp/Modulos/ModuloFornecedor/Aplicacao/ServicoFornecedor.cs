using FluentResults;
using ControleDeMedicamentosWeb.WebApp.Modulos.ModuloFornecedor.Dominio;

namespace ControleDeMedicamentosWeb.WebApp.Modulos.ModuloFornecedor.Aplicacao;

public class ServicoFornecedor
{
    private readonly IRepositorioFornecedor repositorioFornecedor;    

    public ServicoFornecedor(
        IRepositorioFornecedor repositorioFornecedor        
    )
    {
        this.repositorioFornecedor = repositorioFornecedor;        
    }

    public Result Cadastrar(CadastrarFornecedorDto dto)
    {
        if (ExisteFornecedorComCnpj(dto.Cnpj))
            return Falha(nameof(dto.Cnpj), "Já existe um fornecedor com este CNPJ.");

        Fornecedor novoFornecedor = new Fornecedor(dto.Nome, dto.Telefone, dto.Cnpj);

        Result resultadoValidacao = ValidarEntidade(novoFornecedor);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioFornecedor.Cadastrar(novoFornecedor);

        return Result.Ok();
    }

    public Result Editar(EditarFornecedorDto dto)
    {
        if (ExisteFornecedorComCnpj(dto.Cnpj, dto.Id))
            return Falha(nameof(dto.Cnpj), "Já existe um fornecedor com este CNPJ.");

        Fornecedor fornecedorAtualizado = new Fornecedor(dto.Nome, dto.Telefone, dto.Cnpj);

        Result resultadoValidacao = ValidarEntidade(fornecedorAtualizado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        bool conseguiuEditar = repositorioFornecedor.Editar(dto.Id, fornecedorAtualizado);

        if (!conseguiuEditar)
            return Result.Fail("Fornecedor não encontrado.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Fornecedor? fornecedor = repositorioFornecedor.SelecionarPorId(id);

        if (fornecedor == null)
            return Result.Fail("Fornecedor não encontrado.");    
        
        repositorioFornecedor.Excluir(id);

        return Result.Ok();
    }

    public List<ListarFornecedorsDto> SelecionarTodos()
    {
        return repositorioFornecedor
            .SelecionarTodos()
            .Select(f => new ListarFornecedorsDto(f.Id, f.Nome, f.Telefone, f.Cnpj))
            .ToList();
    }

    public Result<DetalhesFornecedorDto> SelecionarPorId(Guid id)
    {
        Fornecedor? fornecedor = repositorioFornecedor.SelecionarPorId(id);

        if (fornecedor == null)
            return Result.Fail("Fornecedor não encontrado.");

        return Result.Ok(new DetalhesFornecedorDto(
            fornecedor.Id,
            fornecedor.Nome,
            fornecedor.Telefone,
            fornecedor.Cnpj
            ));
    }

    private bool ExisteFornecedorComCnpj(string cnpj, Guid? idIgnorado = null)
    {
        return repositorioFornecedor
            .SelecionarTodos()
            .Any(f =>
                f.Id != idIgnorado &&
                string.Equals(f.Cnpj, cnpj, StringComparison.OrdinalIgnoreCase)
            );
    }

    private static Result ValidarEntidade(Fornecedor fornecedor)
    {
        List<string> erros = fornecedor.Validar();

        if (erros.Count == 0)
            return Result.Ok();

        return Result.Fail(new Error(erros.First()).WithMetadata("Campo", string.Empty));
    }

    private static Result Falha(string campo, string mensagem)
    {
        return Result.Fail(new Error(mensagem).WithMetadata("Campo", campo));
    }
}
