using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{
   
    



        public partial class scrapValoresPorPeriodoMensualDto
    {
            public int Ano { get; set; }
            public int Mes { get; set; }
            public double ScrapNoRegistrado { get; set; }

        public double TonsProducidas { get; set; }


        public int Record_Id { get; set; }
    }

    
}
