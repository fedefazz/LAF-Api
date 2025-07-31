using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS.Dtos
{
    public class RoleDto
    {

        public RoleDto()
        {
            this.Action = new HashSet<ActionDto>();
            //this.User = new HashSet<UserDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ActionDto> Action { get; set; }
        //public virtual ICollection<UserDto> User { get; set; }


    }
}
