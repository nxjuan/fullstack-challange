using Microsoft.AspNetCore.Mvc;
using pinterestapi.Model;
using pinterestapi.Service.UsuarioService;

namespace pinterestapi.Controller;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUsuario(UsuariosModel usuarioModel)
    {
        var resp = await _usuarioService.CreateUsuario(usuarioModel);
        return resp.Success ? Ok(resp) : BadRequest(resp);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUsuarios(Guid id)
    {
        var resp = await _usuarioService.GetUsuario(id);
        return resp.Success ? Ok(resp) : NotFound(resp);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var resp = await _usuarioService.GetUsuariosList();
            return resp.Success ? Ok(resp) : NotFound(resp);
    }
}