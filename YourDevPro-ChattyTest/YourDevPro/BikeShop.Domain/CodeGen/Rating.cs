namespace BikeShop.Domain
{
    public partial class Rating : Entity<Rating>
    {
        public Rating() { }
        public Rating(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public int Stars { get; set; }
    }
}