using LVS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS.Dtos
{
    public class UserDto
    {

        public UserDto()
        {

            this.UserClaim = new HashSet<UserClaim>();

            this.UserLogin = new HashSet<UserLogin>();


            this.Role = new HashSet<RoleDto>();


        }


        public string Id { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public Nullable<bool> PhoneNumberConfirmed { get; set; }

        public Nullable<bool> TwoFactorEnabled { get; set; }

        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }

        public Nullable<bool> LockoutEnabled { get; set; }

        public Nullable<int> AccessFailedCount { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string CellPhone { get; set; }

        public string Description { get; set; }

        public Nullable<bool> IsEnabled { get; set; }

        public Nullable<bool> IsDeleted { get; set; }

        public string CreationUser { get; set; }

        public Nullable<System.DateTime> CreationDate { get; set; }

        public string LastModificationUser { get; set; }

        public Nullable<System.DateTime> LastModificationDate { get; set; }

        public string ProfileImagePath { get; set; }

        public string MigrationId { get; set; }




        public virtual ICollection<UserClaim> UserClaim { get; set; }


        public virtual ICollection<UserLogin> UserLogin { get; set; }




        public virtual ICollection<RoleDto> Role { get; set; }



    }
}
