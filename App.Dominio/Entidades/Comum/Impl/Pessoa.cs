using System;
using System.Collections.Generic;
using App.Dominio.Generico;
using App.Dominio.ObjetoDeValor;
using App.Dominio.Regras;

namespace App.Dominio.Entidades.Comum.Impl
{
    public class Pessoa : EntidadeBase
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string EmailOpcao1 { get; set; }
        public string EmailOpcao2 { get; set; }
        
        public Pessoa()
        {
        }
        
        protected override void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
