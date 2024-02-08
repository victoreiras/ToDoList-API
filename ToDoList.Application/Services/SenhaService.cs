using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace ToDoList.Application.Services;

public class SenhaService : ISenhaService
{
    private readonly IConfiguration _config;

    public SenhaService(IConfiguration config)
    {
        _config = config;
    }

    public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            senhaSalt = hmac.Key;
            senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
        }
    }

    public string GerarToken(Usuario usuario)
    {
        //Clainms são as informações do PAYLOAD do JWT
        List<Claim> claims = new List<Claim>()
        {
            new Claim("Nome", usuario.Nome),
            new Claim("Email", usuario.Email)
        };

        //Criação da chave -> Vai pro App.Settings, "igual ao senhaSalt"
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

        //Criação da credencial
        var credencial = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //Criação do Token JWT
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credencial
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;

    }

    public bool VerificaSenhaHashValida(string senha, byte[] senhaHash, byte[] senhaSalt)
    {
        using (var hmac = new HMACSHA512(senhaSalt))
        {
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            return computeHash.SequenceEqual(senhaHash);
        }
    }


}
