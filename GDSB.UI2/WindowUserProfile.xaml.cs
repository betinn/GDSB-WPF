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
    /// Interaction logic for WindowUserProfile.xaml
    /// </summary>
    public partial class WindowUserProfile : Window
    {
        private Model.ProfileObjects.Profile profile;
        public WindowUserProfile(Model.ProfileObjects.Profile profile)
        {
            InitializeComponent();
            //this.Background = new SolidColorBrush(profile.pnColor);
            //Background = Brushes.Red;
            this.profile = profile;

            UpdateWindowProfile();

            BtnCreateNewBox.MouseEnter += BtnCreateNewBox_MouseEnter;
            BtnCreateNewBox.MouseLeave += BtnCreateNewBox_MouseLeave;

            GradLine1.Color = profile.colorGradLine1;
            GradLine2.Color = profile.colorGradLine2;
            GradLine3.Color = profile.colorGradLine3;
        }

        

        private void UpdateWindowProfile()
        {
            if (PanelBoxes.Children.Count != 0)
                PanelBoxes.Children.Clear();
            foreach (var box in profile.boxes.OrderBy(x => x.boxName))
            {
                var sb = new CustomComponents.UserSecretBox(box);
                sb.Excluir.MouseLeftButtonDown += new MouseButtonEventHandler(delegate (object sender, MouseButtonEventArgs args)
                {
                    if (MessageBox.Show("Isto é irreversível, tem certeza disso?", "!", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        profile.boxes.Remove(box);
                        Business.ProfileConfiguration.UpdateProfile(profile);
                        PanelBoxes.Children.Remove(sb);
                    }
                });
                sb.BtnEdit.MouseLeftButtonDown += new MouseButtonEventHandler(delegate (object sender, MouseButtonEventArgs args)
                {
                    Hide();
                    using (WindowCreateSecretBox fm = new WindowCreateSecretBox(profile, box))
                        if (fm.ShowDialog() == true)
                            UpdateWindowProfile();
                    Show();
                });
                this.PanelBoxes.Children.Add(sb);
            }
        }

        private void BtnCreateNewBox_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            using (WindowCreateSecretBox fm = new WindowCreateSecretBox(profile))
                if (fm.ShowDialog() == true)
                    UpdateWindowProfile();
            Show();
        }

        private void textboxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var lsSB = PanelBoxes.Children;

            foreach(var sb in lsSB)
            {
                if(sb.GetType() == typeof(CustomComponents.UserSecretBox))
                {
                    var element = (CustomComponents.UserSecretBox)sb;
                    if (element.box.boxName.Contains(textboxSearch.Text))
                        element.Visibility = Visibility.Visible;
                    else
                        element.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void BtnConfigurationProfile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            using (var fm = new WindowSettingsProfile(this.profile))
            {
                Hide();
                if (fm.ShowDialog() == true)
                {

                    GradLine1.Color = profile.colorGradLine1;
                    GradLine2.Color = profile.colorGradLine2;
                    GradLine3.Color = profile.colorGradLine3;
                }
                Show();
            }
        }
        #region Visual Effects Events
        private void BtnCreateNewBox_MouseLeave(object sender, MouseEventArgs e)
        {
            ScaleBtnCreateNewBox.ScaleX = 1.15;
            ScaleBtnCreateNewBox.ScaleY = 1.15;
        }

        private void BtnCreateNewBox_MouseEnter(object sender, MouseEventArgs e)
        {
            //ScaleX="1.15" ScaleY="1.15"
            ScaleBtnCreateNewBox.ScaleX = 1.35;
            ScaleBtnCreateNewBox.ScaleY = 1.35;
        }
        private void BtnConfigurationProfile_MouseEnter(object sender, MouseEventArgs e)
        {
            //ScaleX="0.85" ScaleY="0.85"
            ScaleBtnConfiguration.ScaleX = 1.05;
            ScaleBtnConfiguration.ScaleY = 1.05;
        }

        private void BtnConfigurationProfile_MouseLeave(object sender, MouseEventArgs e)
        {
            ScaleBtnConfiguration.ScaleX = 0.85;
            ScaleBtnConfiguration.ScaleY = 0.85;
        }




        #endregion

        private void textboxSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textboxSearch.Text))
                textboxSearch.SelectAll();
        }

    }
}
