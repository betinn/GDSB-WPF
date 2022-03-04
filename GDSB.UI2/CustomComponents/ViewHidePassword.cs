using System.Drawing;
using System.Windows.Forms;

namespace GDSB.UI.CustomComponents
{
    public class ViewHidePassword : PictureBox
    {
        private bool _hide;
        public bool hide
        {
            get { return _hide; }
            set
            {
                _hide = value;
                if (_hide)
                    BackgroundImage = Properties.Resources.PasswordHide;
                else
                    BackgroundImage = Properties.Resources.PasswordView;
            }
        }
        public ViewHidePassword()
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            BackColor = Color.Transparent;

            Cursor = Cursors.Hand;

            hide = true;
        }

    }
}
