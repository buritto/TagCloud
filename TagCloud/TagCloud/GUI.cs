using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TagCloud
{
    internal class ImageSettingWindow : Form
    {
       
    }

    internal class TextSettingWindow : Form
    {

    }

    internal class ShowImageAfterCreated : Form
    {

    }


    internal class GUI : Form
    {
       
        private ImageSettingWindow ISWindow = new ImageSettingWindow();
        private TextSettingWindow TSWindow = new TextSettingWindow();
        private ShowImageAfterCreated STCWindow = new ShowImageAfterCreated();

        private void CreateButton()
        {
            #region initializationButton
            var buttonFont = new Font(FontFamily.GenericSerif, 14);
            var listForButton = new List<Button>();
            listForButton.Add(new Button()
            {
                Text = "Image setting",
                Font = buttonFont
            });
            listForButton.Last().Click += (sender, args) => ISWindow.Show();

            listForButton.Add(new Button()
            {
                Text = "Text setting",
                Font = buttonFont
            });
            listForButton.Last().Click += (sender, args) => TSWindow.Show();

            listForButton.Add(new Button()
            {
                Text = "Load text from file ",
                Font = buttonFont
            });
            listForButton.Last().Click += (sender, args) => LoadText(); 

            listForButton.Add(new Button()
            {
                Text = "Create tag cloud",
                Font = buttonFont
            });
            listForButton.Last().Click += (sender, args) => CreateTagCloud();

            listForButton.Add(new Button()
            {
                Text = "Exit",
                Font = buttonFont
            });
            listForButton.Last().Click += (sender, args) => Application.Exit();
            #endregion

            foreach (var button in SetBounds(listForButton))
            {
                Controls.Add(button);
            }
        }

        private void CreateTagCloud()
        {
            throw new System.NotImplementedException();
        }

        private void LoadText()
        {
            throw new System.NotImplementedException();
        }

        private List<Button> SetBounds(List<Button> buttons)
        {
            var im = new ImageSettingWindow();
            var x = 17;
            var y = 20;
            var width = 250;
            var height = 35;
            foreach (var button in buttons)
            {
                button.Bounds = new Rectangle(x, y, width, height);
                y += 60;
            }
            return buttons;
        }

        public GUI(int width = 300, int height = 400)
        {
            Width = width;
            Height = height;
            CreateButton();
        }
    }
}
