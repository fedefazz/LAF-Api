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
using static LVS.Model.LAFScrapEntities;




namespace LVS.Api.Controllers
{
    public class PSSScrapsController : ApiController
    {
        private LAFScrapEntities db = new LAFScrapEntities();

        // GET: api/PSSScraps
        public List<ScrapDto> GetPSSScrap(string dateDesde, string dateHasta)
        {

            DateTime fechaDesde = Convert.ToDateTime(dateDesde);
            DateTime fechaHasta = Convert.ToDateTime(dateHasta + " 11:59:00 PM");

            List<PSSScrap> scrap = db.PSSScrap.Where(c => c.Habilitado != false && c.Fecha > fechaDesde && c.Fecha < fechaHasta).ToList();


            List<ScrapDto> listScrap = Mapper.Map<List<PSSScrap>, List<ScrapDto>>(scrap);


            foreach (ScrapDto scrapItem in listScrap)
            {

                PSSMaquinasController maquinas = new PSSMaquinasController();
                MaquinasDto maquinaActiva = maquinas.GetPSSMaquinasPorID(scrapItem.IdMaqImputaScrap);

                if (maquinaActiva != null)
                {
                    scrapItem.IdMaqImputaScrapName = maquinaActiva.Descripcion;

                }

            }




            return listScrap;





           
        }

        [HttpGet]
        // GET: api/PSSScraps
        [Route("api/PSSScraps/GetPSSScrapServerSide")]

