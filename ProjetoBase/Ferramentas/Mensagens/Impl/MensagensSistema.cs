using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.Ferramentas.Mensagens.Interface;

namespace ProjetoBase.Ferramentas.Mensagens
{
    public class MensagensSistema : IMensagensSistema
    {
        private static IMensagensSistema _mensagens;

        public static IMensagensSistema Instancia => _mensagens ?? (new MensagensSistema(Idioma.PortuguesBrasil));

        private MensagensSistema(Idioma idioma)
        {
            _mensagens = CriarMensagem(idioma);
        }

        public IMensagensSistema CriarMensagem(Idioma idioma)
        {
            switch (idioma)
            {
                case Idioma.PortuguesBrasil:
                    return new MensagensPortuguesBrasil();
                case Idioma.Ingles:
                    return new MensagensIngles();
                default:
                    return new MensagensPortuguesBrasil();
            }
        }

        public string RegistroInexitente => _mensagens.RegistroInexitente;

        public string OperacaoNaoPermitida => _mensagens.OperacaoNaoPermitida;

        public string SucessoRealizarOperacao => _mensagens.SucessoRealizarOperacao;

        public enum Idioma
        {
            PortuguesBrasil = 1,
            Ingles
        }
    }

    public class MensagensPortuguesBrasil : IMensagensSistema
    {
        public string RegistroInexitente => "Informação procurada não existe.";

        public string OperacaoNaoPermitida => "Operação não permitida.";

        public string SucessoRealizarOperacao => "Sucesso ao realizar operação.";

    }

    public class MensagensIngles : IMensagensSistema
    {
        public string RegistroInexitente => "Record does not exist.";

        public string OperacaoNaoPermitida => "Operation not permitted.";

        public string SucessoRealizarOperacao => "Success when performing operation.";

    }
}
