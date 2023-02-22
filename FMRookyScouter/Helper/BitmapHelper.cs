using System;
using System.IO;
using System.Net;
using System.Windows.Media.Imaging;

namespace FMRookyScouter.Helper
{
    public static class BitmapHelper
    {
        public static void Save(this BitmapImage image, string filePath)
        {
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));

            using (var fileStream = new FileStream(filePath, FileMode.Create))
                encoder.Save(fileStream);
        }

        public static BitmapImage Load(string path)
        {
            if (string.IsNullOrEmpty(path) || !File.Exists(path))
                return null;

            var bitmap = new BitmapImage();

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(path, UriKind.Relative);
            bitmap.EndInit();

            return bitmap;
        }

        public static bool TryLoad(string path, out BitmapImage bitmap)
        {
            bitmap = Load(path);
            return bitmap != null;
        }

        public static BitmapImage Download(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                    return null;

                var client = new WebClient();
                var data = client.DownloadData(url);

                client.Dispose();

                var bitmap = new BitmapImage();

                bitmap.BeginInit();
                bitmap.StreamSource = new MemoryStream(data);
                bitmap.EndInit();

                return bitmap;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static bool TryDownload(string url, out BitmapImage bitmap)
        {
            bitmap = Download(url);
            return bitmap != null;
        }

        public static bool IsImageExtension(string ext)
        {
            return string.Equals(ext, ".png", StringComparison.OrdinalIgnoreCase)
                || string.Equals(ext, ".jpg", StringComparison.OrdinalIgnoreCase)
                || string.Equals(ext, ".jpeg", StringComparison.OrdinalIgnoreCase);
        }
    }
}
