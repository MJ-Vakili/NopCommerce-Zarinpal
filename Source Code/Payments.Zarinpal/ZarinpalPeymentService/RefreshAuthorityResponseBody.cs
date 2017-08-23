using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace NopFarsi.Payments.Zarinpal.ZarinpalPeymentService
{
	
	[DebuggerStepThrough, GeneratedCode("System.ServiceModel", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Advanced), DataContract(Namespace = "http://zarinpal.com/")]
	public class RefreshAuthorityResponseBody
	{
		
		public RefreshAuthorityResponseBody()
		{
		}

		
		public RefreshAuthorityResponseBody(int Status)
		{
			this.Status = Status;
		}

		
		[DataMember(Order = 0)]
		public int Status;
	}
}
