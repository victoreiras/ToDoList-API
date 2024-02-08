using System.ComponentModel.DataAnnotations;

namespace ToDoList.Application.DTOs;

public record LoginDto
{
    [Required(ErrorMessage = "Campo obrigatório"), EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string Senha { get; set; }
}
