using System;
using System.Collections.Generic;
using System.Drawing;

namespace GDSB.Model.Old
{
    public class Profile
    {
        public string fullFileName { get; set; }
        public string nome { get; set; }
        public DateTime dataNascimento { get; private set; }
        public string senha { get; set; }
        public DateTime dtCreated { get; private set; }
        public List<SecretBox> boxes { get; set; }
        public bool secretKey { get; private set; }
        public string imageBase64 { get; set; }
        public Settings.Config config { get; set; }
        public Color pnColor { get; set; }


        public Color pnBackColor { get; set; } //Velho


        public Profile(string fullFileName, string nome, DateTime dataNascimento, bool secretKey, string senha, DateTime dtCreated, List<SecretBox> lssecrets, string imageBase64
            , Color color)
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
            this.pnColor = color;

        }

        public string GetSecretKey()
        {
            return string.Format("GD-SECRET-{0}{1}{2}{3}{4}{5}",
                nome.Substring(0, 1), senha, nome.Substring(nome.Length - 1, 1), dataNascimento.Month.ToString(), dtCreated.Day.ToString(), dtCreated.Second.ToString());
        }
    }
}
