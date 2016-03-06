using System;
using System.Collections.Generic;
using System.Linq;
using LinqKit;
using ProjetoBase.ExceptionsExtension;
using ProjetoBase.Ferramentas;
using ProjetoBase.RespositorioBase.Interface;

namespace ProjetoBase.RespositorioBase.Impl
{
    public class RepositorioList<TEntidade> : IRepositorio<TEntidade> where TEntidade : EntidadeBase.Generico.EntidadeBase<TEntidade>
    {
        private static readonly List<TEntidade> _contextList = new List<TEntidade>();
        
        public TEntidade Adicionar(TEntidade entidade)
        {
            try
            {
                var last = _contextList.LastOrDefault();

                entidade.Id = 1;

                if (last != null)
                    entidade.Id = last.Id + 1;

                _contextList.Add(entidade);

                return entidade;
            }
            catch (Exception exception)
            {
                new AdicionarRepositorioException(exception).AdicionarNoControle();

                return entidade;
            }
        }

        public bool Adicionar(IEnumerable<TEntidade> entidades)
        {
            try
            {
                entidades.ForEach(entidade => Adicionar(entidade));

                return true;
            }
            catch (Exception exception)
            {
                new AdicionarRepositorioException(exception).AdicionarNoControle();

                return false;
            }
        }

        public TEntidade Alterar(TEntidade entidade)
        {
            try
            {
                var entidadeNoContexto = _contextList.Find(x => x.Id == entidade.Id);

                if (entidadeNoContexto == null)
                {
                    new RegistroInexistenteException(true).AdicionarNoControle();
                    return entidade;
                }

                entidade.CopiarPara(entidadeNoContexto);

                return entidadeNoContexto;
            }
            catch (Exception exception)
            {
                new AlterarRepositorioException(exception).AdicionarNoControle();

                return entidade;
            }
        }

        public bool Alterar(IEnumerable<TEntidade> entidades)
        {
            try
            {
                entidades.ForEach(entidade => Alterar(entidade));

                return true;
            }
            catch (Exception exception)
            {
                new AlterarRepositorioException(exception).AdicionarNoControle();

                return false;
            }
        }

        public bool Remover(TEntidade entidade)
        {
            try
            {
                _contextList.RemoveAll(x => x.Id == entidade.Id);

                return true;
            }
            catch (Exception exception)
            {
                new RemoverRepositorioException(exception).AdicionarNoControle();

                return false;
            }
        }

        public bool Remover(IEnumerable<TEntidade> entidades)
        {
            try
            {
                IEnumerable<uint> ids = entidades.Select(x => x.Id);
                _contextList.RemoveAll(x => ids.Contains(x.Id));

                return true;
            }
            catch (Exception exception)
            {
                new RemoverRepositorioException(exception).AdicionarNoControle();

                return false;
            }
        }

        public TEntidade BuscarPorId(uint id)
        {
            return _contextList.Find(x => x.Id == id);
        }

        public IEnumerable<TEntidade> ListarTodos(bool incluirInativos = false)
        {
            try
            {
                if (incluirInativos)
                    return _contextList;

                return _contextList.Where(x => x.Ativo);
            }
            catch (Exception exception)
            {
                new RemoverRepositorioException(exception).AdicionarNoControle();

                return null;
            }
        }

        public void Dispose()
        {
            
        }
    }
}
