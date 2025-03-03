using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public ICollection<MembroEquipe>? MembroEquipe { get; set; }
}