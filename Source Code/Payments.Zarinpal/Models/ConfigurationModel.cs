using System;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc;

namespace NopFarsi.Payments.Zarinpal.Models
{
	
	public class ConfigurationModel : BaseNopModel
	{
		
		public int ActiveStoreScopeConfiguration
		{
			get;
			set;
		}

		
		[NopResourceDisplayName("NopFarsi.Zarinpal.Fields.MerchantId")]
		public string MerchantId
		{
			get;
			set;
		}

		
		public bool MerchantIdOverrideForStore
		{
			get;
			set;
		}

		
		[NopResourceDisplayName("NopFarsi.Zarinpal.Fields.PayementUrl")]
		public string PayementUrl
		{
			get;
			set;
		}

		
		public bool PayementUrlOverrideForStore
		{
			get;
			set;
		}

		
		[NopResourceDisplayName("NopFarsi.Zarinpal.Fields.WebServiceUrl")]
		public string WebServiceUrl
		{
			get;
			set;
		}

		
		public bool WebServiceUrlOverrideForStore
		{
			get;
			set;
		}


		
        [NopResourceDisplayName("NopFarsi.Zarinpal.Fields.IsToman")]
        public bool IsTomanForStore
        {
            get;
            set;
        }
	}
}
