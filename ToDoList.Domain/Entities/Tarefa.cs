namespace ToDoList.Domain.Entities;

public class Tarefa
{
    public Tarefa(string nome)
    {
        Nome = nome;
    }

    public Tarefa(DateTime dataConclusao, string nome) : this(nome)
    {
        DataConclusao = dataConclusao;
    }

    public int Id { get; private set; }
    public string Nome { get; private set; }
    public DateTime DataCriacao { get; private set; } = DateTime.Now;
    public DateTime DataConclusao { get; private set; }
    public bool Concluida { get; private set; } = false;
    public bool Recorrente { get; private set; } = false;
    public Lista Lista { get; private set; }

    public void AlterarNome(string nome)
    {
        Nome = nome;
    }

    public void ConcluirTarefa()
    {
        Concluida = true;

        if (Recorrente)
            DataConclusao = DateTime.Now.AddDays(1);
    }

    public void AdicionarDataConclusao(DateTime dataConclusao)
    {
        if (dataConclusao >= DateTime.Now)
            DataConclusao = dataConclusao;
    }

    public void AdicionarRecorrencia()
    {
        Recorrente = true;
    }

    public void RemoverRecorrencia()
    {
        Recorrente = false;
    }
}