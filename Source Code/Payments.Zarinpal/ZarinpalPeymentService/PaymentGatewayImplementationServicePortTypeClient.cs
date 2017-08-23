using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace NopFarsi.Payments.Zarinpal.ZarinpalPeymentService
{
	
	[DebuggerStepThrough, GeneratedCode("System.ServiceModel", "4.0.0.0")]
	public class PaymentGatewayImplementationServicePortTypeClient : ClientBase<PaymentGatewayImplementationServicePortType>, PaymentGatewayImplementationServicePortType
	{
		
		public PaymentGatewayImplementationServicePortTypeClient()
		{
		}

		
		public PaymentGatewayImplementationServicePortTypeClient(string endpointConfigurationName) : base(endpointConfigurationName)
		{
		}

		
		public PaymentGatewayImplementationServicePortTypeClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		
		public PaymentGatewayImplementationServicePortTypeClient(string endpointConfigurationName, EndpointAddress remoteAddress) : base(endpointConfigurationName, remoteAddress)
		{
		}

		
		public PaymentGatewayImplementationServicePortTypeClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
		{
		}

		
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		PaymentRequestResponse PaymentGatewayImplementationServicePortType.PaymentRequest(PaymentRequestRequest request)
		{
			return base.Channel.PaymentRequest(request);
		}

		
		public int PaymentRequest(string MerchantID, int Amount, string Description, string Email, string Mobile, string CallbackURL, out string Authority)
		{
            PaymentRequestResponse paymentRequestResponse = ((PaymentGatewayImplementationServicePortType)this).PaymentRequest(new PaymentRequestRequest
            {
                Body = new PaymentRequestRequestBody() 
                {
                    MerchantID = MerchantID,
                    Amount = Amount,
                    Description = Description,
                    Email = Email,
                    Mobile = Mobile,
                    CallbackURL = CallbackURL
                }
            });
			Authority = paymentRequestResponse.Body.Authority;
			return paymentRequestResponse.Body.Status;
		}

		
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		Task<PaymentRequestResponse> PaymentGatewayImplementationServicePortType.PaymentRequestAsync(PaymentRequestRequest request)
		{
			return base.Channel.PaymentRequestAsync(request);
		}

		
		public Task<PaymentRequestResponse> PaymentRequestAsync(string MerchantID, int Amount, string Description, string Email, string Mobile, string CallbackURL)
		{
			return ((PaymentGatewayImplementationServicePortType)this).PaymentRequestAsync(new PaymentRequestRequest
			{
				Body = new PaymentRequestRequestBody
				{
					MerchantID = MerchantID,
					Amount = Amount,
					Description = Description,
					Email = Email,
					Mobile = Mobile,
					CallbackURL = CallbackURL
				}
			});
		}

		
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		PaymentRequestWithExtraResponse PaymentGatewayImplementationServicePortType.PaymentRequestWithExtra(PaymentRequestWithExtraRequest request)
		{
			return base.Channel.PaymentRequestWithExtra(request);
		}

		
		public int PaymentRequestWithExtra(string MerchantID, int Amount, string Description, string AdditionalData, string Email, string Mobile, string CallbackURL, out string Authority)
		{
			PaymentRequestWithExtraResponse paymentRequestWithExtraResponse = ((PaymentGatewayImplementationServicePortType)this).PaymentRequestWithExtra(new PaymentRequestWithExtraRequest
			{
				Body = new PaymentRequestWithExtraRequestBody()
				{
					MerchantID = MerchantID,
					Amount = Amount,
					Description = Description,
					AdditionalData = AdditionalData,
					Email = Email,
					Mobile = Mobile,
					CallbackURL = CallbackURL
				}
			});
			Authority = paymentRequestWithExtraResponse.Body.Authority;
			return paymentRequestWithExtraResponse.Body.Status;
		}

		
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		Task<PaymentRequestWithExtraResponse> PaymentGatewayImplementationServicePortType.PaymentRequestWithExtraAsync(PaymentRequestWithExtraRequest request)
		{
			return base.Channel.PaymentRequestWithExtraAsync(request);
		}

		
		public Task<PaymentRequestWithExtraResponse> PaymentRequestWithExtraAsync(string MerchantID, int Amount, string Description, string AdditionalData, string Email, string Mobile, string CallbackURL)
		{
			return ((PaymentGatewayImplementationServicePortType)this).PaymentRequestWithExtraAsync(new PaymentRequestWithExtraRequest
			{
				Body = new PaymentRequestWithExtraRequestBody()
				{
					MerchantID = MerchantID,
					Amount = Amount,
					Description = Description,
					AdditionalData = AdditionalData,
					Email = Email,
					Mobile = Mobile,
					CallbackURL = CallbackURL
				}
			});
		}

		
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		PaymentVerificationResponse PaymentGatewayImplementationServicePortType.PaymentVerification(PaymentVerificationRequest request)
		{
			return base.Channel.PaymentVerification(request);
		}

		
		public int PaymentVerification(string MerchantID, string Authority, int Amount, out long RefID)
		{
			PaymentVerificationResponse paymentVerificationResponse = ((PaymentGatewayImplementationServicePortType)this).PaymentVerification(new PaymentVerificationRequest
			{
				Body = new PaymentVerificationRequestBody()
				{
					MerchantID = MerchantID,
					Authority = Authority,
					Amount = Amount
				}
			});
			RefID = paymentVerificationResponse.Body.RefID;
			return paymentVerificationResponse.Body.Status;
		}

		
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		Task<PaymentVerificationResponse> PaymentGatewayImplementationServicePortType.PaymentVerificationAsync(PaymentVerificationRequest request)
		{
			return base.Channel.PaymentVerificationAsync(request);
		}

		
		public Task<PaymentVerificationResponse> PaymentVerificationAsync(string MerchantID, string Authority, int Amount)
		{
			return ((PaymentGatewayImplementationServicePortType)this).PaymentVerificationAsync(new PaymentVerificationRequest
			{
				Body = new PaymentVerificationRequestBody()
				{
					MerchantID = MerchantID,
					Authority = Authority,
					Amount = Amount
				}
			});
		}

		
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		PaymentVerificationWithExtraResponse PaymentGatewayImplementationServicePortType.PaymentVerificationWithExtra(PaymentVerificationWithExtraRequest request)
		{
			return base.Channel.PaymentVerificationWithExtra(request);
		}

		
		public int PaymentVerificationWithExtra(string MerchantID, string Authority, int Amount, out long RefID, out string ExtraDetail)
		{
			PaymentVerificationWithExtraResponse paymentVerificationWithExtraResponse = ((PaymentGatewayImplementationServicePortType)this).PaymentVerificationWithExtra(new PaymentVerificationWithExtraRequest
			{
				Body = new PaymentVerificationWithExtraRequestBody()
				{
					MerchantID = MerchantID,
					Authority = Authority,
					Amount = Amount
				}
			});
			RefID = paymentVerificationWithExtraResponse.Body.RefID;
			ExtraDetail = paymentVerificationWithExtraResponse.Body.ExtraDetail;
			return paymentVerificationWithExtraResponse.Body.Status;
		}

		
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		Task<PaymentVerificationWithExtraResponse> PaymentGatewayImplementationServicePortType.PaymentVerificationWithExtraAsync(PaymentVerificationWithExtraRequest request)
		{
			return base.Channel.PaymentVerificationWithExtraAsync(request);
		}

		
		public Task<PaymentVerificationWithExtraResponse> PaymentVerificationWithExtraAsync(string MerchantID, string Authority, int Amount)
		{
			return ((PaymentGatewayImplementationServicePortType)this).PaymentVerificationWithExtraAsync(new PaymentVerificationWithExtraRequest
			{
				Body = new PaymentVerificationWithExtraRequestBody()
				{
					MerchantID = MerchantID,
					Authority = Authority,
					Amount = Amount
				}
			});
		}

		
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		GetUnverifiedTransactionsResponse PaymentGatewayImplementationServicePortType.GetUnverifiedTransactions(GetUnverifiedTransactionsRequest request)
		{
			return base.Channel.GetUnverifiedTransactions(request);
		}

		
		public int GetUnverifiedTransactions(string MerchantID, out string Authorities)
		{
			GetUnverifiedTransactionsResponse unverifiedTransactions = ((PaymentGatewayImplementationServicePortType)this).GetUnverifiedTransactions(new GetUnverifiedTransactionsRequest
			{
				Body = new GetUnverifiedTransactionsRequestBody()
				{
					MerchantID = MerchantID
				}
			});
			Authorities = unverifiedTransactions.Body.Authorities;
			return unverifiedTransactions.Body.Status;
		}

		
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		Task<GetUnverifiedTransactionsResponse> PaymentGatewayImplementationServicePortType.GetUnverifiedTransactionsAsync(GetUnverifiedTransactionsRequest request)
		{
			return base.Channel.GetUnverifiedTransactionsAsync(request);
		}

		
		public Task<GetUnverifiedTransactionsResponse> GetUnverifiedTransactionsAsync(string MerchantID)
		{
			return ((PaymentGatewayImplementationServicePortType)this).GetUnverifiedTransactionsAsync(new GetUnverifiedTransactionsRequest
			{
				Body = new GetUnverifiedTransactionsRequestBody()
				{
					MerchantID = MerchantID
				}
			});
		}

		
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		RefreshAuthorityResponse PaymentGatewayImplementationServicePortType.RefreshAuthority(RefreshAuthorityRequest request)
		{
			return base.Channel.RefreshAuthority(request);
		}

		
		public int RefreshAuthority(string MerchantID, string Authority, int ExpireIn)
		{
			return ((PaymentGatewayImplementationServicePortType)this).RefreshAuthority(new RefreshAuthorityRequest
			{
				Body = new RefreshAuthorityRequestBody()
				{
					MerchantID = MerchantID,
					Authority = Authority,
					ExpireIn = ExpireIn
				}
			}).Body.Status;
		}

		
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		Task<RefreshAuthorityResponse> PaymentGatewayImplementationServicePortType.RefreshAuthorityAsync(RefreshAuthorityRequest request)
		{
			return base.Channel.RefreshAuthorityAsync(request);
		}

		
		public Task<RefreshAuthorityResponse> RefreshAuthorityAsync(string MerchantID, string Authority, int ExpireIn)
		{
			return ((PaymentGatewayImplementationServicePortType)this).RefreshAuthorityAsync(new RefreshAuthorityRequest
			{
				Body = new RefreshAuthorityRequestBody()
				{
					MerchantID = MerchantID,
					Authority = Authority,
					ExpireIn = ExpireIn
				}
			});
		}
	}
}
