using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{
   
        public partial class GpResponsablesDto
    {

        public GpResponsablesDto()
        {
            this.GPModulosResponsables = new HashSet<GpModulosResponsablesDto>();

        }

        public int IdResponsable { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Habilitado { get; set; }

        public virtual ICollection<GpModulosResponsablesDto> GPModulosResponsables { get; set; }






    }
}

