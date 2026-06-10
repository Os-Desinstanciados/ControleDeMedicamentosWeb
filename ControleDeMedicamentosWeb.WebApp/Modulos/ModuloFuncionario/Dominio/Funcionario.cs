using ControleDeMedicamentosWeb.WebApp.Compartilhado.Dominio;

namespace ControleDeMedicamentosWeb.WebApp.Modulos.ModuloFuncionario.Dominio;

public sealed class Funcionario : EntidadeBase<Funcionario>
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;

    public Funcionario() { }

    public Funcionario(string nome, string telefone, string cpf)
    {
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" deve ser preenchido.");

        else if (Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter de 3 a 100 caracteres.");

        if (string.IsNullOrWhiteSpace(Telefone))
            erros.Add("O campo \"Telefone\" deve ser preenchido.");

        else if (Telefone.Length != 10 && Telefone.Length != 11)
            erros.Add("O campo \"Telefone\" deve conter 10 ou 11 dígitos.");

        if (string.IsNullOrWhiteSpace(Cpf))
            erros.Add("O campo \"CPF\" deve ser preenchido.");

        else if (Cpf.Length != 11)
            erros.Add("O campo \"CPF\" deve conter 11 dígitos.");

        return erros;
    }

    public override void Atualizar(Funcionario entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Telefone = entidadeAtualizada.Telefone;
        Cpf = entidadeAtualizada.Cpf;
    }
}