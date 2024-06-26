using AutoMapper;
using backend.models;
using backend.Services.VacinaServices;
using Microsoft.AspNetCore.Mvc;

namespace backend.controller;

[ApiController]
[Route("api/[controller]")]
public class VacinaController : ControllerBase
{
    private IVacinaService _service;
    private readonly IMapper _mapper;

    public VacinaController(IVacinaService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] VacinaDtoRequest vacinaDtoRequest)
    {
        try
        {
            var vacina = _mapper.Map<Vacina>(vacinaDtoRequest);
            await _service.CriarVacina(vacina);
            return Ok(vacina);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao criar o a vacina: {ex.Message}");
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Vacina>>> GetAll()
    {
        try
        {
            List<Vacina> vacinas = await _service.ObterTodasVacinas();
            return Ok(vacinas);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao obter os postos: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vacina>> ObterPostoPorId(Guid id)
    {
        try
        {
            var posto = await _service.ObterPostoPorId(id);
            return Ok(posto);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao obter o posto: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarVacina(Guid id, [FromBody] string novoNome)
    {
        try
        {
            await _service.AtualizarVacina(id, novoNome);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest($"Erro ao atualizar o posto: {ex.Message}");
        }
    }
}