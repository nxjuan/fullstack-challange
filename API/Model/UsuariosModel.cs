using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pinterestapi.Model;

public class UsuariosModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
    [StringLength(255)]
    public string Nome { get; set; } = string.Empty;
    [StringLength(255)]
    public string Email { get; set; } = String.Empty;
    [StringLength(255)]
    public string Password { get; set; } = string.Empty;
    
    public ICollection<TarefasModel>? Tarefas { get; set; }
    
    public ICollection<EquipesModel>? Equipes { get; set; }
}