namespace ToDoList.Application.DTOs;

public record ListaDto(
    int Id,
    string Nome,
    List<TarefaDto> Tarefas,
    UsuarioDto UsuarioDto);