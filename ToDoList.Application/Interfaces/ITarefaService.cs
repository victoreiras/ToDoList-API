using ToDoList.Application.DTOs;

namespace ToDoList.Application.Interfaces;

public interface ITarefaService
{
    Task<ServiceResponse<TarefaDto>> CriarTarefaAsync(TarefaDto tarefaDto);
    Task<ServiceResponse<TarefaDto>> ConcluirTarefaAsync(int idTarefa);
    Task<ServiceResponse<TarefaDto>> EditarTarefaAsync(TarefaDto tarefaDto);
    Task<ServiceResponse<bool>> ExcluirTarefaAsync(int idTarefa);
}