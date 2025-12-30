using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS.Dtos
{
    public partial class GPPGruposEmpaqueDto
    {
        public int IDGrupoEmpaque { get; set; }
        public string Descripcion { get; set; }
        public bool EtiquetaInterna { get; set; }
        public int TipoEtiquetaInterna { get; set; }
        public bool EtiquetaExterna { get; set; }
        public int TipoEtiquetaExterna { get; set; }
        public bool PosicionTaco { get; set; }
        public bool LlevaBolsa { get; set; }
        public bool EtiquetaEnBolsa { get; set; }
        public bool TipoPaletizacion { get; set; }
        public int TipoPallet { get; set; }
        public int TipoEtiquetaPallet { get; set; }
        public bool Habilitado { get; set; }
    }

    // DTO para Tipos de Etiquetas
    public partial class GPPTiposEtiquetasDto
    {
        public int IdEtiqueta { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }
    }
}
