using System.Linq;
using App.Aplicacao.DTO;
using App.Dominio.Entidades.Comum.Impl;
using AutoMapper;

namespace App.Aplicacao.MapperDTO
{
    public class InicializadorMapper
    {
        public static void Inicializar()
        {
            Mapper.CreateMap<UsuarioPessoaDTO, Usuario>()
                .ForMember(x => x.Id, opt => opt.MapFrom(dto => dto.UsuarioId))
                .ForMember(x => x.Login, opt => opt.MapFrom(dto => dto.Login))
                .ForMember(x => x.Senha, opt => opt.MapFrom(dto => dto.Senha))
                .ForMember(x => x.DadosPessoais, opt => opt.MapFrom(dto => Mapper.Map<Pessoa>(dto)));

            Mapper.CreateMap<UsuarioPessoaDTO, Pessoa>()
                .ForMember(x => x.Id, opt => opt.MapFrom(dto => dto.PessoaId))
                .ForMember(x => x.Nome, opt => opt.MapFrom(dto => dto.Nome))
                .ForMember(x => x.SobreNome, opt => opt.MapFrom(dto => dto.SobreNome))
                .ForMember(x => x.EmailOpcao1, opt => opt.MapFrom(dto => dto.EmailOpcao1))
                .ForMember(x => x.EmailOpcao2, opt => opt.MapFrom(dto => dto.EmailOpcao2))
                .ForMember(x => x.DataNascimento, opt => opt.MapFrom(dto => dto.DataNascimento));
                
            Mapper.CreateMap<Usuario, UsuarioPessoaDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(x => x.Login, opt => opt.MapFrom(dto => dto.Login));
        }
    }
}
