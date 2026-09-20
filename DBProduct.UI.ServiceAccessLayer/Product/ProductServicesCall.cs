using System.Text.Json;
using DBProduct.UI.ViewModel.Product;

namespace DBProduct.UI.ServiceAccessLayer.Product
{
    public class ProductServicesCall
    {
        private readonly ProductRepository productRepository;

        public ProductServicesCall()
        {
            productRepository = new ProductRepository();
        }

        // GET
        public async Task<List<ProductViewModel>> GetProducts()
        {
            string json = await productRepository.GetProducts();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            List<ProductViewModel> products =
                JsonSerializer.Deserialize<List<ProductViewModel>>(json, options);

            return products;
        }

        // INSERT
        public async Task<bool> InsertProduct(ProductCreateViewModel product)
        {
            return await productRepository.InsertProduct(product);
        }

        // UPDATE
        public async Task<bool> UpdateProduct(ProductViewModel product)
        {
            return await productRepository.UpdateProduct(product);
        }

        // DELETE
        public async Task<bool> DeleteProduct(int id)
        {
            return await productRepository.DeleteProduct(id);
        }
    }
}