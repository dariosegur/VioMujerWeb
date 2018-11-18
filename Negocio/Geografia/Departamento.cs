using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Geografia
{
    public class Departamento
    {
        public long DepartamentoId { get; set; }
        public string Nombre { get; set; }
        public static List<Departamento> GetDepartamentos()
        {
            using (var context = new Datos.VioMujerEntities())
            {
                var r = context.Departamentoes.ToList().Select(d=>Map(d)).ToList();
                return r;
            }
        }
        private static Departamento Map(Datos.Departamento registro) {
            return new Departamento {
                DepartamentoId=registro.DepartamentoId,
                Nombre=registro.Nombre
            };
        }
    }
}
