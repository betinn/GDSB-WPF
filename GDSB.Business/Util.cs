using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GDSB.Business
{
    public class Util
    {
        public static Random r = new Random();
        
        public static BitmapImage BitmapToBitmapImage(Bitmap src)
        {
            MemoryStream ms = new MemoryStream();
            ((System.Drawing.Bitmap)src).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }

        public static BitmapImage GetBitmapImageByStringBase64(string imgBase64)
        {
            MemoryStream ms = new MemoryStream(Convert.FromBase64String(imgBase64));
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            return image;
        }

        public static System.Windows.Media.Color GetMediaColor(Color color)
        {
            return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }
        public static System.Windows.Media.Color GetMediaColor(string hex)
        {
            var color = ColorTranslator.FromHtml(hex);
            return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}
