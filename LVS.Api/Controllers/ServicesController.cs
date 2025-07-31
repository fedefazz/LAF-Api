//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using System.Web.Http.Description;
//using LVS.Model;
//using System.Threading.Tasks;
//using LVS.Utils.Solr;
//using System.Web;
//using Newtonsoft.Json;
//using LVS.Api.Models;

//namespace LVS.Api.Controllers
//{
//    public class ServicesController : ApiController
//    {
//        private Models.BLSPEntities db = new Models.BLSPEntities();
//        DateTime Now = DateTime.Now;

//        // GET: api/Services
//        public IQueryable<Service> GetService()
//        {
//            return db.Service.Where(c => c.IsDeleted == false);
//        }

//        // GET: api/Services/GetAllSolr
//        [Route("api/Services/GetAllSolr")]
//        public async Task<IHttpActionResult> GetAllSolr()
//        {


//            return Ok(await SolrHelper.ExecuteQuery(SolrCore.SERVICE, HttpUtility.UrlDecode(HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString.ToString()))));



//        }










//        // GET: api/Services/5
//        [ResponseType(typeof(Service))]
//        public IHttpActionResult GetService(int id)
//        {
//            Service service = db.Service.Find(id);
//            if (service == null)
//            {
//                return NotFound();
//            }

//            return Ok(service);
//        }

//        // PUT: api/Services/5
//        [ResponseType(typeof(void))]
//        public async Task<IHttpActionResult> PutService(int id, Service service)
//        {
//            if (!ModelState.IsValid)
//            {
//                BadRequest(ModelState);
//            }

//            if (id != service.ServiceId)
//            {
//                BadRequest();
//            }

//            using (var context = new Model.BLSPEntities())
//            {
//                var serviceInDb = context.Service.Include(c => c.ServiceType)
//                    .Single(c => c.ServiceId == service.ServiceId);

//                // Updates the Name property
//                context.Entry(serviceInDb).CurrentValues.SetValues(service);

//                // Remove types
//                foreach (var typeInDb in serviceInDb.ServiceType.ToList())
//                    if (!service.ServiceType.Any(t => t.TypeServiceId == typeInDb.TypeServiceId))
//                        serviceInDb.ServiceType.Remove(typeInDb);

//                // Add new types
//                foreach (var type in service.ServiceType)
//                    if (!serviceInDb.ServiceType.Any(t => t.TypeServiceId == type.TypeServiceId))
//                    {
//                        context.ServiceType.Attach(type);
//                        serviceInDb.ServiceType.Add(type);
//                    }

//                context.SaveChanges();

//                await SolrHelper.DataImport(SolrCore.SERVICE);

//            }


//            return StatusCode(HttpStatusCode.NoContent);

//        }



//        // POST: api/Services/saveGridDate
//        [Route("api/Services/saveGridDate")]
//        public void saveGridDate(DateTime date, int Slots)
//        {





//        }




//        // POST: api/Services
//        [ResponseType(typeof(Service))]
//        public async Task<IHttpActionResult> PostService(Service service)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }


//            //service.LastModificationDate = Now.AddHours(3);
//            //service.CreationDate = Now.AddHours(3);






//            service.LastModificationDate = Now;
//            service.CreationDate = Now;


//            List<ServiceType> listatiposervicio = new List<ServiceType>();
//            ServiceType tiposervicio = new ServiceType();

//            foreach (var item in service.ServiceType)
//            {

//                tiposervicio = db.ServiceType.Find(item.TypeServiceId);

//                listatiposervicio.Add(tiposervicio);

//            }




//            service.ServiceType = listatiposervicio;


//            db.Service.Add(service);
//            db.SaveChanges();
//            await SolrHelper.DataImport(SolrCore.SERVICE);



//            return CreatedAtRoute("DefaultApi", new { id = service.ServiceId }, service);
//        }

//        // DELETE: api/Services/5
//        [ResponseType(typeof(Service))]
//        public async Task<IHttpActionResult> DeleteService(int id)
//        {
//            Service service = db.Service.Find(id);
//            if (service == null)
//            {
//                return NotFound();
//            }


//            service.IsEnabled = false;
//            service.IsDeleted = true;

//            db.SaveChanges();
//            await SolrHelper.DataImport(SolrCore.SERVICE);

//            return Ok(service);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool ServiceExists(int id)
//        {
//            return db.Service.Count(e => e.ServiceId == id) > 0;
//        }
//    }
//}