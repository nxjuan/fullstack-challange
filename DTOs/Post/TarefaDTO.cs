using GiraChallange.domain.enums;

namespace pinterestapi.Config.DTOs.Post;

public class TarefaDTO
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    
    public Guid ProjetoId { get; set; }
    
    public Guid? ResponsavelId { get; set; }
    
    public StatusEnum? Status { get; set; }

}