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
    public class PSSJobTrackController : ApiController
    {
        private LAFScrapEntities db = new LAFScrapEntities();



        // GET: api/PSSOrigenesScraps
        public List<JobTrackDto> GetPSSJobTrack()


        {

            // Obtener la lista de JobTrack desde la base de datos
            List<PSSJobTrack> jobtrackList = db.PSSJobTrack.Where(c => c.Habilitado == true).ToList();
            List<JobTrackDto> listJobTrack = Mapper.Map<List<PSSJobTrack>, List<JobTrackDto>>(jobtrackList);

            return listJobTrack;
        }

        // GET: api/PSSOrigenesScraps/5
        [ResponseType(typeof(JobTrackDto))]
        public async Task<IHttpActionResult> GetPSSJobTrack(int id)
        {
            PSSJobTrack pSSJobTrack = await db.PSSJobTrack.FindAsync(id);
            if (pSSJobTrack == null)
            {
                return NotFound();
            }

            List<JobtrackModulosDto> modulesForJobTrackdto= new List<JobtrackModulosDto>();
            var modulesForJobTrack = db.PSSJobtrackModulos
                                         .Where(modulo => modulo.IdJobtrack == pSSJobTrack.IDJobTrack)
                                         .ToList();

            foreach (var item in modulesForJobTrack)

            {

                JobTrackDto nuevoJobTrackDto = new JobTrackDto();

                nuevoJobTrackDto.Habilitado = item.PSSJobTrack.Habilitado;
                nuevoJobTrackDto.Descripcion = item.PSSJobTrack.Descripcion;
                nuevoJobTrackDto.IDJobTrack = item.PSSJobTrack.IDJobTrack;
                nuevoJobTrackDto.JobTrack = item.PSSJobTrack.JobTrack;
                nuevoJobTrackDto.PrinterDefault = item.PSSJobTrack.PrinterDefault;
                nuevoJobTrackDto.PrinterEtiquetas = item.PSSJobTrack.PrinterEtiquetas;


                JobtrackModulosDto moduloDto = new JobtrackModulosDto();
                moduloDto.Descripcion = item.Descripcion;
                moduloDto.IdJobtrack = item.IdJobtrack;
                moduloDto.IdModuloApp = item.IdModuloApp;
                moduloDto.PSSJobTrack = nuevoJobTrackDto;
                modulesForJobTrackdto.Add(moduloDto);
            }

            JobTrackDto2 moduloForExport = new JobTrackDto2();
            moduloForExport.JobTrack = pSSJobTrack.JobTrack;
            moduloForExport.Descripcion = pSSJobTrack.Descripcion;
            moduloForExport.Habilitado = pSSJobTrack.Habilitado;
            moduloForExport.IDJobTrack = pSSJobTrack.IDJobTrack;
            moduloForExport.PrinterDefault = pSSJobTrack.PrinterDefault;
            moduloForExport.PrinterEtiquetas = pSSJobTrack.PrinterEtiquetas;
            moduloForExport.PSSJobtrackModulos = modulesForJobTrackdto;


            return Ok(moduloForExport);
        }

        // PUT: api/PSSOrigenesScraps/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPSSJobTrack(int id, PSSJobTrack pSSJobTrack)



        {

            List<PSSJobtrackModulos> modulos = db.PSSJobtrackModulos.Where(z => z.IdJobtrack == id).ToList();


            if (modulos.Count > 0) { 
            foreach (var item in modulos)
            { db.PSSJobtrackModulos.Remove(item); }

               
                
            }
            if (pSSJobTrack.PSSJobtrackModulos.Count > 0)
            {
                foreach (var item in pSSJobTrack.PSSJobtrackModulos)
                {


                    db.PSSJobtrackModulos.Add(item);




                }
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException e)


                {
                    if (!PSSJobTrackExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw e;
                    }
                }

            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pSSJobTrack.IDJobTrack)
            {
                return BadRequest();
            }

            if (pSSJobTrack.PrinterDefault == null)
            {
                pSSJobTrack.PrinterDefault = "";
            }

            if (pSSJobTrack.PrinterEtiquetas == null)
            {
                pSSJobTrack.PrinterEtiquetas = "";
            }

            if (pSSJobTrack.JobTrack == null)
            {
                pSSJobTrack.JobTrack = "";
            }

            db.Entry(pSSJobTrack).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PSSJobTrackExists(id))
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
        public async Task<IHttpActionResult> PostPSSJobTrack(PSSJobTrack pSSJobTrack)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            pSSJobTrack.Habilitado = true;

            if (pSSJobTrack.PrinterDefault == null)
            {
                pSSJobTrack.PrinterDefault = "";
            }

            if (pSSJobTrack.PrinterEtiquetas == null)
            {
                pSSJobTrack.PrinterEtiquetas = "";
            }

            if (pSSJobTrack.JobTrack == null)
            {
                pSSJobTrack.JobTrack = "";
            }


            db.PSSJobTrack.Add(pSSJobTrack);

         


            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PSSJobTrackExists(pSSJobTrack.IDJobTrack))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            JobTrackDto jobtrack = Mapper.Map<JobTrackDto>(pSSJobTrack);

            //PSSJobtrackModulos modulo = new PSSJobtrackModulos();

            //modulo.IdJobtrack = pSSJobTrack.IDJobTrack;
            //modulo.Descripcion = "test";

            //db.PSSJobtrackModulos.Add(modulo);
            //await db.SaveChangesAsync();


            return CreatedAtRoute("DefaultApi", new { id = pSSJobTrack.IDJobTrack }, jobtrack);
        }

        // DELETE: api/PSSOrigenesScraps/5
        [ResponseType(typeof(PSSOrigenesScrap))]
        public async Task<IHttpActionResult> DeletePSSJobTrack(int id)
        {
            PSSJobTrack pSSJobTrack = await db.PSSJobTrack.FindAsync(id);
            if (pSSJobTrack == null)
            {
                return NotFound();
            }

            pSSJobTrack.Habilitado = false;
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

        private bool PSSJobTrackExists(int id)
        {
            return db.PSSJobTrack.Count(e => e.IDJobTrack == id) > 0;
        }
    }
}