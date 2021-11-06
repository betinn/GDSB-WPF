using System;
using System.Collections.Concurrent;
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
        public Model.ProfileObjects.Profile profile;
        public WindowUserProfile(Model.ProfileObjects.Profile profile)
        {
            InitializeComponent();
            this.profile = profile;

            UpdateWindowProfile();

            BtnCreateNewBox.MouseEnter += BtnCreateNewBox_MouseEnter;
            BtnCreateNewBox.MouseLeave += BtnCreateNewBox_MouseLeave;

            GradLine1.Color = profile.colorGradLine1;
            GradLine2.Color = profile.colorGradLine2;
            GradLine3.Color = profile.colorGradLine3;

            textboxSearch.Focus();
        }



        private void UpdateWindowProfile()
        {
            if (PanelBoxes.Children.Count != 0)
                PanelBoxes.Children.Clear();

            //var boxes = profile.boxes;//.OrderByDescending(x => x.favorito).ThenBy(x => x.boxName);

            var listres = profile.boxes.OrderByDescending(x => x.favorito).ThenBy(x => x.boxName).Select(x => new CustomComponents.UserSecretBox(x));

            foreach (var sb in listres)
            {
                sb.Excluir.MouseLeftButtonDown += new MouseButtonEventHandler(delegate (object sender, MouseButtonEventArgs args)
                {
                    if (MessageBox.Show("Isto é irreversível, tem certeza disso?", "!", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        profile.boxes.Remove(sb.box);
                        Business.ProfileConfiguration.UpdateProfile(profile);
                        PanelBoxes.Children.Remove(sb);
                    }
                });
                sb.BtnEdit.MouseLeftButtonDown += new MouseButtonEventHandler(delegate (object sender, MouseButtonEventArgs args)
                {
                    Hide();
                    using (WindowCreateSecretBox fm = new WindowCreateSecretBox(profile, sb.box))
                        if (fm.ShowDialog() == true)
                            UpdateWindowProfile();
                    Show();
                });
                sb.star.MouseLeftButtonDown += new MouseButtonEventHandler(delegate (object sender, MouseButtonEventArgs args)
                {
                    sb.box.favorito = !sb.box.favorito;
                    Business.ProfileConfiguration.UpdateProfile(profile);

                    int i = profile.boxes.OrderByDescending(x => x.favorito).ThenBy(x => x.boxName).ToList().IndexOf(sb.box);
                    PanelBoxes.Children.Remove(sb);
                    PanelBoxes.Children.Insert(i, sb);

                    sb.AtualizaEstrela();
                });
                this.PanelBoxes.Children.Add(sb);
            }
                

            //foreach (var box in boxes)
            //{
            //    var sb = new CustomComponents.UserSecretBox(box);
            //    sb.Excluir.MouseLeftButtonDown += new MouseButtonEventHandler(delegate (object sender, MouseButtonEventArgs args)
            //    {
            //        if (MessageBox.Show("Isto é irreversível, tem certeza disso?", "!", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            //        {
            //            profile.boxes.Remove(box);
            //            Business.ProfileConfiguration.UpdateProfile(profile);
            //            PanelBoxes.Children.Remove(sb);
            //        }
            //    });
            //    sb.BtnEdit.MouseLeftButtonDown += new MouseButtonEventHandler(delegate (object sender, MouseButtonEventArgs args)
            //    {
            //        Hide();
            //        using (WindowCreateSecretBox fm = new WindowCreateSecretBox(profile, box))
            //            if (fm.ShowDialog() == true)
            //                UpdateWindowProfile();
            //        Show();
            //    });
            //    sb.star.MouseLeftButtonDown += new MouseButtonEventHandler(delegate (object sender, MouseButtonEventArgs args)
            //    {
            //        box.favorito = !box.favorito;
            //        Business.ProfileConfiguration.UpdateProfile(profile);
            //        UpdateWindowProfile();
            //    });
            //    this.PanelBoxes.Children.Add(sb);
            //}
            //textboxSearch.Text = "";
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
                    if (element.box.boxName.ToUpper().Contains(textboxSearch.Text.ToUpper()))
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
