namespace DBProduct.UI.ViewModel.Product
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public string Manufacturer { get; set; }

        public int SubCategoryID { get; set; }

        public bool IsAvailable { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}