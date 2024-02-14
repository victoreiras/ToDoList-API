using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs;
using ToDoList.Application.Interfaces;

namespace ToDoList.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ListaController : ControllerBase
{
    private readonly IListaService _listaService;

    public ListaController(IListaService listaService)
    {
        _listaService = listaService;
    }

    [HttpGet(Name = "obterListasDoUsuario")]
    public async Task<IActionResult> ObterListasDoUsuarioAsync(int idUsuario)
    {
        var listas = await _listaService.ObterListasDoUsuarioAsync(idUsuario);
        return Ok(listas);
    }

    [HttpPost(Name = "criarLista")]
    public async Task<IActionResult> CriarListaAsync(string nome)
    {
        var listaCriada = await _listaService.CriarListaAsync(nome);
        return Ok(listaCriada);
    }

    [HttpPut(Name = "editarLista")]
    public async Task<IActionResult> EditarListaAsync(ListaDto lista)
    {
        var listaEditada = await _listaService.EditarListaAsync(lista);
        return Ok(listaEditada);
    }

    [HttpDelete(Name = "excluirLista")]
    public async Task<IActionResult> ExcluirListaAsync(int idLista)
    {
        await _listaService.ExcluirListaAsync(idLista);
        return Ok();
    }
}