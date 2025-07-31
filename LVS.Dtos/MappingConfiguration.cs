using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{
    using AutoMapper;



    public static class MappingConfiguration
    {

        public static void Configure(IMapperConfigurationExpression cfg)
        {


            cfg.CreateMap<User, UserDto>().ReverseMap().ForSourceMember(x => x.Role, y => y.Ignore());

            cfg.CreateMap<Role, RoleDto>().ForSourceMember(x => x.User, y => y.Ignore());

            cfg.CreateMap<LVS.Model.Action, ActionDto>();

            cfg.CreateMap<UserClaim, UserClaimDto>();

            cfg.CreateMap<PSSMaquinas, MaquinasDto>().ForSourceMember(x => x.PSSAreas, y => y.Ignore())
                                                     .ForSourceMember(x => x.PSSOperadores, y => y.Ignore())
                                                     .ForSourceMember(x => x.PSSOrigenesScrap, y => y.Ignore())
                                                     .ForSourceMember(x => x.PSSActividades, y => y.Ignore())
                                                     .ForSourceMember(x => x.PSSJobTrack, y => y.Ignore())
                                                     .ForSourceMember(x => x.PSSTiposMaterial, y => y.Ignore());


            cfg.CreateMap<PSSAreas, AreasDto>().ForSourceMember(x => x.PSSMaquinas, y => y.Ignore());



        }
    }

}
