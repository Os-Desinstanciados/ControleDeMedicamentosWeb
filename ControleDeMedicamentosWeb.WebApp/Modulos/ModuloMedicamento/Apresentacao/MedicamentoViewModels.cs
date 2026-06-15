using System.ComponentModel.DataAnnotations;
using ControleDeMedicamentosWeb.WebApp.Modulos.ModuloFornecedor.Dominio;

namespace ControleDeMedicamentosWeb.WebApp.Modulos.ModuloMedicamento.Apresentacao;

public record ListarMedicamentosViewModel(
    Guid Id,
    string Nome,
    string Descricao,
    uint QuantidadeEstoque,
    string FornecedorNome
);

public record CadastrarMedicamentoViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome,
    
    [Required(ErrorMessage = "O campo \"Descrição\" deve ser preenchido.")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "O campo \"Descrição\" deve conter entre 5 e 255 caracteres.")]
    string Descricao,

    [Required(ErrorMessage = "O campo \"Quantidade no Estoque\" deve ser preenchido.")]
    [Range(1, uint.MaxValue, ErrorMessage = "A quantidade no estoque deve ser maior que ZERO.")]
    uint QuantidadeEstoque,

    [Required(ErrorMessage = "O campo \"Fornecedor\" deve ser preenchido.")]
    string FornecedorNome
);

public record EditarMedicamentoViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome,
    
    [Required(ErrorMessage = "O campo \"Descrição\" deve ser preenchido.")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "O campo \"Descrição\" deve conter entre 5 e 255 caracteres.")]
    string Descricao,

    [Required(ErrorMessage = "O campo \"Quantidade no Estoque\" deve ser preenchido.")]
    [Range(1, uint.MaxValue, ErrorMessage = "A quantidade no estoque deve ser maior que ZERO.")]
    uint QuantidadeEstoque,

    [Required(ErrorMessage = "O campo \"Fornecedor\" deve ser preenchido.")]
    string FornecedorNome
);

public record ExcluirMedicamentoViewModel(
    Guid Id,
    string Nome,
    string Descricao,
    int QuantidadeEstoque,
    string FornecedorNome
);
