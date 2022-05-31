using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace servicos_api.Models
{
    public partial class servicosContext : DbContext
    {
        public servicosContext()
        {
        }

        public servicosContext(DbContextOptions<servicosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Atendimento> Atendimentos { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<Profissional> Profissionals { get; set; } = null!;
        public virtual DbSet<Telefone> Telefones { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=servicos;TrustServerCertificate=True;User Id=sa;Password=P@ssw0rdsenac;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Atendimento>(entity =>
            {
                entity.ToTable("atendimento");

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.DataHora)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("data_hora");

                entity.Property(e => e.Descricao)
                    .HasColumnType("text")
                    .HasColumnName("descricao");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdProfissional).HasColumnName("id_profissional");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_atendimento_atendimento");

                entity.HasOne(d => d.IdProfissionalNavigation)
                    .WithMany(p => p.Atendimentos)
                    .HasForeignKey(d => d.IdProfissional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_atendimento_profissional");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("cliente");

                entity.HasIndex(e => e.Cpf, "UK_cpf_cliente")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.IdEndereco).HasColumnName("id_endereco");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cliente_endereco");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("endereco");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Bairro)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("bairro");

                entity.Property(e => e.Cep)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("cep");

                entity.Property(e => e.Cidade)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cidade");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("complemento");

                entity.Property(e => e.Rua)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("rua");
            });

            modelBuilder.Entity<Profissional>(entity =>
            {
                entity.ToTable("profissional");

                entity.HasIndex(e => e.Cnpj, "UK_cnpj")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UK_cpf")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.Cnpj)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cnpj");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.IdEndereco).HasColumnName("id_endereco");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.Profissionals)
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_profissional_endereco");
            });

            modelBuilder.Entity<Telefone>(entity =>
            {
                entity.ToTable("telefone");

                entity.HasIndex(e => e.Numero, "UK_numero")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id");

                entity.Property(e => e.IdCliente).HasColumnName("id_cliente");

                entity.Property(e => e.IdProfissional).HasColumnName("id_profissional");

                entity.Property(e => e.Numero)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_telefone_cliente");

                entity.HasOne(d => d.IdProfissionalNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.IdProfissional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_telefone_profissional");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
