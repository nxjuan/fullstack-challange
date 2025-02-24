using pinterestapi.Config.DTOs.Post;
using pinterestapi.Model;

namespace pinterestapi.Service.TarefaService;

public interface ITarefaService
{
   Task<ServiceResponse<string>> CreateTarefa(TarefaDTO tarefaDto); 
   Task<ServiceResponse<string>> UpdateTarefa(TarefasModel tarefa, Guid id);
   Task<ServiceResponse<string>> DeleteTarefa(Guid id);
   Task<ServiceResponse<TarefasModel>> GetTarefa(Guid id);
   Task<ServiceResponse<List<TarefasModel>>> GetTarefasList();
}