using RrsChronosTimeSheet.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Configurations
{
    public class StatusProjetoConfigurations : IEntityTypeConfiguration<StatusProjeto>
    {
        public void Configure(EntityTypeBuilder<StatusProjeto> builder)
        {
            builder.ToTable("TbStatusProjeto");

            builder.HasKey(e => e.Id);

            builder.Property(s => s.Descricao)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
