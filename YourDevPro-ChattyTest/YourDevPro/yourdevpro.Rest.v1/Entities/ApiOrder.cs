using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;
using BikeShop.Domain;

namespace yourdevpro.Rest.v1
{
	// Generated 10/27/2016 21:38:15
	
	public class ApiOrder : ApiEntity
	{ 
        public ApiOrder()
        {
            OrderDetails = new List<ApiEntity>();
        }
        public ApiEntity User { get; set; }
        public DateTime? OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public int OrderNumber { get; set; }
        public int ItemCount { get; set; }
        public List<ApiEntity> OrderDetails { get; set; }
	} 
}	
