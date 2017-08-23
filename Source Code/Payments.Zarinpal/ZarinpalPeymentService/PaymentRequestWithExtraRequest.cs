using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace NopFarsi.Payments.Zarinpal.ZarinpalPeymentService
{
	
	[DebuggerStepThrough, GeneratedCode("System.ServiceModel", "4.0.0.0"), MessageContract(IsWrapped = false)]
	public class PaymentRequestWithExtraRequest
	{
		
		public PaymentRequestWithExtraRequest()
		{
		}

		
		public PaymentRequestWithExtraRequest(PaymentRequestWithExtraRequestBody Body)
		{
			this.Body = Body;
		}

		
		[MessageBodyMember(Name = "PaymentRequestWithExtra", Namespace = "http://zarinpal.com/", Order = 0)]
		public PaymentRequestWithExtraRequestBody Body;
	}
}
