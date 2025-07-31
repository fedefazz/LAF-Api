using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{

    public partial class ProductoDto
    {
        public string Cod_Producto { get; set; }
        public string Descripcion { get; set; }
        public string Unid_Medida { get; set; }
        public System.DateTime Fecha_Creacion { get; set; }
        public string Tipo_Adm { get; set; }
        public string Reemplazo_Prod { get; set; }
        public string Cilindros { get; set; }
        public string Referencia_Item { get; set; }
        public Nullable<int> Liberacion { get; set; }
        public System.DateTime Fecha_Liberacion { get; set; }
        public string Nro_Pedido_Original { get; set; }
        public System.DateTime Fecha_Pedido_Original { get; set; }
        public string CodCliente { get; set; }
        public string Nombre_Cliente { get; set; }
        public string OC_Cliente { get; set; }
        public string Cod_Producto_Cliente { get; set; }
        public System.DateTime Fecha_Deseada_Cliente { get; set; }
        public int ResponsableComercial { get; set; }
        public int ResponsableCustomer { get; set; }
        public int Categoria { get; set; }
        public int ResponsableConfeccionIng { get; set; }
        public System.DateTime FechaConfeccionIng { get; set; }
        public string IdentificadorCierreIng { get; set; }
        public bool HabilitaCierreLet { get; set; }
        public int ResponsableLiberacionLet { get; set; }
        public System.DateTime FechaLiberacionLet { get; set; }
        public int ResponsableLiberacionFinalIng { get; set; }
        public System.DateTime FechaLiberacionFinalIng { get; set; }
        public string ObservacionesIng { get; set; }
        public bool CerradoIng { get; set; }
        public bool RushOrder { get; set; }
        public bool ReChequeoProducto { get; set; }
        public int TipoImpresora { get; set; }
        public int Impresora { get; set; }
        public int Proveedor { get; set; }
        public int ResponsablePrePrensa { get; set; }
        public int EstadoPrePrensa { get; set; }
        public string ObservacionesPrePrensa { get; set; }
        public System.DateTime FechaRecepcionArte { get; set; }
        public System.DateTime FechaEnvioArte_ET { get; set; }
        public System.DateTime FechaPDFModulo { get; set; }
        public System.DateTime FechaAprobacionPDFCliente { get; set; }
        public System.DateTime FechaEnvioCromalin { get; set; }
        public System.DateTime FechaAprobacionCromalin { get; set; }
        public System.DateTime FechaPDFArmado { get; set; }
        public System.DateTime FechaLiberadoAGrabado { get; set; }
        public System.DateTime FechaSacaPrueba { get; set; }
        public System.DateTime FechaAprobacionSacaPrueba { get; set; }
        public Nullable<int> TipoMaterialPerfil { get; set; }
        public int PerfilImpresion { get; set; }
        public string Colores { get; set; }
        public string ComentariosColores { get; set; }
        public bool CerradoPrePrensa { get; set; }
        public System.DateTime FechaDocumento { get; set; }
        public int Estado { get; set; }
        public System.DateTime FechaStandBy { get; set; }
        public string ObsProducto { get; set; }
        public System.DateTime FechaFinStandBy { get; set; }
        public System.DateTime LastRefreshDate { get; set; }
        public string ObsPerfiles { get; set; }
        public bool ArteModificado { get; set; }
        public System.DateTime FechaArteOriginal { get; set; }
        public string OT { get; set; }
        public int TipoCilindros { get; set; }
        public System.DateTime FechaEntregaNuevosCilindros { get; set; }
        public string CodigosCilindros { get; set; }
        public System.DateTime FechaRecepcionCodigosCilindros { get; set; }
        public System.DateTime FechaPreparacionCilindros { get; set; }
        public System.DateTime FechaLiberacionMontaje { get; set; }
        public System.DateTime FechaRetiroCilindro { get; set; }
        public System.DateTime FechaPromesaProveedorGrabado { get; set; }
        public System.DateTime FechaRecepcionHerramental { get; set; }
        public string ObsHerramental { get; set; }
        public bool NoUsaPrePrensa { get; set; }

        public virtual GpModulosResponsablesDto GPModulosResponsables { get; set; }

        public List<GpEstadosPrPrensaDto> GPEstadosPrePrensa { get; set; }


        public List<GpPerfilesPrePrensaDto> GPPerfilesPrePrensa { get; set; }

        public List<GPImpresorasDto> impresoras { get; set; }

        public List<GPTipoMaterialDto> materiales { get; set; }

        public List<GPEstadosProductosDto> estados { get; set; }

        public bool AcuerdoDirectoProveedor { get; set; }
        public string OC_Proveedor { get; set; }

        public List<GpModulosResponsablesDto> responsables { get; set; }
    }
}
