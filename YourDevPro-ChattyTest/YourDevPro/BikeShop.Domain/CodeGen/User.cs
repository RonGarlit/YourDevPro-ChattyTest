using System;

namespace BikeShop.Domain
{
    public partial class User : Entity<User>
    {
        public User() { }
        public User(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime? SignupDate { get; set; }
        public int OrderCount { get; set; }
        public string AspNetUserId { get; set; }
    }
}