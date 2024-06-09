using System.ComponentModel.DataAnnotations;

namespace AppCompleta.Components.Produtos;

public class Produto
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Nome")]
    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    public string Nome { get; set; }

    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    [Display(Name = "Categoria")]
    [Required(ErrorMessage = "A categoria do produto é obrigatória.")]
    public string Categoria { get; set; }

    [Display(Name = "Preço")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
    public decimal Preco { get; set; }

    [Display(Name = "Disponível?")]
    [Required(ErrorMessage = "É necessário informar se o produto está disponível em estoque.")]
    public bool DisponivelEstoque { get; set; }

    [Display(Name = "Data de Validade")]
    [Required(ErrorMessage = "A data de validade é obrigatória.")]
    public DateTime DataValidade { get; set; }
}
