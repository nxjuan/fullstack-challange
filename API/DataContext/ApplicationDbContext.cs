using Microsoft.EntityFrameworkCore;
using pinterestapi.Model;

namespace pinterestapi.DataContext;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
   
    public DbSet<UsuariosModel> Usuarios { get; set; }
    
    public DbSet<EquipesModel> Equipes { get; set; }
    public DbSet<ProjetosModel> Projetos { get; set; }
    public DbSet<TarefasModel> Tarefas { get; set; }
    public DbSet<MembroEquipe> MembroEquipe { get; set; }
    
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
        
        modelBuilder.Entity<MembroEquipe>()
            .HasKey(me => new { me.MembroId, me.EquipeId });

        modelBuilder.Entity<MembroEquipe>()
            .HasOne(me => me.Membro)
            .WithMany(u => u.MembroEquipe)
            .HasForeignKey(me => me.MembroId);

        modelBuilder.Entity<MembroEquipe>()
            .HasOne(me => me.Equipes)
            .WithMany(e => e.MembroEquipe)
            .HasForeignKey(me => me.EquipeId);
   


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