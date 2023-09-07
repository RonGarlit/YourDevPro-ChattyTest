using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;
using BikeShop.Domain;

namespace yourdevpro.Rest.v1
{
	// Generated 10/27/2016 21:38:15
	
	public class ApiRating : ApiEntity
	{ 
        public ApiEntity User { get; set; }
        public ApiEntity Product { get; set; }
        public int Stars { get; set; }
	} 
}	
