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
    /// Interaction logic for WindowLoginProfile.xaml
    /// </summary>
    public partial class WindowLoginProfile : Window, IDisposable
    {
        private Model.ProfileObjects.EncryptedProfile EncProfile;
        public WindowLoginProfile(Model.ProfileObjects.EncryptedProfile EncProfile)
        {
            InitializeComponent();

            this.EncProfile = EncProfile;

            this.PreviewKeyDown += WindowLoginProfile_PreviewKeyDown;

            imageProfile.Source = Business.Util.GetBitmapImageByStringBase64(EncProfile.baseImg64);
            imageProfile.Stretch = Stretch.Fill;
            lblNome.Content = EncProfile.name;

            textBoxPassword.Focus();
        }

        private void WindowLoginProfile_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.DialogResult = false;
        }

        public void Dispose()
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TryDecript();
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                TryDecript();
        }
        

        private void TryDecript()
        {
            try
            {
                var profile = Business.ProfileConfiguration.TryDecryptProfile(textBoxPassword.Password, EncProfile.profileEncrypted);
                new WindowUserProfile(profile).Show();
                DialogResult = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Falha ao descriptografar arquivo devido senha INCORRETA ");
                return;
            }
        }
    }
}
