using FluentValidation;

namespace App.Dominio.Generico
{
    public abstract class AppBaseValidadtor<T> : AbstractValidator<T> where T : EntidadeBase
    {
    }
}
