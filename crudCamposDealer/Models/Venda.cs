using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace crudCamposDealer.Models
{
    public class Venda
    {
        [Key]
        [Column("idVenda")]
        [Display(Name = "Id do Venda")]
        public int IdVenda { get; set; }

        [Required]
        [Column("idCliente")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public required Cliente Cliente { get; set; }

        [Required]
        [Column("idProduto")]
        [Display(Name = "Produto de Interesse")]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public required Produto Produto { get; set; }

        [Required]
        [Column("qtdVenda")]
        [Display(Name = "Quantidade do Produto")]
        public int Quantidade { get; set; }

        [Required]
        [Column("vlrUnitarioVenda")]
        [Display(Name = "Valor Unitário")]
        public decimal ValorUnitario { get; set; }

        [Required]
        [Column("dthVenda")]
        [Display(Name = "Data da Venda")]
        public DateTime DataVenda { get; set; }

        [Required]
        [Column("vlrTotalVenda")]
        [Display(Name = "Valor da Venda")]
        public decimal ValorTotal { get; set; }
    }
}
