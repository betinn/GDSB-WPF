using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace GDSB.UI.CustomComponents
{
    /// <summary>
    /// Interaction logic for EncryptedProfileMainWindow.xaml
    /// </summary>
    public partial class EncryptedProfileMainWindow : System.Windows.Controls.UserControl
    {
        public GDSB.Model.ProfileObjects.EncryptedProfile encryptedProfile { get; set; }

        private bool colorEffectOnClick = false;

        public EncryptedProfileMainWindow(GDSB.Model.ProfileObjects.EncryptedProfile profile)
        {
            InitializeComponent();
            this.encryptedProfile = profile;
            labelNome.Content = profile.name;

            img.Source = Business.Util.GetBitmapImageByStringBase64(profile.baseImg64);
            img.Stretch = Stretch.Fill;

            this.MouseLeftButtonUp += profile_MouseLeftClick;
            this.MouseEnter += EncryptedProfileMainWindow_MouseEnter;
            this.MouseLeave += EncryptedProfileMainWindow_MouseLeave;
        }

        private void EncryptedProfileMainWindow_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (!colorEffectOnClick)
                labelNome.Background = Brushes.Transparent;
        }

        private void EncryptedProfileMainWindow_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            labelNome.Background = Brushes.Green;
        }

        private void profile_MouseLeftClick(object sender, MouseButtonEventArgs e)
        {
            colorEffectOnClick = true;
            this.labelNome.Background = Brushes.Orange;
            var wd = Window.GetWindow(this);
            wd.IsEnabled = false;

            try
            {
                using (WindowLoginProfile fm = new WindowLoginProfile(encryptedProfile))
                {
                    if (fm.ShowDialog() == true)
                    {
                        wd.Close();
                    }
                    else
                    {
                        wd.IsEnabled = true;
                        this.labelNome.Background = Brushes.Transparent;
                        colorEffectOnClick = false;

                    }
                }
            }
            catch (Exception ex)
            {
                colorEffectOnClick = false;

                System.Windows.MessageBox.Show(ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                wd.IsEnabled = true;
                this.labelNome.Background = Brushes.Transparent;
            }
            System.Threading.Thread.Sleep(100);
        }
    }
}
