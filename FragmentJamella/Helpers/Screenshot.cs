using System.Drawing;

namespace FragmentJamella.Helpers
{
    public static class Screenshot
    {
        public static Image CaptureScreen(int x, int y, int width, int height)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(x, y, 0, 0, bmp.Size);
            return bmp;
        }
    }
}
