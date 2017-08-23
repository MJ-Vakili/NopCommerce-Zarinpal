using System;
using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace NopFarsi.Payments.Zarinpal.ZarinpalPeymentService
{
	
	[GeneratedCode("System.ServiceModel", "4.0.0.0"), ServiceContract(Namespace = "http://zarinpal.com/", ConfigurationName = "ZarinpalPeymentService.PaymentGatewayImplementationServicePortType")]
	public interface PaymentGatewayImplementationServicePortType
	{
		
		[OperationContract(Action = "#PaymentRequest", ReplyAction = "*")]
		PaymentRequestResponse PaymentRequest(PaymentRequestRequest request);

		
		[OperationContract(Action = "#PaymentRequest", ReplyAction = "*")]
		Task<PaymentRequestResponse> PaymentRequestAsync(PaymentRequestRequest request);

		
		[OperationContract(Action = "#PaymentRequestWithExtra", ReplyAction = "*")]
		PaymentRequestWithExtraResponse PaymentRequestWithExtra(PaymentRequestWithExtraRequest request);

		
		[OperationContract(Action = "#PaymentRequestWithExtra", ReplyAction = "*")]
		Task<PaymentRequestWithExtraResponse> PaymentRequestWithExtraAsync(PaymentRequestWithExtraRequest request);

		
		[OperationContract(Action = "#PaymentVerification", ReplyAction = "*")]
		PaymentVerificationResponse PaymentVerification(PaymentVerificationRequest request);

		
		[OperationContract(Action = "#PaymentVerification", ReplyAction = "*")]
		Task<PaymentVerificationResponse> PaymentVerificationAsync(PaymentVerificationRequest request);

		
		[OperationContract(Action = "#PaymentVerificationWithExtra", ReplyAction = "*")]
		PaymentVerificationWithExtraResponse PaymentVerificationWithExtra(PaymentVerificationWithExtraRequest request);

		
		[OperationContract(Action = "#PaymentVerificationWithExtra", ReplyAction = "*")]
		Task<PaymentVerificationWithExtraResponse> PaymentVerificationWithExtraAsync(PaymentVerificationWithExtraRequest request);

		
		[OperationContract(Action = "#GetUnverifiedTransactions", ReplyAction = "*")]
		GetUnverifiedTransactionsResponse GetUnverifiedTransactions(GetUnverifiedTransactionsRequest request);

		
		[OperationContract(Action = "#GetUnverifiedTransactions", ReplyAction = "*")]
		Task<GetUnverifiedTransactionsResponse> GetUnverifiedTransactionsAsync(GetUnverifiedTransactionsRequest request);

		
		[OperationContract(Action = "#RefreshAuthority", ReplyAction = "*")]
		RefreshAuthorityResponse RefreshAuthority(RefreshAuthorityRequest request);

		
		[OperationContract(Action = "#RefreshAuthority", ReplyAction = "*")]
		Task<RefreshAuthorityResponse> RefreshAuthorityAsync(RefreshAuthorityRequest request);
	}
}
