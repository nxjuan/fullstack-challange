using Microsoft.AspNetCore.Mvc;
using pinterestapi.Config.DTOs.Post;
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
    public async Task<IActionResult> CreateEquipe(EquipeDTO equipe)
    {
        var response = await _interface.CreateEquipe(equipe);
        return response.Success ? Ok(response) : BadRequest(response);
    }
    
    [HttpPost("addmember")]
    public async Task<IActionResult> AddMember([FromBody] MembroEquipe request)
    {
        if (request == null || request.EquipeId == Guid.Empty || request.MembroId == Guid.Empty)
            return BadRequest($"Dados inválidos. Equipe: {request.EquipeId}, Membro: {request.MembroId}");

        var response = await _interface.AddMember(request.EquipeId, request.MembroId);
        return response.Success ? Ok(response) : BadRequest(response);
    }
    
    [HttpDelete("removemember")]
    public async Task<IActionResult> RemoveMember(Guid membroEquipeId){
        var response = await _interface.RemoveMember(membroEquipeId);
        return response.Success ? Ok(response) : BadRequest(response);
    }
}