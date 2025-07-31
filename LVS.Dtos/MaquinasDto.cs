using LVS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS.Dtos
{
    public class MaquinasDto
    {

        
            public MaquinasDto()
            {
                this.PSSOrigenesScrap = new HashSet<OrigenesScrapDto>();
                this.PSSOperadores = new HashSet<OperadoresDto>();
                this.PSSTiposMaterial = new HashSet<TiposMaterialDto>();
                this.PSSActividades = new HashSet<ActividadDto>();
                this.PSSJobTrack = new HashSet<JobTrackDto>();


           


        }

        public int IDMaq { get; set; }
            public string Descripcion { get; set; }
            public string Recurso { get; set; }
            public int IDArea { get; set; }
            public bool Habilitado { get; set; }



             public virtual AreasDto PSSAreas { get; set; }
            public virtual ICollection<OrigenesScrapDto> PSSOrigenesScrap { get; set; }
            public virtual ICollection<OperadoresDto> PSSOperadores { get; set; }
            public virtual ICollection<TiposMaterialDto> PSSTiposMaterial { get; set; }
            public virtual ICollection<ActividadDto> PSSActividades { get; set; }
            public virtual ICollection<JobTrackDto> PSSJobTrack { get; set; }


    }
}



