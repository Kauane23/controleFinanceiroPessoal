using controleFinanceiro.Dtos;
using controleFinanceiro.Dtos.Responses;
using controleFinanceiro.Entities;
using AutoMapper;

namespace controleFinanceiro.Profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<UsuarioDto, Usuario>()
                .ForMember(
                    dest => dest.Senha,
                    opt => opt.Ignore()
                );

            CreateMap<Usuario, UsuarioResponseDto>();

            CreateMap<ContaDto, Conta>();
            CreateMap<Conta, ContaResponseDto>();

            CreateMap<CategoriaDto, Categoria>();
            CreateMap<Categoria, CategoriaResponseDto>();

            CreateMap<MovimentacaoDto, Movimentacao>();
            CreateMap<Movimentacao, MovimentacaoResponseDto>();
        }
    }
}
