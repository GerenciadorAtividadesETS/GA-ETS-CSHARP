using AutoMapper;
using GA_ETS.DTO;
using GA_ETS.Model;

namespace GA_ETS.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<DadosCadastroUsuario, Usuario>();
        CreateMap<Usuario, DadosRetornoUsuario>();
    }
}