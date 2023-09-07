using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;
using BikeShop.Domain;

namespace yourdevpro.Rest.v1
{
	// Generated 10/27/2016 21:38:15
	
	public class ApiProduct : ApiEntity
	{ 
        public ApiProduct()
        {
            OrderDetails = new List<ApiEntity>();
            Ratings = new List<ApiEntity>();
        }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public decimal	 ListPrice { get; set; }
        public ApiEntity Vendor { get; set; }
        public int QuantitySold { get; set; }
        public float AvgStars { get; set; }
        public string CategoryName { get; set; }
        public ApiEntity Category { get; set; }
        public List<ApiEntity> OrderDetails { get; set; }
        public List<ApiEntity> Ratings { get; set; }
	} 
}	
