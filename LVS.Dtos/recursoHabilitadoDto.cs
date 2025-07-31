using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{

    public partial class recursoHabilitadoDto
    {




        public recursoHabilitadoDto()
        {
            this.PSSMotivosScrapVinculos = new HashSet<vinculoDto>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<vinculoDto> PSSMotivosScrapVinculos { get; set; }


    }

}