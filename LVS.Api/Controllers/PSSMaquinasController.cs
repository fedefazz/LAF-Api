using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LVS.Model;
using LVS.Dtos;
using AutoMapper;
using System.Threading.Tasks;

namespace LVS.Api.Controllers
{
    public class PSSMaquinasController : ApiController
    {
        private LAFScrapEntities db = new LAFScrapEntities();

        // GET: api/PSSMaquinas
        public List<MaquinasDto> GetPSSMaquinas()
        {
            List<PSSMaquinas> maquinas = db.PSSMaquinas.Where(c => c.Habilitado == true).ToList();


            List<MaquinasDto> listMaquinas = Mapper.Map<List<PSSMaquinas>, List<MaquinasDto>>(maquinas);

            

            return listMaquinas;
        }

        // GET: api/PSSMaquinas/5
        [ResponseType(typeof(MaquinasDto))]
        public IHttpActionResult GetPSSMaquinas(int id)
        {
            PSSMaquinas pSSMaquinas = db.PSSMaquinas.Find(id);
            if (pSSMaquinas == null)
            {
                return NotFound();
            }


            MaquinasDto maquina = Mapper.Map<MaquinasDto>(pSSMaquinas);

            return Ok(maquina);
        }


        // GET: api/PSSMaquinas/5
        [ResponseType(typeof(MaquinasDto))]
        [Route("api/PSSMaquinas/GetPSSMaquinasPorID/")]

        public MaquinasDto GetPSSMaquinasPorID(int id)
        {
            PSSMaquinas pSSMaquinas = db.PSSMaquinas.Find(id);
            MaquinasDto maquina = Mapper.Map<MaquinasDto>(pSSMaquinas);

            return maquina;
        }



        // GET: api/PSSMaquinasPorOperador/5
        [ResponseType(typeof(List<MaquinasDto>))]
        [Route("api/PSSMaquinas/GetPSSMaquinasPorOperador/")]
        public IHttpActionResult GetPSSMaquinasPorOperador(int id)
        {
            List<PSSMaquinas> maquinasFinal = new List<PSSMaquinas>();
            PSSOperadores _operador = db.PSSOperadores.Find(id);

            foreach (PSSMaquinas maquina in _operador.PSSMaquinas)
            {


                PSSMaquinas _maquina = db.PSSMaquinas.Where(c => c.IDMaq == maquina.IDMaq).FirstOrDefault();
                    maquinasFinal.Add(_maquina);


            }


            List<MaquinasDto> _maquinasFinal = Mapper.Map<List<PSSMaquinas>, List<MaquinasDto>>(maquinasFinal);

            return Ok(_maquinasFinal);
        }


