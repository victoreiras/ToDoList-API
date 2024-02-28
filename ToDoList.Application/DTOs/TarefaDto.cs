namespace ToDoList.Application.DTOs;

public record TarefaDto(
    int Id,
    string Nome,
    DateTime? DataConclusao);