using ToDoList.Application.DTOs;

namespace ToDoList.Application.Interfaces;

public interface IListaService
{
    Task<ServiceResponse<List<ListaDto>>> ObterListasDoUsuarioAsync(int idUsuario);
    // Lista ObterListaPorId(int id);
    // void Criar(Lista lista);
    // void Atualizar(Lista lista);
    // void Remover(Lista lista);
}