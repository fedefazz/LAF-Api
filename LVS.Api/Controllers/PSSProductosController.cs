using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Description;
using LVS.Model;
using LVS.Dtos;
using AutoMapper;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq.Dynamic;
using System.Web.Http.Results;
using LVS.Api.Models;
using System.Data.Entity.Validation;

namespace LVS.Api.Controllers
{
    public class PSSProductosController : ApiController
    {
        private LAFScrapEntities db = new LAFScrapEntities();

        [HttpGet]
        [ResponseType(typeof(CSP_LISTAR_SEGUMIENTO_PRODUCTO_Result))]
        [Route("api/PSSProductos/getProductos/")]
        public async Task<IHttpActionResult> getProductos(string filter = null)



        {
            

            




            List<CSP_LISTAR_SEGUMIENTO_PRODUCTO_Result> productos = db.CSP_LISTAR_SEGUMIENTO_PRODUCTO().Select(z => new CSP_LISTAR_SEGUMIENTO_PRODUCTO_Result
            {
                Tipo_Adm = z.Tipo_Adm,
                Cod_Producto = z.Cod_Producto,
                Descripcion = z.Descripcion,
                Unid_Medida = z.Unid_Medida,
                Dias = z.Dias,
                Fecha_Final = z.Fecha_Final,
                Fecha_Inicial = z.Fecha_Inicial,
                RushOrder = z.RushOrder,
                SemaforoCustomer = z.SemaforoCustomer,
                SemaforoGeneral = z.SemaforoGeneral,
                SemaforoIngenieria = z.SemaforoIngenieria,
                SemaforoPreprensa = z.SemaforoPreprensa,
                DiasStandby = z.DiasStandby,
                CumpleSLA = z.CumpleSLA,
                Estado = z.Estado,
                FechaRecepcionHerramental = z.FechaRecepcionHerramental,
                LeyendaSLA = z.LeyendaSLA,
                MensajeSemaforoCustomer = z.MensajeSemaforoCustomer,
                MensajeSemaforoGeneral = z.MensajeSemaforoGeneral,
                MensajeSemaforoIngenieria = z.MensajeSemaforoIngenieria,
                MensajeSemaforoPreprensa = z.MensajeSemaforoPreprensa,
                MensajeSemaforoHerramental = z.MensajeSemaforoHerramental,
                SemaforoHerramental = z.SemaforoHerramental,
                TipoImpresora = z.TipoImpresora,
                ArteModificado = z.ArteModificado,
                FechaArteOriginal = z.FechaArteOriginal,
                CodigosCilindros = z.CodigosCilindros,
                FechaEntregaNuevosCilindros = z.FechaEntregaNuevosCilindros,
                FechaLiberacionMontaje = z.FechaLiberacionMontaje,
                FechaPreparacionCilindros = z.FechaPreparacionCilindros,
                FechaPromesaProveedorGrabado = z.FechaPromesaProveedorGrabado,
                FechaRecepcionCodigosCilindros = z.FechaRecepcionCodigosCilindros,
                FechaRetiroCilindro = z.FechaRetiroCilindro,
                ObsHerramental = z.ObsHerramental,
                ObsPerfiles = z.ObsPerfiles,
                ResponsableComercial = z.ResponsableComercial,
                OT = z.OT,
                TipoCilindros = z.TipoCilindros,
                LastRefreshDate = z.LastRefreshDate,
                FechaAprobacionCromalin = z.FechaAprobacionCromalin,
                FechaAprobacionPDFCliente = z.FechaAprobacionPDFCliente,
                FechaAprobacionSacaPrueba = z.FechaAprobacionSacaPrueba,
                FechaDocumento = z.FechaDocumento,
                FechaEnvioArte_ET = z.FechaEnvioArte_ET,
                FechaEnvioCromalin = z.FechaEnvioCromalin,
                FechaFinStandBy = z.FechaFinStandBy,
                FechaLiberadoAGrabado = z.FechaLiberadoAGrabado,
                FechaLiberacionFinalIng = z.FechaLiberacionFinalIng,
                FechaLiberacionLet = z.FechaLiberacionLet,
                FechaPDFArmado = z.FechaPDFArmado,
                FechaPDFModulo = z.FechaPDFModulo,
                FechaRecepcionArte = z.FechaRecepcionArte,
                FechaSacaPrueba = z.FechaSacaPrueba,
                ResponsableCustomer = z.ResponsableCustomer,
                ResponsableConfeccionIng = z.ResponsableConfeccionIng,
                ResponsableLiberacionFinalIng = z.ResponsableLiberacionFinalIng,
                ResponsableLiberacionLet = z.ResponsableLiberacionLet,
                ResponsablePrePrensa = z.ResponsablePrePrensa,
                Categoria = z.Categoria,
                ObservacionesIng = z.ObservacionesIng,
                ObservacionesPrePrensa = z.ObservacionesPrePrensa,
                CerradoIng = z.CerradoIng,
                CerradoPrePrensa = z.CerradoPrePrensa,
                Cilindros = z.Cilindros,
                CodCliente = z.CodCliente,
                Cod_Producto_Cliente = z.Cod_Producto_Cliente,
                Colores = z.Colores,
                ComentariosColores = z.ComentariosColores,
                FechaConfeccionIng = z.FechaConfeccionIng,
                EstadoPrePrensa = z.EstadoPrePrensa,
                FechaStandBy = z.FechaStandBy,
                Fecha_Creacion = z.Fecha_Creacion,
                Fecha_Deseada_Cliente = z.Fecha_Deseada_Cliente,
                Fecha_Liberacion = z.Fecha_Liberacion,
                Fecha_Pedido_Original = z.Fecha_Pedido_Original,
                HabilitaCierreLet = z.HabilitaCierreLet,
                IdentificadorCierreIng = z.IdentificadorCierreIng,
                Impresora = z.Impresora,
                Liberacion = z.Liberacion,
                Nombre_Cliente = z.Nombre_Cliente,
                Nro_Pedido_Original = z.Nro_Pedido_Original,
                ObsProducto = z.ObsProducto,
                OC_Cliente = z.OC_Cliente,
                PerfilImpresion = z.PerfilImpresion,
                Proveedor = z.Proveedor,
                ReChequeoProducto = z.ReChequeoProducto,
                Reemplazo_Prod = z.Reemplazo_Prod,
                Referencia_Item = z.Referencia_Item,
                NoUsaPrePrensa = z.NoUsaPrePrensa,






            }).ToList();
            

            if (filter?.Length > 0 && filter != "undefined")
            {
                productos = productos.Where(p => p.Cod_Producto.Contains(filter) || p.Descripcion.Contains(filter)) // Coincidencia parcial
                               .ToList();
            }


            


            return Ok(productos);
        }




