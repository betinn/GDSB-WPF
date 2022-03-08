using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfAnimatedGif;

namespace GDSB.UI.CustomComponents
{
    /// <summary>
    /// Interaction logic for UserSecretBox.xaml
    /// </summary>
    public partial class UserSecretBox : UserControl
    {
        public GDSB.Model.ProfileObjects.SecretBox box { get; set; }
        BackgroundWorker worker;

        public UserSecretBox(Model.ProfileObjects.SecretBox box)
        {
            InitializeComponent();
            lblBoxName.Content = box.boxName;
            textUsuario.Text = box.user;
            textSenha.Password = box.pass;
            textObs.Text = box.obs;
            LabelBaseColor.Background = new SolidColorBrush(box.newBaseColor);

            if (!string.IsNullOrEmpty(box.url))
            {
                lblBoxName.FontStyle = FontStyles.Italic;
                lblBoxName.Cursor = Cursors.Hand;
                lblBoxName.MouseLeftButtonDown += new MouseButtonEventHandler(delegate (object sender, MouseButtonEventArgs args)
                {
                    Process.Start(box.url);
                });
                lblBoxName.ToolTip = box.url;
            }
            worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.WorkerSupportsCancellation = true;

            this.box = box;
            AtualizaEstrela();

            CopyUser.MouseEnter += CopyUser_MouseEnter;
            CopyUser.MouseLeave += CopyUser_MouseLeave;
            CopyUser.MouseLeftButtonDown += CopyUser_Click;

            CopyPass.MouseEnter += CopyPass_MouseEnter;
            CopyPass.MouseLeave += CopyPass_MouseLeave;
            CopyPass.MouseLeftButtonDown += CopyPass_Click;

            BtnEdit.MouseEnter += BtnEdit_MouseEnter;
            BtnEdit.MouseLeave += BtnEdit_MouseLeave;

            Excluir.MouseEnter += Excluir_MouseEnter;
            Excluir.MouseLeave += Excluir_MouseLeave;

        }

        

        public void AtualizaEstrela()
        {
            if (box.favorito)
            {
                if (!worker.IsBusy)
                {
                    worker.RunWorkerAsync();
                    ImageBehavior.SetAnimatedSource(ImgLikeEffect, 
                        Business.Util.BitmapToBitmapImage(Properties.Resources.Heart_effect_like, imageFormat: System.Drawing.Imaging.ImageFormat.Gif));
                }
                
                star.Source = Business.Util.BitmapToBitmapImage(Properties.Resources.Heart_Like);

                ImageBehavior.SetAutoStart(ImgLikeEffect, true);
                ImgLikeEffect.Visibility = Visibility.Visible;
                
            }
            else
            {
                ImgLikeEffect.Visibility = Visibility.Hidden;
                star.Source = Business.Util.BitmapToBitmapImage(Properties.Resources.Heart_Colorless);
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ImgLikeEffect.Visibility = Visibility.Hidden;
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            
        }

        private void CopyPass_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(textSenha.Password);
        }

        private void CopyUser_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(textUsuario.Text);
        }


        #region Visual Effect Events

        private void Excluir_MouseLeave(object sender, MouseEventArgs e)
        {
            //CenterY="0.5" CenterX="0.5" ScaleX="1.3" ScaleY="1.3"
            ScaleTransfExcluir.ScaleX = 1;
            ScaleTransfExcluir.ScaleY = 1;
        }

        private void Excluir_MouseEnter(object sender, MouseEventArgs e)
        {
            ScaleTransfExcluir.ScaleX = 1.3;
            ScaleTransfExcluir.ScaleY = 1.3;
        }


        private void CopyPass_MouseLeave(object sender, MouseEventArgs e)
        {
            ScaleBtnCopyPass.ScaleX = 1;
            ScaleBtnCopyPass.ScaleY = 1;
        }

        private void CopyPass_MouseEnter(object sender, MouseEventArgs e)
        {
            ScaleBtnCopyPass.ScaleX = 1.1;
            ScaleBtnCopyPass.ScaleY = 1.1;
        }


        private void CopyUser_MouseLeave(object sender, MouseEventArgs e)
        {
            ScaleBtnCopyUser.ScaleX = 1;
            ScaleBtnCopyUser.ScaleY = 1;
        }
        private void CopyUser_MouseEnter(object sender, MouseEventArgs e)
        {
            ScaleBtnCopyUser.ScaleX = 1.1;
            ScaleBtnCopyUser.ScaleY = 1.1;
        }



        private void BtnEdit_MouseLeave(object sender, MouseEventArgs e)
        {
            ScaleBtnEdit.ScaleX = 1;
            ScaleBtnEdit.ScaleY = 1;
        }

        private void BtnEdit_MouseEnter(object sender, MouseEventArgs e)
        {
            ScaleBtnEdit.ScaleX = 1.1;
            ScaleBtnEdit.ScaleY = 1.1;
        }

        #endregion


    }
}
