namespace ControleDeMedicamentosWeb.WebApp.Modulos.ModuloFornecedor.Aplicacao;

public record ListarFornecedorsDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Cnpj
);

public record CadastrarFornecedorDto(
    string Nome,
    string Telefone,
    string Cnpj
);

public record EditarFornecedorDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Cnpj
);

public record DetalhesFornecedorDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Cnpj
);