        // GET: api/getProducto/5
        [HttpGet]
        [Route("api/PSSProductos/getProducto")]
        [ResponseType(typeof(ProductoDto))]
        public async Task<IHttpActionResult> getProducto(string Cod_Producto)
        {
            GPProductos GpProducto = await db.GPProductos.FindAsync(Cod_Producto);
            if (GpProducto == null)
            {
                return NotFound();
            }


            List<GPEstadosProductos> estados = db.GPEstadosProductos.ToList();
            List<GPEstadosProductosDto> estadosForSelect = new List<GPEstadosProductosDto>();
            foreach (var estadoItem in estados)
            {
                var _estado = new GPEstadosProductosDto
                {
                    Estado = estadoItem.Estado,
                    Habilitado = estadoItem.Habilitado,
                    IDEstadoProducto = estadoItem.IDEstadoProducto
                };
                estadosForSelect.Add(_estado);

            }


            List<GPModulosResponsables> responsables = db.GPModulosResponsables.ToList();



            List<GpModulosResponsablesDto> ResponsablesForSelect = new List<GpModulosResponsablesDto>();
            foreach (var ResponsableItem in responsables)
            {
                var _Responsables = new GpModulosResponsablesDto
                {
                    Id = ResponsableItem.Id,
                    IdResponsable = ResponsableItem.IdResponsable,
                    IdModuloProducto = ResponsableItem.IdModuloProducto,

                    GPResponsables = new GpResponsablesDto
                    {
                        Nombre = ResponsableItem.GPResponsables.Nombre,
                        Apellido = ResponsableItem.GPResponsables.Apellido,
                        Habilitado = ResponsableItem.GPResponsables.Habilitado,
                        IdResponsable = ResponsableItem.GPResponsables.IdResponsable,
                    }

                };
                ResponsablesForSelect.Add(_Responsables);

            }

            List<GPEstadosPrePrensa> estadosPrePrensa = db.GPEstadosPrePrensa.ToList();
            List<GpEstadosPrPrensaDto> estadosPrePrensaForSelect = new List<GpEstadosPrPrensaDto>();
            foreach (var _estadosPrePrensa in estadosPrePrensa)
            {

                var estadoPrePrensa = new GpEstadosPrPrensaDto
                {
                    Descripcion = _estadosPrePrensa.Descripcion,
                    IdEstadoPrePrensa = _estadosPrePrensa.IdEstadoPrePrensa,
                    Orden = _estadosPrePrensa.Orden,
                    Habilitado = _estadosPrePrensa.Habilitado,
                };


                estadosPrePrensaForSelect.Add(estadoPrePrensa);

            }

            List<GPPerfilesPrePrensa> perfilesPrePrensa = db.GPPerfilesPrePrensa.ToList();
            List<GpPerfilesPrePrensaDto> perfilesPrePrensaForSelect = new List<GpPerfilesPrePrensaDto>();
            foreach (var _perfilesPrePrensa in perfilesPrePrensa)
            {

                var perfilPrePrensa = new GpPerfilesPrePrensaDto
                {
                    Descripcion = _perfilesPrePrensa.Descripcion,
                    IdPerfilPrePrensa = _perfilesPrePrensa.IdPerfilPrePrensa,
                    Habilitado = _perfilesPrePrensa.Habilitado,
                    IdImpresora = _perfilesPrePrensa.IdImpresora,
                    IdProveedor = _perfilesPrePrensa.IdProveedor,
                    IdTipoMaterial = _perfilesPrePrensa.IdTipoMaterial,
                };


                perfilesPrePrensaForSelect.Add(perfilPrePrensa);

            }

            List<GPImpresoras> impresoras = db.GPImpresoras.ToList();
            List<GPImpresorasDto> impresorasForSelect = new List<GPImpresorasDto>();
            foreach (var _impresoras in impresoras)
            {

                var impresora = new GPImpresorasDto
                {
                    Habilitado = _impresoras.Habilitado,
                    IdImpresora = _impresoras.IdImpresora,
                    IdTipoImpresora = _impresoras.IdTipoImpresora,
                    NombreImpresora = _impresoras.NombreImpresora,


                };


                    impresorasForSelect.Add(impresora);

            }

            List<GPTipoMaterial> materiales = db.GPTipoMaterial.ToList();
            List<GPTipoMaterialDto> materialesForSelect = new List<GPTipoMaterialDto>();
            foreach (var _materiales in materiales)
            {

                var material = new GPTipoMaterialDto
                {
                    Descripcion = _materiales.Descripcion,
                    Habilitado = _materiales.Habilitado,
                    IdTipoMaterial = _materiales.IdTipoMaterial,
               };


                materialesForSelect.Add(material);

            }

            ProductoDto producto = new ProductoDto
            {
                Cod_Producto = GpProducto.Cod_Producto,
                Descripcion = GpProducto.Descripcion,
                Unid_Medida = GpProducto.Unid_Medida,
                Fecha_Creacion = GpProducto.Fecha_Creacion,
                Tipo_Adm = GpProducto.Tipo_Adm,
                Reemplazo_Prod = GpProducto.Reemplazo_Prod,
                Cilindros = GpProducto.Cilindros,
                Referencia_Item = GpProducto.Referencia_Item,
                Liberacion = GpProducto.Liberacion,
                Fecha_Liberacion = GpProducto.Fecha_Liberacion,
                Nro_Pedido_Original = GpProducto.Nro_Pedido_Original,
                Fecha_Pedido_Original = GpProducto.Fecha_Pedido_Original,
                CodCliente = GpProducto.CodCliente,
                Nombre_Cliente = GpProducto.Nombre_Cliente,
                OC_Cliente = GpProducto.OC_Cliente,
                impresoras = impresorasForSelect,
                materiales = materialesForSelect,
                Cod_Producto_Cliente = GpProducto.Cod_Producto_Cliente,
                Fecha_Deseada_Cliente = GpProducto.Fecha_Deseada_Cliente,
                ResponsableCustomer = GpProducto.ResponsableCustomer,
                Categoria = GpProducto.Categoria,
                ResponsableConfeccionIng = GpProducto.ResponsableConfeccionIng,
                FechaConfeccionIng = GpProducto.FechaConfeccionIng,
                IdentificadorCierreIng = GpProducto.IdentificadorCierreIng,
                HabilitaCierreLet = GpProducto.HabilitaCierreLet,
                ResponsableLiberacionLet = GpProducto.ResponsableLiberacionLet,
                FechaLiberacionLet = GpProducto.FechaLiberacionLet,
                ResponsableLiberacionFinalIng = GpProducto.ResponsableLiberacionFinalIng,
                FechaLiberacionFinalIng = GpProducto.FechaLiberacionFinalIng,
                ObservacionesIng = GpProducto.ObservacionesIng,
                TipoMaterialPerfil = GpProducto.TipoMaterialPerfil ?? 1,
                CerradoIng = GpProducto.CerradoIng,
                RushOrder = GpProducto.RushOrder,
                ReChequeoProducto = GpProducto.ReChequeoProducto,
                TipoImpresora = GpProducto.TipoImpresora,
                Impresora = GpProducto.Impresora,
                Proveedor = GpProducto.Proveedor,
                ResponsablePrePrensa = GpProducto.ResponsablePrePrensa,
                EstadoPrePrensa = GpProducto.EstadoPrePrensa,
                ObservacionesPrePrensa = GpProducto.ObservacionesPrePrensa,
                FechaRecepcionArte = GpProducto.FechaRecepcionArte,
                FechaEnvioArte_ET = GpProducto.FechaEnvioArte_ET,
                FechaPDFModulo = GpProducto.FechaPDFModulo,
                FechaAprobacionPDFCliente = GpProducto.FechaAprobacionPDFCliente,
                FechaEnvioCromalin = GpProducto.FechaEnvioCromalin,
                FechaAprobacionCromalin = GpProducto.FechaAprobacionCromalin,
                FechaPDFArmado = GpProducto.FechaPDFArmado,
                FechaLiberadoAGrabado = GpProducto.FechaLiberadoAGrabado,
                FechaSacaPrueba = GpProducto.FechaSacaPrueba,
                FechaAprobacionSacaPrueba = GpProducto.FechaAprobacionSacaPrueba,
                PerfilImpresion = GpProducto.PerfilImpresion,
                Colores = GpProducto.Colores,
                ComentariosColores = GpProducto.ComentariosColores,
                FechaRecepcionHerramental = GpProducto.FechaRecepcionHerramental,
                FechaDocumento = GpProducto.FechaDocumento,
                FechaStandBy = GpProducto.FechaStandBy,
                ObsProducto = GpProducto.ObsProducto,
                estados = estadosForSelect,
                responsables = ResponsablesForSelect,
                FechaFinStandBy = GpProducto.FechaFinStandBy,
                Estado = GpProducto.Estado,
                CerradoPrePrensa = GpProducto.CerradoPrePrensa,
                ArteModificado = GpProducto.ArteModificado,
                FechaArteOriginal = GpProducto.FechaArteOriginal,
                CodigosCilindros = GpProducto.CodigosCilindros,
                FechaEntregaNuevosCilindros = GpProducto.FechaEntregaNuevosCilindros,
                FechaLiberacionMontaje = GpProducto.FechaLiberacionMontaje,
                FechaPreparacionCilindros = GpProducto.FechaPreparacionCilindros,
                FechaPromesaProveedorGrabado = GpProducto.FechaPromesaProveedorGrabado,
                FechaRecepcionCodigosCilindros = GpProducto.FechaRecepcionCodigosCilindros,
                FechaRetiroCilindro = GpProducto.FechaRetiroCilindro,
                ObsHerramental = GpProducto.ObsHerramental,
                ObsPerfiles = GpProducto.ObsPerfiles,
                ResponsableComercial = GpProducto.ResponsableComercial,
                OT = GpProducto.OT,
                TipoCilindros = GpProducto.TipoCilindros,
                LastRefreshDate = GpProducto.LastRefreshDate,
                GPModulosResponsables = new GpModulosResponsablesDto
                {
                    IdModuloProducto = GpProducto.GPModulosResponsables.IdModuloProducto,
                    IdResponsable = GpProducto.GPModulosResponsables.IdResponsable,
                    Id = GpProducto.GPModulosResponsables.Id,
                    GPResponsables = new GpResponsablesDto
                    {
                        Nombre = GpProducto.GPModulosResponsables.GPResponsables.Nombre,
                        Apellido = GpProducto.GPModulosResponsables.GPResponsables.Apellido,
                        Habilitado = GpProducto.GPModulosResponsables.GPResponsables.Habilitado,
                        IdResponsable = GpProducto.GPModulosResponsables.GPResponsables.IdResponsable

                    }

                },
                GPEstadosPrePrensa = estadosPrePrensaForSelect,
                GPPerfilesPrePrensa = perfilesPrePrensaForSelect,
                NoUsaPrePrensa = GpProducto.NoUsaPrePrensa,
                AcuerdoDirectoProveedor = GpProducto.AcuerdoDirectoProveedor,
                OC_Proveedor = GpProducto.OC_Proveedor
            };


            return Ok(producto);
        }


