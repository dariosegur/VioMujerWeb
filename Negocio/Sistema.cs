using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Sistema
    {
        public static Dictionary<int, string> GetDepartamentosColombia()
        {
            return PaisesCiudadesService.PaisesCiudadesService.GetDepartamentos("CO");
        }

        public static Dictionary<int, string> GetCiudadDepartamentosColombia(int DepartamentoId)
        {
            return PaisesCiudadesService.PaisesCiudadesService.GetCiudades("CO",DepartamentoId);
        }
    }
}
