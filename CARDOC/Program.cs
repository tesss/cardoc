using CARDOC.Models;
using CARDOC.Utils;
using System.IO;

namespace CARDOC
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /* init folders */
            Directory.CreateDirectory(Const.DataFolder);
            Directory.CreateDirectory(Const.TemplateFolder);
            Directory.CreateDirectory(Const.DocTemplateFolder);
            Directory.CreateDirectory(Const.ExportFolder);

            DataProvider.ReadAll();
            DataProvider.ReadAllTemplates();
            DataProvider.FillCache();

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}