using System;

namespace GDSB.Model.ProfileObjects
{
    public class SecretBox
    {
        public bool favorito { get; set; }
        public System.Windows.Media.Color newBaseColor { get; set; }
        public string boxName { get; set; }
        public string url { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public string obs { get; set; }
        public string base64IMG { get; set; }
        public DateTime dtCreated { get; set; }
    }
}
