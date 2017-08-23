using System;
using Nop.Core.Configuration;

namespace NopFarsi.Payments.Zarinpal
{
	
	public class ZarinpalSettings : ISettings
	{
		
		
		
		
		
		public string MerchantId
		{
			get;
			set;
		}

		
		public string PayementUrl
		{
			get;
			set;
		}

		
		public string WebServiceUrl
		{
			get;
			set;
		}


		
       

        public bool IsToman
        {
            get;
            set;
        }
        
	}
}
