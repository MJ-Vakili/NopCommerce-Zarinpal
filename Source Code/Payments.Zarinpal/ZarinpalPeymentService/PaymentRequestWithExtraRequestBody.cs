using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace NopFarsi.Payments.Zarinpal.ZarinpalPeymentService
{
	
	[DebuggerStepThrough, GeneratedCode("System.ServiceModel", "4.0.0.0"), DataContract(Namespace = "http://zarinpal.com/")]
	public class PaymentRequestWithExtraRequestBody
	{
		
		public PaymentRequestWithExtraRequestBody()
		{
		}

		
		public PaymentRequestWithExtraRequestBody(string MerchantID, int Amount, string Description, string AdditionalData, string Email, string Mobile, string CallbackURL)
		{
			this.MerchantID = MerchantID;
			this.Amount = Amount;
			this.Description = Description;
			this.AdditionalData = AdditionalData;
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

		
		[DataMember(EmitDefaultValue = false, Order = 3)]
		public string AdditionalData;

		
		[DataMember(Order = 4)]
		public string Email;

		
		[DataMember(Order = 5)]
		public string Mobile;

		
		[DataMember(EmitDefaultValue = false, Order = 6)]
		public string CallbackURL;
	}
}
