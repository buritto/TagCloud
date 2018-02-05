using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TagCloud.WindowsForGUI
{
    internal class TextSettingWindow : WindowSetting
    {
        public TextSettingWindow(ProgrammArgumentsValue values)
               :base("Text setting", values)
        {

            var dx = 100;
            var dy = 45;
            #region MaxSizeField

            var maxSizeLabel = new Label()
            {
                Text = "Max size of word",
                Font = config.TextFont
            };

            var maxSizeText = new TextBox(){Text = "120"};
            maxSizeLabel.Bounds = GetBounds(config.PadX, config.PadY);
            maxSizeText.Bounds = GetBounds(config.PadX + dx, config.PadY);
            Controls.Add(maxSizeLabel);
            Controls.Add(maxSizeText);

            #endregion

            #region MinSizeField

            var minSizeLabel = new Label()
            {
                Text = "Min size of word",
                Font = config.TextFont
            };

            var minSizeText = new TextBox() { Text = "3" };
            minSizeLabel.Bounds = GetBounds(config.PadX, config.PadY+=dy);
            minSizeText.Bounds = GetBounds(config.PadX + dx, config.PadY);
            Controls.Add(minSizeLabel);
            Controls.Add(minSizeText);

            #endregion

            #region TextStyleField

            
            var textStyleLabel = new Label()
            {
                Text = "Text Style",
                Font =  config.TextFont
            };

            var textStyleCheange = new ComboBox();
            textStyleCheange.Items.AddRange(new object[]{ "Regular", "Bold", "Italic", "Strikeout", "Underline" });

            textStyleLabel.Bounds = GetBounds(config.PadX, config.PadY += dy);
            textStyleCheange.Bounds = GetBounds(config.PadX + dx, config.PadY);
            Controls.Add(textStyleLabel);
            Controls.Add(textStyleCheange);
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
            cancel.Bounds = new Rectangle(config.PadX + dx + 20, config.PadY, config.Width, config.Height);
            accept.Click += (sender, args) => Accept(maxSizeText.Text, minSizeText.Text, textStyleCheange.SelectedItem);
            cancel.Click += (sender, args) => this.Hide();
            Controls.Add(accept);
            Controls.Add(cancel);
            #endregion
        }

        private Dictionary<string, FontStyle> styles = new Dictionary<string, FontStyle>()
        {
            {"Bold", FontStyle.Bold },
            {"Italic", FontStyle.Italic},
            {"Regular", FontStyle.Regular},
            {"Strikeout", FontStyle.Strikeout},
            {"Underline", FontStyle.Underline}
        };
        private void Accept(string maxSize, string minSize, object style)
        {
            try
            {
                values.MaxSizeWord = int.Parse(maxSize);
                values.MinSizeWord = int.Parse(minSize);
                values.FontStyle = styles[style.ToString()];
                this.Hide();
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "One or more parameters were not specified correctly, please check the correctness of the data",
                    "Invalid parameters");
            }
        }
    }
}
