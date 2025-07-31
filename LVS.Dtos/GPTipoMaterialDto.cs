using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{

    public partial class GPTipoMaterialDto
    {
        public GPTipoMaterialDto()
        {
            this.GPPerfilesPrePrensa = new HashSet<GpPerfilesPrePrensaDto>();
        }

        public int IdTipoMaterial { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }

        public virtual ICollection<GpPerfilesPrePrensaDto> GPPerfilesPrePrensa { get; set; }
    }
}

