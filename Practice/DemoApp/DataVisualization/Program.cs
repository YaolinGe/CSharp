using System;
using System.Diagnostics;
using System.Drawing;

class Program
{
    static void Main()
    {
        using Bitmap bmp = new Bitmap(600, 400);
        using Graphics gfx = Graphics.FromImage(bmp);
        gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

        gfx.Clear(Color.Navy);

        Random rand = new Random(0);
        using Pen pen = new Pen(Color.White);
        for (int i = 0; i < 10_000; i++)
        {
            pen.Color = Color.FromArgb(rand.Next());
            Point pt1 = new Point(rand.Next(bmp.Width), rand.Next(bmp.Height));
            Point pt2 = new Point(rand.Next(bmp.Width), rand.Next(bmp.Height));
            gfx.DrawLine(pen, pt1, pt2);
        }

        string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
        string filePath = Path.Combine(downloadsFolder, "demo.png");
        bmp.Save(filePath);

        Process.Start(filePath);
    }
}
