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

	public class VendorsController : BaseApiController
	{

		// GET Collection

		[HttpGet]
		public IEnumerable<ApiVendor> Get(string expand = "")
		{
			return new List<ApiVendor>();
		}

		// GET Single

		[HttpGet]
		public ApiVendor Get(int? id, string expand = "")
		{
			return new ApiVendor();
		}

		// POST = Insert

		[HttpPost]
		public ApiVendor Post([FromBody] ApiVendor apivendor)
		{
			return apivendor;
		}

		// PUT = Update

		[HttpPut]
		public ApiVendor Put(int? id, [FromBody] ApiVendor apivendor)
		{
			return apivendor;
		}

		// DELETE

		[HttpDelete]
		public ApiVendor Delete(int? id)
		{
			return new ApiVendor();
		}
	}
}
