using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TrasnporteAdmin.Models
{
    public class ResultadoApi
    {
        public string mensaje { get; set; }
        public List<EmpleadoViewModel> lista { get; set; }
        public EmpleadoViewModel objeto { get; set; }
    }
}
