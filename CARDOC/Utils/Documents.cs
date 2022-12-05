using CARDOC.Models;
using CARDOC.Models.Doc;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2019.Drawing.Model3D;
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
        public static List<string> Generate(List<Vehicle> vehicles, Func<Vehicle, string, string> action, bool folderIn = true)
        {
            bool success = true;
            var files = new List<string>();
            foreach (var folder in vehicles.GroupBy(x => folderIn ? x.ExportFolderIn: x.ExportFolderOut))
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
            }, false);
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
            }, false);
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

        public static List<string> GenerateInOutGeneral(List<Vehicle> vehicles, bool withWear)
        {
            bool success = true;
            var files = new List<string>();
            foreach (var date in vehicles.GroupBy(x => x.OutDate))
            {
                try
                {
                    var document = DocumentFactory.Create(Const.DocTemplateFolder + (withWear ? "/inOutGeneralWear.docx" : "/inOutGeneral.docx"), date.ToArray());
                    var file = string.Format("{0}/{1} АКТ ПРИЙМАННЯ-ПЕРЕДАЧІ ОСН ЗАС{2}.docx", Const.ExportFolder, date.Key.ToString(Const.DateFormat), withWear ? " ЗНОС" : "");
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

        internal static List<string> GeneratePrice(List<Vehicle> vehicles, decimal rate)
        {
            bool success = true;
            var files = new List<string>();
            foreach (var model in vehicles.GroupBy(x => x.Date))
            {
                try
                {
                    var document = DocumentFactory.Create(Const.DocTemplateFolder + "/price.docx", new PriceModel
                    {
                        Rate = rate,
                        Vehicles = model.ToList()
                    });
                    var file = string.Format("{0}/{1} ВІДОМІСТЬ ВИЗНАЧЕННЯ ВАРТОСТІ.docx", Const.ExportFolder, model.Key.ToString(Const.DateFormat));
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

        internal static List<string> GenerateGeneral(List<Vehicle> vehicles)
        {
            var files = new List<string>();
            try
            {
                var document = DocumentFactory.Create(Const.DocTemplateFolder + "/general.docx", vehicles.OrderBy(x => x.Date).ThenBy(x => x.TemplateName).ThenBy(x => x.Vin).ToArray());
                var file = string.Format("{0}/{1} ЗАГАЛЬНА ВІДОМІСТЬ.docx", Const.ExportFolder, DateTime.Now.ToString(Const.DateFormat));
                document.Generate(file);
                files.Add(file);
            }
            catch (Exception ex)
            {
            }
            return files;
        }

        internal static List<string> GeneratePriceCalc(List<Vehicle> vehicles)
        {
            bool success = true;
            var files = new List<string>();
            foreach (var model in vehicles.GroupBy(x => x.Date))
            {
                try
                {
                    var document = DocumentFactory.Create(Const.DocTemplateFolder + "/priceCalc.docx", model.ToArray());
                    var file = string.Format("{0}/{1} ВІДОМІСТЬ ВИЗНАЧЕННЯ ВАРТОСТІ КОЕФ.docx", Const.ExportFolder, model.Key.ToString(Const.DateFormat));
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

        internal static List<string> GenerateInvoice(List<Vehicle> vehicles)
        {
            bool success = true;
            var files = new List<string>();
            foreach (var model in vehicles.GroupBy(x => x.OutDate))
            {
                try
                {
                    var document = DocumentFactory.Create(Const.DocTemplateFolder + "/invoice.docx", model.ToArray());
                    var file = string.Format("{0}/{1} НАКЛАДНА.docx", Const.ExportFolder, model.Key.ToString(Const.DateFormat));
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