using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace GDSB.Business
{
    public static class Util
    {
        public static readonly Random r = new Random();

        public static BitmapImage BitmapToBitmapImage(Bitmap src, System.Drawing.Imaging.ImageFormat imageFormat = null)
        {
            MemoryStream ms = new MemoryStream();
            (src).Save(ms, imageFormat == null ? System.Drawing.Imaging.ImageFormat.Png : imageFormat);
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
