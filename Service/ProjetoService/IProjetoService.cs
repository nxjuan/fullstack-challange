using pinterestapi.Config.DTOs.Post;
using pinterestapi.Model;
using pinterestapi.Service;

namespace pinterestapi.Service.ProjetoService;

public interface IProjetoService
{
    Task<ServiceResponse<string>> CreateProjeto(ProjetoDTO projetoModel);
    Task<ServiceResponse<string>> GetProjeto(Guid Id);
    Task<ServiceResponse<string>> UpdateProjeto(ProjetosModel projetoModel, Guid Id);
    Task<ServiceResponse<string>> DeleteProjeto(Guid Id);
    Task<ServiceResponse<List<ProjetosModel>>> GetProjetosList();
}