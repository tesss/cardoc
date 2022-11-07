using CARDOC.Models;
using CARDOC.Models.Doc;
using DocumentFormat.OpenXml.EMMA;
using Microsoft.CodeAnalysis.Diagnostics;
using SharpDocx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARDOC.Utils
{
    public static class Documents
    {
        public static void GenerateZip(ZipModel model)
        {
            var document = DocumentFactory.Create(Const.DocTemplateFolder + "/zip.docx", model);
            var templateName = model.Vehicle.GetTemplateName();
            var path = string.Format("{0}/{1} {2} - {3} шт", Const.ExportFolder, model.Vehicle.Date.ToString("dd.MM.yyyy"), templateName, model.Quantity);
            Directory.CreateDirectory(path);
            document.Generate(string.Format("{0}/ЗІП {1} - {2} шт.docx", path, templateName, model.Quantity));
        }
    }
}