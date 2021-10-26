using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDSB.UI.CustomComponents
{
    public class ViewHidePassword : PictureBox 
    {
        public bool hide
        {
            get
            {
                return hide;
            }

            set
            {
                if(value == true)
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
