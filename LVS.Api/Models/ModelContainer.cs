using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using LVS.Model;

namespace LVS.Api.Models
{
    public partial class BLSPEntities : DbContext
    {


        public virtual DbSet<Model.Action> Action { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }


        public BLSPEntities() 
        {
            this.Database.CommandTimeout = 4500;
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


         



            //throw new UnintentionalCodeFirstException();



           





        }







    }

}