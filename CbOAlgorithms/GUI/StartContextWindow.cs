using System;
using System.Windows.Forms;

namespace CbOAlgorithms.GUI
{
    public partial class StartContextWindow : Form
    {
        public StartContextWindow()
        {
            InitializeComponent();
        }

        private void createContextHandlyButton_Click(object sender, EventArgs e)
        {
            var createContextWindow = new CreateContext();
            createContextWindow.ShowDialog();
            if (createContextWindow.DialogResult != DialogResult.OK) return;
            var main = new Main(new Context(createContextWindow.objectCount, createContextWindow.attributeCount));
            main.Show();
            Hide();
            main.FormClosed += FormClosed;
        }

        private void createRandomContextButton_Click(object sender, EventArgs e)
        {
            var createContextWindow = new CreateContext();
            createContextWindow.ShowDialog();
            if (createContextWindow.DialogResult != DialogResult.OK) return;
            var main = new Main(Context.RandomContext(createContextWindow.objectCount,
                createContextWindow.attributeCount, 0.8));
            main.Show();
            Hide();
            main.FormClosed += FormClosed;
        }

        private void importContextButton_Click(object sender, EventArgs e)
        {
            var main = new Main();
            main.Show();
            Hide();
            main.FormClosed += FormClosed;
        }

        private new void FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}