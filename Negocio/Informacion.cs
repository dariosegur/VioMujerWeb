using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Information
    {
        public long InformationId { get; set; }
        public string Texto { get; set; }
        public string Imagen { get; set; }
        public static Information GetInformacion(int InformationId)
        {
            var result = new Information();
            using (var context = new Datos.VioMujerEntities())
            {
                var r = context.Information.Single(i => i.InformationId == InformationId);
            }
            return result;
        }
        private static Information Map(Datos.Information origen)
        {
            return new Information {
                InformationId= origen.InformationId,
                Imagen= origen.Imagen,
                Texto= origen.Texto
            };
        }
    }
}
