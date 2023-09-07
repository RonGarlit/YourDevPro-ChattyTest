namespace BikeShop.Domain
{
    public partial class OrderNumber : Entity<OrderNumber>
    {
        public OrderNumber() { }
        public OrderNumber(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public int Number { get; set; }
    }
}