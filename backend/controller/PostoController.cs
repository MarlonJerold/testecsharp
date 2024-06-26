using backend.Data;
using backend.Dtos;
using backend.models;
using backend.Repositorio;
using backend.Services.PostoServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.controller;

[ApiController]
[Route("api/[controller]")]
public class PostoController : ControllerBase
{
    private IPostoService _service;
    

    public PostoController(IPostoService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddPosto([FromBody] PostoDtoRequest novoPosto)
    {
        try
        {
            _ = _service.CriarPosto(novoPosto);
            return Ok(novoPosto);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao criar o posto: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<Posto>>> ObterTodosOsPostos()
    {
        try
        {
            List<Posto> postos = await _service.ObterTodosOsPostos();
            return Ok(postos);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao obter os postos: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Posto>> ObterPostoPorId(Guid id)
    {
        try
        {
            var posto = await _service.ObterPostoPorId(id);
            if (posto == null)
                return NotFound($"Posto com ID {id} não encontrado");

            return Ok(posto);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao obter o posto: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarPosto(Guid id, [FromBody] string novoNome)
    {
        try
        {
            await _service.AtualizarPosto(id, novoNome);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao atualizar o posto: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePostoAsync(Guid id)
    {
        try
        {
            await _service.DeletePostoAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao deletar o posto: {ex.Message}");
        }
    }

}
