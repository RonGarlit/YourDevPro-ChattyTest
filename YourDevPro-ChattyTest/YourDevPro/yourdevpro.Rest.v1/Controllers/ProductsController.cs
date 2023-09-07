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

	public class ProductsController : BaseApiController
	{

		// GET Collection

		[HttpGet]
		public IEnumerable<ApiProduct> Get(string expand = "")
		{
			return new List<ApiProduct>();
		}

		// GET Single

		[HttpGet]
		public ApiProduct Get(int? id, string expand = "")
		{
			return new ApiProduct();
		}

		// POST = Insert

		[HttpPost]
		public ApiProduct Post([FromBody] ApiProduct apiproduct)
		{
			return apiproduct;
		}

		// PUT = Update

		[HttpPut]
		public ApiProduct Put(int? id, [FromBody] ApiProduct apiproduct)
		{
			return apiproduct;
		}

		// DELETE

		[HttpDelete]
		public ApiProduct Delete(int? id)
		{
			return new ApiProduct();
		}
	}
}
