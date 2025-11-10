using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using LVS.Dtos;
using LVS.Model;

namespace LVS.Api.Controllers
{
    public class GPPGruposEmpaquesController : ApiController
    {
        private LAFScrapEntities db = new LAFScrapEntities();

        // GET: api/GPPGruposEmpaques
        public List<GPPGruposEmpaqueDto> GetGPPGruposEmpaque()
        {
            var list = db.GPPGruposEmpaque.Where(x => x.Habilitado == true).ToList();
            return Mapper.Map<List<GPPGruposEmpaque>, List<GPPGruposEmpaqueDto>>(list);
        }

        // GET: api/GPPGruposEmpaques/5
        [ResponseType(typeof(GPPGruposEmpaqueDto))]
        public IHttpActionResult GetGPPGruposEmpaque(int id)
        {
            var entity = db.GPPGruposEmpaque.Find(id);
            if (entity == null)
                return NotFound();

            return Ok(Mapper.Map<GPPGruposEmpaque, GPPGruposEmpaqueDto>(entity));
        }

        // PUT: api/GPPGruposEmpaques/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGPPGruposEmpaque(int id, GPPGruposEmpaque entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != entity.IDGrupoEmpaque)
                return BadRequest();

            entity.Descripcion = entity.Descripcion ?? string.Empty;

            db.Entry(entity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GPPGruposEmpaqueExists(id))
                    return NotFound();
                else
                    throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GPPGruposEmpaques
        [ResponseType(typeof(GPPGruposEmpaqueDto))]
        public IHttpActionResult PostGPPGruposEmpaque(GPPGruposEmpaque entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            entity.Habilitado = true;
            entity.Descripcion = entity.Descripcion ?? string.Empty;

            db.GPPGruposEmpaque.Add(entity);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (GPPGruposEmpaqueExists(entity.IDGrupoEmpaque))
                    return Conflict();
                else
                    throw;
            }

            var dto = Mapper.Map<GPPGruposEmpaque, GPPGruposEmpaqueDto>(entity);
            return CreatedAtRoute("DefaultApi", new { id = entity.IDGrupoEmpaque }, dto);
        }

        // DELETE: api/GPPGruposEmpaques/5
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteGPPGruposEmpaque(int id)
        {
            var entity = db.GPPGruposEmpaque.Find(id);
            if (entity == null)
                return NotFound();

            entity.Habilitado = false; // soft delete
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

        private bool GPPGruposEmpaqueExists(int id)
        {
            return db.GPPGruposEmpaque.Count(e => e.IDGrupoEmpaque == id) > 0;
        }
    }
}
