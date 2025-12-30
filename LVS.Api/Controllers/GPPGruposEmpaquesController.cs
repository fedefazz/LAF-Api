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

        // ========== ENDPOINTS PARA TIPOS DE ETIQUETAS ==========

        // GET: api/GPPGruposEmpaques/TiposEtiquetas
        [HttpGet]
        [Route("api/GPPGruposEmpaques/TiposEtiquetas")]
        public List<GPPTiposEtiquetasDto> GetTiposEtiquetas()
        {
            var list = db.GPPTiposEtiquetas.Where(x => x.Habilitado == true).ToList();
            return Mapper.Map<List<GPPTiposEtiquetas>, List<GPPTiposEtiquetasDto>>(list);
        }

        // GET: api/GPPGruposEmpaques/TiposEtiquetas/5
        [HttpGet]
        [Route("api/GPPGruposEmpaques/TiposEtiquetas/{id}")]
        [ResponseType(typeof(GPPTiposEtiquetasDto))]
        public IHttpActionResult GetTipoEtiqueta(int id)
        {
            var entity = db.GPPTiposEtiquetas.Find(id);
            if (entity == null)
                return NotFound();

            return Ok(Mapper.Map<GPPTiposEtiquetas, GPPTiposEtiquetasDto>(entity));
        }

        // PUT: api/GPPGruposEmpaques/TiposEtiquetas/5
        [HttpPut]
        [Route("api/GPPGruposEmpaques/TiposEtiquetas/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoEtiqueta(int id, GPPTiposEtiquetas entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != entity.IdEtiqueta)
                return BadRequest();

            entity.Descripcion = entity.Descripcion ?? string.Empty;

            db.Entry(entity).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoEtiquetaExists(id))
                    return NotFound();
                else
                    throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/GPPGruposEmpaques/TiposEtiquetas
        [HttpPost]
        [Route("api/GPPGruposEmpaques/TiposEtiquetas")]
        [ResponseType(typeof(GPPTiposEtiquetasDto))]
        public IHttpActionResult PostTipoEtiqueta(GPPTiposEtiquetas entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            entity.Habilitado = true;
            entity.Descripcion = entity.Descripcion ?? string.Empty;

            db.GPPTiposEtiquetas.Add(entity);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TipoEtiquetaExists(entity.IdEtiqueta))
                    return Conflict();
                else
                    throw;
            }

            var dto = Mapper.Map<GPPTiposEtiquetas, GPPTiposEtiquetasDto>(entity);
            return CreatedAtRoute("DefaultApi", new { id = entity.IdEtiqueta }, dto);
        }

        // DELETE: api/GPPGruposEmpaques/TiposEtiquetas/5
        [HttpDelete]
        [Route("api/GPPGruposEmpaques/TiposEtiquetas/{id}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult DeleteTipoEtiqueta(int id)
        {
            var entity = db.GPPTiposEtiquetas.Find(id);
            if (entity == null)
                return NotFound();

            entity.Habilitado = false; // soft delete
            db.SaveChanges();
            return Ok();
        }

        private bool TipoEtiquetaExists(int id)
        {
            return db.GPPTiposEtiquetas.Count(e => e.IdEtiqueta == id) > 0;
        }
    }
}
