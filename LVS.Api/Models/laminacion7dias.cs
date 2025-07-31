using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVS.Api.Models
{
    public class laminacion7dias
    {

        public decimal totalScrap { get; set; }
        public double totalProducidos { get; set; }

       public List<listadodetallemaquina> listadodetallemaquina { get; set; }


    }


    public class listadodetallemaquina {

        public decimal incidencia { get; set; }
        public decimal produccion { get; set; }
        public decimal scrap { get; set; }
        public string nombre { get; set; }


    }
}