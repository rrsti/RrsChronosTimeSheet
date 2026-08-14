using RrsChronosTimeSheet.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class FuncaoConfigurations : IEntityTypeConfiguration<Funcao>
    {
        public void Configure(EntityTypeBuilder<Funcao> builder)
        {
            builder.ToTable("TbFuncao");

            builder.HasKey(e => e.Id);

            builder.Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(f => f.Descricao)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(f => f.Observacao)
                .IsRequired(false)
                .HasMaxLength(500);
        }
    }
}
