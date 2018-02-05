using System.Drawing;
using DocoptNet;

namespace TagCloud
{

    internal static class CUI
    {
        private const string usage = @" Tag Cloud

        Usage:
        TagCloud.exe [--width WIDTH] [--height HEIGHT] [--count COUNT] [--color COLOR] [--style STYLE] [--text TEXT] [--pict PICTURE] [--maxsize MAX] [--minsize MIN]
        TagCloud.exe (-h|--help)

        Options:
        -h --help           Show this screen.
        --width WIDTH       Width window.[default: 800]
        --height HEIGHT     Height window.[default: 600]
        --count COUNT       Minimum number of characters allowed.[default: 3]
        --maxsize MAX       The maximum word size in the cloud.[default: 120]
        --minsize MIN       The minimum word size in the cloud.[default: 3]
        --color COLOR       Color text.[default: Red]
        --style STYLE       Font Style.[default: FontStyle.Regular]
        --text TEXT         File name\path is have some text.[default: input.txt]
        --pict PICTURE      File name\path where save picture.[default: output.png]
    ";

        public static ProgrammArgumentsValue ParseArguments(string[] args)
        {
            var arguments = new Docopt().Apply(usage, args, version: "Tag Cloud 0.1", exit: true);
            var values = new ProgrammArgumentsValue();
            values.Width = int.Parse(arguments["--width"].Value.ToString());
            values.Heigth = int.Parse(arguments["--height"].Value.ToString());
            values.Count = int.Parse(arguments["--count"].Value.ToString());
            values.MaxSizeWord = float.Parse(arguments["--maxsize"].Value.ToString());
            values.MinSizeWord = float.Parse(arguments["--minsize"].Value.ToString());
            values.Color = (Color) new ColorConverter().ConvertFromString(arguments["--color"].ToString());
            values.FontStyle = ((Font) new FontConverter().ConvertFromString(arguments["--style"].ToString())).Style;
            values.TextFileName = arguments["--text"].Value.ToString();
            values.FileNameWithPicture = arguments["--pict"].ToString();
            return values;
        }
    }
    internal class ProgrammArgumentsValue
    {
        public ProgrammArgumentsValue()
        {
            //init defoult param
            Width = 800;
            Heigth = 600;
            Count = 3;
            MaxSizeWord = 120;
            MinSizeWord = 3;
            Color = Color.Red;
            FontStyle = FontStyle.Regular;
            TextFileName = "input.txt";
            FileNameWithPicture = "C:\\Users\\buritto\\Desktop\\someFolder\\output.png";
        }
        public int Width { get; set; }
        public int Heigth { get; set; }
        public int Count { get; set; }
        public float MaxSizeWord { get; set; }
        public float MinSizeWord { get; set; }
        public Color Color { get; set; }
        public FontStyle FontStyle { get; set; }
        public string TextFileName { get; set; }
        public string FileNameWithPicture { get; set; }
    }
}
