using BlazorApp.Server.Interfaces;
using BlazorApp.Server.Models;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Services
{
    public class UsuarioService : IUsuario
    {
        readonly DatabaseContext _dbContext = new();

        public UsuarioService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Retorna detalhe com todos os usuários 
        public List<Usuario> ListaUsuarios()
        {
            try
            {
                return _dbContext.Usuario.ToList();
            }
            catch
            {
                throw;
            }
        }

        //Adicionar um novo registro de usuário   
        public void AdicionaUsuario(Usuario user)
        {
            try
            {
                _dbContext.Usuario.Add(user);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Atualiza usuário em particular   
        public void AtualizaUsuario(Usuario user)
        {
            try
            {
                _dbContext.Entry(user).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Retorna Usuário por ID 
        public Usuario RetornaUsuarioPorId(int id)
        {
            try
            {
                Usuario? user = _dbContext.Usuario.Find(id);

                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        //Deleta usuário por ID   
        public void DeletaUsuario(int id)
        {
            try
            {
                Usuario? user = _dbContext.Usuario.Find(id);

                if (user != null)
                {
                    _dbContext.Usuario.Remove(user);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}