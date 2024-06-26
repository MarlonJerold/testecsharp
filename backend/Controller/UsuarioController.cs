using backend.models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.controller;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    public readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddUsuario(Usuario usuario)
    {
        await _usuarioService.Add(usuario);
        return Ok("Usuário adicionado com sucesso!");
    }
}
