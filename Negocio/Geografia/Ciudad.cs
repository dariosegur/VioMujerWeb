using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Geografia
{
    public class Ciudad
    {
        public long CiudadId { get; set; }
        public string Nombre { get; set; }
        public long DepartamentoId { get; set; }
        public static List<Ciudad> GetCiudadesPorDepartamento(int DepartamentoId)
        {
            using (var context = new Datos.VioMujerEntities())
            {
                var r = context.Ciudads.Where(c=>c.DepartamentoId==DepartamentoId).ToList().Select(d => Map(d)).ToList();
                return r;
            }
        }
        private static Ciudad Map(Datos.Ciudad registro)
        {
            return new Ciudad
            {
                DepartamentoId=registro.DepartamentoId,
                CiudadId = registro.CiudadId,
                Nombre = registro.Nombre
            };
        }
    }
}
