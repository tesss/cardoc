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
            //var vehicles = Dummy.GetVehicles();
            //for (int i = 0; i < 5; i++)
            //    foreach(var vehicle in vehicles)
            //        DataProvider.Write(vehicle, new DateTime(2022, 1, 1).AddDays(i));
            DataProvider.ReadAll();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}