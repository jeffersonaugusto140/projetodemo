
namespace App.Dominio.ObjetoDeValor
{
    public abstract class AtributoObjetoValorBase
    {
        protected abstract bool ComparaValor(AtributoObjetoValorBase obj);

        public abstract override int GetHashCode();

        public override bool Equals(object obj)
        {
            if (obj == null || (!obj.GetType().Equals(this.GetType())))
                return false;

            if (obj == this)
                return true;

            return ComparaValor((AtributoObjetoValorBase)obj);
        }
    }
}
