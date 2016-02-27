
using System.Data.Entity;
using App.Dominio.GerenciamentoUsuario.Entidades;

namespace App.Infra.DataContext
{
    public class AppContext : DbContext
    {
        // <add name="ManagerSuiteContext" providerName="System.Data.SqlClient" connectionString="Server=JeffersonPC;Database=ManagerSuite;Trusted_Connection=false;Persist Security Info=True;User Id=sa;Password=root; MultipleActiveResultSets=True;" />
        private const string _strConn =
            "Server=JeffersonPC;Database=AppDatabase;Trusted_Connection=false;Persist Security Info=True;User Id=sa;Password=root; MultipleActiveResultSets=True;";

        public AppContext() : base(_strConn)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<OrganizacaoEsportiva> OrganizacoesEsportivas { get; set; }
        public DbSet<ClubeEsportivo> ClubesEsportivos { get; set; }
    }
}
