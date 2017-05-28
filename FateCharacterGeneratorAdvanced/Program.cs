using System;
using System.Windows.Forms;

namespace FateCharacterGeneratorAdvanced
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string[] test = Resources.FemaleForeNames;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Base());

        }
    }
}
