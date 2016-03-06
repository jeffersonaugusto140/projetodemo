using System.Data.Entity;
using App.Comuns;
using App.Dominio.Entidades.Comum.Impl;

namespace App.Infra.DataContext.Context
{
    public class AppContext : DbContext
    {
        public AppContext() : base(Constantes.DefaultConnName)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
