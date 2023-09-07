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

	public class CategoriesController : BaseApiController
	{

		// GET Collection

		[HttpGet]
		public IEnumerable<ApiCategory> Get(string expand = "")
		{
			return new List<ApiCategory>();
		}

		// GET Single

		[HttpGet]
		public ApiCategory Get(int? id, string expand = "")
		{
			return new ApiCategory();
		}

		// POST = Insert

		[HttpPost]
		public ApiCategory Post([FromBody] ApiCategory apicategory)
		{
			return apicategory;
		}

		// PUT = Update

		[HttpPut]
		public ApiCategory Put(int? id, [FromBody] ApiCategory apicategory)
		{
			return apicategory;
		}

		// DELETE

		[HttpDelete]
		public ApiCategory Delete(int? id)
		{
			return new ApiCategory();
		}
	}
}
