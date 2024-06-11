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

            BitmapData lockedimage = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int img_size = lockedimage.Stride * lockedimage.Height;
            byte[] image_copy = new byte[img_size];

            System.Runtime.InteropServices.Marshal.Copy(lockedimage.Scan0, image_copy, 0, img_size);

            Parallel.For(0, bitmap.Height, y =>
            {
                int yPos = y * lockedimage.Stride;
                for (int x = 0; x < bitmap.Width; x++)
                {
                    int pos = yPos + x * 4;

                    image_copy[pos] = (byte)(255 - image_copy[pos]);
                    image_copy[pos + 1] = (byte)(255 - image_copy[pos + 1]);
                    image_copy[pos + 2] = (byte)(255 - image_copy[pos + 2]);
                }
            });

            System.Runtime.InteropServices.Marshal.Copy(image_copy, 0, lockedimage.Scan0, img_size);
            bitmap.UnlockBits(lockedimage);

            string[] slip = file_name.Split(new char[] { '/', '.' });
            bitmap.Save(slip[slip.Length - 2] + "_inverse." + slip[slip.Length - 1]);
        });
    }
}
