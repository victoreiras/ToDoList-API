namespace ToDoList.Application.DTOs;

public record UsuarioDto(
    string Nome,
    string Email,
    string Senha,
    string ConfirmaSenha);