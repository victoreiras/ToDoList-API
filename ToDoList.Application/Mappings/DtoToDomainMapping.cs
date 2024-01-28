using AutoMapper;
using ToDoList.Application.DTOs;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Mappings;

public class DtoToDomainMapping : Profile
{
    public DtoToDomainMapping()
    {
        CreateMap<ListaDto, Lista>();
    }
}