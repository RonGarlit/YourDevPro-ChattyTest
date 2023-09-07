
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

	public class CartsController : BaseApiController
	{

		// GET Collection

		[HttpGet]
		public IEnumerable<ApiCart> Get(string expand = "")
		{
			return new List<ApiCart>();
		}

		// GET Single

		[HttpGet]
		public ApiCart Get(int? id, string expand = "")
		{
			return new ApiCart();
		}

		// POST = Insert

		[HttpPost]
		public ApiCart Post([FromBody] ApiCart apicart)
		{
			return apicart;
		}

		// PUT = Update

		[HttpPut]
		public ApiCart Put(int? id, [FromBody] ApiCart apicart)
		{
			return apicart;
		}

		// DELETE

		[HttpDelete]
		public ApiCart Delete(int? id)
		{
			return new ApiCart();
		}
	}
}
