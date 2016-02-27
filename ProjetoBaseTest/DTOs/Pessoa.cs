using System;
using System.Collections.Generic;
using ProjetoBase.EntidadeBase.Generico;

namespace ProjetoBaseTest.DTOs
{
    public class Pessoa : EntidadeBase<Pessoa>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public ICollection<Endereco> Enderecos { get; set; }
        public ICollection<Telefone> Telefones { get; set; }

        public Pessoa()
        {
            Enderecos = new HashSet<Endereco>();
            Telefones = new List<Telefone>();
        }


        public static Pessoa CriarPessoPadrao()
        {
            return new Pessoa
            {
                Id = 0,
                DataCriacao = DateTime.Now,
                DataAlteracao = DateTime.Now,
                Ativo = true,
                Nome = "Maria",
                Sobrenome = "Silva",
                Enderecos = new List<Endereco>
                {
                    new Endereco
                    {
                        Id = 0,
                        DataCriacao = DateTime.Now,
                        DataAlteracao = DateTime.Now,
                        Ativo = true,
                        Logradouro = "José Silva",
                        Numero = "325",
                        CEP = "88102-000",
                        Complemento = "Casa"
                    }
                },
                Telefones = new List<Telefone>
                {
                    new Telefone
                    {
                        Id = 0,
                        DataCriacao = DateTime.Now,
                        DataAlteracao = DateTime.Now,
                        Ativo = true,
                        Numero = "8844-33-22",
                        TipoTelefone = Telefone.EnTipoTelefone.Celular
                    },
                    new Telefone
                    {
                        Id = 0,
                        DataCriacao = DateTime.Now,
                        DataAlteracao = DateTime.Now,
                        Ativo = true,
                        Numero = "3322-4545",
                        TipoTelefone = Telefone.EnTipoTelefone.Residencial
                    }
                }
            };
        }

    }
}
