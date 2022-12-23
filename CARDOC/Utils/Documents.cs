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
            if (!vehicles.Any())
                return new List<string>();
            bool success = true;
            var files = new List<string>();
            foreach (var folder in vehicles.GroupBy(x => x.ExportFolderOut))
            {
                var folderPath = string.Format("{0}", folder.Key);
                Directory.CreateDirectory(folderPath);
                foreach (var vehicle in folder)
                {
                    try
                    {
                        var document = DocumentFactory.Create(Const.DocTemplateFolder + "/zip.docx", vehicle);
                        var file = string.Format("{0}/ЗІП {1} - {2}.docx", folderPath, vehicle.TemplateName, vehicle.Vin.RemoveInvalidChars());
                        document.Generate(file);
                        files.Add(file);
                        if(vehicle.GetEquipmentCargo().Any())
                        {
                            document = DocumentFactory.Create(Const.DocTemplateFolder + "/zipCargo.docx", vehicle);
                            file = string.Format("{0}/ЗІП КУЗОВ {1} - {2}.docx", folderPath, vehicle.TemplateName, vehicle.Vin.RemoveInvalidChars());
                            document.Generate(file);
                            files.Add(file);
                        }
                    }
                    catch (Exception ex)
                    {
                        success = false;
                    }
                }
            }
            return files;
        }
        
        public static List<string> GenerateIn(List<Vehicle> vehicles)
        {
            if (!vehicles.Any())
                return new List<string>();
            bool success = true;
            var files = new List<string>();
            foreach (var folder in vehicles.GroupBy(x => x.ExportFolderIn))
            {
                var folderPath = string.Format("{0}", folder.Key);
                Directory.CreateDirectory(folderPath);
                foreach (var vehicle in folder)
                {
                    try
                    {
                        var document = DocumentFactory.Create(Const.DocTemplateFolder + "/in.docx", vehicle);
                        var file = string.Format("{0}/АКТ ПРИЙМАННЯ {1} - {2}.docx", folderPath, vehicle.TemplateName, vehicle.Vin.RemoveInvalidChars());
                        document.Generate(file);
                        files.Add(file);
                    }
                    catch (Exception ex)
                    {
                        success = false;
                    }
                }
            }
            return files;
        }

        public static List<string> GenerateOut(List<Vehicle> vehicles)
        {
            if (!vehicles.Any())
                return new List<string>();
            bool success = true;
            var files = new List<string>();
            foreach (var folder in vehicles.GroupBy(x => x.ExportFolderOut))
            {
                var folderPath = string.Format("{0}", folder.Key);
                Directory.CreateDirectory(folderPath);
                foreach (var vehicle in folder)
                {
                    try
                    {
                        var document = DocumentFactory.Create(Const.DocTemplateFolder + "/out.docx", vehicle);
                        var file = string.Format("{0}/АКТ ПЕРЕДАЧІ {1} - {2}.docx", folderPath, vehicle.TemplateName, vehicle.Vin.RemoveInvalidChars());
                        document.Generate(file);
                        files.Add(file);
                    }
                    catch (Exception ex)
                    {
                        success = false;
                    }
                }
            }
            return files;
        }

        public static List<string> GenerateInGeneral(List<Vehicle> vehicles)
        {
            if (!vehicles.Any())
                return new List<string>();
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
            if (!vehicles.Any())
                return new List<string>();
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
            if (!vehicles.Any())
                return new List<string>();
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
            if (!vehicles.Any())
                return new List<string>();
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
            if (!vehicles.Any())
                return new List<string>();
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
            if (!vehicles.Any())
                return new List<string>();
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
            if (!vehicles.Any())
                return new List<string>();
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

        internal static List<string> GenerateInvoice(List<Vehicle> vehicles, bool withWear)
        {
            if (!vehicles.Any())
                return new List<string>();
            bool success = true;
            var files = new List<string>();
            foreach (var model in vehicles.GroupBy(x => x.OutDate))
            {
                try
                {
                    var document = DocumentFactory.Create(Const.DocTemplateFolder + (withWear ? "/invoiceWear.docx" : "/invoice.docx"), model.ToArray());
                    var file = string.Format("{0}/{1} НАКЛАДНА{2}.docx", Const.ExportFolder, model.Key.ToString(Const.DateFormat), withWear ? " ЗНОС" : "");
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

        internal static List<string> GenerateReg(List<Vehicle> vehicles)
        {
            if (!vehicles.Any())
                return new List<string>();
            bool success = true;
            var files = new List<string>();
            foreach (var model in vehicles.GroupBy(x => x.Date))
            {
                try
                {
                    var document = DocumentFactory.Create(Const.DocTemplateFolder + "/reg.docx", model.ToArray());
                    var file = string.Format("{0}/{1} РЕЄСТРАЦІЯ ВІБДР.docx", Const.ExportFolder, model.Key.ToString(Const.DateFormat));
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

        internal static List<string> GenerateCounts(DateTime from, DateTime to)
        {
            bool success = true;
            var files = new List<string>();
            var vehicles = DataProvider.Vehicles.Where(x => x.Date >= from && x.Date <= to);
            var counts = vehicles.GroupBy(x => x.Type).OrderBy(x => x.Key).Select(x => new KeyValuePair<string, int>(x.Key, x.Count())).ToArray();
            var model = new AT1Model
            {
                From = from,
                To = to,
                Counts = counts
            };
            try
            {
                var document = DocumentFactory.Create(Const.DocTemplateFolder + "/counts.docx", model);
                var file = string.Format("{0}/{1}-{2} КІЛЬКІСТЬ ТЗ.docx", Const.ExportFolder, model.From.ToString(Const.DateFormat), model.To.ToString(Const.DateFormat), model);
                document.Generate(file);
                files.Add(file);
            }
            catch (Exception ex)
            {
                success = false;
            }
            return files;
        }
    }
}