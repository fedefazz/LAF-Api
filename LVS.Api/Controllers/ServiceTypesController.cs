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
//using LVS.Utils.Solr;
//using System.Web;
//using System.Threading.Tasks;

//namespace LVS.Api.Controllers
//{
//    public class ServiceTypesController : ApiController
//    {
//        private BLSPEntities db = new BLSPEntities();

//        // GET: api/ServiceTypes
//        public IQueryable<ServiceType> GetServiceType()
//        {
//            return db.ServiceType.Where(c => c.IsDeleted == false).Distinct();
//        }

//        // GET: api/Clients/GetAllSolr
//        [Route("api/ServiceTypes/GetAllSolr")]
//        public async Task<IHttpActionResult> GetAllSolr()
//        {
//            return Ok(await SolrHelper.ExecuteQuery(SolrCore.SERVICETYPE, HttpUtility.UrlDecode(HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString.ToString()))));
//        }

//        // GET: api/ServiceTypes/5
//        [ResponseType(typeof(ServiceType))]
//        public IHttpActionResult GetServiceType(int id)
//        {
//            ServiceType serviceType = db.ServiceType.Find(id);
//            if (serviceType == null)
//            {
//                return NotFound();
//            }

//            return Ok(serviceType);
//        }

//        // PUT: api/ServiceTypes/5
//        [ResponseType(typeof(void))]
//        public async Task<IHttpActionResult> PutServiceType(int id, ServiceType serviceType)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != serviceType.TypeServiceId)
//            {
//                return BadRequest();
//            }

//            db.Entry(serviceType).State = EntityState.Modified;

//            try
//            {
//                serviceType.LastModificationDate = DateTime.Now.AddHours(3);

//                db.SaveChanges();

//                await SolrHelper.DataImport(SolrCore.SERVICETYPE);
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!ServiceTypeExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/ServiceTypes
//        [ResponseType(typeof(ServiceType))]
//        public async Task<IHttpActionResult> PostServiceType(ServiceType serviceType)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            serviceType.LastModificationDate = DateTime.Now.AddHours(3);
//            serviceType.CreationDate = DateTime.Now.AddHours(3);

//            db.ServiceType.Add(serviceType);
//            db.SaveChanges();

//            await SolrHelper.DataImport(SolrCore.SERVICETYPE);

//            return CreatedAtRoute("DefaultApi", new { id = serviceType.TypeServiceId }, serviceType);
//        }

//        // DELETE: api/ServiceTypes/5
//        [ResponseType(typeof(ServiceType))]
//        public async Task<IHttpActionResult> DeleteServiceType(int id)
//        {
//            ServiceType serviceType = db.ServiceType.Find(id);
//            if (serviceType == null)
//            {
//                return NotFound();
//            }

//            serviceType.IsDeleted = true;
//            serviceType.IsEnabled = false;

//            db.SaveChanges();

//            await SolrHelper.DataImport(SolrCore.SERVICETYPE);

//            return Ok(serviceType);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool ServiceTypeExists(int id)
//        {
//            return db.ServiceType.Count(e => e.TypeServiceId == id) > 0;
//        }
//    }
//}