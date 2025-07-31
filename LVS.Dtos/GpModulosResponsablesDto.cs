using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{
   
        public partial class GpModulosResponsablesDto
    {

        public GpModulosResponsablesDto()
        {
            this.GPProductos = new HashSet<ProductoDto>();
        }

        public int IdModuloProducto { get; set; }
        public int IdResponsable { get; set; }

        public int Id { get; set; }

        public virtual ProductoDto GPModulosProductos { get; set; }
        public virtual GpResponsablesDto GPResponsables { get; set; }
        public virtual ICollection<ProductoDto> GPProductos { get; set; }


    }
}

