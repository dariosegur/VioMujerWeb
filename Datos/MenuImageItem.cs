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
    
    public partial class MenuImageItem
    {
        public long MenuImageItemId { get; set; }
        public long MenuImageId { get; set; }
        public string Texto { get; set; }
        public string Imagen { get; set; }
        public string Link { get; set; }
    
        public virtual MenuImage MenuImage { get; set; }
    }
}