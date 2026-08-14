using RrsChronosTimeSheet.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class TipoProjetoConfigurations : IEntityTypeConfiguration<TipoProjeto>
    {
        public void Configure(EntityTypeBuilder<TipoProjeto> builder)
        {
            builder.ToTable("TbTipoProjeto");

            builder.HasKey(e => e.Id);

            builder.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
