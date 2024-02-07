using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;
using ToDoList.Infrastructure.Data;

namespace ToDoList.Infrastructure.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _db;

    public UsuarioRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Usuario> ObterUsuarioPorEmail(string email)
    {
        return await _db.Usuarios.FirstOrDefaultAsync(q => q.Email == email);
    }

    public async Task Registrar(Usuario usuario)
    {
        _db.Add(usuario);
        await _db.SaveChangesAsync();
    }
}
