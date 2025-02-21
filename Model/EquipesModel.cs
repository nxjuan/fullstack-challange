using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pinterestapi.Model;

public class EquipesModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
    [StringLength(255)]
    [Required]
    public string Nome { get; set; } = string.Empty;
    [StringLength(2083)]
    public string Descricao { get; set; } = string.Empty;
    
    public ICollection<UsuariosModel>? Membros { get; set; }
}