using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace NopFarsi.Payments.Zarinpal.ZarinpalPeymentService
{
	
	[DebuggerStepThrough, GeneratedCode("System.ServiceModel", "4.0.0.0"), MessageContract(IsWrapped = false)]
	public class PaymentVerificationResponse
	{
		
		public PaymentVerificationResponse()
		{
		}

		
		public PaymentVerificationResponse(PaymentVerificationResponseBody Body)
		{
			this.Body = Body;
		}

		
		[MessageBodyMember(Name = "PaymentVerificationResponse", Namespace = "http://zarinpal.com/", Order = 0)]
		public PaymentVerificationResponseBody Body;
	}
}
