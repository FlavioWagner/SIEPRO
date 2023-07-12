using Microsoft.EntityFrameworkCore;
using SIEPRO.Data.src.Domain.Entities;

namespace SIEPRO.Data.src.Infrastructure.Data.Contexts
{
    public partial class SIEPROContext : DbContext
    {
        public virtual DbSet<Pessoa> Pessoa { get; set; } = null!;
        public virtual DbSet<PessoaFisica> PessoaFisica { get; set; } = null!;
        public virtual DbSet<PessoaJuridica> PessoaJuridica { get; set; } = null!;
        public virtual DbSet<Ramo> Ramo { get; set; } = null!;
        public virtual DbSet<RamoJuridica> RamoJuridica { get; set; } = null!;

        public SIEPROContext()
        {
        }

        public SIEPROContext(DbContextOptions<SIEPROContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("pessoa");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('pessoa_seq'::regclass)");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("data_cadastro")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasColumnName("nome");

                entity.Property(e => e.Registro)
                    .HasMaxLength(25)
                    .HasColumnName("registro");
            });

            modelBuilder.Entity<PessoaFisica>(entity =>
            {
                entity.ToTable("pessoa_fisica");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.DataNascimento).HasColumnName("data_nascimento");

                entity.Property(e => e.NomeMae)
                    .HasMaxLength(50)
                    .HasColumnName("nome_mae");

                entity.Property(e => e.NomePai)
                    .HasMaxLength(50)
                    .HasColumnName("nome_pai");

                entity.Property(e => e.Rg)
                    .HasMaxLength(10)
                    .HasColumnName("rg");

                entity.Property(e => e.RgExpedicao).HasColumnName("rg_expedicao");

                entity.Property(e => e.RgExpedidor)
                    .HasMaxLength(50)
                    .HasColumnName("rg_expedidor");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(10)
                    .HasColumnName("titulo");

                entity.Property(e => e.TituloSecao)
                    .HasMaxLength(5)
                    .HasColumnName("titulo_secao");

                entity.Property(e => e.TituloZona)
                    .HasMaxLength(5)
                    .HasColumnName("titulo_zona");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PessoaFisica)
                    .HasForeignKey<PessoaFisica>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pessoa_fisica_pessoa");
            });

            modelBuilder.Entity<PessoaJuridica>(entity =>
            {
                entity.ToTable("pessoa_juridica");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.NomeFantasia)
                    .HasMaxLength(100)
                    .HasColumnName("nome_fantasia");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PessoaJuridica)
                    .HasForeignKey<PessoaJuridica>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_pessoa_juridica_pessoa");
            });

            modelBuilder.Entity<Ramo>(entity =>
            {
                entity.ToTable("ramo");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('ramo_seq'::regclass)");

                entity.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<RamoJuridica>(entity =>
            {
                entity.ToTable("ramo_juridica");

                entity.HasIndex(e => new { e.IdPessoaJuridica, e.IdRamo }, "uk_ramo_juridica")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('ramo_juridica_seq'::regclass)");

                entity.Property(e => e.IdPessoaJuridica).HasColumnName("id_pessoa_juridica");

                entity.Property(e => e.IdRamo).HasColumnName("id_ramo");

                entity.HasOne(d => d.IdPessoaJuridicaNavigation)
                    .WithMany(p => p.RamoJuridica)
                    .HasForeignKey(d => d.IdPessoaJuridica)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ramo_juridica_pessoa");

                entity.HasOne(d => d.IdRamoNavigation)
                    .WithMany(p => p.RamoJuridica)
                    .HasForeignKey(d => d.IdRamo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ramo_juridica_ramo");
            });

            modelBuilder.HasSequence("pessoa_seq");

            modelBuilder.HasSequence("ramo_juridica_seq");

            modelBuilder.HasSequence("ramo_seq");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
