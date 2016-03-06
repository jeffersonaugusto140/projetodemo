using System;
using App.Aplicacao.DTO.Generico;
using App.Dominio.Entidades.Comum.Impl;

namespace App.Aplicacao.DTO
{
    public class UsuarioPessoaDTO : DTOGenerico
    {
        // Usuário
        public long UsuarioId { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        // Pessoa
        public long PessoaId { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string EmailOpcao1 { get; set; }
        public string EmailOpcao2 { get; set; }

        internal override object ConverterParaEntidade()
        {
            var user = new Usuario
            {
                Ativo = true,
                DadosPessoais = new Pessoa
                {
                    Ativo = true,
                    DataAlteracao = DateTime.Now,
                    DataCriacao = DateTime.Now,
                    DataNascimento = DataNascimento,
                    EmailOpcao1 = EmailOpcao1,
                    EmailOpcao2 = EmailOpcao2,
                    Nome = Nome,
                    SobreNome = SobreNome
                },
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                Login = Login,
                Senha = Senha
            };

            return user;
        }
    }
}