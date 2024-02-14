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
}