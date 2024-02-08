using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Interfaces;

namespace ToDoList.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ListaController : ControllerBase
{
    private readonly IListaService _listaService;

    public ListaController(IListaService listaService)
    {
        _listaService = listaService;
    }

    [HttpGet(Name = "ObterListasDoUsuario")]
    public async Task<IActionResult> ObterListasDoUsuario(int idUsuario)
    {
        var listas = await _listaService.ObterListasDoUsuarioAsync(idUsuario);
        return Ok(listas);
    }
}