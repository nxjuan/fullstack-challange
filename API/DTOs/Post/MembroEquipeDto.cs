using System.Text.Json.Serialization;

namespace pinterestapi.Config.DTOs.Post;

public class MembroEquipeDto
{
    [JsonPropertyName("membro")]
    public Guid MembroId { get; set; }

    [JsonPropertyName("equipes")]
    public Guid EquipeId { get; set; }
}