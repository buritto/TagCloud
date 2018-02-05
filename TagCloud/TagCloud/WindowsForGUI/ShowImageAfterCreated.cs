using System.Windows.Forms;

namespace TagCloud.WindowsForGUI
{
    internal class ShowImageAfterCreated : Form
    {
        private PictureBox pb;
        public ShowImageAfterCreated()
        {
            pb = new PictureBox();
            Controls.Add(pb);
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public void BuildTagCloud(ProgrammArgumentsValue values)
        {
           var img = Program.StartTagCloud(values.Width, values.Heigth, values.Count, values.Color, values.MaxSizeWord,
                values.MinSizeWord, values.FontStyle, values.TextFileName, values.FileNameWithPicture);
            pb.Image = img;
            Height = pb.Image.Height;
            Width = pb.Image.Width;
            Show();
        }
    }
}

