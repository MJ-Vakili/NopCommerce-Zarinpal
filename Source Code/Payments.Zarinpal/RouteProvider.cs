using System;
using System.Web.Mvc;
using System.Web.Routing;
using Nop.Web.Framework.Mvc.Routes;

namespace NopFarsi.Payments.Zarinpal
{
	
	public class RouteProvider : IRouteProvider
	{
		
		public void RegisterRoutes(RouteCollection routes)
		{
            RouteCollectionExtensions.MapRoute(routes, "NopFarsi.Payments.Zarinpal.Verify", "Plugins/ZarinpalNopFarsi/Verify", new
			{
                controller = "ZarinpalNopFarsi",
				action = "Verify"
			}, new string[]
			{
				"NopFarsi.Payments.Zarinpal.Controllers"
			});
		}

		
		public int Priority
		{
			get
			{
				return 0;
			}
		}
	}
}
