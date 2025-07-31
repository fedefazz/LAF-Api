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
    public class PSSAreasController : ApiController
    {
        private LAFScrapEntities db = new LAFScrapEntities();

        // GET: api/PSSAreas
        public List<AreasDto> GetPSSAreas()
        {
          
            List<PSSAreas> areas = db.PSSAreas.ToList();


            List<AreasDto> listAreas = Mapper.Map<List<PSSAreas>, List<AreasDto>>(areas);

            return listAreas;
        }

        // GET: api/PSSAreas/5
        [ResponseType(typeof(PSSAreas))]
        public async Task<IHttpActionResult> GetPSSAreas(int id)
        {
            PSSAreas pSSAreas = await db.PSSAreas.FindAsync(id);
            if (pSSAreas == null)
            {
                return NotFound();
            }

            return Ok(pSSAreas);
        }

        // PUT: api/PSSAreas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPSSAreas(int id, PSSAreas pSSAreas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pSSAreas.IDArea)
            {
                return BadRequest();
            }

            db.Entry(pSSAreas).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PSSAreasExists(id))
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

        // POST: api/PSSAreas
        [ResponseType(typeof(PSSAreas))]
        public async Task<IHttpActionResult> PostPSSAreas(PSSAreas pSSAreas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PSSAreas.Add(pSSAreas);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PSSAreasExists(pSSAreas.IDArea))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pSSAreas.IDArea }, pSSAreas);
        }

        // DELETE: api/PSSAreas/5
        [ResponseType(typeof(PSSAreas))]
        public async Task<IHttpActionResult> DeletePSSAreas(int id)
        {
            PSSAreas pSSAreas = await db.PSSAreas.FindAsync(id);
            if (pSSAreas == null)
            {
                return NotFound();
            }

            db.PSSAreas.Remove(pSSAreas);
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

        private bool PSSAreasExists(int id)
        {
            return db.PSSAreas.Count(e => e.IDArea == id) > 0;
        }
    }
}