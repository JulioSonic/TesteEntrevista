using BlazorApp.Shared.Models;

namespace BlazorApp.Server.Interfaces
{
    public interface IUsuario
    {
        public List<Usuario> ListaUsuarios();

        public void AdicionaUsuario(Usuario user);

        public void AtualizaUsuario(Usuario user);

        public Usuario RetornaUsuarioPorId(int id);

        public void DeletaUsuario(int id);
    }
}
