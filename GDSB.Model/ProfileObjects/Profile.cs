using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDSB.Model.ProfileObjects
{
    public class Profile
    {
        public string fullFileName { get; set; }
        public string nome { get; set; }
        public DateTime dataNascimento { get; private set; }
        public string senha { get; set; }
        public DateTime dtCreated { get; private set; }

        public List<SecretBox> boxes = null;
        public bool secretKey { get; private set; }
        public string imageBase64 { get; set; }
        public Settings.Config config { get; set; }
        public System.Windows.Media.Color colorGradLine1 { get; set; }
        public System.Windows.Media.Color colorGradLine2 { get; set; }
        public System.Windows.Media.Color colorGradLine3 { get; set; }
        public List<CreditCard> creditCards = new List<CreditCard>();


        public Profile(string fullFileName, string nome, DateTime dataNascimento, bool secretKey, string senha, DateTime dtCreated, List<SecretBox> lssecrets, string imageBase64
            , System.Windows.Media.Color color1, System.Windows.Media.Color color2, System.Windows.Media.Color color3)
        {
            config = new Settings.Config();

            this.fullFileName = fullFileName;
            this.nome = nome;
            this.dataNascimento = dataNascimento;
            this.senha = senha;
            this.dtCreated = dtCreated;
            this.boxes = lssecrets;
            this.secretKey = secretKey;
            this.imageBase64 = imageBase64;
            this.colorGradLine1 = color1;
            this.colorGradLine2 = color2;
            this.colorGradLine3 = color3;


        }

        public string GetSecretKey()
        {
            return string.Format("GD-SECRET-{0}{1}{2}{3}{4}{5}", 
                nome.Substring(0, 1), senha, nome.Substring(nome.Length - 1, 1), dataNascimento.Month.ToString(), dtCreated.Day.ToString(), dtCreated.Second.ToString());
        }
    }
}
