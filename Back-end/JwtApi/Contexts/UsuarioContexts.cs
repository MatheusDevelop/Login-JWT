using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using JwtApi.Domains;
using Microsoft.Extensions.Configuration;

namespace JwtApi.Contexts
{
    public partial class UsuarioContexts : DbContext
    {
        private readonly IConfiguration confg;

        public UsuarioContexts()
        {
                
        }
        public UsuarioContexts(IConfiguration conf)
        {
            confg = conf;
        }

        public UsuarioContexts(DbContextOptions<UsuarioContexts> options)
            : base(options)
        {
        }

        public virtual DbSet<Usuarios> Usuarios { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                
            {
                optionsBuilder.UseSqlServer(@"Data Source=.\SqlExpress; Initial Catalog= JWTApp; User Id=sa; Password=sa132");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF976B42CE75");

                entity.Property(e => e.IdUsuario).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(225)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
