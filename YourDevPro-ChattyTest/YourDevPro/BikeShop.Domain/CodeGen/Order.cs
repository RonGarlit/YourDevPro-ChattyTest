using System;

namespace BikeShop.Domain
{
    public partial class Order : Entity<Order>
    {
        public Order() { }
        public Order(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public int? UserId { get; set; }
        public DateTime? OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public int OrderNumber { get; set; }
        public int ItemCount { get; set; }
    }
}