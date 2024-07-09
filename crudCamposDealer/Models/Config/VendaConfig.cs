using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace crudCamposDealer.Models.Config;

public class VendaConfig : IEntityTypeConfiguration<Venda>
{
    public void Configure(EntityTypeBuilder<Venda> builder)
    {
        builder.ToTable("Venda");

        builder.HasKey(x => x.IdVenda);

        builder.HasOne(x => x.Cliente);
        builder.HasOne(x => x.Produto);
    }
}
