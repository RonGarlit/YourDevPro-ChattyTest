namespace BikeShop.Domain
{
    public partial class CartItem : Entity<CartItem>
    {
        public CartItem() { }
        public CartItem(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public int? CartId { get; set; }
        public int? ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}