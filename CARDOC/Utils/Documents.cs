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
        private static void OpenFolder()
        {
            Process.Start("explorer.exe", System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Const.ExportFolder);
        }
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
                OpenFolder();
        }
        public static void GenerateZip(List<Vehicle> vehicles)
        {
            Generate(vehicles, (vehicle, folderPath) =>
            {
                var document = DocumentFactory.Create(Const.DocTemplateFolder + "/zip.docx", vehicle);
                document.Generate(string.Format("{0}/ЗІП {1} - {2}.docx", folderPath, vehicle.TemplateName, vehicle.Vin));
            });
        }

        public static void GenerateIn(List<Vehicle> vehicles)
        {
            Generate(vehicles, (vehicle, folderPath) =>
            {
                var document = DocumentFactory.Create(Const.DocTemplateFolder + "/in.docx", vehicle);
                document.Generate(string.Format("{0}/АКТ ПРИЙМАННЯ {1} - {2}.docx", folderPath, vehicle.TemplateName, vehicle.Vin));
            });
        }

        public static void GenerateOut(List<Vehicle> vehicles)
        {
            Generate(vehicles, (vehicle, folderPath) =>
            {
                var document = DocumentFactory.Create(Const.DocTemplateFolder + "/out.docx", vehicle);
                document.Generate(string.Format("{0}/АКТ ПЕРЕДАЧІ {1} - {2}.docx", folderPath, vehicle.TemplateName, vehicle.Vin));
            });
        }

        public static void GenerateInGeneral(List<Vehicle> vehicles)
        {
            bool success = true;
            foreach (var date in vehicles.GroupBy(x => x.Date.Date))
            {
                try
                {
                    var document = DocumentFactory.Create(Const.DocTemplateFolder + "/inGeneral.docx", date.ToArray());
                    document.Generate(string.Format("{0}/{1} АКТ ПРИЙМАННЯ ЗАГАЛЬНИЙ - {2} шт.docx", Const.ExportFolder, date.Key.ToString(Const.DateFormat), date.Count()));
                }
                catch (Exception ex)
                {
                    success = false;
                }
            }
            if (success)
                OpenFolder();
        }

        public static void GenerateInOut(List<Vehicle> vehicles)
        {
            bool success = true;
            foreach (var date in vehicles.GroupBy(x => x.OutDate))
            {
                try
                {
                    var document = DocumentFactory.Create(Const.DocTemplateFolder + "/inOut.docx", date.ToArray());
                    document.Generate(string.Format("{0}/{1} АКТ ПРИЙМАННЯ ПЕРЕДАЧІ - {2} шт.docx", Const.ExportFolder, date.Key.ToString(Const.DateFormat), date.Count()));
                }
                catch (Exception ex)
                {
                    success = false;
                }
            }
            if (success)
                OpenFolder();
        }

        public static void GenerateZero(List<Vehicle> vehicles)
        {
            bool success = true;
            foreach (var model in vehicles.GroupBy(x => x.TemplateName))
            {
                try
                {
                    Vehicle vehicle = model.First();
                    if (DataProvider.Templates.ContainsKey(vehicle.TemplateName))
                        vehicle = DataProvider.Templates[vehicle.TemplateName];
                    var document = DocumentFactory.Create(Const.DocTemplateFolder + "/zero.docx", vehicle);
                    document.Generate(string.Format("{0}/ШАБЛОН {1}.docx", Const.ExportFolder, model.Key));
                }
                catch (Exception ex)
                {
                    success = false;
                }
            }
            if (success)
                OpenFolder();
        }
    }
}