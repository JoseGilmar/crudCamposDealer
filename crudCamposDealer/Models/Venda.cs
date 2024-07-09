using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudCamposDealer.Models
{
    public class Venda
    {
        [Key]
        [Column("idVenda")]
        [Display(Name = "Id da Venda")]
        public int IdVenda { get; set; }

        [Required]
        [Column("idCliente")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [Required]
        [Column("idProduto")]
        [Display(Name = "Produto de Interesse")]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }

        [Required]
        [Column("qtdVenda")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
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

        [NotMapped]
        [Display(Name = "Valor da Venda")]
        public decimal ValorTotal => Quantidade * ValorUnitario;
    }
}
