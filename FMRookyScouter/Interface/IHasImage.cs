using Avalonia.Media.Imaging;
using System;
using System.IO;
using System.Net;
using System.Windows.Media.Imaging;

namespace FMRookyScouter.Interface
{
    public interface IHasImage
    {
        string Name { get; }
        string Image { get; }
    }

    public static class HasImageExt
    {
        public static BitmapImage LoadImage(string url)   //Image URL -> Bitmap으로..
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                    return null;

                var wc = new WebClient();

                Byte[] MyData = wc.DownloadData(url);

                wc.Dispose();

                BitmapImage bimgTemp = new BitmapImage();

                bimgTemp.BeginInit();
                bimgTemp.StreamSource = new MemoryStream(MyData);
                bimgTemp.EndInit();

                return bimgTemp;
            }
            catch
            {
                return null;
            }

        }
    }
}
