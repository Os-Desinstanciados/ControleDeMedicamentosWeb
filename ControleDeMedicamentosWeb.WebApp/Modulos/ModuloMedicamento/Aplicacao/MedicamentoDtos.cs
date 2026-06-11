namespace ControleDeMedicamentosWeb.WebApp.Modulos.ModuloMedicamento.Aplicacao;

public record ListarMedicamentosDto(
    Guid Id,
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    string FornecedorNome
);

public record CadastrarMedicamentoDto(
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    Guid FornecedorId
);

public record EditarMedicamentoDto(
    Guid Id,
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    Guid FornecedorId
);

public record DetalhesMedicamentoDto(
    Guid Id,
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    string FornecedorNome
);
