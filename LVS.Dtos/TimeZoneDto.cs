using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS.Dtos
{
    public class TimeZoneDto
    {

        public TimeZoneDto()
        {
            this.Branch = new HashSet<AreasDto>();
            this.Branch1 = new HashSet<AreasDto>();
            this.User = new HashSet<UserDto>();
        }

        public int Id { get; set; }
        public string DisplayName { get; set; }
        public double UTCOffset { get; set; }
        public string Abbr { get; set; }

        public virtual ICollection<AreasDto> Branch { get; set; }
        public virtual ICollection<AreasDto> Branch1 { get; set; }
        public virtual ICollection<UserDto> User { get; set; }



    }
}
