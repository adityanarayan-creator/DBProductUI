using System.Net.Http.Json;
using DBProduct.UI.Common.Helper;
using DBProduct.UI.ViewModel.Product;

namespace DBProduct.UI.ServiceAccessLayer.Product
{
    public class ProductRepository
    {
        private readonly HttpClient httpClient;
        private readonly LogHelper logHelper;

        public ProductRepository()
        {
            httpClient = new HttpClient();
            logHelper = new LogHelper();
        }

        // GET
        public async Task<string> GetProducts()
        {
            try
            {
                string apiUrl =
                    "https://localhost:7283/api/Product";

                HttpResponseMessage response =
                    await httpClient.GetAsync(apiUrl);

                string responseMessage =
                    await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    logHelper.Log(
                        $"Get products API failed: {response.StatusCode}",
                        "Error",
                        "UI");

                    throw new Exception(
                        $"API Error: {response.StatusCode} - {responseMessage}");
                }

                logHelper.Log(
                    "Products fetched successfully from API",
                    "Event",
                    "UI");

                return responseMessage;
            }
            catch (Exception ex)
            {
                logHelper.LogException(
                    ex,
                    "UI");

                throw;
            }
        }

        // INSERT
        public async Task<bool> InsertProduct(
            ProductCreateViewModel product)
        {
            try
            {
                string apiUrl =
                    "https://localhost:7283/api/Product";

                HttpResponseMessage response =
                    await httpClient.PostAsJsonAsync(
                        apiUrl,
                        product);

                string responseMessage =
                    await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    logHelper.Log(
                        $"Insert product API failed: {response.StatusCode}",
                        "Error",
                        "UI");

                    throw new Exception(
                        $"API Error: {response.StatusCode} - {responseMessage}");
                }

                logHelper.Log(
                    "Product inserted successfully through UI",
                    "Event",
                    "UI");

                return true;
            }
            catch (Exception ex)
            {
                logHelper.LogException(
                    ex,
                    "UI");

                throw;
            }
        }

        // UPDATE
        public async Task<bool> UpdateProduct(
            ProductViewModel product)
        {
            try
            {
                string apiUrl =
                    "https://localhost:7283/api/Product";

                HttpResponseMessage response =
                    await httpClient.PutAsJsonAsync(
                        apiUrl,
                        product);

                string responseMessage =
                    await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    logHelper.Log(
                        $"Update product API failed: {response.StatusCode}",
                        "Error",
                        "UI");

                    throw new Exception(
                        $"API Error: {response.StatusCode} - {responseMessage}");
                }

                logHelper.Log(
                    "Product updated successfully through UI",
                    "Event",
                    "UI");

                return true;
            }
            catch (Exception ex)
            {
                logHelper.LogException(
                    ex,
                    "UI");

                throw;
            }
        }

        // DELETE
        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                string apiUrl =
                    $"https://localhost:7283/api/Product/{id}";

                HttpResponseMessage response =
                    await httpClient.DeleteAsync(apiUrl);

                string responseMessage =
                    await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    logHelper.Log(
                        $"Delete product API failed: {response.StatusCode}",
                        "Error",
                        "UI");

                    throw new Exception(
                        $"API Error: {response.StatusCode} - {responseMessage}");
                }

                logHelper.Log(
                    "Product deleted successfully through UI",
                    "Event",
                    "UI");

                return true;
            }
            catch (Exception ex)
            {
                logHelper.LogException(
                    ex,
                    "UI");

                throw;
            }
        }
    }
}