using ToDoList.Application.DTOs;
using ToDoList.Domain.interfaces;
using ToDoList.Application.Interfaces;
using AutoMapper;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Services;

public class ListaService : IListaService
{
    private readonly IMapper _mapper;
    private readonly IListaRepository _listaRepository;
    private readonly ICacheRepository _cacheRepository;

    public ListaService(IMapper mapper, IListaRepository listaRepository, ICacheRepository cacheRepository)
    {
        _mapper = mapper;
        _listaRepository = listaRepository;
        _cacheRepository = cacheRepository;
    }

    public async Task<ServiceResponse<List<ListaDto>>> ObterListasDoUsuarioAsync(int idUsuario)
    {
        var serviceResponse = new ServiceResponse<List<ListaDto>>();

        try
        {
            var resultado = await _cacheRepository.GetAsync<List<Lista>>(idUsuario.ToString());

            if (resultado is null)
                resultado = await _listaRepository.ObterListasDoUsuarioAsync(idUsuario);

            serviceResponse.Dados = _mapper.Map<List<ListaDto>>(resultado);
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }
}