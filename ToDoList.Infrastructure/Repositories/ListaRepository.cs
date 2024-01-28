using ToDoList.Domain.Entities;
using ToDoList.Domain.interfaces;

namespace ToDoList.Infrastructure.Repositories;

public class ListaRepository : IListaRepository
{
    public void Atualizar(Lista lista)
    {
        throw new NotImplementedException();
    }

    public void Criar(Lista lista)
    {
        throw new NotImplementedException();
    }

    public Lista ObterListaPorId(int id)
    {
        throw new NotImplementedException();
    }

    public List<Lista> ObterListasDoUsuario(int idUsuario)
    {
        throw new NotImplementedException();
    }

    public void Remover(Lista lista)
    {
        throw new NotImplementedException();
    }
}