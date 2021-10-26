using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDSB.Model.ProfileObjects
{
    public class SecretBox
    {
        public System.Windows.Media.Color newBaseColor { get; set; }
        public string boxName = string.Empty;
        public string url = string.Empty;
        public string user = string.Empty;
        public string pass = string.Empty;
        public string obs = string.Empty;
        public string base64IMG = string.Empty;
        public DateTime dtCreated;
    }
}
