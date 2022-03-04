using System;
using System.Drawing;

namespace GDSB.Model.Old
{
    public class SecretBox
    {
        public Color baseColor { get; set; }
        public string boxName { get; set; }
        public string url { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public string obs { get; set; }
        public string base64IMG { get; set; }
        public DateTime dtCreated { get; set; }
    }
}
