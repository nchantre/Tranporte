using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransporteModel.Model
{
    public  class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Origen { get; set; }
        public int TiempoTranscurrido { get; set; }
        public string NombrePasajero { get; set; }
        public string PlacaVehiculo { get; set; }
        public string HoraViaje { get; set; }
    }
}