        public IHttpActionResult GetPSSScrapServerSide(int draw, int start, int length, string search, int order, string orderDir, string dateDesde, string dateHasta)
        {

            string SortColumnName = "";


            DateTime fechaDesde = Convert.ToDateTime(dateDesde);
            DateTime fechaHasta = Convert.ToDateTime(dateHasta + " 11:59:00 PM");




            List<PSSScrap> scrap = db.PSSScrap.Where(c => c.Habilitado != false && c.Fecha > fechaDesde && c.Fecha < fechaHasta).ToList();

            int recordsTotal = scrap.Count;


            if (!string.IsNullOrEmpty(search))
            {

                scrap = scrap.Where(x=> x.PSSActividades.Descripcion.ToLower().Contains(search.ToLower()) || x.PSSMaquinas.Descripcion.ToLower().Contains(search.ToLower()) || x.PSSOperadores.Nombre.ToLower().Contains(search.ToLower()) || x.PSSOperadores.Apellido.ToLower().Contains(search.ToLower()) ||  x.NumOP.ToString().Contains(search) || x.PSSOrigenesScrap.Descripcion.ToLower().Contains(search.ToLower()) || x.PSSTiposMaterial.Descripcion.ToLower().Contains(search.ToLower())).ToList<PSSScrap>();

            }

            int recordsFiltered = scrap.Count;

            order = order + -1;

            switch (order)
            {
                case 0:
                    if (orderDir == "desc")
                    {
                        scrap = scrap.OrderByDescending(s => s.IdRegScrap).ToList<PSSScrap>();

                    }
                    else
                    {
                        scrap = scrap.OrderBy(s => s.IdRegScrap).ToList<PSSScrap>();

                    }

                    break;

                case 1:
                    if (orderDir == "desc")
                    {
                        scrap = scrap.OrderByDescending(s => s.Fecha).ToList<PSSScrap>();

                    }
                    else
                    {
                        scrap = scrap.OrderBy(s => s.Fecha).ToList<PSSScrap>();

                    }
                    break;
                case 2:
                    if (orderDir == "desc")
                    {
                        scrap = scrap.OrderByDescending(s => s.NumOP).ToList<PSSScrap>();

                    }
                    else
                    {
                        scrap = scrap.OrderBy(s => s.NumOP).ToList<PSSScrap>();

                    }
                    break;
                case 3:
                    SortColumnName = "Maquina";
                    if (orderDir == "desc")
                    {
                        scrap = scrap.OrderByDescending(s => s.PSSMaquinas.Descripcion).ToList<PSSScrap>();

                    }
                    else
                    {
                        scrap = scrap.OrderBy(s => s.PSSMaquinas.Descripcion).ToList<PSSScrap>();

                    }
                    break;
                case 4:
                    SortColumnName = "IdMaqImputaScrapName";
                    if (orderDir == "desc")
                    {
                        scrap = scrap.OrderByDescending(s => s.IdMaqImputaScrap).ToList<PSSScrap>();

                    }
                    else
                    {
                        scrap = scrap.OrderBy(s => s.IdMaqImputaScrap).ToList<PSSScrap>();

                    }
                    break;
                case 5:
                    SortColumnName = "Actividad";
                    if (orderDir == "desc")
                    {
                        scrap = scrap.OrderByDescending(s => s.PSSActividades.Descripcion).ToList<PSSScrap>();

                    }
                    else
                    {
                        scrap = scrap.OrderBy(s => s.PSSActividades.Descripcion).ToList<PSSScrap>();

                    }
                    break;
                case 6:
                    SortColumnName = "Operador";
                    if (orderDir == "desc")
                    {
                        scrap = scrap.OrderByDescending(s => s.PSSOperadores.Nombre).ToList<PSSScrap>();

                    }
                    else
                    {
                        scrap = scrap.OrderBy(s => s.PSSOperadores.Nombre).ToList<PSSScrap>();

                    }

                    break;
                case 7:
                    SortColumnName = "Origen";
                    if (orderDir == "desc")
                    {
                        scrap = scrap.OrderByDescending(s => s.PSSOrigenesScrap.Descripcion).ToList<PSSScrap>();

                    }
                    else
                    {
                        scrap = scrap.OrderBy(s => s.PSSOrigenesScrap.Descripcion).ToList<PSSScrap>();

                    }
                    break;
                case 8:
                    SortColumnName = "Material";
                    if (orderDir == "desc")
                    {
                        scrap = scrap.OrderByDescending(s => s.PSSTiposMaterial.Descripcion).ToList<PSSScrap>();

                    }
                    else
                    {
                        scrap = scrap.OrderBy(s => s.PSSTiposMaterial.Descripcion).ToList<PSSScrap>();

                    }
                    break;


                case 9:
                    SortColumnName = "Peso";
                    if (orderDir == "desc")
                    {
                        scrap = scrap.OrderByDescending(s => s.Peso).ToList<PSSScrap>();

                    }
                    else
                    {
                        scrap = scrap.OrderBy(s => s.Peso).ToList<PSSScrap>();

                    }
                    break;
                case 10:
                    SortColumnName = "Observaciones";

                    break;


                default:
                    SortColumnName = "IdRegScrap";
                    if (orderDir == "desc")
                    {
                        scrap = scrap.OrderByDescending(s => s.IdRegScrap).ToList<PSSScrap>();

                    }
                    else
                    {
                        scrap = scrap.OrderBy(s => s.IdRegScrap).ToList<PSSScrap>();

                    }
                    break;
            }
            //sorting


            //paging
            scrap = scrap.Skip(start).Take(length).ToList<PSSScrap>();





            List<ScrapDto> listScrap = Mapper.Map<List<PSSScrap>, List<ScrapDto>>(scrap);


            foreach (ScrapDto scrapItem in listScrap)
            {

                PSSMaquinasController maquinas = new PSSMaquinasController();
                MaquinasDto maquinaActiva = maquinas.GetPSSMaquinasPorID(scrapItem.IdMaqImputaScrap);

                if (maquinaActiva != null)
                {
                    scrapItem.IdMaqImputaScrapName = maquinaActiva.Descripcion;

                }

            }



            return Json( new {data = listScrap, draw = draw, recordsTotal = recordsTotal, recordsFiltered = recordsFiltered });


        }





        // GET: api/PSSScraps/5
        [ResponseType(typeof(ScrapDto))]
        public async Task<IHttpActionResult> GetPSSScrap(int id)
        {
            PSSScrap pSSScrap = await db.PSSScrap.FindAsync(id);
            if (pSSScrap == null)
            {
                return NotFound();
            }

            ScrapDto scrap = Mapper.Map<ScrapDto>(pSSScrap);


            return Ok(scrap);
        }

        // PUT: api/PSSScraps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPSSScrap(int id, PSSScrap pSSScrap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pSSScrap.IdRegScrap)
            {
                return BadRequest();
            }



            var scrapInDb = db.PSSScrap
                .Include(c => c.PSSOrigenesScrap)
                .Include(c => c.PSSTiposMaterial)
                .Include(c => c.PSSActividades)
                .Include(c => c.PSSOperadores)
                .Include(c => c.PSSMaquinas)
                .Single(c => c.IdRegScrap == pSSScrap.IdRegScrap);




            


            PSSTiposMaterial tipoInDb = db.PSSTiposMaterial.Find(pSSScrap.PSSTiposMaterial.IDTipoMat);
            scrapInDb.PSSTiposMaterial = tipoInDb;
            scrapInDb.IdTipoMat = tipoInDb.IDTipoMat;


