using System.Drawing;

namespace TagCloud.WindowsForGUI
{
    public class GraphicInterfaceConfig
    {
        public GraphicInterfaceConfig( )
        {
            //Size = new Size(100, 30);
            Width = 100;
            Height = 30;
            PadX = 25;
            PadY = 75;
            TextFont = new Font(FontFamily.GenericSansSerif, 10);
        }

        public int Width { get; }
        public int Height { get; }
        public int PadX { get; }
        public int PadY { get; set; }
        public Font TextFont { get; }
    }
}
