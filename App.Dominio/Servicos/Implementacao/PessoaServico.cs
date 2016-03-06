using App.Dominio.Entidades.Comum.Impl;
using App.Dominio.Repositorio.Comum;
using App.Dominio.Servicos.Interfaces;

namespace App.Dominio.Servicos.Implementacao
{
    public class PessoaServico : IPessoaServico
    {
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public PessoaServico(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        public void Adicionar(Pessoa entity)
        {
            _pessoaRepositorio.Adicionar(entity);
        }
    }
}
