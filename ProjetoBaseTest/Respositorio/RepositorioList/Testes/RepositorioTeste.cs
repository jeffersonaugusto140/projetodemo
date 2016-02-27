using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ProjetoBase.ExceptionsExtension;
using ProjetoBase.RespositorioBase.Impl;
using ProjetoBase.RespositorioBase.Interface;
using ProjetoBaseTest.DTOs;
using Assert = NUnit.Framework.Assert;

namespace ProjetoBaseTest.Respositorio.RepositorioList.Testes
{
    [TestFixture]
    public class RepositorioTeste
    {
        private IRepositorio<Pessoa> _repositorio;

        #region Configurações

        [SetUp]
        public void SetUp()
        {
            _repositorio = FabricaRepositorio.Construir<Pessoa>();
        }

        [TearDown]
        public void TearDown()
        {
            _repositorio.Remover(_repositorio.ListarTodos(true));
        }

        private Pessoa CriarPessoPadrao()
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

        #endregion

        #region Salvar

        [Test]
        public void SalvarAdicionar_OK()
        {
            //Arrange
            Pessoa pessoa = CriarPessoPadrao();

            //Act
            pessoa.Salvar();

            //Assert
            Pessoa pessoaRep = _repositorio.BuscarPorId(pessoa.Id);

            Assert.IsNotNull(pessoaRep);
            Assert.AreEqual(pessoa, pessoaRep);
        }

        [Test]
        public void SalvarAlterar_OK()
        {
            //Arrange
            Pessoa pessoa = CriarPessoPadrao();

            //Act
            pessoa.Salvar();

            pessoa.Nome = "Joao";

            pessoa.Salvar();

            //Assert
            Pessoa pessoaRep = _repositorio.BuscarPorId(pessoa.Id);

            Assert.IsNotNull(pessoaRep);
            Assert.AreEqual(pessoa, pessoaRep);
            Assert.AreEqual(pessoa.Nome, pessoaRep.Nome);
        }

        #endregion

        #region Adicionar

        [Test]
        public void Adicionar_OK()
        {
            //Arrange
            Pessoa pessoa = CriarPessoPadrao();

            //Act
            pessoa = _repositorio.Adicionar(pessoa);

            //Assert
            Pessoa pessoaRep = _repositorio.BuscarPorId(pessoa.Id);

            Assert.IsNotNull(pessoaRep);
            Assert.AreEqual(pessoa, pessoaRep);
        }

        [Test]
        public void Adicionar_Erro()
        {
            //Arrange
            Pessoa pessoa = null;

            //Act
            _repositorio.Adicionar(pessoa);

            //Assert
            Assert.IsTrue(ControladorExcecao.ExisteExcecoes());
        }

        [Test]
        public void AdicionarVarios_OK()
        {
            //Arrange
            List<Pessoa> pessoas = new List<Pessoa>();

            for (int i = 0; i < 100; i++)
            {
                var p = CriarPessoPadrao();
                p.Nome = p.Nome + " - " + i;
                p.Sobrenome = p.Sobrenome + " - " + i;

                pessoas.Add(p);
            }

            //Act
            bool result = _repositorio.Adicionar(pessoas);

            //Assert
            Assert.AreEqual(100, _repositorio.ListarTodos().Count());
            Assert.IsTrue(result);
        }

        [Test]
        public void AdicionarVarios_Erro()
        {
            //Arrange
            List<Pessoa> pessoas = null;

            //Act
            bool result = _repositorio.Adicionar(pessoas);

            //Assert
            Assert.IsFalse(_repositorio.ListarTodos().Any());
            Assert.IsFalse(result);
            Assert.IsTrue(ControladorExcecao.ExisteExcecoes());
        }

        #endregion

        #region Alterar

