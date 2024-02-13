using ToDoList.Application.DTOs;

namespace ToDoList.Application.Interfaces;

public interface IListaService
{
    Task<ServiceResponse<List<ListaDto>>> ObterListasDoUsuarioAsync(int idUsuario);
    // Lista ObterListaPorId(int id);
    Task<ServiceResponse<ListaDto>> CriarListaAsync(string nome);
    Task<ServiceResponse<ListaDto>> EditarListaAsync(ListaDto lista);
    Task<ServiceResponse<bool>> ExcluirListaAsync(int idLista);
}