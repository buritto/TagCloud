using System.Drawing;
using System.Windows.Forms;

namespace TagCloud.WindowsForGUI
{
    internal class ImageSettingWindow : Form
    {
        public ImageSettingWindow(ProgrammArgumentsValue values)
        {
            var padx = 25;
            var pady = 75;
            var dx = 100;
            var dy = 45;
            var size = new Size(100, 30);
            Width = 300;
            Height = 400;
            var font = new Font(FontFamily.GenericSansSerif, 10);
            
            var settingName = new Label()
            {
                Font = new Font(FontFamily.GenericSansSerif, 14),
                Text = "Image setting"
            };
            #region SettingWidth
            var labelWidth = new Label()
            {
                Font = font,
                Text = "Width:"
            };

            var textWidth =new TextBox();
            labelWidth.Bounds = new Rectangle(padx, pady, size.Width, size.Height);
            textWidth.Bounds = new Rectangle(padx + dx, pady, size.Width, size.Height);
            Controls.Add(textWidth);
            Controls.Add(labelWidth);
            #endregion

            #region SettingHeight

            var labelHeight = new Label()
            {
                Text =  "Height",
                Font =  font
            };

            var textHeight = new TextBox();
            labelHeight.Bounds = new Rectangle(padx, pady+=dy, size.Width, size.Height);
            textHeight.Bounds = new Rectangle(padx + dx, pady, size.Width, size.Height);
            Controls.Add(labelHeight);
            Controls.Add(textHeight);
            #endregion

            #region BackgroundColorSetting
            var labelBackgroundColor = new Label()
            {
                Text = "Background color",
                Font = font,
            };
            var cheangeColorButton = new Button();
            cheangeColorButton.Click += (sender, args) => CheangeColor(sender);
            labelBackgroundColor.Bounds = new Rectangle(padx, pady+=dy, size.Width, size.Height);
            cheangeColorButton.Bounds = new Rectangle(padx + dx, pady, size.Width, size.Height);
            Controls.Add(labelBackgroundColor);
            Controls.Add(cheangeColorButton);
            #endregion

            #region TextColor

            var labelTextColor = new Label()
            {
                Text = "Text color",
                Font = font
            };

            var cheangeTextColorButton = new Button()
            {
                Text = "Example",
                ForeColor = Color.Red,
            };
            labelTextColor.Bounds = new Rectangle(padx, pady += dy, size.Width, size.Height);
            cheangeTextColorButton.Bounds = new Rectangle(padx + dx, pady, size.Width, size.Height);
            cheangeTextColorButton.Click += (sender, args) => CheangeTextColor(sender);
            Controls.Add(labelTextColor);
            Controls.Add(cheangeTextColorButton);
            #endregion

            var accept = new Button()
            {
                Text = "Ok",
                Font = font
            };

            var cancel = new Button()
            {
                Text = "Cancel",
                Font = font
            };

            accept.Bounds = new Rectangle(padx, pady += dy, size.Width, size.Height);
            cancel.Bounds = new Rectangle(padx + dx + 20, pady ,size.Width, size.Height);
            accept.Click += (sender, args) => Accept(textWidth.Text, textHeight.Text, cheangeColorButton.BackColor,
                cheangeTextColorButton.ForeColor);
            cancel.Click += (sender, args) => this.Hide();
            Controls.Add(accept);
            Controls.Add(cancel);
            settingName.Bounds = new Rectangle(75, 20, 250, 30);
            Controls.Add(settingName);
        }

        private void Accept(string widthWindow, string heightWindow, Color backgroundColor, Color textColor)
        {
            throw new System.NotImplementedException();
        }

        private void CheangeTextColor(object sender)
        {
            throw new System.NotImplementedException();
        }

        private void CheangeColor(object sender)
        {
            throw new System.NotImplementedException();
        }
    }
}