        [Test]
        public void Alterar_OK()
        {
            //Arrange
            Pessoa pessoa = CriarPessoPadrao();

            //Act
            pessoa.Salvar();

            pessoa.Nome = "Joao";

            pessoa.Salvar();

            //Assert
            Pessoa pessoaRep = _repositorio.BuscarPorId(pessoa.Id);

            Assert.IsNotNull(pessoaRep);
            Assert.AreEqual(pessoa, pessoaRep);
            Assert.AreEqual(pessoa.Nome, pessoaRep.Nome);
        }

        [Test]
        public void Alterar_Erro()
        {
            //Arrange
            Pessoa pessoa = CriarPessoPadrao();

            //Act
            pessoa.Salvar();

            pessoa = null;

            _repositorio.Alterar(pessoa);
            
            //Assert
            Assert.IsTrue(ControladorExcecao.ExisteExcecoes());
        }

        [Test]
        public void AlterarVarios_OK()
        {
            //Arrange
            List<Pessoa> pessoas = new List<Pessoa>();

            for (int i = 0; i < 100; i++)
            {
                var p = CriarPessoPadrao();
                p.Nome = p.Nome + " - " + i;
                p.Sobrenome = p.Sobrenome + " - " + i;

                pessoas.Add(p);
            }

            //Act
            bool result = _repositorio.Adicionar(pessoas);

            pessoas
                .Select((p, i) => new {p, i})
                .ToList()
                .ForEach(o => o.p.Nome = o.p.Nome + " " + o.i);

            result = _repositorio.Alterar(pessoas);

            //Assert
            Assert.AreEqual(100, _repositorio.ListarTodos().Count());
            Assert.IsTrue(result);
            CollectionAssert.AreEqual(pessoas, _repositorio.ListarTodos(true));
        }

        [Test]
        public void AlterarVarios_Erro()
        {
            //Arrange
            List<Pessoa> pessoas = null;

            //Act
            bool result = _repositorio.Alterar(pessoas);

            //Assert
            Assert.IsFalse(_repositorio.ListarTodos().Any());
            Assert.IsFalse(result);
            Assert.IsTrue(ControladorExcecao.ExisteExcecoes());
        }

        #endregion
        
        #region Remover

        [Test]
        public void Remover_OK()
        {
            //Arrange
            Pessoa pessoa = CriarPessoPadrao();

            //Act
            pessoa.Salvar();
            bool result = pessoa.Remover();

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Remover_Erro()
        {
            //Arrange
            Pessoa pessoa = CriarPessoPadrao();

            //Act
            pessoa.Salvar();

            pessoa = null;

            _repositorio.Remover(pessoa);

            //Assert
            Assert.IsTrue(ControladorExcecao.ExisteExcecoes());
        }

        [Test]
        public void RemoverVarios_OK()
        {
            //Arrange
            List<Pessoa> pessoas = new List<Pessoa>();

            for (int i = 0; i < 100; i++)
            {
                var p = CriarPessoPadrao();
                p.Nome = p.Nome + " - " + i;
                p.Sobrenome = p.Sobrenome + " - " + i;

                pessoas.Add(p);
            }

            //Act
            bool result = _repositorio.Adicionar(pessoas);
            
            result = _repositorio.Remover(pessoas);

            //Assert
            Assert.AreEqual(0, _repositorio.ListarTodos().Count());
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoverVarios_Erro()
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            for (int i = 0; i < 100; i++)
            {
                var p = CriarPessoPadrao();
                p.Nome = p.Nome + " - " + i;
                p.Sobrenome = p.Sobrenome + " - " + i;

                pessoas.Add(p);
            }

            //Act
            bool result = _repositorio.Adicionar(pessoas);

            pessoas = null;
            result = _repositorio.Remover(pessoas);

            //Assert
            Assert.IsTrue(_repositorio.ListarTodos().Any());
            Assert.IsFalse(result);
            Assert.IsTrue(ControladorExcecao.ExisteExcecoes());
        }

        #endregion
    }
}
