namespace App.Dominio.Servicos.Interfaces.Base
{
    public interface IServicoBase<T>
    {
        void Adicionar(T entity);
    }
}