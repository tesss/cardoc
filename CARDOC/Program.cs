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
            if (!Directory.Exists(Const.DataFolder))
                Directory.CreateDirectory(Const.DataFolder);
            if (!Directory.Exists(Const.TemplateFolder))
                Directory.CreateDirectory(Const.TemplateFolder);
            DataProvider.ReadAll();
            DataProvider.ReadAllTemplates();
            DataProvider.FillCache();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}