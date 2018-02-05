using System;
using System.Drawing;
using Autofac;
using System.Windows.Forms;

namespace TagCloud
{
    public static class Program
    {
        private static void StartTagCloud(int width, int height, int count,
            Color color, float maxSizeWord, float minSizeWord, FontStyle style, string textFileName, string fileNameWithPicture)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TxtReader>().As<IFormatReader>();
            builder.Register(c =>
            {
                IWordFilter config = new ContentConfigurator();
                config = config.SetMinCountSymbolInWord(count);
                return (ContentConfigurator)config;
            }).As<IWordFilter>();
            builder.Register(c => new PictureConfigurator(width, height, color, maxSizeWord, minSizeWord, style)).As<IPainter>();
            builder.Register(c => new SpiralBuilder(new Point(width / 2, height / 2), width, height))
                .As<ITagCloudBuilder>();
            builder.RegisterType<TagCloud>();
            var container = builder.Build();
            using (container.BeginLifetimeScope())
            {
                var component = container.Resolve<TagCloud>();
                component.PaintTagCloud(textFileName, fileNameWithPicture);
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            var form = new GUI();
            try
            {
                var values = CUI.ParseArguments(args); 
                StartTagCloud(values.Width, values.Heigth, values.Count, values.Color, values.MaxSizeWord,
                    values.MinSizeWord, values.FontStyle, values.TextFileName, values.FileNameWithPicture);
                Application.Run(form);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
            }
        }
    }
}
