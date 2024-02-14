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

    public TarefaService(ITarefaRepository tarefaRepository, IMapper mapper)
    {
        _tarefaRepository = tarefaRepository;
        _mapper = mapper;
    }

    public Task<ServiceResponse<TarefaDto>> ConcluirTarefaAsync(int idTarefa)
    {
        throw new NotImplementedException();
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

    public Task<ServiceResponse<TarefaDto>> EditarTarefaAsync(TarefaDto tarefaDto)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<bool>> ExcluirTarefaAsync(int idTarefa)
    {
        throw new NotImplementedException();
    }
}