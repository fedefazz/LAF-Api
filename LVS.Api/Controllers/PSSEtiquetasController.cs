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

    public class PSSEtiquetasController : ApiController
    {
        private LAFScrapEntities db = new LAFScrapEntities();

        // GET: api/PSSEtiquetas
        public List<EtiquetasDto> GetPSSEtiquetas()
        {
            List<LVS.Model.PSSEtiquetas> etiquetas = db.PSSEtiquetas.ToList();
            List<EtiquetasDto> listEtiquetas = Mapper.Map<List<Model.PSSEtiquetas>, List<EtiquetasDto>>(etiquetas);



            return listEtiquetas;
        }

        // GET: api/PSSEtiquetas/5
        [ResponseType(typeof(EtiquetasDto))]
        public IHttpActionResult GetPSSEtiquetas(int id)
        {
            Model.PSSEtiquetas etiquetas = db.PSSEtiquetas.Find(id);
            if (etiquetas == null)
            {
                return NotFound();
            }


            EtiquetasDto etiqueta = Mapper.Map<EtiquetasDto>(etiquetas);

            return Ok(etiqueta);
        }


        // GET: api/PSSEtiquetas/5
        [ResponseType(typeof(EtiquetasDto))]
        [Route("api/Role/GetRolePorID/")]

        public EtiquetasDto GetPSSEtiquetasPorID(int id)
        {
            Model.PSSEtiquetas etiqueta = db.PSSEtiquetas.Find(id);
            EtiquetasDto _etiqueta = Mapper.Map<EtiquetasDto>(etiqueta);

            return _etiqueta;
        }






        // PUT: api/PSSEtiquetas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPSSEtiquetas(int id, Model.PSSEtiquetas etiqueta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Convert.ToInt32(etiqueta.id))
            {
                return BadRequest();
            }

            db.Entry(etiqueta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!estiquetaExists(id))
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

        // POST: api/PSSEtiquetas
        [ResponseType(typeof(Model.PSSEtiquetas))]
        public IHttpActionResult PostPSSEtiquetas(Model.PSSEtiquetas etiqueta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.PSSEtiquetas.Add(etiqueta);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (estiquetaExists(Convert.ToInt32(etiqueta.id)))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            EtiquetasDto _etiqueta = Mapper.Map<EtiquetasDto>(etiqueta);


            return CreatedAtRoute("DefaultApi", new { id = etiqueta.id }, _etiqueta);
        }

        // DELETE: api/PSSEtiquetas/5
        [ResponseType(typeof(Model.PSSEtiquetas))]
        public IHttpActionResult DeletePSSEtiquetas(int id)
        {
            Model.PSSEtiquetas etiqueta = db.PSSEtiquetas.Find(id);
            if (etiqueta == null)
            {
                return NotFound();
            }

            db.Entry(etiqueta).State = EntityState.Deleted;

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

        private bool estiquetaExists(int id)
        {
            return db.PSSEtiquetas.Count(e => Convert.ToInt32(e.id) == id) > 0;
        }
    }
}