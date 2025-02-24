using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GiraChallange.domain.enums;

namespace pinterestapi.Model;

public class TarefasModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
    [StringLength(255)]
    public string Nome { get; set; } = String.Empty;
    [StringLength(2083)]
    public string Descricao { get; set; } = String.Empty;
    
    [Required]
    public Guid ProjetoId { get; set; }
    
    [Required]
    public Guid? ResponsavelId { get; set; }
    
    public StatusEnum? Status { get; set; }
}