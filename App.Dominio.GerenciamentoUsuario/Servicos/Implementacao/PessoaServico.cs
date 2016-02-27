using App.Dominio.GerenciamentoUsuario.Entidades;
using App.Dominio.GerenciamentoUsuario.Servicos.Interfaces;
using App.Dominio.GerenciamentoUsuario.Servicos.Repositorio;

namespace App.Dominio.GerenciamentoUsuario.Servicos.Implementacao
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
