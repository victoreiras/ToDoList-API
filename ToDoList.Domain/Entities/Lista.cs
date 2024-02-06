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

    public void AdicionarTarefa(Tarefa tarefa)
    {
        Tarefas.Add(tarefa);
    }

    public void AlterarNome(string nome)
    {
        Nome = nome;
    }

    public int ObterQuantidadeTarefasConcluidas()
    {
        return Tarefas.Count(t => t.Concluida == true);
    }

    public int ObterQuantidadeTarefasNaoConcluidas()
    {
        return Tarefas.Count(t => t.Concluida == false);
    }
}