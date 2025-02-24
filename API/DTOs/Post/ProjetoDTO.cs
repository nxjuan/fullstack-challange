using GiraChallange.domain.enums;

namespace pinterestapi.Config.DTOs.Post;

public class ProjetoDTO
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DataInicio { get; init; } 
    public DateTime DataFim { get; set; }
    public StatusEnum Status { get; set; }
}