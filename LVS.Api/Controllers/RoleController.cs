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
    public class RoleController : ApiController
    {
        private LAFScrapEntities db = new LAFScrapEntities();

        // GET: api/PSSMaquinas
        public List<RoleDto> GetRole()
        {
            List<Role> roles = db.Role.ToList();


            List<RoleDto> listMaquinas = Mapper.Map<List<Role>, List<RoleDto>>(roles);



            return listMaquinas;
        }

        // GET: api/PSSMaquinas/5
        [ResponseType(typeof(RoleDto))]
        public IHttpActionResult GetRole(int id)
        {
            Role roles = db.Role.Find(id);
            if (roles == null)
            {
                return NotFound();
            }


            RoleDto role = Mapper.Map<RoleDto>(roles);

            return Ok(role);
        }


        // GET: api/PSSMaquinas/5
        [ResponseType(typeof(RoleDto))]
        [Route("api/Role/GetRolePorID/")]

        public RoleDto GetRolePorID(int id)
        {
            Role role = db.Role.Find(id);
            RoleDto _role = Mapper.Map<RoleDto>(role);

            return _role;
        }






        // PUT: api/PSSTiposMaterials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRole(int id, Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Convert.ToInt32(role.Id))
            {
                return BadRequest();
            }

            db.Entry(role).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roleExists(id))
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
        [ResponseType(typeof(Role))]
        public IHttpActionResult PostRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Role.Add(role);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (roleExists(Convert.ToInt32(role.Id)))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            RoleDto _role = Mapper.Map<RoleDto>(role);


            return CreatedAtRoute("DefaultApi", new { id = role.Id }, _role);
        }

        // DELETE: api/PSSTiposMaterials/5
        [ResponseType(typeof(Role))]
        public IHttpActionResult DeleteRole(int id)
        {
            Role role = db.Role.Find(id);
            if (role == null)
            {
                return NotFound();
            }

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

        private bool roleExists(int id)
        {
            return db.Role.Count(e => Convert.ToInt32(e.Id) == id) > 0;
        }
    }
}