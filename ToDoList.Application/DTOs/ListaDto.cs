using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Application.DTOs;

public record ListaDto
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo é obrigatório!")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Nome da lista")]
    public string Nome { get; set; }
}