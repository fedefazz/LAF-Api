using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS.Dtos
{
    public class ScrapDto
    {




        public int IdRegScrap { get; set; }
        public System.DateTime Fecha { get; set; }
        public int NumOP { get; set; }
        public int IdMaq { get; set; }
        public int IdOperador { get; set; }
        public int IdActividad { get; set; }
        public int IdTipoMat { get; set; }
        public int IdOrigenScrap { get; set; }
        public decimal Peso { get; set; }
        public string Observaciones { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public int IdMaqImputaScrap { get; set; }
        public Nullable<bool> Habilitado { get; set; }
        public string IdMaqImputaScrapName { get; set; }


        public virtual ActividadDto PSSActividades { get; set; }
        public virtual MaquinasDto PSSMaquinas { get; set; }
        public virtual OperadoresDto PSSOperadores { get; set; }
        public virtual OrigenesScrapDto PSSOrigenesScrap { get; set; }
        public virtual TiposMaterialDto PSSTiposMaterial { get; set; }




    }

    public class ScrapMotivoResult
{
        public int? CRITERIO { get; set; }
        public int? ID_MOTIVO { get; set; }
        public string DESC_MOTIVO_SCRAP { get; set; }
        public double? _1 { get; set; }  // Cambiado de float? a double?
        public double? _2 { get; set; }  // Cambiado de float? a double?
        public double? _3 { get; set; }  // Cambiado de float? a double?
        public double? _4 { get; set; }  // Cambiado de float? a double?
        public double? _5 { get; set; }  // Cambiado de float? a double?
        public double? _6 { get; set; }  // Cambiado de float? a double?
        public double? _7 { get; set; }  // Cambiado de float? a double?
        public double? _8 { get; set; }  // Cambiado de float? a double?
        public double? _9 { get; set; }  // Cambiado de float? a double?
        public double? _10 { get; set; } // Cambiado de float? a double?
        public double? _11 { get; set; } // Cambiado de float? a double?
        public double? _12 { get; set; } // Cambiado de float? a double?
        public double? TOTAL_GENERAL { get; set; }  // Cambiado de float? a double?
        public double? SCRAP_TOT { get; set; }      // Cambiado de float? a double?
        public double? SCRAP_MES { get; set; }      // Cambiado de float? a double?
        public double? PERC_SCRAP_TOT { get; set; } // Cambiado de float? a double?
        public double? PERC_SCRAP_MES_ACTUAL { get; set; } // Cambiado de float? a double?
        public double? PORCENTAJESIMULACIONMEJORA { get; set; } // Cambiado de float? a double?
        public double? MEJORADEFINIDA { get; set; }  // Cambiado de float? a double?
        public double? MES_ANO_PROX { get; set; }    // Cambiado de float? a double?
        public double? PERC_MEJORA { get; set; }     // Cambiado de float? a double?
    }
}