        // PUT: api/PSSOrigenesScraps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> putProducto(string id, GPProductos producto)
        {


            producto.Reemplazo_Prod = producto.Reemplazo_Prod ?? "";
            producto.Cilindros = producto.Cilindros ?? "";
            producto.Referencia_Item = producto.Referencia_Item ?? "";
            producto.Nro_Pedido_Original = producto.Nro_Pedido_Original ?? "";
            producto.OC_Cliente = producto.OC_Cliente ?? "";
            producto.Cod_Producto_Cliente = producto.Cod_Producto_Cliente ?? "";
            producto.ObservacionesPrePrensa = producto.ObservacionesPrePrensa ?? "";
            producto.Colores = producto.Colores ?? "";
            producto.ComentariosColores = producto.ComentariosColores ?? "";
            producto.ObsProducto = producto.ObsProducto ?? "";
            producto.ObsPerfiles = producto.ObsPerfiles ?? "";
            producto.OT = producto.OT ?? "";
            producto.CodigosCilindros = producto.CodigosCilindros ?? "";
            producto.ObsHerramental = producto.ObsHerramental ?? "";
            producto.Tipo_Adm = producto.Tipo_Adm ?? "";
            producto.ObservacionesIng = producto.ObservacionesIng ?? "";
            producto.CodCliente = producto.CodCliente ?? "";
            producto.Nombre_Cliente = producto.Nombre_Cliente ?? "";
            producto.Unid_Medida = producto.Unid_Medida ?? "";
            producto.OC_Proveedor = producto.OC_Proveedor ?? "";

            // Ajusta DateTimeKind de las fechas si es necesario
            producto.FechaArteOriginal = EnsureValidDateTime(producto.FechaArteOriginal);
            producto.FechaEntregaNuevosCilindros = EnsureValidDateTime(producto.FechaEntregaNuevosCilindros);
            producto.FechaLiberacionMontaje = EnsureValidDateTime(producto.FechaLiberacionMontaje);
            producto.FechaPreparacionCilindros = EnsureValidDateTime(producto.FechaPreparacionCilindros);
            producto.FechaPromesaProveedorGrabado = EnsureValidDateTime(producto.FechaPromesaProveedorGrabado);
            producto.FechaRecepcionCodigosCilindros = EnsureValidDateTime(producto.FechaRecepcionCodigosCilindros);
            producto.FechaRetiroCilindro = EnsureValidDateTime(producto.FechaRetiroCilindro);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var productoInDb = await db.GPProductos
                    .Include(c => c.GPModulosResponsables)
                    .FirstOrDefaultAsync(c => c.Cod_Producto == producto.Cod_Producto);

                //if (productoInDb == null)
                //{
                //    return NotFound();
                //}


                ////var nuevoModuloresponsable = new GPModulosResponsables();
                ////nuevoModuloresponsable.Id = producto.GPModulosResponsables1.Id;
                ////nuevoModuloresponsable.IdModuloProducto = producto.GPModulosResponsables1.IdModuloProducto;
                ////nuevoModuloresponsable.IdResponsable = producto.GPModulosResponsables1.IdModuloProducto;
                ////var nuevoResponsables = new GPResponsables();
                ////nuevoResponsables.Apellido = producto.GPModulosResponsables1.GPResponsables.Apellido;
                ////nuevoResponsables.Nombre = producto.GPModulosResponsables1.GPResponsables.Nombre;
                ////nuevoResponsables.IdResponsable = producto.GPModulosResponsables1.GPResponsables.IdResponsable;
                ////nuevoModuloresponsable.GPResponsables = nuevoResponsables;
                ////productoInDb.GPModulosResponsables1 = nuevoModuloresponsable;

                //// Actualiza las propiedades del producto en la base de datos

                if (productoInDb == null)
                {
                    return NotFound();
                }
                db.Entry(productoInDb).CurrentValues.SetValues(producto);

                // Actualiza el responsable del producto
                //productoInDb.GPModulosResponsables1.IdResponsable = producto.GPModulosResponsables1.IdResponsable;

                await db.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                // Log or handle the error appropriately
                // Logger.LogError(fullErrorMessage);

                return InternalServerError(new Exception(fullErrorMessage, ex));
            }
            catch (Exception ex)
            {
                // Maneja la excepción aquí (puedes registrarla, devolver un código de estado específico, etc.)
                
                
                
                
                
                
                
                
                
                return InternalServerError(ex);
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        private DateTime EnsureValidDateTime(DateTime dateTime)
        {
            // Ajusta DateTimeKind según tu configuración (ejemplo con DateTimeKind.Utc)
            return dateTime == DateTime.MinValue ? DateTime.UtcNow : DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }


        [HttpGet]
        [ResponseType(typeof(CSP_GET_SEGUIMIENTO_PRODUCTO_X_CODIGO_Result))]
        [Route("api/PSSProductos/getProductoPorCodigo/")]
        public async Task<IHttpActionResult> getProductoPorCodigo(string Cod_Producto)
        {


            List<CSP_GET_SEGUIMIENTO_PRODUCTO_X_CODIGO_Result> producto = db.CSP_GET_SEGUIMIENTO_PRODUCTO_X_CODIGO(Cod_Producto).Select(z => new CSP_GET_SEGUIMIENTO_PRODUCTO_X_CODIGO_Result
            {
                Tipo_Adm = z.Tipo_Adm,
                Cod_Producto = z.Cod_Producto,
                Descripcion = z.Descripcion,
                SemaforoCustomer = z.SemaforoCustomer,
                SemaforoGeneral = z.SemaforoGeneral,
                SemaforoIngenieria = z.SemaforoIngenieria,
                SemaforoPreprensa = z.SemaforoPreprensa,
                DiasCustomer = z.DiasCustomer,
                DiasGeneral = z.DiasGeneral,
                DiasIngenieria = z.DiasIngenieria,
                DiasHerramental = z.DiasHerramental,
                DiasPrePrensa = z.DiasPrePrensa,
                SemaforoHerramental = z.SemaforoHerramental,
            }).ToList();
            
            return Ok(producto);
     }


        [HttpGet]
        [ResponseType(typeof(CSP_DASHBOARD_SLA_PRODUCTOS_Result))]
        [Route("api/PSSProductos/getDataForDashboard/")]
        public async Task<IHttpActionResult> getDataForDashboard()
        {

            List<CSP_DASHBOARD_SLA_PRODUCTOS_Result> producto = db.CSP_DASHBOARD_SLA_PRODUCTOS().Select(z => new CSP_DASHBOARD_SLA_PRODUCTOS_Result
            {
                SLA_SCP = z.SLA_SCP,
                QTY_SCP = z.QTY_SCP,
                BEST_SCP = z.BEST_SCP,
                WORST_SCP = z.WORST_SCP,
                SLA_SND = z.SLA_SND,
                QTY_SND = z.QTY_SND,
                BEST_SND = z.BEST_SND,
                WORST_SND = z.WORST_SND,
                SLA_SNP = z.SLA_SNP,
                BEST_SNP = z.BEST_SNP,
                SLA_SNPS = z.SLA_SNPS,
                BEST_SNPS = z.BEST_SNPS,
                PERIODO = z.PERIODO,
                QTY_SNP = z.QTY_SNP,
                QTY_SNPS = z.QTY_SNPS,
                TipoImpresora = z.TipoImpresora,
                WORST_SNP = z.WORST_SNP,
                WORST_SNPS = z.WORST_SNPS,

            }).ToList();

            return Ok(producto);



        }



        [HttpGet]
        [ResponseType(typeof(CSP_DASHBOARD_SLA_PRODUCTOS_TOTAL_Result))]
        [Route("api/PSSProductos/getDataForDashboard2/")]
        public async Task<IHttpActionResult> getDataForDashboard2()
        {

            List<CSP_DASHBOARD_SLA_PRODUCTOS_TOTAL_Result> producto = db.CSP_DASHBOARD_SLA_PRODUCTOS_TOTAL().Select(z => new CSP_DASHBOARD_SLA_PRODUCTOS_TOTAL_Result
            {
                SLA_FLEXO = z.SLA_FLEXO,
                SLA_HUECO = z.SLA_HUECO,
                BEST_FLEXO = z.BEST_FLEXO,
                BEST_HUECO = z.BEST_HUECO,
                QTY_FLEXO = z.QTY_FLEXO,
                QTY_HUECO = z.QTY_HUECO,
                WORST_FLEXO = z.WORST_FLEXO,
                WORST_HUECO = z.WORST_HUECO,
                PERIODO = z.PERIODO,


            }).ToList();

            return Ok(producto);



        }

        [HttpGet]
        [ResponseType(typeof(CSP_GPPRODUCTOS_KPI_PREPRENSA_DIAS_ENVIOET_Result))]
        [Route("api/PSSProductos/getDataForDashboardProductosKpiPrePrensaDias/")]
        public async Task<IHttpActionResult> getDataForDashboardProductosKpiPrePrensaDias()
        {

            List<CSP_GPPRODUCTOS_KPI_PREPRENSA_DIAS_ENVIOET_Result> producto = db.CSP_GPPRODUCTOS_KPI_PREPRENSA_DIAS_ENVIOET().Select(z => new CSP_GPPRODUCTOS_KPI_PREPRENSA_DIAS_ENVIOET_Result
            {
                QTY_DIAS_EnvioArteET = z.QTY_DIAS_EnvioArteET,
                Periodo = z.Periodo,



            }).ToList();

            return Ok(producto);



        }

        [HttpGet]
        [ResponseType(typeof(CSP_GPPRODUCTOS_KPI_PREPRENSA_LIBGRABADOVSRECEPCIONHERRAMENTAL_X_TIPOIMPRESORA_Result))]
        [Route("api/PSSProductos/getDataForDashboardProductosKpiPrePrensaDLibgrabado/")]
        public async Task<IHttpActionResult> getDataForDashboardProductosKpiPrePrensaDLibgrabado()
        {

            List<CSP_GPPRODUCTOS_KPI_PREPRENSA_LIBGRABADOVSRECEPCIONHERRAMENTAL_X_TIPOIMPRESORA_Result> producto = db.CSP_GPPRODUCTOS_KPI_PREPRENSA_LIBGRABADOVSRECEPCIONHERRAMENTAL_X_TIPOIMPRESORA().Select(z => new CSP_GPPRODUCTOS_KPI_PREPRENSA_LIBGRABADOVSRECEPCIONHERRAMENTAL_X_TIPOIMPRESORA_Result
            {

                AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Flexo = z.AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Flexo,
                AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Hueco = z.AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Hueco,
                AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_SinAsignar = z.AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_SinAsignar,
                MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Flexo = z.MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Flexo,
                MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Hueco = z.MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Hueco,
                MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_SinAsignar = z.MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_SinAsignar,
                MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Flexo = z.MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Flexo,
                MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Hueco = z.MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Hueco,
                MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_SinAsignar = z.MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_SinAsignar,
                QTY_LiberadoGrabadoVsRecepcionHerramental_SinAsignar = z.QTY_LiberadoGrabadoVsRecepcionHerramental_SinAsignar,
                PERIODO = z.PERIODO,
                QTY_LiberadoGrabadoVsRecepcionHerramental_Flexo = z.QTY_LiberadoGrabadoVsRecepcionHerramental_Flexo,
                QTY_LiberadoGrabadoVsRecepcionHerramental_Hueco = z.QTY_LiberadoGrabadoVsRecepcionHerramental_Hueco,




            }).ToList();

            return Ok(producto);



        }


        [HttpGet]
        [ResponseType(typeof(CSP_GPPRODUCTOS_KPI_PREPRENSA_LIBGRABADOVSRECEPCIONHERRAMENTAL_X_PROVEEDOR_Result))]
        [Route("api/PSSProductos/getDataForDashboardProductosKpiPrePrensaDLibgrabadoProveedor/")]
        public async Task<IHttpActionResult> getDataForDashboardProductosKpiPrePrensaDLibgrabadoProveedor()
        {

            List<CSP_GPPRODUCTOS_KPI_PREPRENSA_LIBGRABADOVSRECEPCIONHERRAMENTAL_X_PROVEEDOR_Result> producto = db.CSP_GPPRODUCTOS_KPI_PREPRENSA_LIBGRABADOVSRECEPCIONHERRAMENTAL_X_PROVEEDOR().Select(z => new CSP_GPPRODUCTOS_KPI_PREPRENSA_LIBGRABADOVSRECEPCIONHERRAMENTAL_X_PROVEEDOR_Result
            {

                AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Flexo = z.AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Flexo,
                AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Longo_Flexo = z.AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Longo_Flexo,
                AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Lynch_Flexo = z.AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Lynch_Flexo,
                MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Flexo = z.MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Flexo,
                MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Longo_Flexo = z.MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Longo_Flexo,
                MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Lynch_Flexo = z.MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Lynch_Flexo,
                MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Flexo = z.MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Flexo,
                MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Longo_Flexo = z.MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Longo_Flexo,
                MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Lynch_Flexo = z.MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Lynch_Flexo,
                QTY_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Flexo = z.QTY_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Flexo,
                QTY_LiberadoGrabadoVsRecepcionHerramental_Longo_Flexo = z.QTY_LiberadoGrabadoVsRecepcionHerramental_Longo_Flexo,
                QTY_LiberadoGrabadoVsRecepcionHerramental_Lynch_Flexo = z.QTY_LiberadoGrabadoVsRecepcionHerramental_Lynch_Flexo,
                AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Hueco = z.AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Hueco,
                AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Longo_Hueco = z.AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Longo_Hueco,
                AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Lynch_Hueco = z.AVG_DAYS_LiberadoGrabadoVsRecepcionHerramental_Lynch_Hueco,
                MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Hueco = z.MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Hueco,
                MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Longo_Hueco = z.MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Longo_Hueco,
                MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Lynch_Hueco = z.MAX_DAYS_LiberadoGrabadoVsRecepcionHerramental_Lynch_Hueco,
                MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Hueco = z.MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Hueco,
                MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Longo_Hueco = z.MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Longo_Hueco,
                MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Lynch_Hueco = z.MIN_DAYS_LiberadoGrabadoVsRecepcionHerramental_Lynch_Hueco,
                QTY_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Hueco = z.QTY_LiberadoGrabadoVsRecepcionHerramental_Bosisio_Hueco,
                QTY_LiberadoGrabadoVsRecepcionHerramental_Longo_Hueco = z.QTY_LiberadoGrabadoVsRecepcionHerramental_Longo_Hueco,
                QTY_LiberadoGrabadoVsRecepcionHerramental_Lynch_Hueco = z.QTY_LiberadoGrabadoVsRecepcionHerramental_Lynch_Hueco,
                
                
                
                PERIODO = z.PERIODO



            }).ToList();

            return Ok(producto);



        }


        [HttpGet]
        [ResponseType(typeof(CSP_GPPRODUCTOS_KPI_PREPRENSA_QTY_X_RESPONSABLE_Result))]
        [Route("api/PSSProductos/getDataForDashboardProductosKpiPrePrensaResponsable/")]
        public async Task<IHttpActionResult> getDataForDashboardProductosKpiPrePrensaResponsable()
        {

            List<CSP_GPPRODUCTOS_KPI_PREPRENSA_QTY_X_RESPONSABLE_Result> producto = db.CSP_GPPRODUCTOS_KPI_PREPRENSA_QTY_X_RESPONSABLE().Select(z => new CSP_GPPRODUCTOS_KPI_PREPRENSA_QTY_X_RESPONSABLE_Result
            {
                MAX_DAYS_10 = z.MAX_DAYS_10,
                MAX_DAYS_17 = z.MAX_DAYS_17,
                MAX_DAYS_18 = z.MAX_DAYS_18,
                MIN_DAYS_10 = z.MIN_DAYS_10,
                MIN_DAYS_17 = z.MIN_DAYS_17,
                MIN_DAYS_18 = z.MIN_DAYS_18,
                QTY_10 = z.QTY_10,
                QTY_17 = z.QTY_17,
                QTY_18 = z.QTY_18,
                PERIODO = z.PERIODO,
                SLA_DAYS_10 = z.SLA_DAYS_10,
                SLA_DAYS_17 = z.SLA_DAYS_17,
                SLA_DAYS_18 = z.SLA_DAYS_18,
            }).ToList();

            return Ok(producto);



        }




        [HttpGet]
        [ResponseType(typeof(CSP_GPPRODUCTOS_KPI_INGENIERIA_GENERAL_Result))]
        [Route("api/PSSProductos/getDataForDashboardProductosKpiIngenieriaGeneral/")]
        public async Task<IHttpActionResult> getDataForDashboardProductosKpiIngenieriaGeneral()
        {

            List<CSP_GPPRODUCTOS_KPI_INGENIERIA_GENERAL_Result> producto = db.CSP_GPPRODUCTOS_KPI_INGENIERIA_GENERAL().Select(z => new CSP_GPPRODUCTOS_KPI_INGENIERIA_GENERAL_Result
            {
                AVG_DAYS_DocumentoVSPedido = z.AVG_DAYS_DocumentoVSPedido,
                AVG_DAYS_FechaConfeccionVSLiberacionTec = z.AVG_DAYS_FechaConfeccionVSLiberacionTec,
                AVG_DAYS_LiberacionTecVsDocumento = z.AVG_DAYS_LiberacionTecVsDocumento,
                MAX_DAYS_DocumentoVSPedido = z.MAX_DAYS_DocumentoVSPedido,
                MAX_DAYS_FechaConfeccionVSLiberacionTec = z.MAX_DAYS_FechaConfeccionVSLiberacionTec,
                MAX_DAYS_LiberacionFinalVsLiberacionTec = z.MAX_DAYS_LiberacionFinalVsLiberacionTec,
                MAX_DAYS_LiberacionTecVsDocumento = z.MAX_DAYS_LiberacionTecVsDocumento,
                MIN_DAYS_DocumentoVSPedido = z.MIN_DAYS_DocumentoVSPedido,
                MIN_DAYS_FechaConfeccionVSLiberacionTec = z.MIN_DAYS_FechaConfeccionVSLiberacionTec,
                MIN_DAYS_LiberacionFinalVsLiberacionTec = z.MIN_DAYS_LiberacionFinalVsLiberacionTec,
                MIN_DAYS_LiberacionTecVsDocumento = z.MIN_DAYS_LiberacionTecVsDocumento,
                PERIODO = z.PERIODO,
                QTY_DocumentoVSPedido = z.QTY_DocumentoVSPedido,
                QTY_FechaConfeccionVSLiberacionTec = z.QTY_FechaConfeccionVSLiberacionTec,
                QTY_LiberacionFinalVsLiberacionTec = z.QTY_LiberacionFinalVsLiberacionTec,
                QTY_LiberacionTecVsDocumento = z.QTY_LiberacionTecVsDocumento,
                AVG_DAYS_LiberacionFinalVsLiberacionTec = z.AVG_DAYS_LiberacionFinalVsLiberacionTec,


            }).ToList();

            return Ok(producto);



        }

        [HttpGet]
        [ResponseType(typeof(CSP_GPPRODUCTOS_KPI_PREPRENSA_QTY_X_TIPOIMPRESORA_Result))]
        [Route("api/PSSProductos/getDataForDashboardProductosKpiPrePrensaImpresora/")]
        public async Task<IHttpActionResult> getDataForDashboardProductosKpiPrePrensaImpresora()
        {

            List<CSP_GPPRODUCTOS_KPI_PREPRENSA_QTY_X_TIPOIMPRESORA_Result> producto = db.CSP_GPPRODUCTOS_KPI_PREPRENSA_QTY_X_TIPOIMPRESORA().Select(z => new CSP_GPPRODUCTOS_KPI_PREPRENSA_QTY_X_TIPOIMPRESORA_Result
            {
               QTY_SinAsignar = z.QTY_SinAsignar,
               PERIODO = z.PERIODO,
               QTY_Flexo = z.QTY_Flexo,
                QTY_Hueco = z.QTY_Hueco,
               


            }).ToList();

            return Ok(producto);



        }

        [HttpGet]
        [ResponseType(typeof(CSP_GPPRODUCTOS_KPI_PREPRENSA_QTY_X_PROVEEDOR_Result))]
        [Route("api/PSSProductos/getDataForDashboardProductosKpiPrePrensaProveedor/")]
        public async Task<IHttpActionResult> getDataForDashboardProductosKpiPrePrensaProveedor()
        {

            List<CSP_GPPRODUCTOS_KPI_PREPRENSA_QTY_X_PROVEEDOR_Result> producto = db.CSP_GPPRODUCTOS_KPI_PREPRENSA_QTY_X_PROVEEDOR().Select(z => new CSP_GPPRODUCTOS_KPI_PREPRENSA_QTY_X_PROVEEDOR_Result
            {
                QTY_SinAsignar = z.QTY_SinAsignar,
                PERIODO = z.PERIODO,
                QTY_Bosisio = z.QTY_Bosisio,
                QTY_Longo = z.QTY_Longo,
                QTY_Lynch = z.QTY_Lynch,
                



            }).ToList();

            return Ok(producto);



        }





        [HttpGet]
        [ResponseType(typeof(CSP_GPPRODUCTOS_EXCEL_EXPORT_Result))]
        [Route("api/PSSProductos/getProductoParaExcel/")]
        public async Task<IHttpActionResult> getProductoParaExcel(int estado,string dateDesde, string dateHasta)
        {

            DateTime fechaDesde = Convert.ToDateTime(dateDesde);
            DateTime fechaHasta = Convert.ToDateTime(dateHasta);

            List<CSP_GPPRODUCTOS_EXCEL_EXPORT_Result> scrapExcel = db.CSP_GPPRODUCTOS_EXCEL_EXPORT(fechaDesde.Date, fechaHasta.Date, estado).Select(z => new CSP_GPPRODUCTOS_EXCEL_EXPORT_Result
            {
                ArteModificado = z.ArteModificado,
                Categoria = z.Categoria,
                CerradoIng = z.CerradoIng,
                CerradoPrePrensa = z.CerradoPrePrensa,
                Cilindros = z.Cilindros,
                CodCliente = z.CodCliente,
                Cod_Producto = z.Cod_Producto,
                Cod_Producto_Cliente = z.Cod_Producto_Cliente,
                Colores = z.Colores,
                ComentariosColores = z.ComentariosColores,
                EstadoPrePrensa = z.EstadoPrePrensa,
                FechaAprobacionCromalin = z.FechaAprobacionCromalin,
                FechaAprobacionPDFCliente = z.FechaAprobacionPDFCliente,
                FechaAprobacionSacaPrueba = z.FechaAprobacionSacaPrueba,
                FechaConfeccionIng = z.FechaConfeccionIng,
                Fecha_Creacion = z.Fecha_Creacion,
                Fecha_Deseada_Cliente = z.Fecha_Deseada_Cliente,
                Fecha_Liberacion = z.Fecha_Liberacion,
                FechaLiberacionFinalIng = z.FechaLiberacionFinalIng,
                FechaLiberacionLet = z.FechaLiberacionLet,
                FechaPDFArmado = z.FechaPDFArmado,
                FechaPDFModulo = z.FechaPDFModulo,
                FechaRecepcionArte = z.FechaRecepcionArte,
                FechaSacaPrueba = z.FechaSacaPrueba,
                HabilitaCierreLet = z.HabilitaCierreLet,
                Impresora = z.Impresora,
                Liberacion = z.Liberacion,
                Nombre_Cliente = z.Nombre_Cliente,
                Nro_Pedido_Original = z.Nro_Pedido_Original,
                OC_Cliente = z.OC_Cliente,
                ObservacionesIng = z.ObservacionesIng,
                ObservacionesPrePrensa = z.ObservacionesPrePrensa,
                OT = z.OT,
                PerfilImpresion = z.PerfilImpresion,
                Proveedor = z.Proveedor,
                ReChequeoProducto = z.ReChequeoProducto,
                Referencia_Item = z.Referencia_Item,
                ResponsableComercial = z.ResponsableComercial,
                ResponsableConfeccionIng = z.ResponsableConfeccionIng,
                ResponsableCustomer = z.ResponsableCustomer,
                ResponsableLiberacionFinalIng = z.ResponsableLiberacionFinalIng,
                ResponsableLiberacionLet = z.ResponsableLiberacionLet,
                ResponsablePrePrensa = z.ResponsablePrePrensa,
                RushOrder = z.RushOrder,
                TipoImpresora = z.TipoImpresora,
                Tipo_Adm = z.Tipo_Adm,
                Unid_Medida = z.Unid_Medida,
                Estado = z.Estado,
                FechaArteOriginal = z.FechaArteOriginal,
                FechaEntregaNuevosCilindros = z.FechaEntregaNuevosCilindros,
                FechaLiberacionMontaje = z.FechaLiberacionMontaje,
                FechaPreparacionCilindros = z.FechaPreparacionCilindros,
                FechaPromesaProveedorGrabado = z.FechaPromesaProveedorGrabado,
                FechaRecepcionCodigosCilindros = z.FechaRecepcionCodigosCilindros,
                FechaRetiroCilindro = z.FechaRetiroCilindro,
                FechaRecepcionHerramental = z.FechaRecepcionHerramental,
                FechaStandBy = z.FechaStandBy,
                LastRefreshDate = z.LastRefreshDate,
                ObsHerramental = z.ObsHerramental,
                ObsPerfiles = z.ObsPerfiles,
                FechaEnvioArte_ET = z.FechaEnvioArte_ET,
                FechaEnvioCromalin = z.FechaEnvioCromalin,
                FechaFinStandBy = z.FechaFinStandBy,
                FechaLiberadoAGrabado = z.FechaLiberadoAGrabado,
                CodigosCilindros = z.CodigosCilindros,
                TipoCilindros = z.TipoCilindros,
                Descripcion = z.Descripcion,
                FechaDocumento = z.FechaDocumento,
                Fecha_Pedido_Original = z.Fecha_Pedido_Original,
                ObsProducto = z.ObsProducto,
                Reemplazo_Prod = z.Reemplazo_Prod,
                AcuerdoDirectoProveedor = z.AcuerdoDirectoProveedor,
                Dif_FechaAprobCroma_FechaPDFArmado = z.Dif_FechaAprobCroma_FechaPDFArmado,
                Dif_FechaArte_FechaRecepHerra = z.Dif_FechaArte_FechaRecepHerra,
                Dif_FechaDocArte_FechaEnvioET = z.Dif_FechaDocArte_FechaEnvioET,
                Dif_FechaEnvCroma_FechaAprobCroma = z.Dif_FechaEnvCroma_FechaAprobCroma,
                Dif_FechaPDFArmado_FechaLibGrabado = z.Dif_FechaPDFArmado_FechaLibGrabado,
                Dif_FechaSacaPrueba_FechaAprobSacaPrueba = z.Dif_FechaSacaPrueba_FechaAprobSacaPrueba,
                Dif_FechaCreacion_FechaPedido = z.Dif_FechaCreacion_FechaPedido,
                Dif_FechaDocumento_FechaLiberacion = z.Dif_FechaDocumento_FechaLiberacion,
                Dif_FechaLiberacion_FechaConfeccion = z.Dif_FechaLiberacion_FechaConfeccion,
                Dif_FechaLiberacion_FechaLibFinal = z.Dif_FechaLiberacion_FechaLibFinal,
                Dif_FechaLibGrabado_FechaHerramental = z.Dif_FechaLibGrabado_FechaHerramental,
                Dif_FechaLibMontaje_FechaRetiro = z.Dif_FechaLibMontaje_FechaRetiro,
                Dif_FechaPDF_FechaRespCliente = z.Dif_FechaPDF_FechaRespCliente,
                Dif_FechaPedido_FechaDocumento = z.Dif_FechaPedido_FechaDocumento,
                Dif_FechaPedido_FechaRecepHerra = z.Dif_FechaPedido_FechaRecepHerra,
                Dif_FechaPrepCil_FechaLibMonaje = z.Dif_FechaPrepCil_FechaLibMonaje,
                Dif_FechaPromesaProv_FechaRecepHerra = z.Dif_FechaPromesaProv_FechaRecepHerra,
                Dif_Nivel_Servicio = z.Dif_Nivel_Servicio,
                NoUsaPrePrensa = z.NoUsaPrePrensa,
                OC_PROVEEDOR = z.OC_PROVEEDOR,
                TipoMaterial = z.TipoMaterial,
                CantCodigosCilindros = z.CantCodigosCilindros,
                Dif_LiberadoAGrabado_FechaArte = z.Dif_LiberadoAGrabado_FechaArte,
                Dif_RecepcionHerramental_LiberadoAGrabado = z.Dif_RecepcionHerramental_LiberadoAGrabado,
                Dif_LiberacionLet_FechaPedido = z.Dif_LiberacionLet_FechaPedido,
                





            }).ToList();
            return Ok(scrapExcel);
        }

        [HttpGet]
        [ResponseType(typeof(CSP_GPPRODUCTOS_EXCEL_GRABADOS_EXPORT_Result))]
        [Route("api/PSSProductos/getProductoParaExcel2/")]
        public async Task<IHttpActionResult> getProductoParaExcel2()
        {


            List<CSP_GPPRODUCTOS_EXCEL_GRABADOS_EXPORT_Result> scrapExcel = db.CSP_GPPRODUCTOS_EXCEL_GRABADOS_EXPORT().Select(z => new CSP_GPPRODUCTOS_EXCEL_GRABADOS_EXPORT_Result
            {
               Apariciones = z.Apariciones,
               Cant_Almas = z.Cant_Almas,
                Cant_Colores = z.Cant_Colores,
                Cant_Colores_Facturados = z.Cant_Colores_Facturados,
                Cliente = z.Cliente,
                Cod_Producto = z.Cod_Producto,
                Comentarios = z.Comentarios,
                Descripcion = z.Descripcion,
                Fecha_Pedido = z.Fecha_Pedido,
                Nro_Factura = z.Nro_Factura,
                Observaciones = z.Observaciones,
                OC_NRO = z.OC_NRO,
                Pedido = z.Pedido,
                Pedido_Pendiente = z.Pedido_Pendiente,
                Producto_Entregado = z.Producto_Entregado,
                Se_Factura = z.Se_Factura,
                TipoImpresora = z.TipoImpresora,
                Valor_Unit_Fotopolimero_Color = z.Valor_Unit_Fotopolimero_Color,
                Valor_Unit_Grabado_Cilindro = z.Valor_Unit_Grabado_Cilindro,

            }).ToList();
            return Ok(scrapExcel);
        }


        [HttpGet]
        [ResponseType(typeof(List<GpTrabajoCilindrosDto>))]  // Corregido el tipo de respuesta para que sea una lista de DTOs
        [Route("api/PSSProductos/getTrabajosCilindros/")]
        public async Task<IHttpActionResult> getTrabajosCilindros()
        {
            // Proyección directamente a un DTO
            var productos = await db.GPTrabajosCilindros
                .Select(z => new GpTrabajoCilindrosDto
                {
                    FechaEnvioAProveedor = z.FechaEnvioAProveedor,
                    FechaCompromiso = z.FechaCompromiso,
                    FechaDeseada = z.FechaDeseada,
                    FechaPreparacion = z.FechaPreparacion,
                    FechaRealEntrega = z.FechaRealEntrega,
                    CantColores = z.CantColores,
                    Cod_Facturacion = z.Cod_Facturacion,
                    Cod_Producto = z.Cod_Producto,
                    Enviado = z.Enviado,
                    EnvioHabilitado = z.EnvioHabilitado,
                    Estado = z.Estado,
                    Fotocromista = z.Fotocromista,
                    GPProductos = new ProductoDto
                    {
                        Proveedor = z.GPProductos.Proveedor,
                        FechaRecepcionArte = z.GPProductos.FechaRecepcionArte,
                        FechaEnvioArte_ET = z.GPProductos.FechaEnvioArte_ET,
                        ArteModificado = z.GPProductos.ArteModificado,
                        FechaArteOriginal = z.GPProductos.FechaArteOriginal,
                        FechaPromesaProveedorGrabado = z.GPProductos.FechaPromesaProveedorGrabado,
                        AcuerdoDirectoProveedor = z.GPProductos.AcuerdoDirectoProveedor,
                        OC_Proveedor = z.GPProductos.OC_Proveedor,
                        Descripcion =z.GPProductos.Descripcion,
                        TipoImpresora = z.GPProductos.TipoImpresora
          
                    },
                    Notas = z.Notas,
                    Nro_Version = z.Nro_Version,
                    OrdCompra = z.OrdCompra,
                    OT_Bolsapel = z.OT_Bolsapel,
                    OT_Proveedor = z.OT_Proveedor,
                    Recibo = z.Recibo,
                    RemitoEntrada = z.RemitoEntrada,
                    RemitoRetiro = z.RemitoRetiro,
                    Solicitado = z.Solicitado,
                    Causa = z.Causa,
                    Anexos = z.Anexos,
                    FechaReprogramacion = z.FechaReprogramacion,


                }).ToListAsync();

            // Devolver la lista de DTOs proyectados
            return Ok(productos);
        }


        [HttpGet]
        [Route("api/PSSProductos/getMaxVersion/")]
        public async Task<IHttpActionResult> getMaxVersion(string codProd)
        {
            var maxVersion = await db.GPTrabajosCilindros
            .Where(z => z.Cod_Producto == codProd)
            .Select(z => z.Nro_Version)
            .DefaultIfEmpty()  // En caso de que no haya registros, devuelve un valor por defecto
            .MaxAsync();  // Obtiene el valor máximo de Nro_Version

            return Ok(maxVersion);
        }





        // POST: api/PSSOrigenesScraps
        [ResponseType(typeof(GPTrabajosCilindros))]
        public async Task<IHttpActionResult> postTrabajosCilindros(GPTrabajosCilindros GpTrabajosCilindros)
        {

            GpTrabajosCilindros.Fotocromista = GpTrabajosCilindros.Fotocromista ?? "";
            GpTrabajosCilindros.OrdCompra = GpTrabajosCilindros.OrdCompra ?? "";
            GpTrabajosCilindros.Cod_Facturacion = GpTrabajosCilindros.Cod_Facturacion ?? "";
            GpTrabajosCilindros.Notas = GpTrabajosCilindros.Notas ?? "";
            GpTrabajosCilindros.OT_Bolsapel = GpTrabajosCilindros.OT_Bolsapel ?? "";
            GpTrabajosCilindros.OT_Proveedor = GpTrabajosCilindros.OT_Proveedor ?? "";
            GpTrabajosCilindros.RemitoRetiro = GpTrabajosCilindros.RemitoRetiro ?? "";
            GpTrabajosCilindros.Fotocromista = GpTrabajosCilindros.Fotocromista ?? "";
            GpTrabajosCilindros.Anexos = GpTrabajosCilindros.Anexos ?? "";
            GpTrabajosCilindros.Recibo = GpTrabajosCilindros.Recibo ?? "";
            GpTrabajosCilindros.RemitoEntrada = GpTrabajosCilindros.RemitoEntrada ?? "";


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GPTrabajosCilindros.Add(GpTrabajosCilindros);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }

            return CreatedAtRoute("DefaultApi", new { Cod_Producto = GpTrabajosCilindros.Cod_Producto }, GpTrabajosCilindros);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GpProductosExists(string id)
        {
            return db.GPProductos.Count(e => e.Cod_Producto == id) > 0;
        }


        [HttpGet]
        [ResponseType(typeof(GpTrabajoCilindrosDto))]
        [Route("api/PSSProductos/getTrabajosCilindrosPorVersion")]
        public async Task<IHttpActionResult> getTrabajosCilindrosPorVersion(int version, string codProd)
        {
            var trabajosCilindros = await db.GPTrabajosCilindros
                .Where(t => t.Nro_Version == version)
                .Where(t => t.Cod_Producto == codProd)
                .Select(z => new GpTrabajoCilindrosDto
                {
                    FechaEnvioAProveedor = z.FechaEnvioAProveedor,
                    FechaCompromiso = z.FechaCompromiso,
                    FechaDeseada = z.FechaDeseada,
                    FechaPreparacion = z.FechaPreparacion,
                    FechaRealEntrega = z.FechaRealEntrega,
                    CantColores = z.CantColores,
                    Cod_Facturacion = z.Cod_Facturacion,
                    Cod_Producto = z.Cod_Producto,
                    Enviado = z.Enviado,
                    EnvioHabilitado = z.EnvioHabilitado,
                    Estado = z.Estado,
                    Fotocromista = z.Fotocromista,
                    GPProductos = new ProductoDto
                    {
                        Proveedor = z.GPProductos.Proveedor,
                        Impresora = z.GPProductos.Impresora,
                        Descripcion = z.GPProductos.Descripcion,
                        TipoImpresora = z.GPProductos.TipoImpresora
                        
                    },
                    Notas = z.Notas,
                    Nro_Version = z.Nro_Version,
                    OrdCompra = z.OrdCompra,
                    OT_Bolsapel = z.OT_Bolsapel,
                    OT_Proveedor = z.OT_Proveedor,
                    Recibo = z.Recibo,
                    RemitoEntrada = z.RemitoEntrada,
                    RemitoRetiro = z.RemitoRetiro,
                    Solicitado = z.Solicitado,
                    Causa = z.Causa,
                    Anexos = z.Anexos,
                    FechaReprogramacion = z.FechaReprogramacion,
                })
                .ToListAsync();

            return Ok(trabajosCilindros);
        }


        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("api/PSSProductos/editTrabajoCilindo")]

