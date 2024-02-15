namespace ToDoList.Domain.Entities;

public class Usuario
{
    public Usuario(string nome, string email, byte[] senhaHash, byte[] senhaSalt)
    {
        Nome = nome;
        Email = email;
        SenhaHash = senhaHash;
        SenhaSalt = senhaSalt;
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public byte[] SenhaHash { get; private set; }
    public byte[] SenhaSalt { get; private set; }
    public DateTime TokenDataCriacao { get; private set; } = DateTime.Now;
    public List<Lista> Listas { get; private set; } = new List<Lista>();
}
