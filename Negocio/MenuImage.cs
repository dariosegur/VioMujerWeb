using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MenuImage
    {
        public long MenuImageId { get; set; }
        public string Titulo { get; set; }
        public List<MenuImageItem> Items { get; set; }
        public static MenuImage GetMenuImage(int MenuItemId) {
            var result = new MenuImage();
            using (var context = new Datos.VioMujerEntities())
            {
                var r = context.MenuImages.Single(i=>i.MenuImageId== MenuItemId);
                result = Map(r);
            }
            return result;
        }
        private static MenuImage Map(Datos.MenuImage origen) {
            return new MenuImage {
                Titulo = origen.Titulo,
                MenuImageId = origen.MenuImageId,
                Items = origen.MenuImageItems.Select(i=>MenuImageItem.Map(i)).ToList()
            };
        }
    }
}
