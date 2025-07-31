using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{

    public partial class GPImpresorasDto
    {
        public GPImpresorasDto()
        {
            this.GPPerfilesPrePrensa = new HashSet<GpPerfilesPrePrensaDto>();
        }

        public int IdImpresora { get; set; }
        public int IdTipoImpresora { get; set; }
        public string NombreImpresora { get; set; }
        public bool Habilitado { get; set; }

        public virtual ICollection<GpPerfilesPrePrensaDto> GPPerfilesPrePrensa { get; set; }
    }
}


