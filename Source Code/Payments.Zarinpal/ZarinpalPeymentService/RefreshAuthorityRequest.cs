using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace NopFarsi.Payments.Zarinpal.ZarinpalPeymentService
{
	
	[DebuggerStepThrough, GeneratedCode("System.ServiceModel", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Advanced), MessageContract(IsWrapped = false)]
	public class RefreshAuthorityRequest
	{
		
		public RefreshAuthorityRequest()
		{
		}

		
		public RefreshAuthorityRequest(RefreshAuthorityRequestBody Body)
		{
			this.Body = Body;
		}

		
		[MessageBodyMember(Name = "RefreshAuthority", Namespace = "http://zarinpal.com/", Order = 0)]
		public RefreshAuthorityRequestBody Body;
	}
}
