using System.Text.Json.Serialization;

namespace pinterestapi.Model;

public class MembroEquipe
{
    
    public Guid Id { get; init; }
    public Guid EquipeId { get; init; }
    [JsonIgnore]
    public EquipesModel Equipes { get; set; }
    
    public Guid MembroId { get; init; }
    public UsuariosModel Membro { get; set; }
}