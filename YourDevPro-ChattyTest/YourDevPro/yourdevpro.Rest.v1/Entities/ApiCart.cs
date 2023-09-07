using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;
using BikeShop.Domain;

namespace yourdevpro.Rest.v1
{
	// Generated 10/27/2016 21:38:15
	
	public class ApiCart : ApiEntity
	{ 
        public ApiCart()
        {
            CartItems = new List<ApiEntity>();
        }
        public string Cookie { get; set; }
        public DateTime? CartDate { get; set; }
        public int ItemCount { get; set; }
        public List<ApiEntity> CartItems { get; set; }
	} 
}	
