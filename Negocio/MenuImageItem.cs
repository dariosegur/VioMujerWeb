using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MenuImageItem
    {
        public long MenuImageItemId { get; set; }
        public long MenuImageId { get; set; }
        public string Texto { get; set; }
        public string Imagen { get; set; }
        public string Link { get; set; }
        public static MenuImageItem Map(Datos.MenuImageItem origen) {
            return new MenuImageItem {
                Imagen=origen.Imagen,
                Link=origen.Link,
                MenuImageId=origen.MenuImageId,
                MenuImageItemId=origen.MenuImageItemId,
                Texto=origen.Texto
            };
        }
    }
}
