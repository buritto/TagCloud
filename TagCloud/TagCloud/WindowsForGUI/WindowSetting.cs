using System.Drawing;
using System.Windows.Forms;

namespace TagCloud.WindowsForGUI
{
    internal class WindowSetting : Form
    {
        protected readonly ProgrammArgumentsValue values;
        protected readonly GraphicInterfaceConfig config;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        public WindowSetting(string nameSetting, ProgrammArgumentsValue values)
        {

            Width = 300;
            Height = 400;
            config = new GraphicInterfaceConfig();
            this.values = values;
            var settingName = new Label()
            {
                Font = new Font(FontFamily.GenericSansSerif, 14),
                Text = nameSetting
            };
            settingName.Bounds = new Rectangle(75, 20, 250, 30);
            Controls.Add(settingName);
        }

        protected Rectangle GetBounds(int padx, int pady)
        {
            return new Rectangle(padx, pady, config.Width, config.Height);
        }
    }
}
