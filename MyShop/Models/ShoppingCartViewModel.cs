namespace MyShop.Models
{
    public class ShoppingCartViewModel
    {
        public List<ShoppingCartItem> Items { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? TotalQuantity { get; set; }
    }
}
