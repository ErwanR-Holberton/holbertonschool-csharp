using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

class ImageProcessor
{
    public static void Main()
    {
        string[] files = { "image.png", "image2.png" };
        Inverse(files);
    }
    public static void Inverse(string[] filenames)
    {
        Parallel.ForEach(filenames, file_name =>
        {
            using (Bitmap bitmap = new Bitmap(file_name))
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color pixelColor = bitmap.GetPixel(x, y);
                        bitmap.SetPixel(x, y, Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B));
                    }
                }
                bitmap.Save(file_name.Split(".")[0] + "_inverted.png");
            }
        });
    }
}
