using Microsoft.AspNetCore.Mvc;
using pinterestapi.DataContext;
using pinterestapi.Model;
using pinterestapi.Service.Equipes;
using pinterestapi.Service.EquipeService;

namespace pinterestapi.Controller;

[Route("api/[controller]")]
[ApiController]
public class EquipeController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IEquipeService _interface;

    public EquipeController(ApplicationDbContext context, IEquipeService service)
    {
        _context = context;
        _interface = service;
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEquipe(Guid id)
    {
        var response = await _interface.GetEquipe(id);
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _interface.GetEquipesList();
        return response.Success ? Ok(response) : NotFound(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEquipe(EquipesModel equipe)
    {
        var response = await _interface.CreateEquipe(equipe);
        return response.Success ? Ok(response) : NotFound(response);
    }
    
    [HttpPost("addmember")]
    public async Task<IActionResult> AddMember(Guid equipeId, Guid usuarioId){
        var response = await _interface.AddMember(equipeId, usuarioId);
        return response.Success ? Ok(response) : NotFound(response);
    }
    
    [HttpDelete("removemember")]
    public async Task<IActionResult> RemoveMember(Guid membroEquipeId){
        var response = await _interface.RemoveMember(membroEquipeId);
        return response.Success ? Ok(response) : NotFound(response);
    }
}