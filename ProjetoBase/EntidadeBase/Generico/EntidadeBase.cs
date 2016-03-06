using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoBase.RespositorioBase.Impl;

namespace ProjetoBase.EntidadeBase.Generico
{
    public abstract class EntidadeBase<TEntidade> where TEntidade : EntidadeBase<TEntidade>
    {
        [Key]
        public uint Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAlteracao { get; set; }

        public bool Ativo { get; set; }

        public TEntidade Salvar()
        {
            using (var repositorio = FabricaRepositorio.Construir<TEntidade>())
            {
                if (Id == 0)
                    return repositorio.Adicionar((TEntidade) this);
                return repositorio.Alterar((TEntidade) this);
            }
        }

        public bool Remover()
        {
            using (var repositorio = FabricaRepositorio.Construir<TEntidade>())
            {
                return repositorio.Remover((TEntidade) this);
            }
        }
    }
}
