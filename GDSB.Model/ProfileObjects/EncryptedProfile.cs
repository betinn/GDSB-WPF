using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDSB.Model.ProfileObjects
{
    public class EncryptedProfile
    {
        public string name = string.Empty;
        public string baseImg64 = string.Empty;

        public byte[] profileEncrypted;
    }
}
