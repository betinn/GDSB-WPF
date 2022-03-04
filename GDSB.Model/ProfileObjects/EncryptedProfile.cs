namespace GDSB.Model.ProfileObjects
{
    public class EncryptedProfile
    {
        public string name { get; set; }
        public string baseImg64 { get; set; }

        public byte[] profileEncrypted { get; set; }
    }
}
