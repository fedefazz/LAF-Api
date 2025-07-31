using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVS.Api.Models
{
    public class impresion7dias
    {

        public decimal totalScrap { get; set; }
        public double totalProducidos { get; set; }

        public decimal incidenciaFischer { get; set; }
        public decimal produccionFischer { get; set; }
        public decimal scrapFischer { get; set; }

        public decimal incidenciaRotomec { get; set; }
        public decimal produccionRotomec { get; set; }
        public decimal scrapRotomec { get; set; }



        public decimal incidenciaHeliostar { get; set; }
        public decimal produccionHeliostar { get; set; }
        public decimal scrapHeliostar { get; set; }

        public decimal incidenciaAllstein { get; set; }
        public decimal produccionAllstein { get; set; }
        public decimal scrapAllstein { get; set; }





    }
}