using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{

    public partial class GpTrabajoCilindrosDto
    {
        public string Cod_Producto { get; set; }
        public int Nro_Version { get; set; }
        public string OT_Bolsapel { get; set; }
        public bool EnvioHabilitado { get; set; }
        public bool Solicitado { get; set; }
        public bool Enviado { get; set; }
        public string OrdCompra { get; set; }
        public System.DateTime FechaPreparacion { get; set; }
        public System.DateTime FechaEnvioAProveedor { get; set; }
        public string RemitoRetiro { get; set; }
        public System.DateTime FechaDeseada { get; set; }
        public System.DateTime FechaCompromiso { get; set; }
        public System.DateTime FechaRealEntrega { get; set; }
        public string RemitoEntrada { get; set; }
        public string Recibo { get; set; }
        public string Cod_Facturacion { get; set; }
        public string Notas { get; set; }
        public string OT_Proveedor { get; set; }
        public int Estado { get; set; }
        public int CantColores { get; set; }
        public string Fotocromista { get; set; }

        public int? Causa { get; set; }

        public string Anexos { get; set; }

        public System.DateTime FechaReprogramacion { get; set; }


        public virtual ProductoDto GPProductos { get; set; }
    }
}
