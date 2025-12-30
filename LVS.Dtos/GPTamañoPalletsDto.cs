using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LVS.Model;

namespace LVS.Dtos
{
    public partial class GPTamañoPalletsDto
    {
        public int IdTamañoPallet { get; set; }
        public string Descripcion { get; set; }
        public long Habilitado { get; set; }
    }
}
