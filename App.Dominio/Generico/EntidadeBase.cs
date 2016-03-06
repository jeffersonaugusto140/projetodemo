using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace App.Dominio.Generico
{
    public abstract class EntidadeBase
    {
        public long Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAlteracao { get; set; }

        public bool Ativo { get; set; }

        protected ValidationResult _validationResult;

        public bool EhValido()
        {
            Validar();
            return _validationResult.IsValid;
        }

        public bool EhInvalido()
        {
            return !EhValido();
        }

        public IList<ValidationFailure> ListarErros()
        {
            return _validationResult.Errors;
        }

        protected abstract void Validar();
    }
}
