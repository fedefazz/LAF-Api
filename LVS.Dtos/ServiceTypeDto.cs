using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LVS.Dtos
{
    public class ServiceTypeDto
    {

        public ServiceTypeDto()
        {
            this.Branch = new HashSet<AreasDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> Duration { get; set; }
        public Nullable<decimal> Price { get; set; }
        public bool IsEnabled { get; set; }
        public string CreationUser { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string LastModificationUser { get; set; }
        public Nullable<System.DateTime> LastModificationDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<AreasDto> Branch { get; set; }


    }
}
