
using pinterestapi.Config.DTOs.Post;
using pinterestapi.Model;

namespace pinterestapi.Service.UsuarioService;

public interface IUsuarioService
{
    Task<ServiceResponse<string>> CreateUsuario(UsuarioDTO dto);
    Task<ServiceResponse<string>> UpdateUsuario(UsuariosModel usuarioModel);
    Task<ServiceResponse<string>> DeleteUsuario(UsuariosModel usuarioModel);
    Task<ServiceResponse<UsuariosModel>> GetUsuario(Guid Id);
    
    Task<ServiceResponse<List<UsuariosModel>>> GetUsuariosList();
    
}