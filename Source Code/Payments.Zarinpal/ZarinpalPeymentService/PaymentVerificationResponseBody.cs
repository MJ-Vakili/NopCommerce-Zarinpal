using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace NopFarsi.Payments.Zarinpal.ZarinpalPeymentService
{
	
	[DebuggerStepThrough, GeneratedCode("System.ServiceModel", "4.0.0.0"), DataContract(Namespace = "http://zarinpal.com/")]
	public class PaymentVerificationResponseBody
	{
		
		public PaymentVerificationResponseBody()
		{
		}

		
		public PaymentVerificationResponseBody(int Status, long RefID)
		{
			this.Status = Status;
			this.RefID = RefID;
		}

		
		[DataMember(Order = 0)]
		public int Status;

		
		[DataMember(Order = 1)]
		public long RefID;
	}
}
