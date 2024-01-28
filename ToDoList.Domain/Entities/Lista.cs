namespace ToDoList.Domain.Entities;

public class Lista
{
    public Lista(string nome)
    {
        Nome = nome;
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public DateTime DataCriacao { get; private set; } = DateTime.Now;
    public List<Tarefa> Tarefas { get; private set; } = new List<Tarefa>();

    public void AlterarNome(string nome)
    {
        Nome = nome;
    }
}