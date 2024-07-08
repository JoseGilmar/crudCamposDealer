using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace crudCamposDealer.Models
{
    public class Cliente
    {
        [Key]
        [Column("idCliente")]
        [Display(Name = "Id do Cliente")]
        public int IdCliente { get; set; }

        [Required]
        [Column("nmCliente")]
        [Display(Name = "Nome")]
        public required string Nome { get; set; }

        [Required]
        [Column("Cidade")]
        [Display(Name = "Cidade")]
        public required string Cidade { get; set; }

        public required ICollection<Venda> Vendas { get; set; }
    }
}
