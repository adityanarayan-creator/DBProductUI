using System.Net.Http;
using System.Net.Http.Json;
using DBProduct.UI.ViewModel.Product;

namespace DBProduct.UI.ServiceAccessLayer.Product
{
    public class ProductRepository
    {
        private readonly HttpClient httpClient;

        public ProductRepository()
        {
            httpClient = new HttpClient();
        }

        // GET
        public async Task<string> GetProducts()
        {
            string apiUrl = "https://localhost:7283/api/Product";

            HttpResponseMessage response =
                await httpClient.GetAsync(apiUrl);

            return await response.Content.ReadAsStringAsync();
        }

        // INSERT
        public async Task<bool> InsertProduct(ProductCreateViewModel product)
        {
            string apiUrl = "https://localhost:7283/api/Product";

            HttpResponseMessage response =
                await httpClient.PostAsJsonAsync(apiUrl, product);

            string responseMessage =
                await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    $"API Error: {response.StatusCode} - {responseMessage}");
            }

            return true;
        }

        // UPDATE
        public async Task<bool> UpdateProduct(ProductViewModel product)
        {
            string apiUrl = "https://localhost:7283/api/Product";

            HttpResponseMessage response =
                await httpClient.PutAsJsonAsync(apiUrl, product);

            string responseMessage =
                await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    $"API Error: {response.StatusCode} - {responseMessage}");
            }

            return true;
        }

        // DELETE
        public async Task<bool> DeleteProduct(int id)
        {
            string apiUrl = $"https://localhost:7283/api/Product/{id}";

            HttpResponseMessage response =
                await httpClient.DeleteAsync(apiUrl);

            string responseMessage =
                await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(
                    $"API Error: {response.StatusCode} - {responseMessage}");
            }

            return true;
        }
    }
}