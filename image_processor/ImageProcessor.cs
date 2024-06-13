using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

class ImageProcessor
{
    public static void Inverse(string[] filenames)
    {
        Parallel.ForEach(filenames, file_name =>
        {
            Bitmap bitmap = new Bitmap(file_name);



            Parallel.For(0, bitmap.Height, y =>
            {
                Parallel.For(0, bitmap.Width, x =>
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    bitmap.SetPixel(x, y, Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B));
                });
            });

            string[] slip = file_name.Split(new char[] { '/', '.' });
            bitmap.Save(slip[slip.Length - 2] + "_inverse." + slip[slip.Length - 1]);
        });
    }
}
