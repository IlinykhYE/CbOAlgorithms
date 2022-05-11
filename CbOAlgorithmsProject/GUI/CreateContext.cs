using System;
using System.Windows.Forms;

namespace CbOAlgorithms
{
    public partial class CreateContext : Form
    {
        public int attributeCount;
        public int objectCount;

        public CreateContext()
        {
            InitializeComponent();
        }

        //Событие нажатия на кнопку ОК
        private void onClickOkButton(object sender, EventArgs e)
        {
            objectCount = int.Parse(objCountTextBox.Text);
            attributeCount = int.Parse(attrCountTextBox.Text);
        }

        //Событие изменения текста в текстовом поле: проверка, что введённый текст - число
        private void textChanged(object sender, EventArgs e)
        {
            int testNumber;
            if (objCountTextBox.Text == ""
                || attrCountTextBox.Text == ""
                || !int.TryParse(objCountTextBox.Text, out testNumber)
                || !int.TryParse(attrCountTextBox.Text, out testNumber)) okButton.Enabled = false;
            else okButton.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}