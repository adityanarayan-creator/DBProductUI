using DBProduct.UI.ServiceAccessLayer.Product;
using DBProduct.UI.ViewModel.Product;
using Microsoft.AspNetCore.Mvc;

namespace DBProduct.UI.Web.Areas.Products.Controllers
{
    [Area("Products")]
    public class ProductsController : Controller
    {
        private readonly ProductServicesCall productServicesCall;

        public ProductsController()
        {
            productServicesCall = new ProductServicesCall();
        }

        // GET: /Products/Products
        public async Task<IActionResult> Index()
        {
            List<ProductViewModel> products =
                await productServicesCall.GetProducts();

            return View(products);
        }

        // GET: /Products/Products/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Products/Products/Create
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel product)
        {
            bool result =
                await productServicesCall.InsertProduct(product);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: /Products/Products/Edit/42
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            List<ProductViewModel> products =
                await productServicesCall.GetProducts();

            ProductViewModel product =
                products.FirstOrDefault(x => x.ProductID == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: /Products/Products/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel product)
        {
            bool result =
                await productServicesCall.UpdateProduct(product);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // POST: /Products/Products/Delete/42
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            bool result =
                await productServicesCall.DeleteProduct(id);

            if (result)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}