using Microsoft.EntityFrameworkCore;
using pinterestapi.DataContext;
using pinterestapi.Model;
using pinterestapi.Service.EquipeService;

namespace pinterestapi.Service.Equipes;

public class EquipeService : IEquipeService
{

    private readonly ApplicationDbContext _context;

    public EquipeService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async  Task<ServiceResponse<string>> CreateEquipe(EquipesModel equipe)
    {
        var result = new ServiceResponse<string>();
        try
        {
            await _context.Equipes.AddAsync(equipe);
            await _context.SaveChangesAsync();
            
            result.Success = true;
            result.Message = "Equipe cadastrado com sucesso!";
            result.Data = equipe.Id.ToString();
        }
        catch (Exception e)
        {
            result.Success = false;
            result.Message = "Erro durante o post: " + e.Message;
            Console.WriteLine(e);
            throw;
        }
        
        return result;
    }

    public Task<ServiceResponse<string>> UpdateEquipe(EquipesModel equipe, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<string>> DeleteEquipe(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<EquipesModel>> GetEquipe(Guid id)
    {
        var result = new ServiceResponse<EquipesModel>();
        try
        {
            var equipe = await _context.Equipes.FindAsync(id);

            if (equipe == null)
            {
                result.Success = false;
                result.Message = "Equipe não encontrada";
                return result;
            }
            
            result.Data = equipe;
            result.Success = true;
            result.Message = "Equipe encontrada com sucesso!";
        }
        catch (Exception e)
        {
            result.Success = false;
            result.Message = "Erro durante o GetEquipe: " + e.Message;
            Console.WriteLine(e);
            throw;
        }
        
        return result;
    }

    public async Task<ServiceResponse<List<EquipesModel>>> GetEquipesList()
    {
        
        var result = new ServiceResponse<List<EquipesModel>>();

        try
        {
            var equipeList = await _context.Equipes.ToListAsync();

            if (equipeList.Count < 1)
            {
                result.Success = false;
                result.Message = "Lista vazia";
                return result;
            }
            result.Data = equipeList;
            result.Success = true;
            result.Message = "Lista encontrada com sucesso!";
        }
        catch (Exception e)
        {   
            result.Success = false;
            result.Message = "Erro durante o GetEquipeList: " + e.Message;
            Console.WriteLine(e);
            throw;
        }
        return result;
    }

    public async Task<ServiceResponse<string>> AddMember(Guid equipeId, Guid usuarioId)
    {
        var result = new ServiceResponse<string>();
        try
        {
            var equipe = await _context.Equipes
                .Include(e => e.Membros) // Garantir que Membros seja carregado
                .FirstOrDefaultAsync(e => e.Id == equipeId);

            var usuario = await _context.Usuarios.FindAsync(usuarioId);
            if (equipe == null || usuario == null)
            {
                result.Success = false;
                result.Message = "Nenhum equipe ou usuario encontrados";
                return result;
            }
            
            equipe.Membros ??= new List<UsuariosModel>();

            if (equipe.Membros.Any(m => m.Id == usuarioId))
            {
                equipe.Membros.Add(usuario);
                await _context.SaveChangesAsync();
                result.Success = true;
                result.Message = "Usuario adicionado à equipe";
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            result.Success = false;
            result.Message = "Erro ao adicionar usuário à equipe";
        }
        return result;
    }


    public async Task<ServiceResponse<string>> RemoveMember(Guid membroEquipeId)
    {
        var result = new ServiceResponse<string>();
        return result;
    }
}