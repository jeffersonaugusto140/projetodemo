using App.Dominio.Entidades.Comum.Impl;

namespace App.Dominio.Repositorio.Comum
{
    public interface IPessoaRepositorio : IRepositorio<Pessoa>
    {
        Pessoa BuscarPorEmail(string email);
    }
}
