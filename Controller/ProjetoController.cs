using Microsoft.AspNetCore.Mvc;
using pinterestapi.Config.DTOs.Post;
using pinterestapi.DataContext;
using pinterestapi.Model;
using pinterestapi.Service.ProjetoService;

namespace pinterestapi.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProjetoController : ControllerBase
{
    private readonly IProjetoService _projetoService;
    private readonly ApplicationDbContext _context;

    public ProjetoController(IProjetoService projetoService, ApplicationDbContext context)
    {
        _projetoService = projetoService;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetProjetosList()
    {
        var result = await _projetoService.GetProjetosList();
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjeto(Guid Id)
    {
        var result = await _projetoService.GetProjeto(Id);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProjeto(ProjetoDTO projeto)
    {
        var result = await _projetoService.CreateProjeto(projeto);
        return result.Success ? Ok(result) : BadRequest(result);
    }
    
}