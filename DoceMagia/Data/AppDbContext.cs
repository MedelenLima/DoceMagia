using DoceMagia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoceMagia.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Ingrediente> Ingredientes { get; set; }
    public DbSet<Preparo> Preparos { get; set; }
    public DbSet<Receita> receitas { get; set; }
    public DbSet<ReceitaIngrediente> ReceitaIngredientes{ get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Definindo chave primaria composta
        builder.Entity<ReceitaIngrediente>()
            .HasKey(ri => new { ri.ReceitaId, ri.IngredienteId });
        
        #region Definição de nomes do Indentity
        builder.Entity<Usuario>().ToTable("Usuarios");
        builder.Entity<IdentityRole>().ToTable("Perfis");
        builder.Entity<IdentityUserRole<string>>().ToTable("UsuarioPerfis");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UsuarioRegras");
        builder.Entity<IdentityUserToken<string>>().ToTable("UsuarioTokens");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UsuarioLogins");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("PerfilRegra");
        #endregion

    }

}
