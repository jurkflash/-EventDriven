namespace Cart.Domain
{
    public class CartDetail
    {
        public string ItemName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
