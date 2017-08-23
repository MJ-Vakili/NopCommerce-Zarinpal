using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace NopFarsi.Payments.Zarinpal.ZarinpalPeymentService
{
	
	[DebuggerStepThrough, GeneratedCode("System.ServiceModel", "4.0.0.0"), DataContract(Namespace = "http://zarinpal.com/")]
	public class PaymentRequestRequestBody
	{
		
		public PaymentRequestRequestBody()
		{
		}

		
		public PaymentRequestRequestBody(string MerchantID, int Amount, string Description, string Email, string Mobile, string CallbackURL)
		{
			this.MerchantID = MerchantID;
			this.Amount = Amount;
			this.Description = Description;
			this.Email = Email;
			this.Mobile = Mobile;
			this.CallbackURL = CallbackURL;
		}

		
		[DataMember(EmitDefaultValue = false, Order = 0)]
		public string MerchantID;

		
		[DataMember(Order = 1)]
		public int Amount;

		
		[DataMember(EmitDefaultValue = false, Order = 2)]
		public string Description;

		
		[DataMember(Order = 3)]
		public string Email;

		
		[DataMember(Order = 4)]
		public string Mobile;

		
		[DataMember(EmitDefaultValue = false, Order = 5)]
		public string CallbackURL;
	}
}
