
using Microsoft.EntityFrameworkCore;
using pinterestapi.DataContext;
using pinterestapi.Model;

namespace pinterestapi.Service.ProjetoService;

public class ProjetoService : IProjetoService
{
    private readonly ApplicationDbContext _context;

    public ProjetoService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<ServiceResponse<string>> CreateProjeto(ProjetosModel projetoModel)
    {
        var response = new ServiceResponse<string>();
        try
        {
            await _context.Projetos.AddAsync(projetoModel);
            await _context.SaveChangesAsync();
            
            response.Data = projetoModel.Id.ToString();
            response.Success = true;
            response.Message = "Projeto Cadastrado com sucesso!";
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = "Erro ao criar projeto" + e.Message;
            Console.WriteLine(e);
            throw;
        }
        return response;
    }

    public async Task<ServiceResponse<string>> GetProjeto(Guid Id)
    {
        var response = new ServiceResponse<string>();
        try
        {
            var projeto = await _context.Projetos.FindAsync(Id);
            if (projeto == null)
            {
                response.Success = false;
                response.Message = "Projeto não encontrado";
                return response;
            }
            response.Data = projeto.Id.ToString();
            response.Success = true;
            response.Message = "Projeto Encontrado com sucesso!";
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = "Erro ao encontrar projeto" + e.Message;
            Console.WriteLine(e);
            throw;
        }
        return response;
    }

    public Task<ServiceResponse<string>> UpdateProjeto(ProjetosModel projetoModel, Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<string>> DeleteProjeto(Guid Id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<List<ProjetosModel>>> GetProjetosList()
    {
        var response = new ServiceResponse<List<ProjetosModel>>();
        try
        {
            var projetosList = await _context.Projetos.ToListAsync();
            if (projetosList.Count == 0)
            {
                response.Success = false;
                response.Message = "A lista está vazia!";
                return response;
            }
            response.Data = projetosList;
            response.Success = true;
            response.Message = "Lista de projetos encontrada com sucesso!";
        }
        catch (Exception e)
        {
            response.Success = false;
            response.Message = "Erro ao buscar projetos" + e.Message;
            Console.WriteLine(e);
            throw;
        }
        return response;
    }
}