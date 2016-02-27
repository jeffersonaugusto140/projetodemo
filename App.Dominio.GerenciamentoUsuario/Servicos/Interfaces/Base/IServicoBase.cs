namespace App.Dominio.GerenciamentoUsuario.Servicos.Interfaces.Base
{
    public interface IServicoBase<T>
    {
        void Adicionar(T entity);
    }
}