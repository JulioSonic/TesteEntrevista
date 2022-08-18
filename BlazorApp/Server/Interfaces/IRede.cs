using BlazorApp.Shared.Models;

namespace BlazorApp.Server.Interfaces
{
    public interface IRede
    {
        public List<Rede> ListaRedes();

        public void AdicionaRede(Rede rede);

        public void AtualizaRede(Rede rede);

        public Rede RetornaRedePorId(int id);

        public void DeletaRede(int id);
    }
}
