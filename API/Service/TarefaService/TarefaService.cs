

using Microsoft.EntityFrameworkCore;
using pinterestapi.Config.DTOs.Post;
using pinterestapi.DataContext;
using pinterestapi.Model;

namespace pinterestapi.Service.TarefaService;

public class TarefaService : ITarefaService
{
    private readonly ApplicationDbContext _context;

    public TarefaService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<ServiceResponse<string>> CreateTarefa(TarefaDTO tarefaDto)
    {
        var response = new ServiceResponse<string>();
        try
        {
            TarefasModel newTarefa = new TarefasModel();
            newTarefa.Nome = tarefaDto.Nome;
            newTarefa.Descricao = tarefaDto.Descricao;
            newTarefa.ResponsavelId = tarefaDto.ResponsavelId;
            newTarefa.Status = tarefaDto.Status;
            newTarefa.ProjetoId = tarefaDto.ProjetoId;
            
            await _context.Tarefas.AddAsync(newTarefa);
            await _context.SaveChangesAsync();
            
            response.Data = newTarefa.Id.ToString();
            response.Message = "Tarefa cadastrada com sucesso!";
            response.Success = true;
        }
        catch (Exception e)
        {
            response.Message = "Erro ao cadastrar Tarefa: " + e.Message;
            response.Success = false;
            Console.WriteLine(e);
        }
        return response;
    }

    public Task<ServiceResponse<string>> UpdateTarefa(TarefasModel tarefa, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<string>> DeleteTarefa(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<TarefasModel>> GetTarefa(Guid id)
    {
        var response = new ServiceResponse<TarefasModel>();
        try
        {
            var result = await _context.Tarefas.FindAsync(id);
            if (result == null)
            {
                response.Success = false;
                response.Message = "Tarefa não encontrada";
                return response;
            }
            response.Data = result;
            response.Message = "Tarefa encontrada com sucesso!";
            response.Success = true;
        }
        catch (Exception e)
        {
            response.Message = "Erro ao buscar tarefa: " + e.Message;
            response.Success = false;
            Console.WriteLine(e);
            throw;
        }
        return response;
    }

    public async Task<ServiceResponse<List<TarefasModel>>> GetTarefasList()
    {
        var response = new ServiceResponse<List<TarefasModel>>();
        try
        {
            var tarefasList = await _context.Tarefas.ToListAsync();
            if (tarefasList == null)
            {
                response.Success = false;
                response.Message = "Lista vazia";
                return response;
            }
            response.Data = tarefasList;
            response.Message = "Lista de tarefas com sucesso!";
            response.Success = true;
        }
        catch (Exception e)
        {
            response.Message = "Erro ao buscar tarefas: " + e.Message;
            response.Success = false;
            Console.WriteLine(e);
            throw;
        }
        return response;
    }
}