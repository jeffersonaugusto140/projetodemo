using System;
using System.Collections.Generic;
using System.Linq;
using App.Dominio.Generico;
using App.Dominio.ObjetoDeValor;
using App.Dominio.Repositorio;

namespace App.Infra.Repositorio.Generico
{
    public class RepositorioDados<TEntidade> : IRepositorio<TEntidade> where TEntidade : EntidadeBase
    {
        protected static readonly List<TEntidade> Set = new List<TEntidade>();
        
        public TEntidade Adicionar(TEntidade entidade)
        {
            try
            {
                var last = Set.LastOrDefault();

                entidade.Id = 1;

                if (last != null)
                    entidade.Id = last.Id + 1;

                Set.Add(entidade);

                return entidade;
            }
            catch (Exception exception)
            {
                return entidade;
            }
        }

        public bool Adicionar(IEnumerable<TEntidade> entidades)
        {
            try
            {
                entidades.ToList().ForEach(entidade => Adicionar(entidade));

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }

        public TEntidade Alterar(TEntidade entidade)
        {
            try
            {
                var entidadeNoContexto = Set.Find(x => x.Id == entidade.Id);

                if (entidadeNoContexto == null)
                {
                    //new RegistroInexistenteException(true).AdicionarNoControle();
                    return entidade;
                }

                entidade.CopiarPara(entidadeNoContexto);

                return entidadeNoContexto;
            }
            catch (Exception exception)
            {
                //new AlterarRepositorioException(exception).AdicionarNoControle();

                return entidade;
            }
        }

        public bool Alterar(IEnumerable<TEntidade> entidades)
        {
            try
            {
                entidades.ToList().ForEach(entidade => Alterar(entidade));

                return true;
            }
            catch (Exception exception)
            {
                //new AlterarRepositorioException(exception).AdicionarNoControle();

                return false;
            }
        }

        public bool Remover(TEntidade entidade)
        {
            try
            {
                Set.RemoveAll(x => x.Id == entidade.Id);

                return true;
            }
            catch (Exception exception)
            {
                //new RemoverRepositorioException(exception).AdicionarNoControle();

                return false;
            }
        }

        public bool Remover(IEnumerable<TEntidade> entidades)
        {
            try
            {
                IEnumerable<long> ids = entidades.Select(x => x.Id);
                Set.RemoveAll(x => ids.Contains(x.Id));

                return true;
            }
            catch (Exception exception)
            {
                //new RemoverRepositorioException(exception).AdicionarNoControle();

                return false;
            }
        }

        public TEntidade BuscarPorId(uint id)
        {
            return Set.Find(x => x.Id == id);
        }

        public IEnumerable<TEntidade> ListarTodos(bool incluirInativos = false)
        {
            try
            {
                if (incluirInativos)
                    return Set;

                return Set.Where(x => x.Ativo);
            }
            catch (Exception exception)
            {
                //new RemoverRepositorioException(exception).AdicionarNoControle();

                return null;
            }
        }

        public void Dispose()
        {
            
        }
    }
}
