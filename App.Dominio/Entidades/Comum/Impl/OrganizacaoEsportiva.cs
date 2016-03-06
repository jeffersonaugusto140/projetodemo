using System.Collections.Generic;
using System.Linq;
using App.Dominio.Generico;
using App.Dominio.ObjetoDeValor;
using App.Dominio.Regras;

namespace App.Dominio.Entidades.Comum.Impl
{
    public class OrganizacaoEsportiva : EntidadeBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public byte[] Logomarca { get; set; }
        public EnTipoOrganizacaoEsportiva TipoOrganizacaoEsportiva { get; set; }
        public Usuario UsuarioCriador { get; set; }

        public virtual ICollection<Pessoa> Membros { get; set; }
        public virtual ICollection<Usuario> Administradores { get; set; }

        public enum EnTipoOrganizacaoEsportiva
        {
            FutebolCampo = 1,
            FutebolSalao = 2,
            FutebolSociety = 3,
            FutebolDeAreira = 4,
            Basquete = 5,
            Volei = 6
        }

        public OrganizacaoEsportiva()
        {
            Membros = new List<Pessoa>();
            Administradores = new List<Usuario>();
        }

        public void AdicionarMembro(Pessoa membro)
        {
            if (Membros.Any(x => x.Id == membro.Id))
                ;//throw new OrganizacaoEsportivaExcecao(OrganizacaoEsportivaRegra.MemborJaFoiAdicionado.Descricao, mostrarParaUsuario: true, ehSomenteAlerta: true);

            Membros.Add(membro);
        }

        public void AdicionarAdministrador(Usuario usuario)
        {
            if (VerificadorExistencia.Existe(Administradores, usuario))
                ;//throw new OrganizacaoEsportivaExcecao(OrganizacaoEsportivaRegra.JaFoiAdicionadoComoAdm.Descricao, mostrarParaUsuario: true, ehSomenteAlerta: true);

            if (VerificadorExistencia.NaoExiste(Membros, usuario.DadosPessoais))
                ;//throw new OrganizacaoEsportivaExcecao(OrganizacaoEsportivaRegra.AdministradorDeveSerMembro.Descricao, mostrarParaUsuario: true, ehSomenteAlerta: true);

            Administradores.Add(usuario);
        }

        public void AdicionarUsuarioCriador(Usuario usuarioCriador)
        {
            if (this.UsuarioCriador != null)
                ;//throw new OrganizacaoEsportivaExcecao(OrganizacaoEsportivaRegra.JaExisteUsuarioCriador.Descricao, mostrarParaUsuario: true, ehSomenteAlerta: true);

            this.AdicionarMembro(UsuarioCriador.DadosPessoais);
            this.AdicionarAdministrador(usuarioCriador);
            this.UsuarioCriador = usuarioCriador;
        }

        public bool EhFutebol()
        {
            return
                this.TipoOrganizacaoEsportiva == EnTipoOrganizacaoEsportiva.FutebolCampo ||
                this.TipoOrganizacaoEsportiva == EnTipoOrganizacaoEsportiva.FutebolSalao ||
                this.TipoOrganizacaoEsportiva == EnTipoOrganizacaoEsportiva.FutebolSociety ||
                this.TipoOrganizacaoEsportiva == EnTipoOrganizacaoEsportiva.FutebolDeAreira;
        }

        protected override void Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}
