using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS.Dtos
{
   
        public partial class OrigenesScrapDto
        {


        public OrigenesScrapDto()
        {
            this.PSSTiposMaterial = new HashSet<TiposMaterialDto>();
            





        }

        public int IDOrigen { get; set; }
            public string Descripcion { get; set; }
            public bool Habilitado { get; set; }
            public int idmaquina { get; set; }
            public virtual ICollection<TiposMaterialDto> PSSTiposMaterial { get; set; }



    }
}
