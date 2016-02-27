using App.Dominio.GerenciamentoUsuario.Entidades;
using App.Dominio.Repositorio;

namespace App.Dominio.GerenciamentoUsuario.Servicos.Repositorio
{
    public interface IPessoaRepositorio : IRepositorio<Pessoa>
    {
        Pessoa BuscarPorEmail(string email);
    }
}
