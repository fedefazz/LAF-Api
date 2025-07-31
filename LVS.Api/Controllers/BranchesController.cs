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
//using LVS.Dtos;
//using AutoMapper;
//using AutoMapper.QueryableExtensions;
//using LVS.Utils;
//using LVS.Utils.Solr;
//using System.Threading.Tasks;
//using System.Web;

//namespace LVS.Api.Controllers
//{


//    public class BranchesController : ApiController
//    {
//        private BLSPEntities db = new BLSPEntities();
//        DateTime Now = DateTime.Now;

//        // GET: api/Branches

//        public IQueryable<Branch> GetBranch()
//        {

//            return db.Branch.Where(c => c.IsDeleted == false);

//            //return db.Branch.Where(b => b.IsDeleted != true).ProjectTo<BranchDto>();

//        }



//        // GET: api/Branches/GetAllSolr
//        [Route("api/Branches/GetAllSolr")]
//        public async Task<IHttpActionResult> GetAllSolr()
//        {

            
//            return Ok(await SolrHelper.ExecuteQuery(SolrCore.BRANCH, HttpUtility.UrlDecode(HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString.ToString()))));

           

//        }



//        // GET: api/Branches/5
//        [ResponseType(typeof(Branch))]
//        public IHttpActionResult GetBranch(int id)
//        {
//            Branch branch = db.Branch.Find(id);
//            if (branch == null)
//            {
//                return NotFound();
//            }

//            return Ok(branch);
//        }

//        // PUT: api/Branches/5
//        [HttpPut]
//        [ResponseType(typeof(void))]
//        public async Task PutBranch(int id, Branch branch)
//        {
//            if (!ModelState.IsValid)
//            {
//                BadRequest(ModelState);
//            }

//            if (id != branch.Id)
//            {
//                BadRequest();
//            }

//            db.Entry(branch).State = EntityState.Modified;

//            try
//            {
//                branch.LastModificationDate = Now.AddHours(3);
//                db.SaveChanges();

//                await SolrHelper.DataImport(SolrCore.BRANCH);


                
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!BranchExists(id))
//                {
//                    NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            StatusCode(HttpStatusCode.NoContent);
//        }

//        // POST: api/Branches
//        [ResponseType(typeof(Branch))]
//        public async Task PostBranch(Branch branch)
//        {
//            if (!ModelState.IsValid)
//            {
//                BadRequest(ModelState);
//            }


//            branch.LastModificationDate = Now.AddHours(3);
//            branch.CreationDate = Now.AddHours(3);
//            db.Branch.Add(branch);
//            db.SaveChanges();
//            await SolrHelper.DataImport(SolrCore.BRANCH);


//           CreatedAtRoute("DefaultApi", new { id = branch.Id }, branch);
//        }

//        // DELETE: api/Branches/5
//        [ResponseType(typeof(Branch))]
//        public async Task DeleteBranch(int id)
//        {
//            Branch branch = db.Branch.Find(id);
//            if (branch == null)
//            {
//               NotFound();
//            }

//            branch.IsDeleted = true;
//            branch.IsEnabled = false;

//            await SolrHelper.DataImport(SolrCore.BRANCH);
//            db.SaveChanges();

//            Ok(branch);
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private bool BranchExists(int id)
//        {
//            return db.Branch.Count(e => e.Id == id) > 0;
//        }
//    }
//}