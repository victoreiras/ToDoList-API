using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTOs;
using ToDoList.Application.Interfaces;

namespace ToDoList.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefaController : ControllerBase
{
    private readonly ITarefaService _tarefaService;

    public TarefaController(ITarefaService tarefaService)
    {
        _tarefaService = tarefaService;
    }

    [HttpPost(Name = "criarTarefa")]
    public async Task<IActionResult> CriarTarefa(TarefaDto tarefaDto)
    {
        var tarefaCriada = await _tarefaService.CriarTarefaAsync(tarefaDto);
        return Ok(tarefaCriada);
    }

    [HttpPut(Name = "concluirTarefa")]
    public async Task<IActionResult> ConcluirTarefa(int idTarefa)
    {
        var tarefaConcluida = await _tarefaService.ConcluirTarefaAsync(idTarefa);
        return Ok(tarefaConcluida);
    }

    [HttpPut(Name = "editarTarefa")]
    public async Task<IActionResult> EditarTarefa(TarefaDto tarefaDto)
    {
        var tarefaEditada = await _tarefaService.EditarTarefaAsync(tarefaDto);
        return Ok(tarefaEditada);
    }

    [HttpDelete(Name = "excluirTarefa")]
    public async Task<IActionResult> ExcluirTarefa(int idTarefa)
    {
        await _tarefaService.ExcluirTarefaAsync(idTarefa);
        return Ok();
    }
}