using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Descricao { get; set; }

        [Required]
        [Column("vlrUnitario")]
        [Display(Name = "Valor Unitário")]
        public decimal ValorUnitario { get; set; }
    }
}
