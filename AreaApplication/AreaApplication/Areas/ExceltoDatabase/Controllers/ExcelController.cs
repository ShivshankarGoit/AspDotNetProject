
using AreaApplication.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreaApplication.Areas.ExceltoDatabase.Controllers
{
    public class ExcelController : Controller
    {
        private readonly ExcellEntities2 _context = new ExcellEntities2();

        public ActionResult index()
        {
            return View(_context.excellSheets.ToList());
        }
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                // Save the file to a temporary location
                var filePath = Path.Combine(Server.MapPath("~/App_Data/uploads"), Path.GetFileName(file.FileName));
                file.SaveAs(filePath);

                // Read the Excel file
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet != null)
                    {
                        var rowCount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowCount; row++) // assuming the first row is the header
                        {
                            var data = new excellSheet
                            {
                                Name = worksheet.Cells[row, 1].Text,
                                City = worksheet.Cells[row, 2].Text,
                                // Map other columns as needed
                            };

                            _context.excellSheets.Add(data);
                        }

                        _context.SaveChanges();
                    }
                }

                // Optionally delete the file after processing
                System.IO.File.Delete(filePath);
            }

            return RedirectToAction("Index","home"); // Or any other view
        }
    }
}
