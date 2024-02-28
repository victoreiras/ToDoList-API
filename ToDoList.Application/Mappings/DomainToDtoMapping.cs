using AutoMapper;
using ToDoList.Application.DTOs;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Mappings;

public class DomainToDtoMapping : Profile
{
    public DomainToDtoMapping()
    {
        CreateMap<Lista, ListaDto>();
        CreateMap<Tarefa, TarefaDto>();
    }
}