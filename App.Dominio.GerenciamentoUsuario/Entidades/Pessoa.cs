using System;
using System.Collections.Generic;
using App.Dominio.Generico;
using App.Dominio.GerenciamentoUsuario.Excecoes;
using App.Dominio.GerenciamentoUsuario.ObjetoDeValor;
using App.Dominio.GerenciamentoUsuario.Regras;

namespace App.Dominio.GerenciamentoUsuario.Entidades
{
    public class Pessoa : EntidadeBase
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string EmailOpcao1 { get; set; }
        public string EmailOpcao2 { get; set; }

        public virtual ICollection<ClubeEsportivo> ClubesDeInteresse { get; set; }
        public virtual ICollection<OrganizacaoEsportiva> OrganizacoesEsportivas { get; set; }

        public Pessoa()
        {
            ClubesDeInteresse = new List<ClubeEsportivo>();
            OrganizacoesEsportivas = new List<OrganizacaoEsportiva>();
        }

        public void AdicionarClubeDeInteresse(ClubeEsportivo clubeEsportivo)
        {
            if (VerificadorExistencia.Existe(ClubesDeInteresse, clubeEsportivo))
                throw new PessoaExcecao(PessoaRegras.ClubeJaSelecionado.Descricao, mostrarParaUsuario:true, ehSomenteAlerta:true);

            this.ClubesDeInteresse.Add(clubeEsportivo);
        }

        public void AdicionarOrganizacaoEsportiva(OrganizacaoEsportiva organizacaoEsportiva)
        {
            if (VerificadorExistencia.Existe(OrganizacoesEsportivas, organizacaoEsportiva))
                throw new PessoaExcecao(PessoaRegras.OrganizacaoEsportivaJaExisteNaoPodeSerAdicionada.Descricao, mostrarParaUsuario: true, ehSomenteAlerta: true);
            OrganizacoesEsportivas.Add(organizacaoEsportiva);
        }
    }
}
