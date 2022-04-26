using System;
using System.Windows.Forms;

namespace CbOAlgorithms
{
    public partial class SaveChangesForm : Form
    {
        public bool saveDot;
        public bool saveLattice;
        public bool savePng;

        public SaveChangesForm()
        {
            InitializeComponent();
        }

        //Событие изменения галочек в чек-боксах
        private void onCheckedChanged(object sender, EventArgs e)
        {
            if (latticeCheckBox.Checked || pngCheckBox.Checked || dotCheckBox.Checked) saveButton.Enabled = true;
            else saveButton.Enabled = false;

            saveLattice = latticeCheckBox.Checked;
            savePng = pngCheckBox.Checked;
            saveDot = dotCheckBox.Checked;
        }
    }
}