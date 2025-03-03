using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using GiraChallange.domain.enums;

namespace pinterestapi.Model;

public class ProjetosModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
    [StringLength(255)]
    public string Nome { get; set; } = String.Empty;
    [StringLength(2083)]
    public string Descricao { get; set; } = String.Empty;
    public DateTime DataInicio { get; init; } 
    public DateTime DataFim { get; set; }
    public StatusEnum Status { get; set; }
    
    [JsonInclude]
    public ICollection<TarefasModel>? Tarefas { get; set; }
}