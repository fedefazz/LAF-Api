using System;
using System.Collections.Generic;
using LVS.Model;

namespace LVS.Dtos
{

    public partial class JobtrackModulosDto
    {
        public int IdJobtrack { get; set; }
        public int IdModuloApp { get; set; }
        public string Descripcion { get; set; }

        public virtual JobTrackDto PSSJobTrack { get; set; }
    }
}
