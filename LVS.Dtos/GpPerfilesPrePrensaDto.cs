using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{
   
        public partial class GpPerfilesPrePrensaDto
    {

        public GpPerfilesPrePrensaDto()
        {
            this.GPProductos = new HashSet<ProductoDto>();
        }

        public int IdPerfilPrePrensa { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
        public int IdImpresora { get; set; }
        public int IdProveedor { get; set; }
        public int IdTipoMaterial { get; set; }
        public virtual GPImpresoras GPImpresoras { get; set; }
        public virtual GPTipoMaterial GPTipoMaterial { get; set; }
        public virtual ICollection<ProductoDto> GPProductos { get; set; }




    }
}

