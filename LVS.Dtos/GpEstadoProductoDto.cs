using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{

    public partial class GPEstadosProductosDto
    {
        public GPEstadosProductosDto()
        {
            this.GPProductos = new HashSet<ProductoDto>();
        }

        public int IDEstadoProducto { get; set; }
        public string Estado { get; set; }
        public bool Habilitado { get; set; }

        public virtual ICollection<ProductoDto> GPProductos { get; set; }
    }
}


