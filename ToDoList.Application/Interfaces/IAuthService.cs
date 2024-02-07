using ToDoList.Application.DTOs;

namespace ToDoList.Application.Interfaces;

public interface IAuthService
{
    Task<ServiceResponse<UsuarioDto>> Registrar(UsuarioDto usuarioDto);
}
