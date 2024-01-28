using ToDoList.Application.DTOs;

namespace ToDoList.Application.Interfaces;

public interface IListaService
{
    List<ListaDto> ObterListasDoUsuario(int idUsuario);
    // Lista ObterListaPorId(int id);
    // void Criar(Lista lista);
    // void Atualizar(Lista lista);
    // void Remover(Lista lista);
}