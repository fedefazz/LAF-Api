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
using System.Data.Entity.Migrations;

namespace LVS.Api.Controllers
{
    public class PSSOperadoresController : ApiController
    {
        private LAFScrapEntities db = new LAFScrapEntities();

        // GET: api/PSSOperadores
        public List<OperadoresDto> GetPSSOperadores()
        {

            List<PSSOperadores> operadores = db.PSSOperadores.Where(c => c.Habilitado == true).ToList();


            List<OperadoresDto> listOperadores = Mapper.Map<List<PSSOperadores>, List<OperadoresDto>>(operadores);

            return listOperadores;
        }

        // GET: api/PSSOperadores/5
        [ResponseType(typeof(OperadoresDto))]
        public IHttpActionResult GetPSSOperadores(int id)
        {
            PSSOperadores pSSOperadores = db.PSSOperadores.Find(id);
            if (pSSOperadores == null)
            {
                return NotFound();
            }

            OperadoresDto operador = Mapper.Map<OperadoresDto>(pSSOperadores);

            return Ok(operador);
        }

        // PUT: api/PSSOperadores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPSSOperadores(int id, PSSOperadores pSSOperadores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pSSOperadores.IdOperador)
            {
                return BadRequest();
            }


            db.Entry(pSSOperadores).State = EntityState.Modified;



            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!PSSOperadoresExists(id))
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

        // POST: api/PSSOperadores
        [ResponseType(typeof(PSSOperadores))]
        public IHttpActionResult PostPSSOperadores(PSSOperadores pSSOperadores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            

            pSSOperadores.Habilitado = true;
            db.PSSOperadores.Add(pSSOperadores);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PSSOperadoresExists(pSSOperadores.IdOperador))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            OperadoresDto operador = Mapper.Map<OperadoresDto>(pSSOperadores);


            return CreatedAtRoute("DefaultApi", new { id = pSSOperadores.IdOperador }, operador);
        }

        // DELETE: api/PSSOperadores/5
        [ResponseType(typeof(PSSOperadores))]
        public IHttpActionResult DeletePSSOperadores(int id)
        {
            PSSOperadores pSSOperadores = db.PSSOperadores.Find(id);
            if (pSSOperadores == null)
            {
                return NotFound();
            }



             pSSOperadores.Habilitado = false;
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

        private bool PSSOperadoresExists(int id)
        {
            return db.PSSOperadores.Count(e => e.IdOperador == id) > 0;
        }
    }
}