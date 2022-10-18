using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrasnporteAdmin.Models
{
    public class EmpleadoViewModel
    {
        public int IdEmpleado { get; set; }
        public string Origen { get; set; }
        public int TiempoTranscurrido { get; set; }
        public string NombrePasajero { get; set; }
        public string PlacaVehiculo { get; set; }
        public string HoraViaje { get; set; }
    }
}
