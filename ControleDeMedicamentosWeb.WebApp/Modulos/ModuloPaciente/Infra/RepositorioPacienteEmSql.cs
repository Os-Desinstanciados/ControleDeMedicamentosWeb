using ControleDeMedicamentosWeb.WebApp.Compartilhado.Infra.Sql;
using ControleDeMedicamentosWeb.WebApp.Modulos.ModuloPaciente.Dominio;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ControleDeMedicamentosWeb.WebApp.Modulos.ModuloPaciente.Infra;

public sealed class RepositorioPacienteEmSql(ISqlConnectionFactory connectionFactory) : IRepositorioPaciente
{
    private const string InserirSql = """
        INSERT INTO dbo.TBPaciente (Id, Nome, Telefone, CartaoSUS, Cpf)
        VALUES (@Id, @Nome, @Telefone, @CartaoSUS, @Cpf);
    """;

    private const string AtualizarSql = """
        UPDATE dbo.TBPaciente
        SET
            Nome = @Nome,
            Telefone = @Telefone,
            CartaoSUS = @CartaoSUS,
            Cpf = @Cpf
        WHERE Id = @Id;
    """;

     private const string ExcluirSql = """
        DELETE FROM dbo.TBPaciente
        WHERE Id = @Id;
    """;

    private const string SelecionarPorIdSql = """
        SELECT Id, Nome, Telefone, CartaoSUS, Cpf
        FROM dbo.TBPaciente
        WHERE Id = @Id;
    """;

    private const string SelecionarTodosSql = """
        SELECT Id, Nome, Telefone, CartaoSUS, Cpf
        FROM dbo.TBPaciente
        ORDER BY Nome;
    """;

    public void Cadastrar(Paciente entidade)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        conexao.Execute(InserirSql, entidade);
    }

    public bool Editar(Guid idSelecionado, Paciente entidadeAtualizada)
    {
        entidadeAtualizada.Id = idSelecionado;

        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.Execute(AtualizarSql, entidadeAtualizada) == 1;
    }

    public bool Excluir(Guid idSelecionado)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.Execute(ExcluirSql, new { Id = idSelecionado }) == 1;
    }    

    public Paciente? SelecionarPorId(Guid idSelecionado)
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.QuerySingleOrDefault<Paciente>(SelecionarPorIdSql, new { Id = idSelecionado });
    }

    public List<Paciente> SelecionarTodos()
    {
        using SqlConnection conexao = connectionFactory.CreateConnection();

        conexao.Open();

        return conexao.Query<Paciente>(SelecionarTodosSql).ToList();
    }

    public List<Paciente> Filtrar(Predicate<Paciente> filtro)
    {
        return SelecionarTodos().FindAll(filtro);
    }
}