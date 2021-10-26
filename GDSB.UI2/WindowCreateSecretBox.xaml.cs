using GDSB.Model.ProfileObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GDSB.UI
{
    /// <summary>
    /// Interaction logic for WindowCreateSecretBox.xaml
    /// </summary>
    public partial class WindowCreateSecretBox : Window, IDisposable
    {
        private Profile profile = null;
        private SecretBox box = null;
        public WindowCreateSecretBox(Profile profile, SecretBox box = null)
        {
            InitializeComponent();
            this.profile = profile;

            if(box == null)
            {
                colorPicker.SelectedColor = Color.FromRgb((byte)Business.Util.r.Next(0, 254), (byte)Business.Util.r.Next(0, 254), (byte)Business.Util.r.Next(0, 254));
            }
            else
            {
                this.box = box;
                colorPicker.SelectedColor = box.newBaseColor;
                textBoxNome.Text = box.boxName;
                textBoxURL.Text = box.url;
                textBoxUsuario.Text = box.user;
                textBoxSenha.Text = box.pass;
                textBoxOBS.Text = box.obs;
            }

        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxURL.Text))
            {
                Uri uriResult;
                bool result = Uri.TryCreate(textBoxURL.Text, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

                if (!result)
                {
                    MessageBox.Show("URL indicada é INVALIDA");
                    return;
                }
            }
            if (box != null)
            {
                box.boxName = textBoxNome.Text;
                box.user = textBoxUsuario.Text;
                box.pass = textBoxSenha.Text;
                box.obs = textBoxOBS.Text;
                box.newBaseColor = (Color)colorPicker.SelectedColor;
                box.url = textBoxURL.Text;
            }
            else
                profile.boxes.Add(new SecretBox()
                {
                    boxName = textBoxNome.Text,
                    user = textBoxUsuario.Text,
                    pass = textBoxSenha.Text,
                    newBaseColor  = (Color)colorPicker.SelectedColor,
                    dtCreated = DateTime.Now,
                    obs = textBoxOBS.Text,
                    url = textBoxURL.Text
                });
            GDSB.Business.ProfileConfiguration.UpdateProfile(profile);

            DialogResult = true;
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public void Dispose()
        {
        }

        private void colorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            colorPicker.Background = new SolidColorBrush((Color)colorPicker.SelectedColor);
        }

        private void btnGerarSenha_Click(object sender, RoutedEventArgs e)
        {
            if (!checkBoxCaracEspeciais.IsChecked == true &&
                !checkBoxMaiusculas.IsChecked == true &&
                !checkBoxMinusculas.IsChecked == true &&
                !checkBoxNumeros.IsChecked == true)
            {
                MessageBox.Show("Para gerar uma senha aleatória é necessario que esteja selecionado pelo menos 1 das CheckBox");
                return;
            }

            string firstPass = string.Format("{0}{1}{2}{3}",
                checkBoxMinusculas.IsChecked == true ? GetLowerChar() : "",
                checkBoxMaiusculas.IsChecked == true ? GetUpperChar() : "",
                checkBoxNumeros.IsChecked == true ? GetNumber() : "",
                checkBoxCaracEspeciais.IsChecked == true ? GetEspecialChar() : ""
                );
            for (int i = firstPass.Length; i < numericUpDown.Value; i++)
            {
                switch (Business.Util.r.Next(1, 5))
                {
                    case 1:
                        if (checkBoxMinusculas.IsChecked == true)
                            firstPass += GetLowerChar();
                        else
                            i--;
                        break;
                    case 2:
                        if (checkBoxMaiusculas.IsChecked == true)
                            firstPass += GetUpperChar();
                        else
                            i--;
                        break;
                    case 3:
                        if (checkBoxNumeros.IsChecked == true)
                            firstPass += GetNumber();
                        else
                            i--;
                        break;
                    case 4:
                        if (checkBoxCaracEspeciais.IsChecked == true)
                            firstPass += GetEspecialChar();
                        else
                            i--;
                        break;
                }
            }

            string finalPass = string.Empty;
            int firstPassLenght = firstPass.Length;
            for (int i = 0; i < firstPassLenght; i++)
            {
                var randomIndex = Business.Util.r.Next(0, firstPass.Length);
                finalPass += firstPass[randomIndex];

                firstPass = firstPass.Remove(randomIndex, 1);
            }

            textBoxSenha.Text = finalPass;
        }

        #region GetRandomChars
        private string GetLowerChar()
        {
            char[] lowerChar = new char[]
            {
                'a'
                ,'b'
                ,'c'
                ,'d'
                ,'e'
                ,'f'
                ,'g'
                ,'h'
                ,'i'
                ,'j'
                ,'k'
                ,'l'
                ,'m'
                ,'n'
                ,'o'
                ,'p'
                ,'q'
                ,'r'
                ,'s'
                ,'t'
                ,'u'
                ,'v'
                ,'w'
                ,'y'
                ,'x'
                ,'z'
            };

            return lowerChar[Business.Util.r.Next(0, lowerChar.Length)].ToString();
        }
        private string GetUpperChar()
        {
            char[] upperChar = new char[]
            {
                'A'
                ,'B'
                ,'C'
                ,'D'
                ,'E'
                ,'F'
                ,'G'
                ,'H'
                ,'I'
                ,'J'
                ,'K'
                ,'L'
                ,'M'
                ,'N'
                ,'O'
                ,'P'
                ,'Q'
                ,'R'
                ,'S'
                ,'T'
                ,'U'
                ,'W'
                ,'X'
                ,'Y'
                ,'V'
                ,'Z'
            };

            return upperChar[Business.Util.r.Next(0, upperChar.Length)].ToString();
        }
        private string GetNumber()
        {
            int[] numbers = new int[]
{
                1,
                2,
                3,
                4,
                5,
                6,
                7,
                8,
                9,
                0
};

            return numbers[Business.Util.r.Next(0, numbers.Length)].ToString();
        }
        private string GetEspecialChar()
        {
            char[] especialChar = new char[]
{
                '!',
                '@',
                '#',
                '$',
                '%',
                '&',
                '*'
};

            return especialChar[Business.Util.r.Next(0, especialChar.Length)].ToString();
        }
        #endregion



        private void textBoxUsuario_KeyUp(object sender, KeyEventArgs e)
        {
            if (profile.boxes.Where(x => x.user.StartsWith(textBoxUsuario.Text) && x.user.Length > textBoxUsuario.Text.Length).Any() && e.Key != Key.Back)
            {
                var userSuggest = profile.boxes.Where(x => x.user.StartsWith(textBoxUsuario.Text) && x.user.Length > textBoxUsuario.Text.Length).First().user;
                var oldLength = textBoxUsuario.Text.Length;

                textBoxUsuario.Text += userSuggest.Substring(oldLength);
                textBoxUsuario.Select(oldLength, textBoxUsuario.Text.Length - oldLength);
            }
        }
    }
}