            PSSOrigenesScrap origenInDb = db.PSSOrigenesScrap.Find(pSSScrap.PSSOrigenesScrap.IDOrigen);
            scrapInDb.PSSOrigenesScrap = origenInDb;
            scrapInDb.IdOrigenScrap = origenInDb.IDOrigen;


            PSSActividades actividadInDb = db.PSSActividades.Find(pSSScrap.PSSActividades.IdActividad);
            scrapInDb.PSSActividades = actividadInDb;
            scrapInDb.IdActividad = actividadInDb.IdActividad;


            PSSOperadores operadoresInDb = db.PSSOperadores.Find(pSSScrap.PSSOperadores.IdOperador);
            scrapInDb.PSSOperadores = operadoresInDb;
            scrapInDb.IdOperador = operadoresInDb.IdOperador;


            PSSMaquinas maquinaInDb = db.PSSMaquinas.Find(pSSScrap.PSSMaquinas.IDMaq);
            scrapInDb.PSSMaquinas = maquinaInDb;
            scrapInDb.IdMaq = maquinaInDb.IDMaq;

            if (pSSScrap.PSSOrigenesScrap.IdMaquina != 0)
            {

                scrapInDb.IdMaqImputaScrap = Convert.ToInt32(pSSScrap.PSSOrigenesScrap.IdMaquina);
            }
            else
            {

                scrapInDb.IdMaqImputaScrap = pSSScrap.PSSMaquinas.IDMaq;


            }

            if (pSSScrap.Observaciones != null)
            {
                scrapInDb.Observaciones = pSSScrap.Observaciones;

            }
            scrapInDb.Peso = pSSScrap.Peso;
            
