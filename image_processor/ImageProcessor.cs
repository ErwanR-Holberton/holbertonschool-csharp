using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Threading;

class ImageProcessor
{
    public static void Inverse(string[] filenames)
    {
        Parallel.ForEach(filenames, file_name =>
        {
            Thread thread = new Thread(() => ProcessImageThread(file_name));
            thread.Start();
        });
    }
    private static void ProcessImageThread(string file_name)
    {
        Bitmap bitmap = new Bitmap(file_name);

        for (int y = 0; y < bitmap.Height; y++)
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                Color pixelColor = bitmap.GetPixel(x, y);
                bitmap.SetPixel(x, y, Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B));
            }
        }

        string[] slip = file_name.Split(new char[] { '/', '.' });
        bitmap.Save(slip[slip.Length - 2] + "_inverse." + slip[slip.Length - 1]);

    }
    public static void Grayscale(string[] filenames)
    {
        foreach (var file_name in filenames)
        {
            Bitmap bitmap = new Bitmap(file_name);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    int grey = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    bitmap.SetPixel(x, y, Color.FromArgb(grey, grey, grey));
                }
            }

            string[] slip = file_name.Split(new char[] { '/', '.' });
            bitmap.Save(slip[slip.Length - 2] + "_grayscale." + slip[slip.Length - 1]);
        }
    }
    public static void BlackWhite(string[] filenames, double threshold)
    {
        Parallel.ForEach(filenames, file_name =>
        {
            Bitmap bitmap = new Bitmap(file_name);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    double grey = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    if (grey > threshold)
                        bitmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    else
                        bitmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                }
            }

            string[] slip = file_name.Split(new char[] { '/', '.' });
            bitmap.Save(slip[slip.Length - 2] + "_bw." + slip[slip.Length - 1]);
        });
    }
}
