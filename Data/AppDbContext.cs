using System;
using AgendaTelefonica.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaTelefonica.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ClienteTelefone> ClienteTelefone { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cliente>(b =>
            {
                b.HasKey(c => c.Id);
                b.Property(c => c.Id).HasDefaultValueSql("NEWID()");
                b.Property(c => c.Nome).HasMaxLength(80).IsRequired();
                b.Property(c => c.Email).HasMaxLength(80).IsRequired();
                b.Property(c => c.DataNascimento);
                b.Property(c => c.DataCadastro).HasDefaultValueSql("GETDATE()");
                b.Property(c => c.DataAlteracao).HasDefaultValueSql("GETDATE()");
                b.HasMany(c => c.Telefones)
                .WithOne(t => t.Cliente)
                .HasForeignKey(t => t.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
                b.ToTable("cliente");
            });

            builder.Entity<ClienteTelefone>(b =>
            {
                b.HasKey(t => t.Id);
                b.Property(t => t.Id).HasDefaultValueSql("NEWID()");
                b.Property(t => t.Descricao).HasConversion(
                    v => v.ToString(),
                    v => (TelefoneEnum)Enum.Parse(typeof(TelefoneEnum), v))
                .IsRequired();
                b.Property(t => t.Numero).HasMaxLength(20).IsRequired();
                b.HasOne(t => t.Cliente)
                .WithMany(c => c.Telefones)
                .HasForeignKey(t => t.ClienteId);
                b.ToTable("cliente_telefone");
            });

            builder.Entity<Usuario>(b =>
            {
                b.HasKey(u => u.Id);
                b.Property(u => u.Id).HasDefaultValueSql("NEWID()");
                b.Property(u => u.Name).HasMaxLength(60).IsRequired();
                b.Property(u => u.Email).IsRequired();
                b.Property(u => u.Password).IsRequired();
                b.Property(t => t.Role).HasConversion(
                    v => v.ToString(),
                    v => (RoleEnum)Enum.Parse(typeof(RoleEnum), v)).HasDefaultValue(RoleEnum.USER);
                b.ToTable("usuario");
            });
        }
    }
}