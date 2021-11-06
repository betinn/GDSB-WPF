﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace GDSB.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AtualizarProfiles();
        }
        private void AtualizarProfiles()
        {
            Panel.Children.Clear();
            var profiles = GDSB.Business.ProfileConfiguration.GetAllProfiles();
            foreach (var profile in profiles)
            {
                var prof = new CustomComponents.EncryptedProfileMainWindow(profile)
                {
                    Visibility = Visibility.Visible
                };

                Panel.Children.Add(prof);

                //if (profiles.Count == 1)
                //{
                //    prof.RaiseEvent(new MouseButtonEventArgs(Mouse.PrimaryDevice, Environment.TickCount, MouseButton.Left) { RoutedEvent = Button.MouseLeftButtonUpEvent });
                //}
            }
        }

        private void Panel_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToHorizontalOffset(scv.HorizontalOffset - (e.Delta/3));
            e.Handled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            try
            {
                using (var fmCreate = new FormCreateProfile())
                {
                    if (fmCreate.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        MessageBox.Show("Perfil criado com sucesso", "Wee", MessageBoxButton.OK, MessageBoxImage.Information);

                        AtualizarProfiles();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar dados\n\n" + ex.Message, "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".GDSB";
            dlg.Filter = "Old GDSB profile (*.GDSB) | *.GDSB";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                try
                {
                    var encProfile = Business.ProfileConfiguration.GetEncryptedProfile(dlg.FileName);
                    using (Forms.FormLogin fm = new Forms.FormLogin(encProfile))
                    {
                        if(fm.ShowDialog()== System.Windows.Forms.DialogResult.OK)
                        {
                            MessageBox.Show("Perfil importado e convertido com sucesso", "ebaa", MessageBoxButton.OK);
                            AtualizarProfiles();
                        }
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Falha no processo: " + ex.Message, "", MessageBoxButton.OK);
                }
            }
        }

    }
}
