using System.Drawing;
using System.Windows.Forms;

namespace TagCloud.WindowsForGUI
{
    internal class ShowImageAfterCreated : Form
    {
        private PictureBox pb;
        public ShowImageAfterCreated()
        {
            pb = new PictureBox(){Location = new Point(0, 20)};
            Controls.Add(pb);
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void SaveImage()
        {
       
            var saveDialog = new SaveFileDialog();
            saveDialog.Filter = ".png|";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (!saveDialog.FileName.EndsWith(".png"))
                    saveDialog.FileName += ".png";
                pb.Image.Save(saveDialog.FileName);
            }
        }

        public void BuildTagCloud(ProgrammArgumentsValue values)
        {
            var img = Program.StartTagCloud(values.Width, values.Heigth, values.Count, values.Color, values.MaxSizeWord,
                 values.MinSizeWord, values.FontStyle, values.TextFileName, values.FileNameWithPicture);
            pb.Image = img;
            Height = pb.Image.Height;
            Width = pb.Image.Width;
            var saveButton = new Button()
            {Text = "Save", Location = new Point(0, 0), Height = 20};
            saveButton.Click += (sender, args) => SaveImage();
            Controls.Add(saveButton);
            Show();
        }

    }
}

