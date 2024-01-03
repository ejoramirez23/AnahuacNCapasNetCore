using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class AnahuacNcapasNetCoreContext : DbContext
{
    public AnahuacNcapasNetCoreContext()
    {
    }

    public AnahuacNcapasNetCoreContext(DbContextOptions<AnahuacNcapasNetCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<Colonium> Colonia { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Editorial> Editorials { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Genero> Generos { get; set; }

    public virtual DbSet<Idioma> Idiomas { get; set; }

    public virtual DbSet<Medio> Medios { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Prestamo> Prestamos { get; set; }

    public virtual DbSet<TipoMedio> TipoMedios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=.; Database=AnahuacNCapasNetCore; TrustServerCertificate=True; Trusted_Connection=True; User ID=sa; Password=12345674;");
        => optionsBuilder.UseSqlServer("Server=.; Database=AnahuacNCapasNetCore; TrustServerCertificate=True; Trusted_Connection=False; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.IdAutor).HasName("PK__Autor__D69DAB4A2A613C66");

            entity.ToTable("Autor");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Colonium>(entity =>
        {
            entity.HasKey(e => e.IdColonia).HasName("PK__Colonia__A1580F66AA867EDA");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Colonia)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("FK__Colonia__IdMunic__286302EC");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__Direccio__1F8E0C76E2ACBAE7");

            entity.ToTable("Direccion");

            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdUsuario).HasMaxLength(450);
            entity.Property(e => e.NumExterior)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.NumInterior)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.IdColoniaNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdColonia)
                .HasConstraintName("FK__Direccion__IdCol__47DBAE45");

            entity.HasOne(d => d.IdEditorialNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdEditorial)
                .HasConstraintName("FK__Direccion__IdEdi__49C3F6B7");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Direccion__IdUsu__48CFD27E");
        });

        modelBuilder.Entity<Editorial>(entity =>
        {
            entity.HasKey(e => e.IdEditorial).HasName("PK__Editoria__EF838671BD1C11CB");

            entity.ToTable("Editorial");

            entity.Property(e => e.NombreEdit)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado).HasName("PK__Estado__FBB0EDC12D3274B6");

            entity.ToTable("Estado");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Estados)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("FK__Estado__IdPais__22AA2996");
        });

        modelBuilder.Entity<Genero>(entity =>
        {
            entity.HasKey(e => e.IdGenero).HasName("PK__Genero__0F8349880F3FA6D2");

            entity.ToTable("Genero");

            entity.Property(e => e.NombreGenero)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Idioma>(entity =>
        {
            entity.HasKey(e => e.IdIdioma).HasName("PK__Idioma__C867BD3616A1FE29");

            entity.ToTable("Idioma");

            entity.Property(e => e.NombreIdioma)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Medio>(entity =>
        {
            entity.HasKey(e => e.IdMedio).HasName("PK__Medio__EF8018602EE1F7D7");

            entity.ToTable("Medio");

            entity.Property(e => e.AñoLanzamiento).HasColumnType("date");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Duracion)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Imagen).IsUnicode(false);
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAutorNavigation).WithMany(p => p.Medios)
                .HasForeignKey(d => d.IdAutor)
                .HasConstraintName("FK__Medio__IdAutor__1DE57479");

            entity.HasOne(d => d.IdEditorialNavigation).WithMany(p => p.Medios)
                .HasForeignKey(d => d.IdEditorial)
                .HasConstraintName("FK__Medio__IdEditori__1B0907CE");

            entity.HasOne(d => d.IdGeneroNavigation).WithMany(p => p.Medios)
                .HasForeignKey(d => d.IdGenero)
                .HasConstraintName("FK__Medio__IdGenero__1CF15040");

            entity.HasOne(d => d.IdIdiomaNavigation).WithMany(p => p.Medios)
                .HasForeignKey(d => d.IdIdioma)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Medio__IdIdioma__1BFD2C07");

            entity.HasOne(d => d.IdTipoMedioNavigation).WithMany(p => p.Medios)
                .HasForeignKey(d => d.IdTipoMedio)
                .HasConstraintName("FK__Medio__IdTipoMed__1A14E395");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("PK__Municipi__610059781BFC6108");

            entity.ToTable("Municipio");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK__Municipio__IdEst__25869641");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("PK__Pais__FC850A7BBC70AD28");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Prestamo>(entity =>
        {
            entity.HasKey(e => e.IdPrestamo).HasName("PK__Prestamo__6FF194C0DDAEEA1C");

            entity.ToTable("Prestamo");

            entity.Property(e => e.FechaEntrega).HasColumnType("date");
            entity.Property(e => e.FechaPrestamo).HasColumnType("date");
            entity.Property(e => e.IdUsuario).HasMaxLength(450);

            entity.HasOne(d => d.IdMedioNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdMedio)
                .HasConstraintName("FK__Prestamo__IdMedi__4CA06362");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Prestamos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Prestamo__IdUsua__4D94879B");
        });

        modelBuilder.Entity<TipoMedio>(entity =>
        {
            entity.HasKey(e => e.IdTipoMedio).HasName("PK__TipoMedi__7A9964B22B0ADF95");

            entity.ToTable("TipoMedio");

            entity.Property(e => e.NombreTm)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NombreTM");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
