using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS.Dtos
{
    public partial class OperadoresDto
    {

           
            public int IdOperador { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public bool Habilitado { get; set; }
            public string Legajo { get; set; }

    }
}
