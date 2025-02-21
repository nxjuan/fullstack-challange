using pinterestapi.Model;

namespace pinterestapi.Service.EquipeService;

public interface IEquipeService
{
    Task<ServiceResponse<string>> CreateEquipe(EquipesModel equipe);
    Task<ServiceResponse<string>> UpdateEquipe(EquipesModel equipe, Guid id);
    Task<ServiceResponse<string>> DeleteEquipe(Guid id);
    Task<ServiceResponse<EquipesModel>> GetEquipe(Guid id);
    Task<ServiceResponse<List<EquipesModel>>> GetEquipesList();

    Task<ServiceResponse<string>> AddMember(Guid equipeId, Guid usuarioId);
    Task<ServiceResponse<string>> RemoveMember(Guid membroEquipeId);
    
}