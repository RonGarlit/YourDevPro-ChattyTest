using System;

namespace BikeShop.Domain
{
    public partial class Error : Entity<Error>
    {
        public Error() { }
        public Error(bool defaults) : base(defaults) { }

        public int? Id { get; set; }
        public string UserId { get; set; }
        public DateTime? ErrorDate { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public string Exception { get; set; }
        public string Message { get; set; }
        public string Everything { get; set; }
        public string HttpReferer { get; set; }
        public string PathAndQuery { get; set; }
    }
}