using GDSB.Model;
using GDSB.Model.ProfileObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDSB.UI
{
    public partial class FormCreateProfile : Form
    {
        private string imgBase64 = string.Empty;
        int IndexImgsBases = 0;
        public FormCreateProfile()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(GDSB.Business.ProfileConfiguration.base64ProfilePadrao[IndexImgsBases])));
        }

        private void buttonCreateProfSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxPassword.Text) ||
                    string.IsNullOrWhiteSpace(textBoxName.Text) ||
                    string.IsNullOrWhiteSpace(textBoxConfirmarSenha.Text))
                {
                    MessageBox.Show("Preencha todos os campos", "Atenção", MessageBoxButtons.OK);
                    return;
                }
                if (textBoxConfirmarSenha.Text != textBoxPassword.Text)
                {
                    MessageBox.Show("Senha e Confirmação de senha devem ser identicos!", "Atenção", MessageBoxButtons.OK);
                    return;
                }
                if (MessageBox.Show("Confirmar dados\n\n\nNome: " + textBoxName.Text + "\nData de Nascimento: " + dateTimePicker1.Value.ToString("dd/MM/yyyy") +
                    "\n\nAtenção!\nNão será permitido alteração na Data de nasimento\n\nConfirmar Criação de perfil?",
                    "Atenção!",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                    return;


                if (string.IsNullOrEmpty(imgBase64))
                    imgBase64 = GDSB.Business.ProfileConfiguration.base64ProfilePadrao[IndexImgsBases];

                GDSB.Business.ProfileConfiguration.CreateProfile(new Profile(
                    null,
                    textBoxName.Text,
                    dateTimePicker1.Value.Date,
                    false,
                    textBoxPassword.Text,
                    DateTime.Now,
                    new List<SecretBox>(),
                    imgBase64,
                    Business.Util.GetMediaColor("#FFA200FF"),
                    Business.Util.GetMediaColor("#FF272340"),
                    Business.Util.GetMediaColor("#FF07004D")
                    ));
                DialogResult = DialogResult.OK;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao tentar criar o perfil\n\nErro: " + ex.Message, "", MessageBoxButtons.OK);
            }
        }

        private void buttonCreateProfCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonUploadPic_Click(object sender, EventArgs e)
        {
            using(var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files |*.jpg;*.png;*.jpeg";
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    imgBase64 = GDSB.Business.ProfileConfiguration.ConvertImgToBase64(ofd.FileName);
                    pictureBox1.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(imgBase64)));

                    textBoxPhoto.Text = ofd.FileName;
                }
            }
        }

        private void pictureBoxReload_Click(object sender, EventArgs e)
        {
            IndexImgsBases++;

            if (GDSB.Business.ProfileConfiguration.base64ProfilePadrao.Length < IndexImgsBases + 1)
                IndexImgsBases = 0;
            pictureBox1.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(GDSB.Business.ProfileConfiguration.base64ProfilePadrao[IndexImgsBases])));

            textBoxPhoto.Text = string.Empty;
            imgBase64 = string.Empty;
        }

        private void FormCreateProfile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
                DialogResult = DialogResult.Cancel;
            e.Handled = true;
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                e.Handled = true;
            }
        }
    }
}
