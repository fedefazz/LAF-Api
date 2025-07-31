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
    public class PSSOrigenesScrapsController : ApiController
    {
        private LAFScrapEntities db = new LAFScrapEntities();

        // GET: api/PSSOrigenesScraps
        public List<OrigenesScrapDto> GetPSSOrigenesScrap()
        {
            List<PSSOrigenesScrap> origenesscrap = db.PSSOrigenesScrap.Where(c => c.Habilitado == true).ToList();


            List<OrigenesScrapDto> listOrigenes = Mapper.Map<List<PSSOrigenesScrap>, List<OrigenesScrapDto>>(origenesscrap);

            return listOrigenes;
        }

        // GET: api/PSSOrigenesScraps/5
        [ResponseType(typeof(OrigenesScrapDto))]
        public async Task<IHttpActionResult> GetPSSOrigenesScrap(int id)
        {
            PSSOrigenesScrap pSSOrigenesScrap = await db.PSSOrigenesScrap.FindAsync(id);
            if (pSSOrigenesScrap == null)
            {
                return NotFound();
            }

            OrigenesScrapDto origen = Mapper.Map<OrigenesScrapDto>(pSSOrigenesScrap);


            return Ok(origen);
        }

        // PUT: api/PSSOrigenesScraps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPSSOrigenesScrap(int id, PSSOrigenesScrap pSSOrigenesScrap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pSSOrigenesScrap.IDOrigen)
            {
                return BadRequest();
            }



            var origenInDb = db.PSSOrigenesScrap
               
               .Include(c => c.PSSTiposMaterial)
               

               .Single(c => c.IDOrigen == pSSOrigenesScrap.IDOrigen);


            // Updates the Name property
            db.Entry(origenInDb).CurrentValues.SetValues(pSSOrigenesScrap);


            // Remove types
            foreach (var typeInDb in origenInDb.PSSTiposMaterial.ToList())
            {
                if (!pSSOrigenesScrap.PSSTiposMaterial.Any(t => t.IDTipoMat == typeInDb.IDTipoMat))
                    origenInDb.PSSTiposMaterial.Remove(typeInDb);
            }
            // Add new types
            foreach (var type in pSSOrigenesScrap.PSSTiposMaterial)
            {
                if (!origenInDb.PSSTiposMaterial.Any(t => t.IDTipoMat == type.IDTipoMat))
                {
                    db.PSSTiposMaterial.Attach(type);
                    origenInDb.PSSTiposMaterial.Add(type);
                }
            }




            



            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PSSOrigenesScrapExists(id))
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

        // POST: api/PSSOrigenesScraps
        [ResponseType(typeof(PSSOrigenesScrap))]
        public async Task<IHttpActionResult> PostPSSOrigenesScrap(PSSOrigenesScrap pSSOrigenesScrap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            pSSOrigenesScrap.Habilitado = true;
            if (pSSOrigenesScrap.PSSMaquinas.Count == 0)
            {
                pSSOrigenesScrap.IdMaquina = 0;

            }
            //AGREGO LA LISTA DE ORIGEN DE TIPOS DE MATERIAL

            List<PSSTiposMaterial> listatipos = new List<PSSTiposMaterial>();
            PSSTiposMaterial tiposmaterial = new PSSTiposMaterial();

            foreach (var tipos in pSSOrigenesScrap.PSSTiposMaterial)
            {

                tiposmaterial = db.PSSTiposMaterial.Find(tipos.IDTipoMat);

                listatipos.Add(tiposmaterial);

            }

            pSSOrigenesScrap.PSSTiposMaterial = listatipos;
            db.PSSOrigenesScrap.Add(pSSOrigenesScrap);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PSSOrigenesScrapExists(pSSOrigenesScrap.IDOrigen))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            OrigenesScrapDto origen = Mapper.Map<OrigenesScrapDto>(pSSOrigenesScrap);

            return CreatedAtRoute("DefaultApi", new { id = pSSOrigenesScrap.IDOrigen }, origen);
        }

        // DELETE: api/PSSOrigenesScraps/5
        [ResponseType(typeof(PSSOrigenesScrap))]
        public async Task<IHttpActionResult> DeletePSSOrigenesScrap(int id)
        {
            PSSOrigenesScrap pSSOrigenesScrap = await db.PSSOrigenesScrap.FindAsync(id);
            if (pSSOrigenesScrap == null)
            {
                return NotFound();
            }

            pSSOrigenesScrap.Habilitado = false;
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

        private bool PSSOrigenesScrapExists(int id)
        {
            return db.PSSOrigenesScrap.Count(e => e.IDOrigen == id) > 0;
        }
    }
}