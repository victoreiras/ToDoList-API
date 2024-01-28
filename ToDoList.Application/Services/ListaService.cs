using ToDoList.Application.DTOs;
using ToDoList.Domain.interfaces;
using ToDoList.Application.Interfaces;
using AutoMapper;

namespace ToDoList.Application.Services;

public class ListaService : IListaService
{
    private readonly IMapper _mapper;
    private readonly IListaRepository _listaRepository;

    public ListaService(IMapper mapper, IListaRepository listaRepository)
    {
        _mapper = mapper;
        _listaRepository = listaRepository;
    }

    public List<ListaDto> ObterListasDoUsuario(int idUsuario)
    {
        var listas = _listaRepository.ObterListasDoUsuario(idUsuario);
        return _mapper.Map<List<ListaDto>>(listas);
    }
}