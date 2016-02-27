using System;

namespace App.Dominio.Generico
{
    public abstract class EntidadeBase
    {
        public long Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAlteracao { get; set; }

        public bool Ativo { get; set; }
    }
}
