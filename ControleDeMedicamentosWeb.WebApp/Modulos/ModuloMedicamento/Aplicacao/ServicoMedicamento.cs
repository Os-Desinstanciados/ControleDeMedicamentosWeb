using FluentResults;
using ControleDeMedicamentosWeb.WebApp.Modulos.ModuloMedicamento.Dominio;
using ControleDeMedicamentosWeb.WebApp.Modulos.ModuloFornecedor.Dominio;

namespace ControleDeMedicamentosWeb.WebApp.Modulos.ModuloMedicamento.Aplicacao;

public class ServicoMedicamento
{
    private readonly IRepositorioMedicamento repositorioMedicamento;
    private readonly IRepositorioFornecedor repositorioFornecedor;    

    public ServicoMedicamento(
        IRepositorioMedicamento repositorioMedicamento,
        IRepositorioFornecedor repositorioFornecedor
        
    )
    {
        this.repositorioMedicamento = repositorioMedicamento;
        this.repositorioFornecedor = repositorioFornecedor;       
    }

    public Result Cadastrar(CadastrarMedicamentoDto dto)
    {
        Fornecedor? fornecedor = repositorioFornecedor.SelecionarPorId(dto.FornecedorId);

        if (fornecedor == null)
            return Falha("FornecedorId", "O fornecedor informado não existe.");

        if (ExisteMedicamentoComNome(dto.Nome))
            return Falha("Nome", "Já existe um medicamento com este nome.");

        Medicamento novoMedicamento = new Medicamento(
            dto.Nome,
            dto.Descricao,
            dto.QuantidadeEstoque,
            fornecedor
        );

        repositorioMedicamento.Cadastrar(novoMedicamento);

        return Result.Ok();
    }

    public Result Editar(EditarMedicamentoDto dto)
    {
        if (ExisteMedicamentoComNome(dto.Nome, dto.Id))
            return Falha("Nome", "Já existe um medicamento com este nome.");

        Fornecedor? fornecedor = repositorioFornecedor.SelecionarPorId(dto.FornecedorId);

        if (fornecedor == null)
            return Falha("FornecedorId", "O fornecedor informado não existe.");

        Medicamento MedicamentoAtualizado = new Medicamento(dto.Nome, dto.Descricao, dto.QuantidadeEstoque, fornecedor);

        bool conseguiuEditar = repositorioMedicamento.Editar(dto.Id, MedicamentoAtualizado);

        if (!conseguiuEditar)
            return Result.Fail("Medicamento não encontrado.");

        return Result.Ok();
    }

    public Result Excluir(Guid id)
    {
        Medicamento? Medicamento = repositorioMedicamento.SelecionarPorId(id);

        if (Medicamento == null)
            return Result.Fail("Medicamento não encontrado.");
        
        repositorioMedicamento.Excluir(id);

        return Result.Ok();
    }

    public List<ListarMedicamentosDto> SelecionarTodos()
    {
        List<Medicamento> medicamentos = repositorioMedicamento.SelecionarTodos();

        return medicamentos
            .Select(m => new ListarMedicamentosDto(m.Id, m.Nome, m.Descricao, m.QuantidadeEstoque, m.Fornecedor.Nome))
            .ToList();
    }

    public Result<DetalhesMedicamentoDto> SelecionarPorId(Guid id)
    {
        Medicamento? medicamento = repositorioMedicamento.SelecionarPorId(id);

        if (medicamento == null)
            return Result.Fail("Medicamento não encontrado.");

        return Result.Ok(new DetalhesMedicamentoDto(medicamento.Id, medicamento.Nome, medicamento.Descricao, medicamento.QuantidadeEstoque, medicamento.Fornecedor.Nome));
    }

    private bool ExisteMedicamentoComNome(string nome, Guid? idIgnorado = null)
    {
        List<Medicamento> medicamentos = repositorioMedicamento.SelecionarTodos();

        foreach (Medicamento m in medicamentos)
        {
            if (m.Id != idIgnorado && string.Equals(m.Nome, nome, StringComparison.OrdinalIgnoreCase))
                return true;
        }

        return false;
    }
    

    private static Result Falha(string campo, string mensagem)
    {
        IError erro = new Error(mensagem).WithMetadata("Campo", campo);

        return Result.Fail(erro);
    }
}
