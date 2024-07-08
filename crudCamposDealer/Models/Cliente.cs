using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Nome { get; set; }

        [Required]
        [Column("Cidade")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }
    }
}
