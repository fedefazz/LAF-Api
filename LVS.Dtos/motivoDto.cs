using System;
using System.Collections.Generic;


namespace LVS.Dtos
{
   

    public partial class motivoDto
    {
        public motivoDto()
        {
            this.pSSMotivosScrapObjetivos = new HashSet<objetivoDto>();
            this.pSSMotivosScrapVinculos = new HashSet<vinculoDto>();
        }

        public int Id_Motivo { get; set; }
        public string Descripcion { get; set; }
        public bool Habilitado { get; set; }

        public Nullable<double> PorcentajeSimulacionMejora { get; set; }


        public virtual ICollection<objetivoDto> pSSMotivosScrapObjetivos { get; set; }
        public virtual ICollection<vinculoDto> pSSMotivosScrapVinculos { get; set; }
    }
}
