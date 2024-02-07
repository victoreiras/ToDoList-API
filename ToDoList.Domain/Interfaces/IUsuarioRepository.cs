using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task Registrar(Usuario usuario);
    Task<Usuario> ObterUsuarioPorEmail(string email);
}
