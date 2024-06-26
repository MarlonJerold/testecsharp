using backend.Dtos;
using backend.Infraestrutura.Security;
using Microsoft.AspNetCore.Mvc;

namespace backend.controller;

[ApiController]
[Route("api/[controller]")]
public class AutenticacaoController : ControllerBase
{

    private readonly ITokenService _tokenService;

    public AutenticacaoController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost]
    public ActionResult Logar(LoginDto login)
    {
        var token = _tokenService.GenerateToken(login);

        if (token == "")
        {
            return Unauthorized();
        }
        return Ok(token);
    }
}
