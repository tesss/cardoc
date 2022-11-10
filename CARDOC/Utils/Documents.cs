using CARDOC.Models;
using CARDOC.Models.Doc;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.CodeAnalysis.Diagnostics;
using SharpDocx;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CARDOC.Utils
{
    public static class Documents
    {
        public static void Generate(List<Vehicle> vehicles, Action<Vehicle, string> action)
        {
            bool success = true;
            foreach (var folder in vehicles.GroupBy(x => x.ExportFolder))
            {
                var folderPath = string.Format("{0} - {1} шт", folder.Key, folder.Count());
                Directory.CreateDirectory(folderPath);
                foreach (var vehicle in folder)
                {
                    try
                    {
                        action(vehicle, folderPath);
                    }
                    catch (Exception ex)
                    {
                        success = false;
                    }
                }
            }
            if (success)
                Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Const.ExportFolder);
        }
        public static void GenerateZip(List<Vehicle> vehicles)
        {
            Generate(vehicles, (vehicle, folderPath) =>
            {
                var document = DocumentFactory.Create(Const.DocTemplateFolder + "/zip.docx", vehicle);
                document.Generate(string.Format("{0}/ЗІП {1} - {2}.docx", folderPath, vehicle.GetTemplateName(), vehicle.Vin));
            });
        }

        public static void GenerateIn(List<Vehicle> vehicles)
        {
            Generate(vehicles, (vehicle, folderPath) =>
            {
                var document = DocumentFactory.Create(Const.DocTemplateFolder + "/in.docx", vehicle);
                document.Generate(string.Format("{0}/АКТ ПРИЙМАННЯ {1} - {2}.docx", folderPath, vehicle.GetTemplateName(), vehicle.Vin));
            });
        }

        public static void GenerateOut(List<Vehicle> vehicles)
        {
            Generate(vehicles, (vehicle, folderPath) =>
            {
                var document = DocumentFactory.Create(Const.DocTemplateFolder + "/out.docx", vehicle);
                document.Generate(string.Format("{0}/АКТ ПЕРЕДАЧІ {1} - {2}.docx", folderPath, vehicle.GetTemplateName(), vehicle.Vin));
            });
        }

        public static void GenerateInGeneral(List<Vehicle> vehicles)
        {
            bool success = true;
            foreach (var date in vehicles.GroupBy(x => x.Date.Date))
            {
                try
                {
                    var document = DocumentFactory.Create(Const.DocTemplateFolder + "/inGeneral.docx", vehicles);
                    document.Generate(string.Format("{0}/АКТ ПРИЙМАННЯ ЗАГАЛЬНИЙ {1} - {2}.docx", Const.ExportFolder, date.Key.ToString(Const.DateFormat), date.Count()));
                }
                catch (Exception ex)
                {
                    success = false;
                }
            }
            if (success)
                Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Const.ExportFolder);
        }
    }
}