using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace NopFarsi.Payments.Zarinpal.ZarinpalPeymentService
{
	
	[DebuggerStepThrough, GeneratedCode("System.ServiceModel", "4.0.0.0"), DataContract(Namespace = "http://zarinpal.com/")]
	public class GetUnverifiedTransactionsRequestBody
	{
		
		public GetUnverifiedTransactionsRequestBody()
		{
		}

		
		public GetUnverifiedTransactionsRequestBody(string MerchantID)
		{
			this.MerchantID = MerchantID;
		}

		
		[DataMember(EmitDefaultValue = false, Order = 0)]
		public string MerchantID;
	}
}
