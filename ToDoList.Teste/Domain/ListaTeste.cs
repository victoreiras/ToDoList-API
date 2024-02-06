using ToDoList.Domain.Entities;
using Xunit;

namespace ToDoList.Teste.Domain;

public class ListaTeste
{
    private readonly Lista _lista;

    public ListaTeste()
    {
        //Arrange
        _lista = new Lista("Lista Teste");
        var tarefas = new List<Tarefa>
        {
            new Tarefa("Tarefa 1"),
            new Tarefa("Tarefa 2"),
            new Tarefa("Tarefa 3")
        };

        tarefas[0].ConcluirTarefa();
        tarefas[1].ConcluirTarefa();
    }

    [Fact]
    public void ObterQuantidadeTarefasConcluidasDaLista_Retorna2()
    {
        //Act
        var quantidadeTarefasConcluidas = _lista.ObterQuantidadeTarefasConcluidas();

        //Assert
        Assert.Equal(2, quantidadeTarefasConcluidas);
    }

    [Fact]
    public void ObterQuantidadeTarefasNaoConcluidasDaLista_Retorna1()
    {
        //Act
        var quantidadeTarefasNaoConcluidas = _lista.ObterQuantidadeTarefasNaoConcluidas();

        //Assert
        Assert.Equal(1, quantidadeTarefasNaoConcluidas);
    }

    [Fact]
    public void AlterarNomeDaLista()
    {
        //Arrange
        var novoNome = "Nova Lista";

        //Act
        _lista.AlterarNome(novoNome);

        //Assert
        Assert.Equal(novoNome, _lista.Nome);
    }
}