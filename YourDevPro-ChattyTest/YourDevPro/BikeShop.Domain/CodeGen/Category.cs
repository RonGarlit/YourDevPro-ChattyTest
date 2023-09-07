namespace BikeShop.Domain
{
    public partial class Category : Entity<Category>
    {
        public Category() { }
        public Category(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public string CategoryName { get; set; }
    }
}