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

	public class OrderDetailsController : BaseApiController
	{

		// GET Collection

		[HttpGet]
		public IEnumerable<ApiOrderDetail> Get(string expand = "")
		{
			return new List<ApiOrderDetail>();
		}

		// GET Single

		[HttpGet]
		public ApiOrderDetail Get(int? id, string expand = "")
		{
			return new ApiOrderDetail();
		}

		// POST = Insert

		[HttpPost]
		public ApiOrderDetail Post([FromBody] ApiOrderDetail apiorderdetail)
		{
			return apiorderdetail;
		}

		// PUT = Update

		[HttpPut]
		public ApiOrderDetail Put(int? id, [FromBody] ApiOrderDetail apiorderdetail)
		{
			return apiorderdetail;
		}

		// DELETE

		[HttpDelete]
		public ApiOrderDetail Delete(int? id)
		{
			return new ApiOrderDetail();
		}
	}
}
