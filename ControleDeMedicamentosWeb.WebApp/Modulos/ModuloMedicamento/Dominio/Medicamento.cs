using ControleDeMedicamentosWeb.WebApp.Compartilhado.Dominio;
using ControleDeMedicamentosWeb.WebApp.Modulos.ModuloEstoque.Dominio;
using ControleDeMedicamentosWeb.WebApp.Modulos.ModuloFornecedor.Dominio;

namespace ControleDeMedicamentosWeb.WebApp.Modulos.ModuloMedicamento.Dominio;

public sealed class Medicamento : EntidadeBase<Medicamento>
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public uint QuantidadeEstoque { get; set; } = 0;
    public Fornecedor Fornecedor { get; set; } = null!;
    public List<RequisicaoBase> Requisicoes { get; set; } = new List<RequisicaoBase>();

    public Medicamento() { }

    public Medicamento(string nome, string descricao, uint quantidadeEstoque, Fornecedor fornecedor)
    {
        Nome = nome;
        Descricao = descricao;
        QuantidadeEstoque = quantidadeEstoque;
        Fornecedor = fornecedor;
    }

    public void RegistrarRequisicao(RequisicaoBase requisicao)
    {
        Requisicoes.Add(requisicao);
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" deve ser preenchido.");

        else if (Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 3 e 100 caracteres.");

        if (string.IsNullOrWhiteSpace(Descricao))
            erros.Add("O campo \"Descrição\" deve ser preenchido.");

        else if (Descricao.Length < 5 || Descricao.Length > 255)
            erros.Add("O campo \"Descrição\" deve conter  entre 5 e 255 caracteres.");
        
        if (QuantidadeEstoque < 0)
            erros.Add("O campo \"Quantidade no Estoque\" um número maior ou igual a ZERO.");

        if (Fornecedor == null)
            erros.Add("O campo \"Fornecedor\" deve ser preenchido.");

        return erros;
    }

    public override void Atualizar(Medicamento entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Descricao = entidadeAtualizada.Descricao;
        QuantidadeEstoque = entidadeAtualizada.QuantidadeEstoque;
        Fornecedor = entidadeAtualizada.Fornecedor;
    }
}
