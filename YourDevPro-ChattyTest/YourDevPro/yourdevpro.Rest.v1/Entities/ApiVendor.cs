using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;
using BikeShop.Domain;

namespace yourdevpro.Rest.v1
{
	// Generated 10/27/2016 21:38:15
	
	public class ApiVendor : ApiEntity
	{ 
        public ApiVendor()
        {
            Products = new List<ApiEntity>();
        }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public List<ApiEntity> Products { get; set; }
	} 
}	
