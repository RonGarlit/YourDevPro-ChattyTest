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

	public class OrderNumbersController : BaseApiController
	{

		// GET Collection

		[HttpGet]
		public IEnumerable<ApiOrderNumber> Get(string expand = "")
		{
			return new List<ApiOrderNumber>();
		}

		// GET Single

		[HttpGet]
		public ApiOrderNumber Get(int? id, string expand = "")
		{
			return new ApiOrderNumber();
		}

		// POST = Insert

		[HttpPost]
		public ApiOrderNumber Post([FromBody] ApiOrderNumber apiordernumber)
		{
			return apiordernumber;
		}

		// PUT = Update

		[HttpPut]
		public ApiOrderNumber Put(int? id, [FromBody] ApiOrderNumber apiordernumber)
		{
			return apiordernumber;
		}

		// DELETE

		[HttpDelete]
		public ApiOrderNumber Delete(int? id)
		{
			return new ApiOrderNumber();
		}
	}
}
