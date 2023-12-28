using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {

        public int Id {  get; set; }
        public string UserName { get; set; }
        public ML.Rol rol { get; set; }
        public List<object> Usuarios { get; set; }
    }
}