            //db.Entry(scrapInDb).CurrentValues.SetValues(pSSScrap);



            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PSSScrapExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PSSScraps
        [ResponseType(typeof(PSSScrap))]
        public async Task<IHttpActionResult> PostPSSScrap(PSSScrap pSSScrap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PSSScrap.Add(pSSScrap);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = pSSScrap.IdRegScrap }, pSSScrap);
        }

        // DELETE: api/PSSScraps/5
        [ResponseType(typeof(PSSScrap))]
        public async Task<IHttpActionResult> DeletePSSScrap(int id)





        {


            try
            {

                db.CSP_PSSSCRAP_DELETE(id);

                return Ok();

            }
            catch (Exception e)
            {

                throw ;
            }






            //PSSScrap pSSScrap = await db.PSSScrap.FindAsync(id);
            //if (pSSScrap == null)
            //{
            //    return NotFound();
            //}

            //pSSScrap.Habilitado = false;
            //await db.SaveChangesAsync();

           

        }


        // DELETE: api/PSSScraps/5
        [Route("api/PSSScraps/DeleteMultiple")]

        [ResponseType(typeof(PSSScrap))]
        public async Task<IHttpActionResult> DeleteMultiple(List<ItemsBorrar> selected)
        {
           //// PSSScrap pSSScrap = await db.PSSScrap.FindAsync(id);
           // if (pSSScrap == null)
           // {
           //     return NotFound();
           // }

           // pSSScrap.Habilitado = false;
           // await db.SaveChangesAsync();



            return Ok();
        }



        // GET: api/PSSMaquinasPorOperador/5
        [HttpGet]
        [ResponseType(typeof(CSP_REPORTE_SCRAP_Result))]
        [Route("api/PSSScraps/scrapExcel/")]
        public async Task<IHttpActionResult> scrapExcel(string dateDesde, string dateHasta)
        {

            DateTime fechaDesde = Convert.ToDateTime(dateDesde);
            DateTime fechaHasta = Convert.ToDateTime(dateHasta);

            List<CSP_REPORTE_SCRAP_Result> scrapExcel = db.CSP_REPORTE_SCRAP(fechaDesde.Date, fechaHasta.Date).Select(z => new CSP_REPORTE_SCRAP_Result
            {
                ID = z.ID,
                OBSERVACIONES = z.OBSERVACIONES,
                ACTIVIDAD = z.ACTIVIDAD,
                FECHA = z.FECHA,
                MAQUINA = z.MAQUINA,
                MAQUINA_IMPUTA = z.MAQUINA_IMPUTA,
                OPERADOR = z.OPERADOR,
                ORIGEN_SCRAP = z.ORIGEN_SCRAP,
                TIPO_MATERIAL = z.TIPO_MATERIAL,
                OP = z.OP,
                PESO = z.PESO,
                PRODUCTO = z.PRODUCTO,
            }).ToList();
            return Ok(scrapExcel);
        }

        [HttpGet]
        [Route("api/PSSScraps/GetMotivos/")]
        public async Task<IHttpActionResult> GetMotivos()
        {

            // Proyección directamente a un DTO
            var motivos = await db.PSSMotivosScrap
                .Select(z => new motivoDto
                {

                    Descripcion = z.Descripcion,
                    Id_Motivo = z.Id_Motivo,
                    Habilitado = z.Habilitado,
                    PorcentajeSimulacionMejora = z.PorcentajeSimulacionMejora



                }).ToListAsync();

            // Devolver la lista de DTOs proyectados
            return Ok(motivos);



        }


        [HttpPost]
        [ResponseType(typeof(PSSMotivosScrap))]
        [Route("api/PSSScraps/createMotivo/")]
        public async Task<IHttpActionResult> createMotivo(PSSMotivosScrap Motivo)
        {



            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PSSMotivosScrap.Add(Motivo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }

            return Ok(Motivo);



        }

        [HttpGet]
        [ResponseType(typeof(motivoDto))]
        [Route("api/PSSScraps/getMotivoById")]
        public async Task<IHttpActionResult> getMotivoById(int id)
        {
            var motivo = await db.PSSMotivosScrap
                .Where(t => t.Id_Motivo == id)
                .Select(z => new motivoDto
                {

                    Descripcion = z.Descripcion,
                    Id_Motivo = z.Id_Motivo,
                    Habilitado = z.Habilitado,
                    PorcentajeSimulacionMejora = z.PorcentajeSimulacionMejora
                })
                .ToListAsync();

            return Ok(motivo);
        }


        [HttpGet]
        [ResponseType(typeof(List<vinculoDto>))]
        [Route("api/PSSScraps/getVinculoById")]
        public async Task<IHttpActionResult> getVinculoById(int id)
        {

            List<vinculoDto> vinculos = new List<vinculoDto>();

            List<PSSMotivosScrapVinculos> PSSMotivosScrapVinculo = db.PSSMotivosScrapVinculos.Where(t => t.Id_Motivo == id).ToList();
           

            List<PSSMaquinas> maquinas = db.PSSMaquinas.Where(m => m.Habilitado == true).ToList();
            List<MaquinasDto> maquinassForSelect = new List<MaquinasDto>();
            foreach (var maquinaItem in maquinas)
            {
                var _maquina = new MaquinasDto
                {
                    Descripcion = maquinaItem.Descripcion,
                    IDMaq = maquinaItem.IDMaq,

                };
                maquinassForSelect.Add(_maquina);

            }

            List<PSSTiposMaterial> tiposmaterial = db.PSSTiposMaterial.Where(m => m.Habilitado == true).ToList();
            List<TiposMaterialDto> tiposmaterialForSelect = new List<TiposMaterialDto>();
            foreach (var tipomaterialItem in tiposmaterial)
            {
                var _tipomaterial = new TiposMaterialDto
                {
                    Descripcion = tipomaterialItem.Descripcion,
                    IDTipoMat = tipomaterialItem.IDTipoMat,


                };
                tiposmaterialForSelect.Add(_tipomaterial);

            }

            List<PSSOrigenesScrap> origenes = db.PSSOrigenesScrap.Where(m => m.Habilitado == true).ToList();
            List<OrigenesScrapDto> origenesForSelect = new List<OrigenesScrapDto>();
            foreach (var origenItem in origenes)
            {
                var _origen = new OrigenesScrapDto
                {
                    Descripcion = origenItem.Descripcion,
                    IDOrigen = origenItem.IDOrigen,

                };
                origenesForSelect.Add(_origen);

            }

            List<Metrics_Recursos_Habilitados> metrics_Recursos_Habilitados = db.Metrics_Recursos_Habilitados.ToList();
            List<recursoHabilitadoDto> recursosHabilitadosForSelect = new List<recursoHabilitadoDto>();
            foreach (var recursoItem in metrics_Recursos_Habilitados)
            {
                var _recurso = new recursoHabilitadoDto
                {
                    Descripcion = recursoItem.Descripcion,
                    Id = recursoItem.Id,

                };
                recursosHabilitadosForSelect.Add(_recurso);

            }


            if (PSSMotivosScrapVinculo == null || PSSMotivosScrapVinculo.Count == 0)
            {
                var vinculo = new vinculoDto
                {

                    maquinas = maquinassForSelect,
                    tiposMaterial = tiposmaterialForSelect,
                    origenes = origenesForSelect,
                    recursos = recursosHabilitadosForSelect,

                };
                vinculos.Add(vinculo);

                return Ok(vinculos);

            }


            foreach (var z in PSSMotivosScrapVinculo)
            {
                var vinculo = new vinculoDto
                {
                    Id_MaquinaImpute = z.Id_MaquinaImpute,
                    Id_Motivo = z.Id_Motivo,
                    Id_Origen = z.Id_Origen,
                    Id_Recurso = z.Id_Recurso,
                    Id_TipoMaterial = z.Id_TipoMaterial,
                    maquinas = maquinassForSelect,
                    tiposMaterial = tiposmaterialForSelect,
                    origenes = origenesForSelect,
                    recursos = recursosHabilitadosForSelect,

                };
                vinculos.Add(vinculo);

            }

          

            return Ok(vinculos);
        }



      
        [ResponseType(typeof(PSSMotivosScrapVinculos))]
        [Route("api/PSSScraps/createVinculo/")]
        public async Task<IHttpActionResult> createVinculo(PSSMotivosScrapVinculos vinculo)
        {


            var motivo = db.PSSMotivosScrap.Find(vinculo.Id_Motivo);
            if (motivo == null)
            {
                return NotFound();
            }

            vinculo.PSSMotivosScrap = motivo;


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newVinculo = new PSSMotivosScrapVinculos
            {
                Id_Motivo = vinculo.Id_Motivo,
                Id_Recurso = vinculo.Id_Recurso,
                Id_Origen = vinculo.Id_Origen,
                Id_MaquinaImpute = vinculo.Id_MaquinaImpute,
                Id_TipoMaterial = vinculo.Id_TipoMaterial
            };

            // Aquí no se llenan las entidades completas, solo se usan los ID's.
            // Entity Framework asociará automáticamente los objetos usando estos ID's cuando realices el SaveChanges.

            db.PSSMotivosScrapVinculos.Add(newVinculo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Error al guardar los cambios: " + ex.Message);
                return Conflict();
            }


            return Ok();


        }

        public class VinculoUpdateRequest
        {
            public PSSMotivosScrapVinculos originalData { get; set; }
            public PSSMotivosScrapVinculos newData { get; set; }

        }

            public class ObjetivoUpdateRequest
            {
                public PSSMotivosScrapObjetivos originalData { get; set; }
                public PSSMotivosScrapObjetivos newData { get; set; }
            }
        

            [HttpPut]
        [ResponseType(typeof(PSSMotivosScrapVinculos))]
        [Route("api/PSSScraps/updateVinculo/")]
        public async Task<IHttpActionResult> updateVinculo(VinculoUpdateRequest request)
        {
            var originalVinculo = request.originalData;
            var newVinculo = request.newData;

            // Buscar el vínculo existente usando los valores originales (de originalVinculo)
            // Eliminar el vínculo original
            var existingVinculo = db.PSSMotivosScrapVinculos
                .FirstOrDefault(v => v.Id_Motivo == originalVinculo.Id_Motivo &&
                                     v.Id_MaquinaImpute == originalVinculo.Id_MaquinaImpute &&
                                     v.Id_Origen == originalVinculo.Id_Origen &&
                                     v.Id_TipoMaterial == originalVinculo.Id_TipoMaterial &&
                                     v.Id_Recurso == originalVinculo.Id_Recurso);

            if (existingVinculo != null)
            {
                db.PSSMotivosScrapVinculos.Remove(existingVinculo);
                await db.SaveChangesAsync();
            }

            // Crear un nuevo vínculo con los valores actualizados (incluyendo Id_Origen)
            var newVinculoEntity = new PSSMotivosScrapVinculos
            {
                Id_Motivo = newVinculo.Id_Motivo,
                Id_MaquinaImpute = newVinculo.Id_MaquinaImpute,
                Id_Origen = newVinculo.Id_Origen,
                Id_TipoMaterial = newVinculo.Id_TipoMaterial,
                Id_Recurso = newVinculo.Id_Recurso
            };

          


            try
            {
                db.PSSMotivosScrapVinculos.Add(newVinculoEntity);
                await db.SaveChangesAsync(); 
                return Ok(newVinculoEntity); // Devolvemos el objeto actualizado
            }
            catch (DbUpdateException ex)
            {
                // Si ocurre un error en la base de datos, lo atrapamos y retornamos un error
                return Conflict();
            }
        }


        [HttpDelete]
        [Route("api/PSSScraps/deleteVinculo/")]
        public async Task<IHttpActionResult> DeleteVinculo([FromBody] PSSMotivosScrapVinculos vinculo)
        {
            // Buscar el vínculo usando los atributos clave
            var existingVinculo = db.PSSMotivosScrapVinculos
                .Where(v => v.Id_Motivo == vinculo.Id_Motivo &&
                            v.Id_MaquinaImpute == vinculo.Id_MaquinaImpute &&
                            v.Id_Origen == vinculo.Id_Origen &&
                            v.Id_TipoMaterial == vinculo.Id_TipoMaterial &&
                            v.Id_Recurso == vinculo.Id_Recurso)
                .FirstOrDefault();

            if (existingVinculo == null)
            {
                return NotFound(); // Si no se encuentra el vínculo, retornar NotFound
            }

            // Eliminar el vínculo
            db.PSSMotivosScrapVinculos.Remove(existingVinculo);

            try
            {
                await db.SaveChangesAsync(); // Guardar los cambios en la base de datos
                return Ok(existingVinculo); // Retornar el vínculo eliminado
            }
            catch (Exception ex)
            {
                // Manejar cualquier error al eliminar
                return Conflict();
            }
        }







        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("api/PSSScraps/editMotivo")]

        public async Task<IHttpActionResult> editMotivo(string id, PSSMotivosScrap motivo)
        {

   

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var motivoinDB = await db.PSSMotivosScrap
                    .Include(c => c.PSSMotivosScrapVinculos)
                    .Include(c => c.PSSMotivosScrapObjetivos)
                    .FirstOrDefaultAsync(c => c.Id_Motivo == motivo.Id_Motivo);

                if (motivoinDB == null)
                {
                    return NotFound();
                }
                db.Entry(motivoinDB).CurrentValues.SetValues(motivo);


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

            return Ok(motivo);
        }


        // GET: api/pssscraps/valoresporperiodomensual
        [HttpGet]
        [Route("api/PSSScraps/valoresporperiodomensual")]
        public IHttpActionResult GetPsscrapValoresPorPeriodoMensual()
        {
            var valores = db.PSSScrapValoresPorPeriodoMensual.ToList();
            return Ok(valores);
        }

        // GET: api/pssscraps/getPeriodoById/{id}
        [HttpGet]
        [Route("api/PSSScraps/getPeriodoById")]

        public IHttpActionResult getPeriodoById(int id)
        {
            var valor = db.PSSScrapValoresPorPeriodoMensual.Where(x => x.Record_Id == id);
            if (valor == null)
            {
                return NotFound();
            }
            return Ok(valor);
        }

        // POST: api/pssscraps/valoresporperiodomensual
        [HttpPost]
        [Route("api/PSSScraps/postPsscrapValoresPorPeriodoMensual")]

        public IHttpActionResult PostPsscrapValoresPorPeriodoMensual(scrapValoresPorPeriodoMensualDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var valor = new PSSScrapValoresPorPeriodoMensual
            {
                ScrapNoRegistrado = dto.ScrapNoRegistrado,
                Ano = dto.Ano,
                Mes = dto.Mes,
                TonsProducidas = dto.TonsProducidas,

            };

            db.PSSScrapValoresPorPeriodoMensual.Add(valor);
            db.SaveChanges();

            
            return Ok(valor);
        }

        // PUT: api/pssscraps/valoresporperiodomensualput/{id}
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("api/PSSScraps/valoresporperiodomensualput")]
        public async Task<IHttpActionResult> valoresporperiodomensualput(string id, PSSScrapValoresPorPeriodoMensual motivo)
        {

            var nuevoPeriodo = new PSSScrapValoresPorPeriodoMensual();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var periodoinDB = await db.PSSScrapValoresPorPeriodoMensual
                    .FirstOrDefaultAsync(c => c.Record_Id == motivo.Record_Id);

                if (periodoinDB == null)
                {
                    return NotFound();
                }

                db.PSSScrapValoresPorPeriodoMensual.Remove(periodoinDB);

                // Luego, agregar un nuevo registro con los valores modificados

                nuevoPeriodo.ScrapNoRegistrado = motivo.ScrapNoRegistrado;
                nuevoPeriodo.Ano = motivo.Ano;
                nuevoPeriodo.Mes = motivo.Mes;
                nuevoPeriodo.TonsProducidas = motivo.TonsProducidas;


                db.PSSScrapValoresPorPeriodoMensual.Add(nuevoPeriodo);
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

            return Ok(nuevoPeriodo);
        }

        // DELETE: api/pssscraps/deletePsscrapValoresPorPeriodoMensual/{id}
        [HttpDelete]
        [Route("api/PSSScraps/deletePsscrapValoresPorPeriodoMensual")]


        public async Task<IHttpActionResult> deletePsscrapValoresPorPeriodoMensual(int id)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var periodoinDB = await db.PSSScrapValoresPorPeriodoMensual
                    .FirstOrDefaultAsync(c => c.Record_Id == id);

                if (periodoinDB == null)
                {
                    return NotFound();
                }

                db.PSSScrapValoresPorPeriodoMensual.Remove(periodoinDB);
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

            return Ok();
        }


        [HttpGet]
        [ResponseType(typeof(List<objetivoDto>))]
        [Route("api/PSSScraps/getObjetivoById")]
        public async Task<IHttpActionResult> getObjetivoById(int id)
        {

            List<objetivoDto> objetivos = new List<objetivoDto>();

            List<PSSMotivosScrapObjetivos> PSSMotivosScrapObjetivos = db.PSSMotivosScrapObjetivos.Where(t => t.Id_Motivo == id).ToList();




            foreach (var z in PSSMotivosScrapObjetivos)
            {
                var objetivo = new objetivoDto
                {
                    Id_Motivo = z.Id_Motivo,
                    Id_Objetivo = z.Id_Objetivo,
                    Indicador_Inicio = z.Indicador_Inicio,
                    Indicador_Objetivo = z.Indicador_Objetivo,
                    PSSMotivosScrap = new motivoDto
                    {
                        Descripcion = z.PSSMotivosScrap.Descripcion,
                        Id_Motivo = z.PSSMotivosScrap.Id_Motivo,
                        Habilitado = z.PSSMotivosScrap.Habilitado,
                    },
                    Vigencia_Desde = z.Vigencia_Desde,
                    Vigencia_Hasta = z.Vigencia_Hasta,


                };
                objetivos.Add(objetivo);

            }



            return Ok(objetivos);
        }


        [ResponseType(typeof(PSSMotivosScrapObjetivos))]
        [Route("api/PSSScraps/createObjetivo/")]
        public async Task<IHttpActionResult> createObjetivo(PSSMotivosScrapObjetivos objetivo)
        {


            var motivo = db.PSSMotivosScrap.Find(objetivo.Id_Motivo);
            if (motivo == null)
            {
                return NotFound();
            }

            objetivo.PSSMotivosScrap = motivo;


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newObjetivo = new PSSMotivosScrapObjetivos
            {
                Id_Motivo = objetivo.Id_Motivo,
                Indicador_Inicio = objetivo.Indicador_Inicio,
                Indicador_Objetivo = objetivo.Indicador_Objetivo,
                Vigencia_Desde = objetivo.Vigencia_Desde,
                Vigencia_Hasta = objetivo.Vigencia_Hasta,
                PSSMotivosScrap = motivo,
                

            };

            // Aquí no se llenan las entidades completas, solo se usan los ID's.
            // Entity Framework asociará automáticamente los objetos usando estos ID's cuando realices el SaveChanges.

            db.PSSMotivosScrapObjetivos.Add(newObjetivo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("Error al guardar los cambios: " + ex.Message);
                return Conflict();
            }


            return Ok();


        }

        [HttpPut]
        [ResponseType(typeof(PSSMotivosScrapObjetivos))]
        [Route("api/PSSScraps/updateObjetivo/")]
        public async Task<IHttpActionResult> updateObjetivo(ObjetivoUpdateRequest request)
        {
            var originalObjetivo = request.originalData;
            var newObjetivo = request.newData;

            // Buscar el vínculo existente usando los valores originales (de originalVinculo)
            // Eliminar el vínculo original
            var existingObjetivo = db.PSSMotivosScrapObjetivos
                .FirstOrDefault(v => v.Id_Objetivo == originalObjetivo.Id_Objetivo);

            if (existingObjetivo != null)
            {
                db.PSSMotivosScrapObjetivos.Remove(existingObjetivo);
                await db.SaveChangesAsync();
            }

            // Crear un nuevo vínculo con los valores actualizados (incluyendo Id_Origen)
            var newObjetivoEntity = new PSSMotivosScrapObjetivos
            {
                Id_Motivo = newObjetivo.Id_Motivo,
                Indicador_Inicio = newObjetivo.Indicador_Inicio,
                Indicador_Objetivo = newObjetivo.Indicador_Objetivo,
                Vigencia_Desde = newObjetivo.Vigencia_Desde,
                Vigencia_Hasta = newObjetivo.Vigencia_Hasta


            };




            try
            {
                db.PSSMotivosScrapObjetivos.Add(newObjetivoEntity);
                await db.SaveChangesAsync();
                return Ok(newObjetivoEntity); // Devolvemos el objeto actualizado
            }
            catch (DbUpdateException ex)
            {
                // Si ocurre un error en la base de datos, lo atrapamos y retornamos un error
                return Conflict();
            }
        }


        [HttpDelete]
        [Route("api/PSSScraps/deleteObjetivo/")]
        public async Task<IHttpActionResult> DeleteObjetivoo([FromBody] PSSMotivosScrapObjetivos objetivo)
        {
            // Buscar el vínculo usando los atributos clave
            var existingObjetivo = db.PSSMotivosScrapObjetivos
                .Where(v => v.Id_Objetivo == objetivo.Id_Objetivo)
                .FirstOrDefault();

            if (existingObjetivo == null)
            {
                return NotFound(); // Si no se encuentra el vínculo, retornar NotFound
            }

            // Eliminar el vínculo
            db.PSSMotivosScrapObjetivos.Remove(existingObjetivo);

            try
            {
                await db.SaveChangesAsync(); // Guardar los cambios en la base de datos
                return Ok(existingObjetivo); // Retornar el vínculo eliminado
            }
            catch (Exception ex)
            {
                // Manejar cualquier error al eliminar
                return Conflict();
            }
        }


        [HttpGet]
        [Route("api/PSSScraps/GetMotivosScrap")]
        [ResponseType(typeof(CSP_SCRAP_MOTIVOS_TABLE1_Result))]

        public IHttpActionResult GetMotivosScrap()
        {
            List<CSP_SCRAP_MOTIVOS_TABLE1_Result> scrapExcel = db.CSP_SCRAP_MOTIVOS_TABLE1().Select(z => new CSP_SCRAP_MOTIVOS_TABLE1_Result
            {
                TOTAL_GENERAL = z.TOTAL_GENERAL,
                PERC_SCRAP_TOT = z.PERC_SCRAP_TOT,
                PERC_SCRAP_MES_ACTUAL = z.PERC_SCRAP_MES_ACTUAL,
                MES_ANO_PROX = z.MES_ANO_PROX,
                MEJORADEFINIDA = z.MEJORADEFINIDA,
                DESC_MOTIVO_SCRAP = z.DESC_MOTIVO_SCRAP,
                PERC_MEJORA = z.PERC_MEJORA,
                C1 = z.C1,
                C2 = z.C2,
                C3 = z.C3,
                C4 = z.C4,
                C5 = z.C5,
                C6 = z.C6,
                C7 = z.C7,
                C8 = z.C8,
                C9 = z.C9,
                C10 = z.C10,
                C11 = z.C11,
                C12 = z.C12,
                CRITERIO = z.CRITERIO,
                ID_MOTIVO = z.ID_MOTIVO,




            }).ToList();
            return Ok(scrapExcel);
        }

        [HttpGet]
        [Route("api/PSSScraps/GetMotivosScrap2")]
        [ResponseType(typeof(CSP_SCRAP_MOTIVOS_TABLE2_Result))]

        public IHttpActionResult GetMotivosScrap2()
        {
            List<CSP_SCRAP_MOTIVOS_TABLE2_Result> scrapExcel = db.CSP_SCRAP_MOTIVOS_TABLE2().Select(z => new CSP_SCRAP_MOTIVOS_TABLE2_Result
            {
               
                DESC_MOTIVO_SCRAP = z.DESC_MOTIVO_SCRAP,
                C1 = z.C1,
                C2 = z.C2,
                C3 = z.C3,
                C4 = z.C4,
                C5 = z.C5,
                C6 = z.C6,
                C7 = z.C7,
                C8 = z.C8,
                C9 = z.C9,
                C10 = z.C10,
                C11 = z.C11,
                C12 = z.C12,
                COLOR1 = z.COLOR1,
                COLOR2 = z.COLOR2,
                COLOR3 = z.COLOR3,
                COLOR4 = z.COLOR4,
                COLOR5 = z.COLOR5,
                COLOR6 = z.COLOR6,
                COLOR7 = z.COLOR7,
                COLOR8 = z.COLOR8,
                COLOR9 = z.COLOR9,
                COLOR10 = z.COLOR10,
                COLOR11 = z.COLOR11,
                COLOR12 = z.COLOR12,
                INICIO = z.INICIO,
                OBJETIVO = z.OBJETIVO,
                





            }).ToList();
            return Ok(scrapExcel);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PSSScrapExists(int id)
        {
            return db.PSSScrap.Count(e => e.IdRegScrap == id) > 0;
        }
       
    }
}