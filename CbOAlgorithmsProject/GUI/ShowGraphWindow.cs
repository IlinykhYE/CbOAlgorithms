using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CbOAlgorithms
{
    public partial class ShowGraphWindow : Form
    {
        private readonly string tempFilePath;
        public Image img;
        private WebBrowser wb = new WebBrowser();

        public ShowGraphWindow(string filepath)
        {
            InitializeComponent();

            tempFilePath = filepath;
            savePngFileDialog.AddExtension = true;
            savePngFileDialog.OverwritePrompt = true;
            savePngFileDialog.ValidateNames = true;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            img = Image.FromFile(filepath + ".png");
            pictureBox.Image = img;
        }

        private void onClickSavePngButton(object sender, EventArgs e)
        {
            savePngFileDialog.DefaultExt = "png";
            savePngFileDialog.Filter = "Images (*.png) | *.png";
            savePngFileDialog.FileName = "graph.png";
            if (savePngFileDialog.ShowDialog() != DialogResult.OK) return;
            var newFilePath = savePngFileDialog.FileName;
            File.Copy(tempFilePath + ".png", newFilePath);
        }

        private void onClickSaveDotFileButton(object sender, EventArgs e)
        {
            savePngFileDialog.DefaultExt = "dot";
            savePngFileDialog.FileName = "graph.dot";
            savePngFileDialog.Filter = "Images (*.dot) | *.dot";
            if (savePngFileDialog.ShowDialog() == DialogResult.OK)
            {
                var newFilePath = savePngFileDialog.FileName;
                File.Copy(tempFilePath + ".dot", newFilePath, true);
            }
        }

        private void onCloseWindow(object sender, FormClosedEventArgs e)
        {
            img.Dispose();
            pictureBox.Dispose();
        }

        /*
        private void onClickSaveSvgButton(object sender, EventArgs e)
        {
            Grid.SaveSvg(tempFilePath);
            savePngFileDialog.DefaultExt = "svg";
            savePngFileDialog.Filter = "Images (*.svg) | *.svg";
            savePngFileDialog.FileName = "graph.svg";
            if (savePngFileDialog.ShowDialog() == DialogResult.OK)
            {
                var newFilePath = savePngFileDialog.FileName;
                File.Copy(tempFilePath + ".svg", newFilePath, true);
            }
        }
        */

        private void ShowGraphWindow_Load(object sender, EventArgs e)
        {
        }
    }
}