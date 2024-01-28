using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Interfaces;

namespace ToDoList.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ListaController : ControllerBase
{
    private readonly IListaService _listaService;

    public ListaController(IListaService listaService)
    {
        _listaService = listaService;
    }

    [HttpGet(Name = "ObterListasDoUsuario")]
    public IActionResult ObterListasDoUsuario(int idUsuario)
    {
        var listas = _listaService.ObterListasDoUsuario(idUsuario);
        return Ok(listas);
    }
}