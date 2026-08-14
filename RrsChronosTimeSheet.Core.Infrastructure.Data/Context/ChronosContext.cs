using RrsChronosTimeSheet.Core.Domain.Entities;

using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RrsChronosTimeSheet.Core.Infrastructure.Data.Context
{
    public class ChronosContext : IdentityDbContext<ApplicationUser>
    {
        public ChronosContext(DbContextOptions<ChronosContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=PCRERUM\\SQLEXPRESS;Initial Catalog=CorporeChronosDB;MultipleActiveResultSets=true;User=sa;Password=TboMI6Z7@#$;TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Localiza todas as configurações que estão nos dbsets       
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChronosContext).Assembly);

            // Configura todas as propriedades string como varchar, usando o tamanho do HasMaxLength se definido
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties().Where(p => p.ClrType == typeof(string)))
                {
                    var maxLength = property.GetMaxLength();
                    if (maxLength.HasValue)
                    {
                        property.SetColumnType($"varchar({maxLength.Value})");
                    }
                    else
                    {
                        // Define um tamanho padrão caso não tenha HasMaxLength
                        property.SetColumnType("varchar(255)");
                    }
                }
            }
            // Desativando o delete cascade globalmente para evitar múltiplos caminhos em cascade no SQL Server
            foreach (IMutableForeignKey relationship in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entityEntry in ChangeTracker.Entries()
                            .Where(entry => entry.Entity.GetType().GetProperty("DataCriacao") != null))
                {
                    if (entityEntry.State == EntityState.Added)
                    {
                        entityEntry.Property("DataCriacao").CurrentValue = DateTime.Now;
                    }

                    if (entityEntry.State == EntityState.Modified)
                    {
                        entityEntry.Property("DataCriacao").IsModified = false;

                        if (entityEntry.Entity.GetType().GetProperty("DataAlteracao") != null)
                            entityEntry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                    }
                }

                return await base.SaveChangesAsync(true, cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoTelefone> TipoTelefone { get; set; }
        public DbSet<TelefoneCliente> TelefoneCliente { get; set; }
        public DbSet<EmailCliente> EmailCliente { get; set; }
        public DbSet<UnidadeFederativa> UnidadeFederativa { get; set; }
        public DbSet<Profissional> Profissional { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Funcao> Funcao { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<StatusProjeto> StatusProjeto { get; set; }
        public DbSet<StatusTarefa> StatusTarefa { get; set; }
        public DbSet<TipoProjeto> TipoProjeto { get; set; }
        public DbSet<Tarefas> Tarefas { get; set; }
        public DbSet<HorasProfissional> HorasProfissional { get; set; }
        public DbSet<EmailFornecedor> EmailFornecedor { get; set; }
        public DbSet<EmailProfissional> EmailProfissional { get; set; }
        public DbSet<TelefoneFornecedor> TelefoneFornecedor { get; set; }
        public DbSet<TelefoneProfissional> TelefoneProfissional { get; set; }
        public DbSet<ComentarioTarefa> ComentarioTarefa { get; set; }
    }
}
