using AutoMapper;
using LVS.Api.Models;
using LVS.Dtos;
using LVS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVS.Api.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {

                config.CreateMap<User, UserDto>().ForSourceMember(x => x.Role, y => y.Ignore());



                config.CreateMap<Role, RoleDto>().ForSourceMember(x => x.User, y => y.Ignore());

                config.CreateMap<LVS.Model.Action, ActionDto>();

                config.CreateMap<PSSScrap, ScrapDto>().ForSourceMember(x => x.PSSMaquinas, y => y.Ignore())
                                                         .ForSourceMember(x => x.PSSOperadores, y => y.Ignore())
                                                         .ForSourceMember(x => x.PSSOrigenesScrap, y => y.Ignore())
                                                         .ForSourceMember(x => x.PSSActividades, y => y.Ignore())
                                                         .ForSourceMember(x => x.PSSTiposMaterial, y => y.Ignore());


                config.CreateMap<UserClaim, UserClaimDto>();
                config.CreateMap<PSSEtiquetas, EtiquetasDto>();


                config.CreateMap<PSSMaquinas, MaquinasDto>().ForSourceMember(x => x.PSSAreas, y => y.Ignore())
                                                         .ForSourceMember(x => x.PSSOperadores, y => y.Ignore())
                                                         .ForSourceMember(x => x.PSSOrigenesScrap, y => y.Ignore())
                                                         .ForSourceMember(x => x.PSSJobTrack, y => y.Ignore())
                                                         .ForSourceMember(x => x.PSSActividades, y => y.Ignore())
                                                         .ForSourceMember(x => x.PSSTiposMaterial, y => y.Ignore());


                config.CreateMap<PSSAreas, AreasDto>().ForSourceMember(x => x.PSSMaquinas, y => y.Ignore());

                config.CreateMap<PSSOrigenesScrap, OrigenesScrapDto>().ForSourceMember(x => x.PSSMaquinas, y => y.Ignore())
                                                                      .ForSourceMember(x => x.PSSTiposMaterial, y => y.Ignore());
                

                config.CreateMap<PSSOperadores, OperadoresDto>().ForSourceMember(x => x.PSSMaquinas, y => y.Ignore());

                config.CreateMap<PSSTiposMaterial, TiposMaterialDto>().ForSourceMember(x => x.PSSMaquinas, y => y.Ignore());

                config.CreateMap<PSSActividades, ActividadDto>().ForSourceMember(x => x.PSSMaquinas, y => y.Ignore());

                config.CreateMap<PSSJobTrack, JobTrackDto>().ForSourceMember(x => x.PSSMaquinas, y => y.Ignore());

              
                config.CreateMap<GPModulosResponsables, GpModulosResponsablesDto>().ForSourceMember(x => x.GPResponsables, y => y.Ignore());
                config.CreateMap<GPResponsables, GpResponsablesDto>().ForSourceMember(x => x.GPModulosResponsables, y => y.Ignore());




            });
        }
    }
}