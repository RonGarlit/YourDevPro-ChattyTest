using System;

namespace BikeShop.Domain
{
    public partial class Cart : Entity<Cart>
    {
        public Cart() { }
        public Cart(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public string Cookie { get; set; }
        public DateTime? CartDate { get; set; }
        public int ItemCount { get; set; }
    }
}