using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{
   
        public partial class JobTrackDto
    {

       


        public int IDJobTrack { get; set; }
        public string Descripcion { get; set; }
        public string JobTrack { get; set; }
        public bool Habilitado { get; set; }
        public string PrinterDefault { get; set; }
        public string PrinterEtiquetas { get; set; }


    }

    public partial class JobTrackDto2
    {




        public int IDJobTrack { get; set; }
        public string Descripcion { get; set; }
        public string JobTrack { get; set; }
        public bool Habilitado { get; set; }
        public string PrinterDefault { get; set; }
        public string PrinterEtiquetas { get; set; }

        public List<JobtrackModulosDto> PSSJobtrackModulos { get; set; }


}
}
