using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs;
using ToDoList.Application.Interfaces;

namespace ToDoList.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("registrar")]
    public async Task<ActionResult> Registrar(UsuarioDto usuarioDto)
    {
        var usuarioRegistrado = await _authService.Registrar(usuarioDto);
        return Ok(usuarioRegistrado);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(LoginDto loginDto)
    {
        var usuarioLogado = await _authService.Login(loginDto);
        return Ok(usuarioLogado);
    }
}
