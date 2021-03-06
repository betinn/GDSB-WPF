using GDSB.Model.ProfileObjects;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace GDSB.UI
{
    /// <summary>
    /// Interaction logic for WindowSettingsProfile.xaml
    /// </summary>
    public partial class WindowSettingsProfile : Window, IDisposable
    {
        private Profile profile;
        public WindowSettingsProfile(Profile profile)
        {
            InitializeComponent();
            this.profile = profile;

            imgProfile.Source = Business.Util.GetBitmapImageByStringBase64(profile.imageBase64);
            imgProfile.Stretch = Stretch.Fill;
            textBoxNome.Text = profile.nome;
            textBoxSenha.Text = profile.senha;

            colorPickerGradLine1.SelectedColor = profile.colorGradLine1;
            colorPickerGradLine2.SelectedColor = profile.colorGradLine2;
            colorPickerGradLine3.SelectedColor = profile.colorGradLine3;
        }

        private void textBoxNewImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

                dlg.DefaultExt = ".jpg";
                dlg.Filter = "Imagens |*.jpeg;*.jpg;*.png";

                Nullable<bool> result = dlg.ShowDialog();

                if (result == true)
                {
                    var imgBase64 = Business.ProfileConfiguration.ConvertImgToBase64(dlg.FileName);
                    imgProfile.Source = Business.Util.GetBitmapImageByStringBase64(imgBase64);
                    textBoxNewImg.Text = dlg.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao pegar imagem: " + ex.Message, "!", MessageBoxButton.OK);
            }

        }

        private void colorPickerGradLine1_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (colorPickerGradLine1 == null ||
                colorPickerGradLine2 == null ||
                colorPickerGradLine3 == null ||
                colorPickerGradLine1.SelectedColor == null ||
                colorPickerGradLine2.SelectedColor == null ||
                colorPickerGradLine3.SelectedColor == null)
                return;
            GradLine1.Color = (Color)colorPickerGradLine1.SelectedColor;
            GradLine2.Color = (Color)colorPickerGradLine2.SelectedColor;
            GradLine3.Color = (Color)colorPickerGradLine3.SelectedColor;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            // Clean
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (colorPickerGradLine1.SelectedColor == null ||
                colorPickerGradLine2.SelectedColor == null ||
                colorPickerGradLine3.SelectedColor == null ||
                string.IsNullOrEmpty(textBoxNome.Text) ||
                string.IsNullOrEmpty(textBoxSenha.Text))
            {
                MessageBox.Show("Preencha todos os campos para salvar", "", MessageBoxButton.OK);
                return;
            }
            if (!string.IsNullOrEmpty(textBoxNewImg.Text))
            {
                if (!File.Exists(textBoxNewImg.Text))
                {
                    MessageBox.Show("Imagem selecionada nao existe", "", MessageBoxButton.OK);
                    return;
                }
                else
                    profile.imageBase64 = Business.ProfileConfiguration.ConvertImgToBase64(textBoxNewImg.Text);
            }


            profile.colorGradLine1 = (Color)colorPickerGradLine1.SelectedColor;
            profile.colorGradLine2 = (Color)colorPickerGradLine2.SelectedColor;
            profile.colorGradLine3 = (Color)colorPickerGradLine3.SelectedColor;
            profile.nome = textBoxNome.Text;
            profile.senha = textBoxSenha.Text;

            Business.ProfileConfiguration.UpdateProfile(profile);

            DialogResult = true;
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                DialogResult = false;
        }

        private void BtnRecoveryFiles_MouseEnter(object sender, MouseEventArgs e)
        {
            //ScaleX="0.85" ScaleY="0.85"
            ScaleRecoveryFiles.ScaleX = 1.05;
            ScaleRecoveryFiles.ScaleY = 1.05;
        }

        private void BtnRecoveryFiles_MouseLeave(object sender, MouseEventArgs e)
        {
            ScaleRecoveryFiles.ScaleX = 0.85;
            ScaleRecoveryFiles.ScaleY = 0.85;
        }

        private void BtnRecoveryFiles_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start(GDSB.Business.ProfileConfiguration.GetDirectoryRecoveryProfile(profile.fullFileName));
        }
    }
}
