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

    public async Task<List<ListaDto>> ObterListasDoUsuarioAsync(int idUsuario)
    {
        var listasCache = await _cacheRepository.GetAsync<List<Lista>>(idUsuario.ToString());

        if (listasCache != null)
            return _mapper.Map<List<ListaDto>>(listasCache);

        var listasSql = await _listaRepository.ObterListasDoUsuarioAsync(idUsuario);
        return _mapper.Map<List<ListaDto>>(listasSql);
    }
}