        public async Task<IHttpActionResult> editTrabajoCilindo(string id, GPTrabajosCilindros trabajoCilindro)
        {

            trabajoCilindro.Fotocromista = trabajoCilindro.Fotocromista ?? "";
            trabajoCilindro.OrdCompra = trabajoCilindro.OrdCompra ?? "";
            trabajoCilindro.Cod_Facturacion = trabajoCilindro.Cod_Facturacion ?? "";
            trabajoCilindro.Notas = trabajoCilindro.Notas ?? "";
            trabajoCilindro.OT_Bolsapel = trabajoCilindro.OT_Bolsapel ?? "";
            trabajoCilindro.OT_Proveedor = trabajoCilindro.OT_Proveedor ?? "";
            trabajoCilindro.RemitoRetiro = trabajoCilindro.RemitoRetiro ?? "";
            trabajoCilindro.Fotocromista = trabajoCilindro.Fotocromista ?? "";
            trabajoCilindro.Anexos = trabajoCilindro.Anexos ?? "";
            trabajoCilindro.Recibo = trabajoCilindro.Recibo ?? "";
            trabajoCilindro.RemitoEntrada = trabajoCilindro.RemitoEntrada ?? "";


            trabajoCilindro.FechaDeseada = EnsureValidDateTime(trabajoCilindro.FechaDeseada);
            trabajoCilindro.FechaCompromiso = EnsureValidDateTime(trabajoCilindro.FechaCompromiso);
            trabajoCilindro.FechaEnvioAProveedor = EnsureValidDateTime(trabajoCilindro.FechaEnvioAProveedor);
            trabajoCilindro.FechaPreparacion = EnsureValidDateTime(trabajoCilindro.FechaPreparacion);
            trabajoCilindro.FechaRealEntrega = EnsureValidDateTime(trabajoCilindro.FechaRealEntrega);
            trabajoCilindro.FechaReprogramacion = EnsureValidDateTime(trabajoCilindro.FechaReprogramacion);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var trabajoInDb = await db.GPTrabajosCilindros
                    .Include(c => c.GPProductos)
                    .FirstOrDefaultAsync(c => c.Cod_Producto == trabajoCilindro.Cod_Producto && c.Nro_Version == trabajoCilindro.Nro_Version);

                if (trabajoInDb == null)
                {
                    return NotFound();
                }
                //db.Entry(trabajoInDb).CurrentValues.SetValues(trabajoCilindro);
                db.Entry(trabajoInDb).CurrentValues.SetValues(trabajoCilindro);
                db.Entry(trabajoInDb).Property(c => c.IdTrabajo).IsModified = false; // No modificar IdTrabajo

                await db.SaveChangesAsync();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                return InternalServerError(new Exception(fullErrorMessage, ex));
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(trabajoCilindro);
        }



