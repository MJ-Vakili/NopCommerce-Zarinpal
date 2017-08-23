using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace NopFarsi.Payments.Zarinpal.ZarinpalPeymentService
{
	
	[DebuggerStepThrough, GeneratedCode("System.ServiceModel", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Advanced), MessageContract(IsWrapped = false)]
	public class RefreshAuthorityResponse
	{
		
		public RefreshAuthorityResponse()
		{
		}

		
		public RefreshAuthorityResponse(RefreshAuthorityResponseBody Body)
		{
			this.Body = Body;
		}

		
		[MessageBodyMember(Name = "RefreshAuthorityResponse", Namespace = "http://zarinpal.com/", Order = 0)]
		public RefreshAuthorityResponseBody Body;
	}
}
