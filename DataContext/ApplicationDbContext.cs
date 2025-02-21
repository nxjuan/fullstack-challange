using Microsoft.EntityFrameworkCore;
using pinterestapi.Model;

namespace pinterestapi.DataContext;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<PostModel> Posts { get; set; }
    
    public DbSet<UsuariosModel> Usuarios { get; set; }
    
    public DbSet<EquipesModel> Equipes { get; set; }
    public DbSet<ProjetosModel> Projetos { get; set; }
    public DbSet<TarefasModel> Tarefas { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TarefasModel>()
            .HasOne<ProjetosModel>()
            .WithMany(p => p.Tarefas)
            .HasForeignKey(t => t.ProjetoId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<TarefasModel>()
            .HasOne<UsuariosModel>()
            .WithMany(u => u.Tarefas)
            .HasForeignKey(t => t.ResponsavelId)
            .OnDelete(DeleteBehavior.Cascade);
        
        // ========= tabela intermediaria: usuario -> membroEquipe <- equipe
        modelBuilder.Entity<UsuariosModel>()
            .HasMany(u => u.Equipes)
            .WithMany(e => e.Membros)
            .UsingEntity<Dictionary<string, object>>(
                "MembrosEquipe",
                j => j.HasOne<EquipesModel>().WithMany().HasForeignKey("EquipeId"),
                j => j.HasOne<UsuariosModel>().WithMany().HasForeignKey("UsuarioId")
            );


        modelBuilder.Entity<ProjetosModel>()
            .Property(p => p.DataInicio)
            .HasConversion(v => v.ToUniversalTime(), v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        
        modelBuilder.Entity<ProjetosModel>()
            .Property(p => p.DataFim)
            .HasConversion(v => v.ToUniversalTime(), v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
        
        modelBuilder.Entity<ProjetosModel>()
            .Property(p => p.DataInicio)
            .HasDefaultValueSql("timezone('utc', now())");
    }
}