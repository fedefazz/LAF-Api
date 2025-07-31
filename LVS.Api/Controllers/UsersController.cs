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
using System.Threading.Tasks;
using LVS.Utils.Solr;
using System.Web;
using LVS.Api.Models;
using AutoMapper;
using LVS.Dtos;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace LVS.Api.Controllers
{
    public class UsersController : ApiController
    {

        private ApplicationUserManager _userManager;



        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private LVS.Model.LAFScrapEntities db = new LVS.Model.LAFScrapEntities();
        DateTime Now = DateTime.Now;



        // GET: api/Users
        public List<UserDto> GetUser()
        {
            List<User> usuarios = db.User.ToList();


            List<UserDto> listUser = Mapper.Map<List<User>, List<UserDto>>(usuarios);

            return listUser;

        }

        // GET: api/Users/GetAllSolr
        [Route("api/Users/GetAllSolr")]
        public async Task<IHttpActionResult> GetAllSolr()
        {


            return Ok(await SolrHelper.ExecuteQuery(SolrCore.USER, HttpUtility.UrlDecode(HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString.ToString()))));



        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }




            UserDto User = Mapper.Map<User, UserDto>(user);


            return Ok(User);





        }
        // GET: api/Users/5
        [Route("api/Users/GetUserById")]

        [ResponseType(typeof(User))]
        public User GetUserById(string id)
        {


            User User = db.User.Find(id);
            return User;



        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(string id, User pssuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pssuser.Id)
            {
                return BadRequest();
            }



            var userInDb = db.User

               .Include(c => c.Role)


               .Single(c => c.Id == pssuser.Id);


            // Updates the Name property
            db.Entry(userInDb).CurrentValues.SetValues(pssuser);


            // Remove types
            foreach (var typeInDb in userInDb.Role.ToList())
            {
                if (!pssuser.Role.Any(t => t.Id == typeInDb.Id))
                    userInDb.Role.Remove(typeInDb);
            }
            // Add new types
            foreach (var type in pssuser.Role)
            {
                if (!userInDb.Role.Any(t => t.Id == type.Id))
                {
                    db.Role.Attach(type);
                    userInDb.Role.Add(type);
                }
            }








            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user.LastModificationDate = Now.AddHours(3);
            user.CreationDate = Now.AddHours(3);
            db.User.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(string id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.IsEnabled = false;
            user.IsDeleted = true;

            db.SaveChanges();
            await SolrHelper.DataImport(SolrCore.USER);
            return Ok(user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        [Route("api/Users/Enable")]

        public async Task<IHttpActionResult> Enable(string id)
        {
            User user = db.User.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.IsEnabled = true;
            user.IsDeleted = false;

            db.SaveChanges();
            await SolrHelper.DataImport(SolrCore.USER);
            return Ok(user);
        }



        [HttpPost]
        [Route("api/Users/UpdateProfileImage")]
        public async Task<IHttpActionResult> UpdateProfileImage()
        {
            //if (!Request.Content.IsMimeMultipartContent())
            //{
            //    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            //}

            var file = HttpContext.Current.Request.Files.Count > 0 ?
            HttpContext.Current.Request.Files[0] : null;


            var userId = User.Identity.GetUserId();

            User user = GetUserById(userId);

            var httpRequest = System.Web.HttpContext.Current.Request;

            if (httpRequest.Files != null && httpRequest.Files.Count > 0)
            {
                var postedFile = httpRequest.Files[0];
                user.ProfileImagePath = ImageStorage.ImageStoreHelper.UpdateUserProfileImage(user.ProfileImagePath, postedFile);

                await PutUser(userId, user);
                return Ok();
            }

            ModelState.AddModelError("Image", "image is required");
            return BadRequest(ModelState);
        }






        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(string id)
        {
            return db.User.Count(e => e.Id == id) > 0;
        }
    }
}