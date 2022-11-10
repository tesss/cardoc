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
                vehicle.Parts = vehicle.Parts.Where(x => x.PartType == PartType.Zip).ToList();
                var document = DocumentFactory.Create(Const.DocTemplateFolder + "/zip.docx", vehicle);
                document.Generate(string.Format("{0}/ЗІП {1} - {2}.docx", folderPath, vehicle.GetTemplateName(), vehicle.Vin));
            });
        }

        public static void GenerateIn(List<Vehicle> vehicles)
        {
            Generate(vehicles, (vehicle, folderPath) =>
            {
                vehicle.Parts = vehicle.Parts.Where(x => x.PartType == PartType.Zip).ToList();
                var document = DocumentFactory.Create(Const.DocTemplateFolder + "/in.docx", vehicle);
                document.Generate(string.Format("{0}/АКТ т ст {1} - {2}.docx", folderPath, vehicle.GetTemplateName(), vehicle.Vin));
            });
        }
    }
}