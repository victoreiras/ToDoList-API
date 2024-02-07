using ToDoList.Domain.Entities;

namespace ToDoList.Teste.Domain;

public class TarefaTeste
{
    [Fact]
    public void ConcluirTarefaTeste()
    {
        //Arrange
        var tarefa = new Tarefa("Nova tarefa");

        //Act
        tarefa.ConcluirTarefa();

        //Assert
        Assert.True(tarefa.Concluida && tarefa.DataConclusao >= DateTime.Now);
    }

    [Fact]
    public void AdicionarDataConclusaoTeste()
    {
        //Arrange
        var tarefa = new Tarefa("Tarefa");
        var dataConclusao = DateTime.Now.AddDays(-5);

        //Act
        tarefa.AdicionarDataConclusao(dataConclusao);

        //Assert
        Assert.True(tarefa.DataConclusao != dataConclusao);
    }

    [Fact]
    public void AdicionarRecorrenciaTeste()
    {
        //Arrange
        var tarefa = new Tarefa("Tarefa");

        //Act
        tarefa.AdicionarRecorrencia();

        //Assert
        Assert.True(tarefa.Recorrente);
    }

    [Fact]
    public void RemoverRecorrencia()
    {
        //Arrange
        var tarefa = new Tarefa("Tarefa");

        //Act
        tarefa.RemoverRecorrencia();

        //Assert
        Assert.False(tarefa.Recorrente);
    }
}
