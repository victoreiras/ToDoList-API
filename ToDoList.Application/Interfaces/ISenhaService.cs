using ToDoList.Domain.Entities;

namespace ToDoList.Application.Interfaces;

public interface ISenhaService
{
    void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
    bool VerificaSenhaHashValida(string senha, byte[] senhaHash, byte[] senhaSalt);
    string GerarToken(Usuario usuario);
}
