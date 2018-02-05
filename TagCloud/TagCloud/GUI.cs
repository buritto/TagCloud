using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TagCloud.WindowsForGUI;

namespace TagCloud
{

    internal class GUI : Form
    {
        private ProgrammArgumentsValue values = new ProgrammArgumentsValue();
        private ImageSettingWindow imageSetting;
        private TextSettingWindow textSetting;
        private ShowImageAfterCreated windowWithCreatedImage;

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
            listForButton.Last().Click += (sender, args) => imageSetting.Show();

            listForButton.Add(new Button()
            {
                Text = "Text setting",
                Font = buttonFont
            });
            listForButton.Last().Click += (sender, args) => textSetting.Show();

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
            var openDialog = new OpenFileDialog();
            //  openDialog.InitialDirectory = "c:\\";
            openDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
            openDialog.FilterIndex = 2;
            openDialog.Multiselect = false;
            try
            {
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    values.TextFileName = openDialog.FileName;
                    MessageBox.Show("File successfully selected", "Success");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            

        }

        private List<Button> SetBounds(List<Button> buttons)
        {
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

            imageSetting = new ImageSettingWindow(values);
            textSetting = new TextSettingWindow(values);
            windowWithCreatedImage = new ShowImageAfterCreated();

            Width = width;
            Height = height;
            CreateButton();
        }
    }
}
