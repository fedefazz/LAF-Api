using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LVS.Model;
using LVS.Dtos;
using AutoMapper;

namespace LVS.Api.Controllers
{
    public class PSSActividadesController : ApiController
    {
        private LAFScrapEntities db = new LAFScrapEntities();

        // GET: api/PSSActividades
        public List<ActividadDto> GetPSSActividades()
        {
            List<PSSActividades> actividad = db.PSSActividades.Where(c => c.Habilitada == true).ToList();


            List<ActividadDto> listactividad = Mapper.Map<List<PSSActividades>, List<ActividadDto>>(actividad);

            return listactividad;
        }

        // GET: api/PSSActividades/5
        [ResponseType(typeof(ActividadDto))]
        public async Task<IHttpActionResult> GetPSSActividades(int id)
        {
            PSSActividades pSSActividades = await db.PSSActividades.FindAsync(id);
            if (pSSActividades == null)
            {
                return NotFound();
            }

            ActividadDto actividad = Mapper.Map<ActividadDto>(pSSActividades);


            return Ok(actividad);
        }

        // PUT: api/PSSActividades/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPSSActividades(int id, PSSActividades pSSActividades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pSSActividades.IdActividad)
            {
                return BadRequest();
            }

            db.Entry(pSSActividades).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PSSActividadesExists(id))
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

        // POST: api/PSSActividades
        [ResponseType(typeof(PSSActividades))]
        public async Task<IHttpActionResult> PostPSSActividades(PSSActividades pSSActividades)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            pSSActividades.Habilitada = true;
            db.PSSActividades.Add(pSSActividades);
            await db.SaveChangesAsync();

            ActividadDto actividad = Mapper.Map<ActividadDto>(pSSActividades);


            return CreatedAtRoute("DefaultApi", new { id = pSSActividades.IdActividad }, actividad);
        }

        // DELETE: api/PSSActividades/5
        [ResponseType(typeof(PSSActividades))]
        public async Task<IHttpActionResult> DeletePSSActividades(int id)
        {
            PSSActividades pSSActividades = await db.PSSActividades.FindAsync(id);
            if (pSSActividades == null)
            {
                return NotFound();
            }

            pSSActividades.Habilitada = false;
            await db.SaveChangesAsync();

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

        private bool PSSActividadesExists(int id)
        {
            return db.PSSActividades.Count(e => e.IdActividad == id) > 0;
        }
    }
}