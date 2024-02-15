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

    public async Task<ServiceResponse<ListaDto>> CriarListaAsync(ListaDto listaDto)
    {
        var serviceResponse = new ServiceResponse<ListaDto>();

        try
        {
            if ((listaDto is null))
            {
                serviceResponse.Mensagem = "Nome não pode ser nulo ou vazio.";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            var usuario = _mapper.Map<Usuario>(listaDto.UsuarioDto);
            var lista = new Lista(listaDto.Nome, usuario);

            await _listaRepository.CriarAsync(lista);
            _cacheRepository.SetAsync($"usuarioListas:{lista.Usuario.Id}", lista);

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
            _cacheRepository.RemoveAsync($"usuarioListas:{lista.Usuario.Id}");

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

            //await _tarefaRepository.ExcluirTarefaAsync()
            await _listaRepository.RemoverAsync(lista);
            _cacheRepository.RemoveAsync($"usuarioListas:{lista.Usuario.Id}");

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
            var resultado = await _cacheRepository.GetAsync<List<Lista>>($"usuarioListas:{idUsuario}");

            if (resultado is null)
            {
                resultado = await _listaRepository.ObterListasDoUsuarioAsync(idUsuario);
                _cacheRepository.SetAsync($"usuarioListas:{idUsuario}", resultado);
            }

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