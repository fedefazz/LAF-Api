using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{

    public partial class GPModulosProductosDto
    {
        public GPModulosProductosDto()
        {
            this.GPModulosResponsables = new HashSet<GpModulosResponsablesDto>();
        }

        public int IdModulo { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<GpModulosResponsablesDto> GPModulosResponsables { get; set; }



    }
}

