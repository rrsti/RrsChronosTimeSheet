using RrsChronosTimeSheet.Core.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class TipoTelefoneConfigurations : IEntityTypeConfiguration<TipoTelefone>
    {
        public void Configure(EntityTypeBuilder<TipoTelefone> builder)
        {
            builder.ToTable("TbTipoTelefone");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
