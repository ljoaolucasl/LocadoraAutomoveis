using System.Runtime.CompilerServices;

namespace LocadoraAutomoveis.WinApp.Extensions
{
    public static class ByteArrayExtension
    {
        public static Image? ToImage(this byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
                return null;

            using MemoryStream ms = new(imageBytes);

            Image imagem = Image.FromStream(ms);

            return imagem;
        }
    }
}
