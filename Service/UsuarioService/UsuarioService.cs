
using Microsoft.EntityFrameworkCore;
using pinterestapi.DataContext;
using pinterestapi.Model;

namespace pinterestapi.Service.UsuarioService;

public class UsuarioService : IUsuarioService
{
    private readonly ApplicationDbContext _context;

    public UsuarioService(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<string>> CreateUsuario(UsuariosModel usuarioModel)
    {
        var response = new ServiceResponse<string>();
        try
        {
            await _context.Usuarios.AddAsync(usuarioModel);
            await _context.SaveChangesAsync();  
            
            response.Data = usuarioModel.Id.ToString();
            response.Message = "Usuario cadastrado com sucesso!";
            response.Success = true;
        }
        catch (Exception e)
        {
            response.Message = "Erro no Post: " + e.Message;
            response.Success = false;
        }
        return response;
    }

    public Task<ServiceResponse<string>> UpdateUsuario(UsuariosModel usuarioModel)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<string>> DeleteUsuario(UsuariosModel usuarioModel)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<UsuariosModel>> GetUsuario(Guid id)
    {
        var response = new ServiceResponse<UsuariosModel>();

        try
        {
            var usr = await _context.Usuarios.FindAsync(id);
            if (usr == null)
            {
                response.Success = false;
                response.Message = "Usuario inexistente";
                return response;
            }
            response.Data = usr;
            response.Message = "Usuario Encontrado com sucesso!";
            response.Success = true;
        }
        catch (Exception e)
        {
            response.Message = "Erro na busca: " + e.Message;
            response.Success = false;
            Console.WriteLine(e);
            throw;
        }
        
        return response;
    }

    public async Task<ServiceResponse<List<UsuariosModel>>> GetUsuariosList()
    {
        var response = new ServiceResponse<List<UsuariosModel>>();
        try
        {
            var users = await _context.Usuarios.ToListAsync();
            if (users.Count < 1)
            {
                response.Success = false;
                response.Message = "Tabela Usuarios Vazia. Nenhum registro encontrado";
                return response;
            }
            response.Data = users;
            response.Message = "Usuarios Listado com sucesso!";
            response.Success = true;
            
            return response;
        }
        catch (Exception e)
        {
            response.Message = "Erro na busca: " + e.Message;
            response.Success = false;
            Console.WriteLine(e);
            throw;
        }
    }
}