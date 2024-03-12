using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Image = System.Windows.Controls.Image;

namespace Testing.Infrastructure.Extensions
{
    public static class Images
    {
        /// <summary>
        /// Возвращает изображение из пути к файлу
        /// </summary>
        /// <param name="image"></param>
        /// <param name="filePath">Путь к файлу</param>
        /// <param name="uriKind">Тип (по умолчанию относительный)</param>
        /// <returns></returns>
        public static Image FromFile(this Image image, string filePath, UriKind uriKind = UriKind.Relative)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(filePath, uriKind);
            bitmapImage.DecodePixelWidth = 200;
            bitmapImage.EndInit();
            image.Source = bitmapImage;
            return image;
        }
    }
}
