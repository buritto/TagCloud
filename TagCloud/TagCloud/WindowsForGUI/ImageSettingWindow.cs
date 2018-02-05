using System;
using System.Drawing;
using System.Windows.Forms;

namespace TagCloud.WindowsForGUI
{
    internal class ImageSettingWindow : WindowSetting
    {

        public ImageSettingWindow(ProgrammArgumentsValue values)
                :base("Image setting", values)
        {
            
            //var padx = 25;
            //var pady = 75;
            var dx = 100;
            var dy = 45;
            //var size = new Size(100, 30);
            //var font = new Font(FontFamily.GenericSansSerif, 10);
            
            #region SettingWidth
            var labelWidth = new Label()
            {
                Font = config.TextFont,
                Text = "Width:"
            };

            var textWidth =new TextBox(){Text = "800"};
            labelWidth.Bounds = new Rectangle(config.PadX, config.PadY, config.Width, config.Height);
            textWidth.Bounds = new Rectangle(config.PadX + dx, config.PadY, config.Width, config.Height);
            Controls.Add(textWidth);
            Controls.Add(labelWidth);
            #endregion

            #region SettingHeight

            var labelHeight = new Label()
            {
                Text =  "Height",
                Font =  config.TextFont
            };

            var textHeight = new TextBox(){Text = "600"};
            labelHeight.Bounds = new Rectangle(config.PadX, config.PadY+=dy, config.Width, config.Height);
            textHeight.Bounds = new Rectangle(config.PadX + dx, config.PadY, config.Width, config.Height);
            Controls.Add(labelHeight);
            Controls.Add(textHeight);
            #endregion

            #region BackgroundColorSetting
            var labelBackgroundColor = new Label()
            {
                Text = "Background color",
                Font = config.TextFont,
            };
            var cheangeColorButton = new Button();
            cheangeColorButton.Click += (sender, args) => CheangeColor(sender);
            labelBackgroundColor.Bounds = new Rectangle(config.PadX, config.PadY+=dy, config.Width, config.Height);
            cheangeColorButton.Bounds = new Rectangle(config.PadX + dx, config.PadY, config.Width, config.Height);
            //this function will added in logik
            //Controls.Add(labelBackgroundColor);
            //Controls.Add(cheangeColorButton);
            #endregion

            #region TextColor

            var labelTextColor = new Label()
            {
                Text = "Text color",
                Font = config.TextFont
            };

            var cheangeTextColorButton = new Button()
            {
                Text = "Example",
                ForeColor = Color.Red,
            };
            labelTextColor.Bounds = new Rectangle(config.PadX, config.PadY += dy, config.Width, config.Height);
            cheangeTextColorButton.Bounds = new Rectangle(config.PadX + dx, config.PadY, config.Width, config.Height);
            cheangeTextColorButton.Click += (sender, args) => CheangeTextColor(sender);
            Controls.Add(labelTextColor);
            Controls.Add(cheangeTextColorButton);
            #endregion

            var accept = new Button()
            {
                Text = "Ok",
                Font = config.TextFont
            };

            var cancel = new Button()
            {
                Text = "Cancel",
                Font = config.TextFont
            };

            accept.Bounds = new Rectangle(config.PadX, config.PadY += dy, config.Width, config.Height);
            cancel.Bounds = new Rectangle(config.PadX + dx + 20, config.PadY ,config.Width, config.Height);
            accept.Click += (sender, args) => Accept(textWidth.Text, textHeight.Text, cheangeColorButton.BackColor,
                cheangeTextColorButton.ForeColor);
            cancel.Click += (sender, args) => this.Hide();
            Controls.Add(accept);
            Controls.Add(cancel);
            
        }

        private void Accept(string widthWindow, string heightWindow, Color backgroundColor, Color textColor)
        {
            try
            {
                values.Width = int.Parse(widthWindow);
                values.Heigth = int.Parse(heightWindow);
                values.Color = textColor;
                this.Hide();
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "One or more parameters were not specified correctly, please check the correctness of the data",
                    "Invalid parameters");
            };
        }

        private void CheangeTextColor(object sender)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;
            (sender as Button).ForeColor = colorDialog.Color;
        }

        private void CheangeColor(object sender)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
                return;
            (sender as Button).BackColor = colorDialog.Color;
        }
    }
}
    