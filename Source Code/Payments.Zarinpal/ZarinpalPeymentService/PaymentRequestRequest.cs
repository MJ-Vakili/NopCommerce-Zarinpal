using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace NopFarsi.Payments.Zarinpal.ZarinpalPeymentService
{
	
	[DebuggerStepThrough, GeneratedCode("System.ServiceModel", "4.0.0.0"), MessageContract(IsWrapped = false)]
	public class PaymentRequestRequest
	{
		
		public PaymentRequestRequest()
		{
		}

		
		public PaymentRequestRequest(PaymentRequestRequestBody Body)
		{
			this.Body = Body;
		}

		
		[MessageBodyMember(Name = "PaymentRequest", Namespace = "http://zarinpal.com/", Order = 0)]
		public PaymentRequestRequestBody Body;
	}
}
