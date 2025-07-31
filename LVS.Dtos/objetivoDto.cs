using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{
   
        public partial class objetivoDto
    {
        public int Id_Objetivo { get; set; }
        public int Id_Motivo { get; set; }
        public double Indicador_Inicio { get; set; }
        public double Indicador_Objetivo { get; set; }
        public System.DateTime Vigencia_Desde { get; set; }
        public System.DateTime Vigencia_Hasta { get; set; }
      
        public virtual motivoDto PSSMotivosScrap { get; set; }


    }

   
}
