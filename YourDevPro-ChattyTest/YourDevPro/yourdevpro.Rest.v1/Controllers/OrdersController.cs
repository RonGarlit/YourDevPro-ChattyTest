using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using AutoMapper;
using BikeShop.Domain;

namespace yourdevpro.Rest.v1
{
	// Generated 10/27/2016 21:38:15
	
	// Change code for each method

	public class OrdersController : BaseApiController
	{

		// GET Collection

		[HttpGet]
		public IEnumerable<ApiOrder> Get(string expand = "")
		{
			return new List<ApiOrder>();
		}

		// GET Single

		[HttpGet]
		public ApiOrder Get(int? id, string expand = "")
		{
			return new ApiOrder();
		}

		// POST = Insert

		[HttpPost]
		public ApiOrder Post([FromBody] ApiOrder apiorder)
		{
			return apiorder;
		}

		// PUT = Update

		[HttpPut]
		public ApiOrder Put(int? id, [FromBody] ApiOrder apiorder)
		{
			return apiorder;
		}

		// DELETE

		[HttpDelete]
		public ApiOrder Delete(int? id)
		{
			return new ApiOrder();
		}
	}
}
