using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace App.Comuns.Excecoes
{
    public class ValidadorException : AppBaseException
    {
        private readonly IList<ValidationFailure> _validationFailures;

        public IEnumerable<string> Erros
        {
            get
            {
                List<string> erros = new List<string>();

                _validationFailures.ToList().ForEach(x => erros.Add(x.ErrorMessage));

                return erros;
            }
        }

        public ValidadorException(IList<ValidationFailure> validationFailures)
        {
            _validationFailures = validationFailures;
            
        }

        public ValidadorException(string message, bool mostrarParaUsuario, bool ehSomenteAlerta) : base(message, mostrarParaUsuario, ehSomenteAlerta)
        {
        }
    }
}