        // PUT: api/PSSMaquinas/5
        [ResponseType(typeof(void))]
        public async Task <IHttpActionResult> PutPSSMaquinas(int id, PSSMaquinas pSSMaquinas)
        {


            

            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            if (id != pSSMaquinas.IDMaq)
            {
                BadRequest();
            }





            var maquinaInDb = db.PSSMaquinas
                .Include(c => c.PSSOrigenesScrap)
                .Include(c => c.PSSJobTrack)
                .Include(c => c.PSSTiposMaterial)
                .Include(c => c.PSSAreas)
                .Include(c => c.PSSActividades)
                .Include(c => c.PSSOperadores)

                .Single(c => c.IDMaq == pSSMaquinas.IDMaq);



            foreach (var origen in pSSMaquinas.PSSOrigenesScrap.ToList())
            {
                if (!origen.Habilitado)
                {
                    pSSMaquinas.PSSOrigenesScrap.Remove(origen);

                }


            }
            foreach (var tipo in pSSMaquinas.PSSTiposMaterial.ToList())
            {
                if (!tipo.Habilitado)
                {
                    pSSMaquinas.PSSTiposMaterial.Remove(tipo);

                }


            }


            foreach (var origen in maquinaInDb.PSSOrigenesScrap.ToList())
            {
                maquinaInDb.PSSOrigenesScrap.Remove(origen);
            }

            foreach (var tipo in maquinaInDb.PSSTiposMaterial.ToList())
            {
                maquinaInDb.PSSTiposMaterial.Remove(tipo);
            }

           

            // Remove types
            foreach (var typeInDb in maquinaInDb.PSSJobTrack.ToList())
            {
                if (!pSSMaquinas.PSSJobTrack.Any(t => t.IDJobTrack == typeInDb.IDJobTrack))
                    maquinaInDb.PSSJobTrack.Remove(typeInDb);
            }
            // Add new types
            foreach (var type in pSSMaquinas.PSSJobTrack)
            {
                if (!maquinaInDb.PSSJobTrack.Any(t => t.IDJobTrack == type.IDJobTrack))
                {
                    db.PSSJobTrack.Attach(type);
                    maquinaInDb.PSSJobTrack.Add(type);
                }
            }



            // Remove types
            foreach (var typeInDb in maquinaInDb.PSSActividades.ToList())
            {
                if (!pSSMaquinas.PSSActividades.Any(t => t.IdActividad == typeInDb.IdActividad))
                    maquinaInDb.PSSActividades.Remove(typeInDb);
            }
            // Add new types
            foreach (var type in pSSMaquinas.PSSActividades)
            {
                if (!maquinaInDb.PSSActividades.Any(t => t.IdActividad == type.IdActividad))
                {
                    db.PSSActividades.Attach(type);
                    maquinaInDb.PSSActividades.Add(type);
                }
            }


            // Remove types
            foreach (var typeInDb in maquinaInDb.PSSOperadores.ToList())
            {
                if (!pSSMaquinas.PSSOperadores.Any(t => t.IdOperador == typeInDb.IdOperador))
                    maquinaInDb.PSSOperadores.Remove(typeInDb);
            }
            // Add new types
            foreach (var type in pSSMaquinas.PSSOperadores)
            {
                if (!maquinaInDb.PSSOperadores.Any(t => t.IdOperador == type.IdOperador))
                {
                    db.PSSOperadores.Attach(type);
                    maquinaInDb.PSSOperadores.Add(type);
                }
            }




            PSSAreas areaInDb = db.PSSAreas.Find(pSSMaquinas.PSSAreas.IDArea);





            maquinaInDb.PSSAreas = areaInDb;
            maquinaInDb.IDArea = areaInDb.IDArea;


            //AGREGO LA LISTA DE ORIGEN DE SCRAP
            List<PSSOrigenesScrap> listaorigenes = new List<PSSOrigenesScrap>();
            PSSOrigenesScrap origenscrap = new PSSOrigenesScrap();

            foreach (var origen in pSSMaquinas.PSSOrigenesScrap)
            {

                origenscrap = db.PSSOrigenesScrap.Find(origen.IDOrigen);

                listaorigenes.Add(origenscrap);

            }




            maquinaInDb.PSSOrigenesScrap = listaorigenes;



            //AGREGO LA LISTA DE ORIGEN DE TIPOS DE MATERIAL

            List<PSSTiposMaterial> listatipos = new List<PSSTiposMaterial>();
            PSSTiposMaterial tiposmaterial = new PSSTiposMaterial();

            foreach (var tipos in pSSMaquinas.PSSTiposMaterial)
            {

                tiposmaterial = db.PSSTiposMaterial.Find(tipos.IDTipoMat);

                listatipos.Add(tiposmaterial);

            }

            maquinaInDb.PSSTiposMaterial = listatipos;

            maquinaInDb.Recurso = pSSMaquinas.Recurso;


            maquinaInDb.Descripcion = pSSMaquinas.Descripcion;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PSSMaquinasExists(id))
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

        // POST: api/PSSMaquinas
        [ResponseType(typeof(PSSMaquinas))]
        public IHttpActionResult PostPSSMaquinas(PSSMaquinas pSSMaquinas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }




