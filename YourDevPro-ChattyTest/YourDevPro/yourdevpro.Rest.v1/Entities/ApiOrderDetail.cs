using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;
using BikeShop.Domain;

namespace yourdevpro.Rest.v1
{
	// Generated 10/27/2016 21:38:15
	
	public class ApiOrderDetail : ApiEntity
	{ 
        public ApiEntity Order { get; set; }
        public ApiEntity Product { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
	} 
}	
