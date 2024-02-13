using ToDoList.Application.DTOs;
using ToDoList.Domain.interfaces;
using ToDoList.Application.Interfaces;
using AutoMapper;
using ToDoList.Domain.Entities;
using System.Net;

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

    public async Task<ServiceResponse<ListaDto>> CriarListaAsync(string nome)
    {
        var serviceResponse = new ServiceResponse<ListaDto>();

        try
        {
            if (string.IsNullOrEmpty(nome))
            {
                serviceResponse.Mensagem = "Nome não pode ser nulo ou vazio.";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            var lista = new Lista(nome);
            await _listaRepository.CriarAsync(lista);
            await _cacheRepository.SetAsync($"{lista.Id}", lista);

            serviceResponse.Dados = _mapper.Map<ListaDto>(lista);
            serviceResponse.Mensagem = "Lista criada com sucesso!";
        }
        catch (Exception ex)
        {
            serviceResponse.Dados = null;
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<ListaDto>> EditarListaAsync(ListaDto listaDto)
    {
        var serviceResponse = new ServiceResponse<ListaDto>();

        try
        {
            if (listaDto is null)
            {
                serviceResponse.Mensagem = "Lista não pode ser nula.";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            var lista = _mapper.Map<Lista>(listaDto);
            await _listaRepository.AtualizarAsync(lista);
            await _cacheRepository.SetAsync($"{lista.Id}", lista);

            serviceResponse.Dados = listaDto;
            serviceResponse.Mensagem = "Lista atualizada com sucesso!";
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<bool>> ExcluirListaAsync(int idLista)
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            var lista = await _listaRepository.ObterListaPorIdAsync(idLista);

            if (lista is null)
            {
                serviceResponse.Mensagem = "Lista inválida!";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            await _listaRepository.RemoverAsync(lista);
            //await _cacheRepository.remover();

            serviceResponse.Mensagem = "Lista excluída com sucesso!";
        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
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