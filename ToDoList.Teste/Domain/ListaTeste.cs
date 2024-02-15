using ToDoList.Domain.Entities;
using Xunit;

namespace ToDoList.Teste.Domain;

public class ListaTeste
{
    private readonly Lista _lista;

    public ListaTeste()
    {
        //Arrange
        var senhaHash = System.Text.Encoding.UTF8.GetBytes("senhaHash");
        var senhaSalt = System.Text.Encoding.UTF8.GetBytes("senhaSalt");
        var usuario = new Usuario("Victor", "victor.eiras@gmail.com", senhaHash, senhaSalt);
        _lista = new Lista("Lista Teste", usuario);
        _lista.AdicionarTarefa(new Tarefa("Tarefa 1"));
        _lista.AdicionarTarefa(new Tarefa("Tarefa 2"));
        _lista.AdicionarTarefa(new Tarefa("Tarefa 3"));
        _lista.Tarefas[0].ConcluirTarefa();
        _lista.Tarefas[1].ConcluirTarefa();
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