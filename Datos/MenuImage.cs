//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class MenuImage
    {
        public MenuImage()
        {
            this.MenuImageItems = new HashSet<MenuImageItem>();
        }
    
        public long MenuImageId { get; set; }
        public string Titulo { get; set; }
    
        public virtual ICollection<MenuImageItem> MenuImageItems { get; set; }
    }
}
