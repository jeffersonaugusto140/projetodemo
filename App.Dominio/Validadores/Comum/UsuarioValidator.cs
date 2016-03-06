using App.Dominio.Entidades.Comum.Impl;
using App.Dominio.Generico;
using FluentValidation;

namespace App.Dominio.Validadores.Comum
{
    public class UsuarioValidator : AppBaseValidadtor<Usuario>
    {
        internal UsuarioValidator()
        {
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Senha).NotEmpty();
            RuleFor(x => x.DadosPessoais).NotNull().SetValidator(new PessoaValidator());
        }
    }
}
