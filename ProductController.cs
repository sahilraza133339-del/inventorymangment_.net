using System.Web.Mvc;
using InventoryManagement.Data;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository repository = new ProductRepository();

        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        public ActionResult Create()
        {
            return View("Form", new Product());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Category,Quantity,Price")] Product product)
        {
            if (!ModelState.IsValid)
                return View("Form", product);

            repository.Add(product);
            TempData["Success"] = "Product added successfully.";
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = repository.GetById(id);
            if (product == null)
                return HttpNotFound();

            return View("Form", product);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind(Include = "Name,Category,Quantity,Price")] Product product)
        {
            product.Id = id;

            if (!ModelState.IsValid)
                return View("Form", product);

            if (!repository.Update(product))
                return HttpNotFound();

            TempData["Success"] = "Product updated successfully.";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var product = repository.GetById(id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (!repository.Delete(id))
                return HttpNotFound();

            TempData["Success"] = "Product deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
