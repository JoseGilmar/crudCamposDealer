using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace crudCamposDealer.Models
{
    public class Produto
    {
        [Key]
        [Column("idProduto")]
        [Display(Name = "Id do Produto")]
        public int IdProduto { get; set; }

        [Required]
        [Column("dscProduto")]
        [Display(Name = "Descrição")]
        public required string Descricao { get; set; }

        [Required]
        [Column("vlrUnitario")]
        [Display(Name = "Valor Unitário")]
        public decimal ValorUnitario { get; set; }

        public required ICollection<Venda> Vendas { get; set; }
    }
}
