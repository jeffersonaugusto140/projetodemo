using System;
using App.Dominio.Entidades.Comum.Impl;
using App.Dominio.Generico;
using FluentValidation;

namespace App.Dominio.Validadores.Comum
{
    internal class PessoaValidator : AppBaseValidadtor<Pessoa>
    {
        public PessoaValidator()
        {
            RuleFor(x => x.Nome).NotEmpty();
            RuleFor(x => x.SobreNome).NotEmpty();
            RuleFor(x => x.DataNascimento).GreaterThan(new DateTime(1900, 01, 01));
            RuleFor(x => x.EmailOpcao1).NotEmpty();
        }
    }
}