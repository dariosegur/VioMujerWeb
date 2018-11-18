using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VioMujerWeb.Models
{
    public class GridHeader:BasicModelGrid
    {
        public string Text { get; set; }
        public string Field { get; set; }
        public string Value { get; set; }
        public bool Hasfilter { get; set; }
        public GridHeader(BasicModelGrid Basico, string Text, string Field,string Value) {
            OrderBy = Basico.OrderBy;
            Descendente = Basico.Descendente;
            this.Text = Text;
            this.Field = Field;
            this.Value = Value;
            this.Hasfilter = true;
        }
    }
}