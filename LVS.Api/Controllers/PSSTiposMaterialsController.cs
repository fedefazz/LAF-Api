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

namespace LVS.Api.Controllers
{
    public class PSSTiposMaterialsController : ApiController
    {
        private LAFScrapEntities db = new LAFScrapEntities();

        // GET: api/PSSTiposMaterials
        public List<TiposMaterialDto> GetPSSTiposMaterial()
        {
            List<PSSTiposMaterial> tiposmaterial = db.PSSTiposMaterial.Where(c => c.Habilitado == true).ToList();


            List<TiposMaterialDto> listTipomaterial = Mapper.Map<List<PSSTiposMaterial>, List<TiposMaterialDto>>(tiposmaterial);

            return listTipomaterial;
        }

        // GET: api/PSSTiposMaterials/5
        [ResponseType(typeof(TiposMaterialDto))]
        public IHttpActionResult GetPSSTiposMaterial(int id)
        {
            PSSTiposMaterial pSSTiposMaterial = db.PSSTiposMaterial.Find(id);
            if (pSSTiposMaterial == null)
            {
                return NotFound();
            }

            TiposMaterialDto material = Mapper.Map<TiposMaterialDto>(pSSTiposMaterial);


            return Ok(material);
        }

        // PUT: api/PSSTiposMaterials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPSSTiposMaterial(int id, PSSTiposMaterial pSSTiposMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pSSTiposMaterial.IDTipoMat)
            {
                return BadRequest();
            }

            db.Entry(pSSTiposMaterial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PSSTiposMaterialExists(id))
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

        // POST: api/PSSTiposMaterials
        [ResponseType(typeof(PSSTiposMaterial))]
        public IHttpActionResult PostPSSTiposMaterial(PSSTiposMaterial pSSTiposMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            pSSTiposMaterial.Habilitado = true;
            db.PSSTiposMaterial.Add(pSSTiposMaterial);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PSSTiposMaterialExists(pSSTiposMaterial.IDTipoMat))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            TiposMaterialDto material = Mapper.Map<TiposMaterialDto>(pSSTiposMaterial);


            return CreatedAtRoute("DefaultApi", new { id = pSSTiposMaterial.IDTipoMat }, material);
        }

        // DELETE: api/PSSTiposMaterials/5
        [ResponseType(typeof(PSSTiposMaterial))]
        public IHttpActionResult DeletePSSTiposMaterial(int id)
        {
            PSSTiposMaterial pSSTiposMaterial = db.PSSTiposMaterial.Find(id);
            if (pSSTiposMaterial == null)
            {
                return NotFound();
            }

            pSSTiposMaterial.Habilitado = false;
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

        private bool PSSTiposMaterialExists(int id)
        {
            return db.PSSTiposMaterial.Count(e => e.IDTipoMat == id) > 0;
        }
    }
}