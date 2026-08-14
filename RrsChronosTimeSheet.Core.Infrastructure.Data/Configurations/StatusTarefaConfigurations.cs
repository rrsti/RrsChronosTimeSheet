using RrsChronosTimeSheet.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class StatusTarefaConfigurations : IEntityTypeConfiguration<StatusTarefa>
    {
        public void Configure(EntityTypeBuilder<StatusTarefa> builder)
        {
            builder.ToTable("TbStatusTarefa");

            builder.HasKey(e => e.Id);

            builder.Property(s => s.Descricao)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
