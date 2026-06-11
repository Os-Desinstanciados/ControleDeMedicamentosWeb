using ControleDeMedicamentosWeb.WebApp.Compartilhado.Dominio;

namespace ControleDeMedicamentosWeb.WebApp.Modulos.ModuloFornecedor.Dominio;

public sealed class Fornecedor : EntidadeBase<Fornecedor>
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Cnpj { get; set; } = string.Empty;

    public Fornecedor() { }

    public Fornecedor(string nome, string telefone, string cnpj)
    {
        Nome = nome;
        Telefone = telefone;
        Cnpj = cnpj;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" deve ser preenchido.");

        else if (Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 3 e 100 caracteres.");

        if (string.IsNullOrWhiteSpace(Telefone))
            erros.Add("O campo \"Telefone\" deve ser preenchido.");

        else if (Telefone.Length < 10 || Telefone.Length > 11)
            erros.Add("O campo \"Telefone\" deve conter 10 ou 11 caracteres.");
        
        if (string.IsNullOrWhiteSpace(Cnpj))
            erros.Add("O campo \"CNPJ\" deve ser preenchido.");

        else if (Cnpj.Length != 14)
            erros.Add("O campo \"CNPJ\" deve conter 14 caracteres.");

        return erros;
    }

    public override void Atualizar(Fornecedor entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Telefone = entidadeAtualizada.Telefone;
        Cnpj = entidadeAtualizada.Cnpj;
    }
}
