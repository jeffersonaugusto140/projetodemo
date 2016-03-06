

using System.Collections.Generic;
using NUnit.Framework;
using ProjetoBase.ExceptionsExtension;

namespace ProjetoBaseTest.Excecoes
{
    [TestFixture]
    public class ControladorExcecaoTeste
    {
        [Test]
        public void Trace()
        {
            //Arrenge
            List<ExcecaoGenericaException> exceptions = new List<ExcecaoGenericaException>
            {
                new RegistroInexistenteException(true),
                new AdicionarRepositorioException(),
                new AlterarRepositorioException(),
                new RemoverRepositorioException(),
                new RepositorioException("Teste erro", ExcecaoGenericaException.EnTipoExcecao.Alerta, true)
            };

            //Act
            exceptions.ForEach(x => x.AdicionarNoControle());

            //Assert
            Assert.IsTrue(ControladorExcecao.ExisteExcecoes());

            string trace = ControladorExcecao.Trace();

            StringAssert.StartsWith("Origem", trace);
        }

        [Test]
        public void TraceIn()
        {
            //Arrenge
            List<ExcecaoGenericaException> exceptions = new List<ExcecaoGenericaException>
            {
                new RegistroInexistenteException("teste registro", new AlterarRepositorioException(new RegistroInexistenteException(true)), false, ExcecaoGenericaException.EnTipoExcecao.Erro ),
                new AdicionarRepositorioException(new ListarRepositorioException()),
                new AlterarRepositorioException(),
                new RemoverRepositorioException(),
                new RepositorioException("Teste erro", ExcecaoGenericaException.EnTipoExcecao.Alerta, true)
            };

            //Act
            exceptions.ForEach(x => x.AdicionarNoControle());

            //Assert
            Assert.IsTrue(ControladorExcecao.ExisteExcecoes());

            string trace = ControladorExcecao.Trace();

            StringAssert.StartsWith("Origem", trace);
        }

        [Test]
        public void StackTrace()
        {
            //Arrenge
            var ex = new RegistroInexistenteException("teste registro",
                new AlterarRepositorioException(
                    new RegistroInexistenteException(true)), false,
                ExcecaoGenericaException.EnTipoExcecao.Erro);

            //Act

            string trace = ex.Trace();

            //Assert
            StringAssert.StartsWith("Origem", trace);
        }
    }
}
