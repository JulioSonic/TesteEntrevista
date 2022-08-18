using BlazorApp.Server.Interfaces;
using BlazorApp.Server.Models;
using BlazorApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Services
{
    public class RedeService : IRede
    {
        readonly DatabaseContext _dbContext = new();

        public RedeService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Retorna lista com todas as redes  
        public List<Rede> ListaRedes()
        {
            try
            {
                return _dbContext.Rede.ToList();
            }
            catch
            {
                throw;
            }
        }

        //Adiciona uma nova rede    
        public void AdicionaRede(Rede rede)
        {
            try
            {
                _dbContext.Rede.Add(rede);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Atualiza rede especifica   
        public void AtualizaRede(Rede rede)
        {
            try
            {
                _dbContext.Entry(rede).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //retorna os detalhes de uma rede por id  
        public Rede RetornaRedePorId(int id)
        {
            try
            {
                Rede? rede = _dbContext.Rede.Find(id);

                if (rede != null)
                {
                    return rede;
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

        //Deleta rede 
        public void DeletaRede(int id)
        {
            try
            {
                Rede? rede = _dbContext.Rede.Find(id);

                if (rede != null)
                {
                    _dbContext.Rede.Remove(rede);
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