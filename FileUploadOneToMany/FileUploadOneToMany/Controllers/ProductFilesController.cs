using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUploadOneToMany.Controllers
{
    public class ProductFilesController : Controller
    {
        // GET: ProductFiles
        // GET: ProductFiles/Index/5

        ProductionEntities _context = new ProductionEntities();
        public ActionResult Index()
        {
           

            return View(_context.ProductFiles.ToList());
        }

        // Other actions...

        // GET: ProductFiles/Create
        public ActionResult Create(int productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }

        // POST: ProductFiles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(int productId, HttpPostedFileBase file)
        {
            if (file == null || file.ContentLength == 0)
            {
                ModelState.AddModelError("File", "Please upload a file.");
                ViewBag.ProductId = productId;
                return View();
            }

            var product = await _context.Products.FindAsync(productId);

            if (product == null)
            {
                return HttpNotFound();
            }

            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(Server.MapPath("~/Uploads"), fileName);

            file.SaveAs(filePath);

            var productFile = new ProductFile
            {
                FileName = fileName,
                FilePath = filePath,
                ProductId = productId
            };
            _context.ProductFiles.Add(productFile);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Products", new { id = productId });
        }

        // Other actions...

        // GET: ProductFiles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var productFile = await _context.ProductFiles.FindAsync(id);

            if (productFile == null)
            {
                return HttpNotFound();
            }

            return View(productFile);
        }

        // POST: ProductFiles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind(Include = "Id,FileName,FilePath,ProductId")] ProductFile productFile)
        {
            if (id != productFile.Id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                _context.Entry(productFile).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Products", new { id = productFile.ProductId });
            }
            return View(productFile);
        }

        // GET: ProductFiles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var productFile = await _context.ProductFiles.FindAsync(id);

            if (productFile == null)
            {
                return HttpNotFound();
            }

            return View(productFile);
        }

        // POST: ProductFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var productFile = await _context.ProductFiles.FindAsync(id);
            _context.ProductFiles.Remove(productFile);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Products", new { id = productFile.ProductId });
        }
    }
}
