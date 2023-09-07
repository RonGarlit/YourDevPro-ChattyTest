namespace BikeShop.Domain
{
    public partial class Product : Entity<Product>
    {
        public Product() { }
        public Product(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public decimal	 ListPrice { get; set; }
        public int? VendorId { get; set; }
        public int QuantitySold { get; set; }
        public float AvgStars { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
    }
}