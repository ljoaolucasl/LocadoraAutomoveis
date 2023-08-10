using System.Drawing.Imaging;

namespace LocadoraAutomoveis.WinApp.Extensions
{
    public static class ImageExtension
    {
        public static byte[]? ToByte(this Image image)
        {
            if (image == null)
                return null;

            using MemoryStream ms = new MemoryStream();

            var imageNew = new Bitmap(image);

            imageNew.Save(ms, ImageFormat.Jpeg);

            return ms.ToArray();
        }
    }
}
