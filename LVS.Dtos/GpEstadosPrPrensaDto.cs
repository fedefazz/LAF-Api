using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{
   
        public partial class GpEstadosPrPrensaDto
    {

        public GpEstadosPrPrensaDto()
        {
            this.GPProductos = new HashSet<ProductoDto>();

        }

        public int IdEstadoPrePrensa { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
        public bool Habilitado { get; set; }

        public virtual ICollection<ProductoDto> GPProductos { get; set; }

    }
}

