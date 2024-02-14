using AutoMapper;
using ToDoList.Application.DTOs;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Domain.interfaces;

namespace ToDoList.Application.Services;

public class TarefaService : ITarefaService
{
    private readonly ITarefaRepository _tarefaRepository;
    private readonly IMapper _mapper;
    private readonly ICacheRepository _cacheRepository;

    public TarefaService(ITarefaRepository tarefaRepository, IMapper mapper, ICacheRepository cacheRepository)
    {
        _tarefaRepository = tarefaRepository;
        _mapper = mapper;
        _cacheRepository = cacheRepository;
    }

    public async Task<ServiceResponse<TarefaDto>> ConcluirTarefaAsync(int idTarefa)
    {
        var serviceResponse = new ServiceResponse<TarefaDto>();

        try
        {
            var tarefa = await _tarefaRepository.ObterTarefaPorIdAsync(idTarefa);

            if (tarefa is null)
            {
                serviceResponse.Mensagem = "Não existe Tarefa com esse Id";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            tarefa.ConcluirTarefa();
            await _tarefaRepository.AtualizarAsync(tarefa);
            //await _cacheRepository.SetAsync($"{tarefa.Id}", tarefa);

            serviceResponse.Dados = _mapper.Map<TarefaDto>(tarefa);
            serviceResponse.Mensagem = "Tarefa criada com sucesso";
        }
        catch (Exception ex)
        {
            serviceResponse.Dados = null;
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<TarefaDto>> CriarTarefaAsync(TarefaDto tarefaDto)
    {
        var serviceResponse = new ServiceResponse<TarefaDto>();

        try
        {
            if (tarefaDto is null)
            {
                serviceResponse.Mensagem = "Parâmetros inválidos";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            var tarefa = _mapper.Map<Tarefa>(tarefaDto);
            await _tarefaRepository.CriarAsync(tarefa);

            serviceResponse.Dados = tarefaDto;
            serviceResponse.Mensagem = "Tarefa criada com sucesso";
        }
        catch (Exception ex)
        {
            serviceResponse.Dados = null;
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<TarefaDto>> EditarTarefaAsync(TarefaDto tarefaDto)
    {
        var serviceResponse = new ServiceResponse<TarefaDto>();

        try
        {
            if (tarefaDto is null)
            {
                serviceResponse.Mensagem = "Parâmetros inválidos";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            var tarefa = _mapper.Map<Tarefa>(tarefaDto);
            await _tarefaRepository.AtualizarAsync(tarefa);

            serviceResponse.Dados = tarefaDto;
            serviceResponse.Mensagem = "Tarefa criada com sucesso";
        }
        catch (Exception ex)
        {
            serviceResponse.Dados = null;
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<bool>> ExcluirTarefaAsync(int idTarefa)
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            var tarefa = await _tarefaRepository.ObterTarefaPorIdAsync(idTarefa);

            if (tarefa is null)
            {
                serviceResponse.Mensagem = "Não existe Tarefa com esse Id";
                serviceResponse.Sucesso = false;
                return serviceResponse;
            }

            await _tarefaRepository.ExcluirTarefaAsync(tarefa);

            serviceResponse.Dados = true;
            serviceResponse.Mensagem = "Tarefa criada com sucesso";
        }
        catch (Exception ex)
        {
            serviceResponse.Dados = false;
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }

        return serviceResponse;
    }
}