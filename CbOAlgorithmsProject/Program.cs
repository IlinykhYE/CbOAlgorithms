using System;
using System.Windows.Forms;
using CbOAlgorithms.GUI;

namespace CbOAlgorithms
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartContextWindow());
        }
    }
}