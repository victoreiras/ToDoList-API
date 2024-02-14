using System.ComponentModel.DataAnnotations;

namespace ToDoList.Application.DTOs;

public record TarefaDto
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string Nome { get; set; }

    public DateTime? DataConclusao { get; set; }
}