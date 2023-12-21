using System;
using System.Collections.Generic;


namespace NormControl.Norms
{
    public class Style { 
        public string font_family { get; set; } = "Arial";
        public int font_size {get; set; }
        public bool is_bold {get; set; } = false;
        public bool is_italic {get; set; } = false;

        public Style(int font_size = 12) {
            this.font_size = font_size;
        }
    }
}