            //AGREGO LA LISTA DE ORIGEN DE SCRAP
            List<PSSOrigenesScrap> listaorigenes = new List<PSSOrigenesScrap>();
            PSSOrigenesScrap origenscrap = new PSSOrigenesScrap();

            foreach (var origen in pSSMaquinas.PSSOrigenesScrap)
            {

                origenscrap = db.PSSOrigenesScrap.Find(origen.IDOrigen);

                listaorigenes.Add(origenscrap);

            }




            pSSMaquinas.PSSOrigenesScrap = listaorigenes;



            //AGREGO LA LISTA DE ORIGEN DE TIPOS DE MATERIAL

            List<PSSTiposMaterial> listatipos= new List<PSSTiposMaterial>();
            PSSTiposMaterial tiposmaterial = new PSSTiposMaterial();

            foreach (var tipos in pSSMaquinas.PSSTiposMaterial)
            {

                tiposmaterial = db.PSSTiposMaterial.Find(tipos.IDTipoMat);

                listatipos.Add(tiposmaterial);

            }

            pSSMaquinas.PSSTiposMaterial = listatipos;


            //AGREGO LA LISTA DE ORIGEN DE TIPOS DE MATERIAL

            List<PSSJobTrack> listajob = new List<PSSJobTrack>();
            PSSJobTrack jobstrak = new PSSJobTrack();

            foreach (var tipos in pSSMaquinas.PSSJobTrack)
            {

                jobstrak = db.PSSJobTrack.Find(tipos.IDJobTrack);

                listajob.Add(jobstrak);

            }

            pSSMaquinas.PSSJobTrack = listajob;

            //AGREGO LA LISTA DE ORIGEN DE TIPOS DE MATERIAL

            List<PSSActividades> listaactividades = new List<PSSActividades>();
            PSSActividades actividades = new PSSActividades();

            foreach (var actividad in pSSMaquinas.PSSActividades)
            {

                actividades = db.PSSActividades.Find(actividad.IdActividad);

                listaactividades.Add(actividades);

            }


            pSSMaquinas.PSSActividades = listaactividades;

            //AGREGO LA LISTA DE ORIGEN DE TIPOS DE MATERIAL

            List<PSSOperadores> listaoperadores = new List<PSSOperadores>();
            PSSOperadores operadores = new PSSOperadores();

            foreach (var operador in pSSMaquinas.PSSOperadores)
            {

                operadores = db.PSSOperadores.Find(operador.IdOperador);

                listaoperadores.Add(operadores);

            }


            pSSMaquinas.PSSOperadores = listaoperadores;


            //AGREGO EL AREA
            PSSAreas area = new PSSAreas();
            area = db.PSSAreas.Find(pSSMaquinas.PSSAreas.IDArea);
            pSSMaquinas.PSSAreas = area;
            pSSMaquinas.IDArea = area.IDArea;
            pSSMaquinas.Habilitado = true;


            db.PSSMaquinas.Add(pSSMaquinas);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (PSSMaquinasExists(pSSMaquinas.IDMaq))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }


            MaquinasDto maquina = Mapper.Map<MaquinasDto>(pSSMaquinas);



            return CreatedAtRoute("DefaultApi", new { id = pSSMaquinas.IDMaq }, maquina);
        }

        // DELETE: api/PSSMaquinas/5
        [ResponseType(typeof(PSSMaquinas))]
        public IHttpActionResult DeletePSSMaquinas(int id)
        {
            PSSMaquinas pSSMaquinas = db.PSSMaquinas.Find(id);
            if (pSSMaquinas == null)
            {
                return NotFound();
            }

            pSSMaquinas.Habilitado = false;
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PSSMaquinasExists(int id)
        {
            return db.PSSMaquinas.Count(e => e.IDMaq == id) > 0;
        }
    }
}