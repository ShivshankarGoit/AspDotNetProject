
using AreaApplication.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreaApplication.Areas.DatabaseToExcell.Controllers
{
    public class DatabaseController : Controller
    {
        // GET: DatabaseToExcell/Database
        ExcellEntities2 db = new ExcellEntities2();

        // Action to display data in a view
        public ActionResult Index()
        {
            var employees = db.excellSheets.ToList();
            return View(employees);
        }
        public ActionResult ExportToExcel()
        {
            var excel = db.excellSheets.ToList();

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("excellSheets");

                // Add header row
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Name";
                worksheet.Cells[1, 3].Value = "City";


                // Add data rows
                for (int i = 0; i < excel.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = excel[i].Id;
                    worksheet.Cells[i + 2, 2].Value = excel[i].Name;
                    worksheet.Cells[i + 2, 3].Value = excel[i].City;

                }

                // Auto fit columns
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                var stream = new MemoryStream();
                package.SaveAs(stream);
                stream.Position = 0;

                string excelName = $"Employees-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
        }
    }
}
