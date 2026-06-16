using System.ComponentModel.DataAnnotations;

namespace ControleDeMedicamentosWeb.WebApp.Modulos.ModuloFornecedor.Apresentacao;

public record ListarFornecedoresViewModel(
    Guid Id,
    string Nome,
    string Telefone,
    string Cnpj
);

public record CadastrarFornecedorViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    [StringLength(11, MinimumLength = 10, ErrorMessage = "O campo \"Telefone\" deve conter 10 ou 11 caracteres.")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"CNPJ\" deve ser preenchido.")]
    [StringLength(14, MinimumLength = 14, ErrorMessage = "O campo \"CNPJ\" deve conter 14 caracteres.")]
    string Cnpj
);

public record EditarFornecedorViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    [StringLength(11, MinimumLength = 10, ErrorMessage = "O campo \"Telefone\" deve conter 10 ou 11 caracteres.")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"CNPJ\" deve ser preenchido.")]
    [StringLength(14, MinimumLength = 14, ErrorMessage = "O campo \"CNPJ\" deve conter 14 caracteres.")]
    string Cnpj
);

public record ExcluirFornecedorViewModel(
    Guid Id,
    string Nome,
    string Telefone,
    string Cnpj
);
