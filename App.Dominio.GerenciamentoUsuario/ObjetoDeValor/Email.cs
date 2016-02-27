using System.Text.RegularExpressions;
using App.Dominio.ObjetoDeValor;

namespace App.Dominio.GerenciamentoUsuario.ObjetoDeValor
{
    public class Email : AtributoObjetoValorBase
    {
        private readonly string _email;

        public Email(string email)
        {
            if (!this.EhValido(email))
            {
                
            }

            _email = email;
        }

        private bool EhValido(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            return match.Success;
        }

        protected override bool ComparaValor(AtributoObjetoValorBase obj)
        {
            return this.ToString() == obj.ToString();
        }

        public override int GetHashCode()
        {
            return _email.GetHashCode();
        }
        
        public override string ToString()
        {
            return _email;
        }
        
        public static implicit operator Email(string email)
        {
            return new Email(email);
        }

        public static implicit operator string(Email email)
        {
            return email.ToString();
        }
    }
}
