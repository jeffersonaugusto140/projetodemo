using System;
using System.Collections.Generic;
using App.Aplicacao.DTO.Generico;

namespace App.Aplicacao.DTO
{
    public class UsuarioPessoaDTO : DTOGenerico
    {
        // Usuário
        public long UsuarioId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        // Usuário
        public long PessoaId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string EmailOpcao1 { get; set; }
        public string EmailOpcao2 { get; set; }

        public List<ClubeEsportivoDTO> ClubesDeInteresse { get; set; }
        public List<OrganizacaoEsportivaDTO> OrganizacoesEsportivas { get; set; }

        public UsuarioPessoaDTO()
        {
            this.ClubesDeInteresse = new List<ClubeEsportivoDTO>();
            this.OrganizacoesEsportivas = new List<OrganizacaoEsportivaDTO>();
        }
    }
}
