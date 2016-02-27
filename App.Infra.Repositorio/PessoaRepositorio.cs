using System.Linq;
using App.Dominio.GerenciamentoUsuario.Entidades;
using App.Dominio.GerenciamentoUsuario.Servicos.Repositorio;
using App.Infra.Repositorio.Generico;

namespace App.Infra.Repositorio
{
    public class PessoaRepositorio : RepositorioDados<Pessoa>, IPessoaRepositorio
    {
        public Pessoa BuscarPorEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            return Set.SingleOrDefault(x => x.EmailOpcao1.Equals(email) || x.EmailOpcao2.Equals(email));
        }
    }
}
