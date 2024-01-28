using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Lista> Listas { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
}