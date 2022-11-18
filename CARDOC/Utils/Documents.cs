using CARDOC.Models;
using CARDOC.Models.Doc;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Spreadsheet;
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
        public static List<string> Generate(List<Vehicle> vehicles, Func<Vehicle, string, string> action)
        {
            bool success = true;
            var files = new List<string>();
            foreach (var folder in vehicles.GroupBy(x => x.ExportFolder))
            {
                var folderPath = string.Format("{0}", folder.Key);
                Directory.CreateDirectory(folderPath);
                foreach (var vehicle in folder)
                {
                    try
                    {
                        files.Add(action(vehicle, folderPath));
                    }
                    catch (Exception ex)
                    {
                        success = false;
                    }
                }
            }
            return files;
        }
        public static List<string> GenerateZip(List<Vehicle> vehicles)
        {
            return Generate(vehicles, (vehicle, folderPath) =>
            {
                var document = DocumentFactory.Create(Const.DocTemplateFolder + "/zip.docx", vehicle);
                var file = string.Format("{0}/ЗІП {1} - {2}.docx", folderPath, vehicle.TemplateName, vehicle.Vin);
                document.Generate(file);
                return file;
            });
        }

        public static List<string> GenerateIn(List<Vehicle> vehicles)
        {
            return Generate(vehicles, (vehicle, folderPath) =>
            {
                var document = DocumentFactory.Create(Const.DocTemplateFolder + "/in.docx", vehicle);
                var file = string.Format("{0}/АКТ ПРИЙМАННЯ {1} - {2}.docx", folderPath, vehicle.TemplateName, vehicle.Vin);
                document.Generate(file);
                return file;
            });
        }

        public static List<string> GenerateOut(List<Vehicle> vehicles)
        {
            return Generate(vehicles, (vehicle, folderPath) =>
            {
                var document = DocumentFactory.Create(Const.DocTemplateFolder + "/out.docx", vehicle);
                var file = string.Format("{0}/АКТ ПЕРЕДАЧІ {1} - {2}.docx", folderPath, vehicle.TemplateName, vehicle.Vin);
                document.Generate(file);
                return file; 
            });
        }

        public static List<string> GenerateInGeneral(List<Vehicle> vehicles)
        {
            bool success = true;
            var files = new List<string>();
            foreach (var date in vehicles.GroupBy(x => x.Date.Date))
            {
                try
                {
                    var document = DocumentFactory.Create(Const.DocTemplateFolder + "/inGeneral.docx", date.ToArray());
                    var file = string.Format("{0}/{1} АКТ ПРИЙМАННЯ ЗАГАЛЬНИЙ.docx", Const.ExportFolder, date.Key.ToString(Const.DateFormat));
                    document.Generate(file);
                    files.Add(file);
                }
                catch (Exception ex)
                {
                    success = false;
                }
            }
            return files;
        }

        public static List<string> GenerateInOut(List<Vehicle> vehicles)
        {
            bool success = true;
            var files = new List<string>();
            foreach (var date in vehicles.GroupBy(x => x.OutDate))
            {
                try
                {
                    var document = DocumentFactory.Create(Const.DocTemplateFolder + "/inOut.docx", date.ToArray());
                    var file = string.Format("{0}/{1} АКТ ПРИЙМАННЯ-ПЕРЕДАЧІ.docx", Const.ExportFolder, date.Key.ToString(Const.DateFormat));
                    document.Generate(file);
                    files.Add(file);
                }
                catch (Exception ex)
                {
                    success = false;
                }
            }
            return files;
        }

        public static List<string> GenerateZero(List<Vehicle> vehicles)
        {
            bool success = true;
            var files = new List<string>();
            foreach (var model in vehicles.GroupBy(x => x.TemplateName))
            {
                try
                {
                    Vehicle vehicle = model.First();
                    if (DataProvider.Templates.ContainsKey(vehicle.TemplateName))
                        vehicle = DataProvider.Templates[vehicle.TemplateName];
                    var document = DocumentFactory.Create(Const.DocTemplateFolder + "/zero.docx", vehicle);
                    var file = string.Format("{0}/ШАБЛОН {1}.docx", Const.ExportFolder, model.Key);
                    document.Generate(file);
                    files.Add(file);
                }
                catch (Exception ex)
                {
                    success = false;
                }
            }
            return files;
        }
    }
}