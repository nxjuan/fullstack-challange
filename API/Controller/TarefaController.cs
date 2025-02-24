using Microsoft.AspNetCore.Mvc;
using pinterestapi.Config.DTOs.Post;
using pinterestapi.DataContext;
using pinterestapi.Model;
using pinterestapi.Service.TarefaService;

namespace pinterestapi.Controller;

[ApiController]
[Route("api/[controller]")]
public class TarefaController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ITarefaService _tarefaService;

    public TarefaController(ApplicationDbContext context, ITarefaService tarefaservice)
    {
        _context = context;
        _tarefaService = tarefaservice;
    }

    [HttpGet]
    public async Task<IActionResult> GetTarefasList()
    {
        var result = await _tarefaService.GetTarefasList();
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTarefa(Guid id)
    {
        var result = await _tarefaService.GetTarefa(id);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTarefa(TarefaDTO dto)
    {
        var result = await _tarefaService.CreateTarefa(dto);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}