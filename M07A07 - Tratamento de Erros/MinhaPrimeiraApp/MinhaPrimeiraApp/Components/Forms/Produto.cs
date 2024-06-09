using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;

namespace MinhaPrimeiraApp.Components.Forms
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "A categoria do produto é obrigatória.")]
        public string Categoria { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "É necessário informar se o produto está disponível em estoque.")]
        public bool DisponivelEstoque { get; set; }

        [Required(ErrorMessage = "A data de validade é obrigatória.")]
        public DateTime DataValidade { get; set; }

        public IBrowserFile ArquivoProduto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CorSelecionada { get; set; }
    }

}
