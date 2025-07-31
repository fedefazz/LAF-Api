using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{
   
        public partial class vinculoDto
    {


        public int Id_Motivo { get; set; }
        public int Id_Recurso { get; set; }
        public int Id_Origen { get; set; }
        public int Id_MaquinaImpute { get; set; }
        public int Id_TipoMaterial { get; set; }

        public virtual recursoHabilitadoDto Metrics_Recursos_Habilitados { get; set; }
        public virtual MaquinasDto PSSMaquinas { get; set; }
        public virtual motivoDto PSSMotivosScrap { get; set; }
        public virtual OrigenesScrapDto PSSOrigenesScrap { get; set; }
        public virtual GPTipoMaterialDto PSSTiposMaterial { get; set; }

      
        public List<OrigenesScrapDto> origenes { get; set; }
        public List<TiposMaterialDto> tiposMaterial { get; set; }
        public List<recursoHabilitadoDto> recursos { get; set; }

        public List<MaquinasDto> maquinas { get; set; }

    }

}
