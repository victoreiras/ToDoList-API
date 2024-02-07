namespace ToDoList.Application.Interfaces;

public interface ISenhaService
{
    void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
}
