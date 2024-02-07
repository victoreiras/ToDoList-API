using System.ComponentModel.DataAnnotations;

namespace ToDoList.Application.DTOs;

public record UsuarioDto
{
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [Compare("Senha", ErrorMessage = "Senhas não coincidem")]
    public string ConfirmaSenha { get; set; }
}
