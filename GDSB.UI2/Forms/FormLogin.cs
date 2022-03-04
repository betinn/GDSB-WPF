using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GDSB.UI.Forms
{
    public partial class FormLogin : Form
    {
        public Model.Old.Profile profile { get; set; } = null;
        private GDSB.Model.ProfileObjects.EncryptedProfile encryptedProfile = null;
        public FormLogin(GDSB.Model.ProfileObjects.EncryptedProfile profile)
        {
            InitializeComponent();
            this.encryptedProfile = profile;


            label2.Text = "Two Factor Code - (Não habilitado)";
        }

        private void buttonCreateProfSave_Click(object sender, EventArgs e)
        {
            checkPass();
        }

        private void checkPass()
        {
            try
            {
                profile = GDSB.Business.ProfileConfiguration.TryDecryptOldProfile(textBoxPassword.Text, encryptedProfile.profileEncrypted);

                List<GDSB.Model.ProfileObjects.SecretBox> ls = new List<GDSB.Model.ProfileObjects.SecretBox>();
                foreach (var sb in profile.boxes)
                {
                    ls.Add(new GDSB.Model.ProfileObjects.SecretBox()
                    {
                        base64IMG = sb.base64IMG,
                        boxName = sb.boxName,
                        dtCreated = sb.dtCreated,
                        newBaseColor = System.Windows.Media.Color.FromRgb(sb.baseColor.R, sb.baseColor.G, sb.baseColor.B),
                        obs = sb.obs,
                        pass = sb.pass,
                        url = sb.url,
                        user = sb.user
                    });
                }
                Business.ProfileConfiguration.CreateProfile(new GDSB.Model.ProfileObjects.Profile(
                    null,
                    profile.nome,
                    profile.dataNascimento,
                    false,
                    profile.senha,
                    profile.dtCreated,
                    ls,
                    profile.imageBase64,
                    Business.Util.GetMediaColor("#FFA200FF"),
                    Business.Util.GetMediaColor("#FF272340"),
                    Business.Util.GetMediaColor("#FF07004D")
                    ));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return;
            }


            DialogResult = DialogResult.OK;
        }


        private void buttonCancel_click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textboxsenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                checkPass();
        }
    }
}
