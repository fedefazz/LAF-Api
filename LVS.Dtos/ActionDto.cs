using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS.Dtos
{
    public class ActionDto
    {
        public ActionDto()
        {
            this.Role = new HashSet<RoleDto>();
        }

        public int Id { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }

        public virtual ICollection<RoleDto> Role { get; set; }




    }
}
