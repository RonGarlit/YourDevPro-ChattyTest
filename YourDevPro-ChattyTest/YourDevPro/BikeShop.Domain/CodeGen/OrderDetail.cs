namespace BikeShop.Domain
{
    public partial class OrderDetail : Entity<OrderDetail>
    {
        public OrderDetail() { }
        public OrderDetail(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}