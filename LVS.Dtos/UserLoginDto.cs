using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS.Dtos
{
    public class UserLoginDto
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public int UserId { get; set; }

        public virtual UserDto User { get; set; }



    }
}