        [HttpGet]
        [ResponseType(typeof(CSP_GPTRABAJOSCILINDROS_EXCEL_EXPORT_Result))]
        [Route("api/PSSProductos/getCilindrooParaExcel/")]
        public async Task<IHttpActionResult> getCilindrooParaExcel()
        {


            List<CSP_GPTRABAJOSCILINDROS_EXCEL_EXPORT_Result> scrapExcel = db.CSP_GPTRABAJOSCILINDROS_EXCEL_EXPORT().Select(z => new CSP_GPTRABAJOSCILINDROS_EXCEL_EXPORT_Result
            {
                Anexos = z.Anexos,
                FechaEnvioAProveedor = z.FechaEnvioAProveedor,
                FechaCompromiso = z.FechaCompromiso,
                FechaDeseada = z.FechaDeseada,
                FechaPreparacion = z.FechaPreparacion,
                FechaRealEntrega = z.FechaRealEntrega,
                CantColores = z.CantColores,
                Cod_Facturacion = z.Cod_Facturacion,
                Cod_Producto = z.Cod_Producto,
                EnvioHabilitado = z.EnvioHabilitado,
                Estado = z.Estado,
                Fotocromista = z.Fotocromista,
                Notas = z.Notas,
                Nro_Version = z.Nro_Version,
                OrdCompra = z.OrdCompra,
                OT_Bolsapel = z.OT_Bolsapel,
                OT_Proveedor = z.OT_Proveedor,
                Recibo = z.Recibo,
                RemitoEntrada = z.RemitoEntrada,
                RemitoRetiro = z.RemitoRetiro,
                Solicitado = z.Solicitado,
                Causa = z.Causa,
                FechaReprogramacion = z.FechaReprogramacion,

               


            }).ToList();
            return Ok(scrapExcel);
        }


    }

}