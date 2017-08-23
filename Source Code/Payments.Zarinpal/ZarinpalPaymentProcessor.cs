using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.Web;
using System.Web.Routing;
using Nop.Core;
using Nop.Core.Domain.Orders;
using Nop.Core.Plugins;
using Nop.Data;
using NopFarsi.Payments.Zarinpal.Controller;
using NopFarsi.Payments.Zarinpal.ZarinpalPeymentService;
using Nop.Services.Common;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Orders;
using Nop.Services.Payments;
using Nop.Services.Logging;

namespace NopFarsi.Payments.Zarinpal
{

    public class ZarinpalPaymentProcessor : BasePlugin, IPaymentMethod, IPlugin
    {

        public ZarinpalPaymentProcessor(HttpContextBase httpContext, ZarinpalSettings zarinpalPaymentSettings, ILocalizationService localizationService, ISettingService settingService, IWebHelper webHelper, IGenericAttributeService genericAttributeService, IOrderTotalCalculationService orderTotalCalculationService, IOrderService orderService, IOrderProcessingService orderProcessingService, ILogger logger)
        {
            this._httpContext = httpContext;
            this._zarinpalPaymentSettings = zarinpalPaymentSettings;
            this._localizationService = localizationService;
            this._settingService = settingService;
            this._webHelper = webHelper;
            this._genericAttributeService = genericAttributeService;
            this._orderTotalCalculationService = orderTotalCalculationService;
            this._orderService = orderService;
            this._orderProcessingService = orderProcessingService;
            this._logger = logger;
        }


        private string TranslateStatus(int statusCode)
        {
            string resource = this._localizationService.GetResource(string.Format("NopFarsi.Zarinpal.StatusCode.{0}", statusCode));
            if (!string.IsNullOrWhiteSpace(resource))
            {
                return resource;
            }
            return statusCode.ToString();
        }


        private BasicHttpBinding Binding
        {
            get
            {
                return new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            }
        }


        private EndpointAddress EndPoint
        {
            get
            {
                return new EndpointAddress(this._zarinpalPaymentSettings.WebServiceUrl);
            }
        }


        public ProcessPaymentResult ProcessPayment(ProcessPaymentRequest processPaymentRequest)
        {
            ProcessPaymentResult expr_05 = new ProcessPaymentResult();
            expr_05.NewPaymentStatus = (Nop.Core.Domain.Payments.PaymentStatus)10;
            return expr_05;
        }


        public void PostProcessPayment(PostProcessPaymentRequest postProcessPaymentRequest)
        {
            string text = string.Empty;
            ServicePointManager.Expect100Continue = false;
            PaymentGatewayImplementationServicePortTypeClient service = new PaymentGatewayImplementationServicePortTypeClient(this.Binding, this.EndPoint);
            string callbackURL = this._webHelper.GetStoreLocation(false) + "Plugins/ZarinpalNopFarsi/Verify";
            decimal value = Math.Round(postProcessPaymentRequest.Order.OrderTotal / 10m, 0);
            if (this._zarinpalPaymentSettings.IsToman)
            {
                value *= 10;
            }
            string text2;
            int num = service.PaymentRequest(this._zarinpalPaymentSettings.MerchantId, (int)value * 10, string.Format(this._localizationService.GetResource("NopFarsi.Zarinpal.Payment.Description"), postProcessPaymentRequest.Order.Id.ToString("#,#")), postProcessPaymentRequest.Order.BillingAddress.Email, postProcessPaymentRequest.Order.BillingAddress.PhoneNumber, callbackURL, out text2);
            if (num == 100)
            {
                this._genericAttributeService.SaveAttribute<string>(postProcessPaymentRequest.Order, "ZarinpalAuthority", text2, 0);
                text = string.Format(this._zarinpalPaymentSettings.PayementUrl, text2);
            }
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new Exception(string.Format(this._localizationService.GetResource("NopFarsi.Zarinpal.Payment.FailureMessage"), this.TranslateStatus(num)));
            }
            this._httpContext.Response.Redirect(text);
        }


        public bool HidePaymentMethod(IList<ShoppingCartItem> cart)
        {
            return !ShoppingCartExtensions.RequiresShipping(cart);
        }


        public decimal GetAdditionalHandlingFee(IList<ShoppingCartItem> cart)
        {
            return PaymentExtensions.CalculateAdditionalFee(this, this._orderTotalCalculationService, cart, 0, false);
        }


        public CapturePaymentResult Capture(CapturePaymentRequest capturePaymentRequest)
        {
            CapturePaymentResult capture = new CapturePaymentResult();
            capture.AddError("Capture method not supported.");
            return capture;
        }


        public RefundPaymentResult Refund(RefundPaymentRequest refundPaymentRequest)
        {
            RefundPaymentResult refund = new RefundPaymentResult();
            refund.AddError("Refund method not supported.");
            return refund;
        }


        public VoidPaymentResult Void(VoidPaymentRequest voidPaymentRequest)
        {
            VoidPaymentResult voidPay = new VoidPaymentResult();
            voidPay.AddError("Void method not supported.");
            return voidPay;
        }


        public ProcessPaymentResult ProcessRecurringPayment(ProcessPaymentRequest processPaymentRequest)
        {
            ProcessPaymentResult p = new ProcessPaymentResult();
            p.AddError("Recurring payment not supported.");
            return p;
        }


        public CancelRecurringPaymentResult CancelRecurringPayment(CancelRecurringPaymentRequest cancelPaymentRequest)
        {
            CancelRecurringPaymentResult c = new CancelRecurringPaymentResult();
            c.AddError("Recurring payment not supported.");
            return c;
        }


        public bool CanRePostProcessPayment(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException("order");
            }
            return (DateTime.UtcNow - order.CreatedOnUtc).TotalSeconds >= 5.0;
        }


        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "ZarinpalNopFarsi";
            routeValues = new RouteValueDictionary
			{
				{
					"Namespaces",
					"NopFarsi.Payments.Zarinpal.Controllers"
				},
				{
					"area",
					null
				}
			};
        }


        public void GetPaymentInfoRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "PaymentInfo";
            controllerName = "ZarinpalNopFarsi";
            routeValues = new RouteValueDictionary
			{
				{
					"Namespaces",
					"NopFarsi.Payments.Zarinpal.Controllers"
				},
				{
					"area",
					null
				}
			};
        }


        public Type GetControllerType()
        {
            return typeof(ZarinpalNopFarsiController);
        }


        public override void Install()
        {
            ZarinpalSettings zarinpalPaymentSettings = new ZarinpalSettings
            {
                MerchantId = "",
                PayementUrl = "https://www.zarinpal.com/pg/StartPay/{0}",
                WebServiceUrl = "https://www.zarinpal.com/pg/services/WebGate/service",
                IsToman = false
            };
            this._settingService.SaveSetting<ZarinpalSettings>(zarinpalPaymentSettings, 0);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.Fields.RedirectionTip", " به درگاه زرین‌پال متصل خواهید شد.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.Fields.MerchantId", "کد درگاه پرداخت", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.Fields.MerchantId.Hint", "كدي يكتا و 36 كاراكتري است كه زرین‌پال به ازاي هر درخواست درگاه پرداخت به پذيرنده اختصاص می‌دهد.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.Fields.PayementUrl", "آدرس درگاه پرداخت", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.Fields.PayementUrl.Hint", "آدرس اینترنتی‌ای که مشتری برای پرداخت مبلغ فاکتور به آن هدایت می‌شود.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.Fields.WebServiceUrl", "آدرس وب سرویس", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.Fields.WebServiceUrl.Hint", "آدرس وب سرویس زرین‌پال برای ازتباط با درگاه پرداخت.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.Fields.IsToman", "محاسبه بر اساس تومان", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.PaymentMethodDescription", "پرداخت توسط درگاه زرین‌پال", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.Verify.SuccessMessage", "صورتحساب با موفقیت پرداخت گردید.\r\nکد پیگیری : {0}", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.Verify.FailureMessage", "پردخت  ناموفق بود.\r\nشرح خطا : {0}", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.Payment.Description", "بابت خرید فاکتور شماه {0}", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.Payment.FailureMessage", "برقراری ارتباط با سرور زرین‌پال امکان پذیر نمی‌باشد.\r\nشرح خطا : {0}", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-1", "اطلاعات ارسالی ناقص است.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-2", "آی‌پی و یا مرچنت کد،  صحیح نیست.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-3", "با توجه به محدودیت‌های شاپرک امکان پرداخت با رقم درخواست شده میسر نمی‌باشد.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-4", "سطح تایید پذیرنده پایین‌تر از سطح نقره‌ای است.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-11", "درخواست مورد نظر یافت نشد.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-12", "امکان ویرایش درخواست میسر نمی‌باشد.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-21", "هیچ نوع عملیات مالی برای این تراکنش یافت نشد.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-22", "تراکنش ناموفق می‌باشد.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-33", "رقم تراکنش با رقم پرداخت شده مطابقت ندارد.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-34", "سقف تقسیم تراکنش از لحاظ تعداد یا رقم، عبور نموده است.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-40", "اجازه دسترسی به متد مربوطه وجود ندارد.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-41", "اطلاعات ارسال شده مربوط به AdditionalData غیرمعتبر می‌باشد.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-42", "مدت زمان معتبر طول عمر شناسه پرداخت باید بین  30 دقیه تا  45 روز می‌باشد.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-54", "درخواست مورد نظر آرشیو شده است.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.100", "عملیات با موفقیت انجام گردیده است.", null);
            LocalizationExtensions.AddOrUpdatePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.101", "عملیات پرداخت موفق بوده و قبلاً PaymentVerification تراکنش انجام شده است.", null);
            base.Install();
        }


        public override void Uninstall()
        {
            this._settingService.DeleteSetting<ZarinpalSettings>();
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.Fields.RedirectionTip");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.Fields.MerchantId");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.Fields.MerchantId.Hint");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.Fields.PayementUrl");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.Fields.PayementUrl.Hint");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.PaymentMethodDescription");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.Payment.Description");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.Verify.SuccessMessage");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.Payment.FailureMessage");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-1");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-2");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-3");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-4");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-11");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-12");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-21");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-22");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-33");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-34");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-40");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-41");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-42");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.-54");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.100");
            LocalizationExtensions.DeletePluginLocaleResource(this, "NopFarsi.Zarinpal.StatusCode.101");
            base.Uninstall();
        }


        public bool SupportCapture
        {
            get
            {
                return false;
            }
        }


        public bool SupportPartiallyRefund
        {
            get
            {
                return false;
            }
        }


        public bool SupportRefund
        {
            get
            {
                return false;
            }
        }


        public bool SupportVoid
        {
            get
            {
                return false;
            }
        }


        public RecurringPaymentType RecurringPaymentType
        {
            get
            {
                return 0;
            }
        }


        public PaymentMethodType PaymentMethodType
        {
            get
            {
                return (PaymentMethodType)15;
            }
        }


        public bool SkipPaymentInfo
        {
            get
            {
                return false;
            }
        }


        public string PaymentMethodDescription
        {
            get
            {
                return this._localizationService.GetResource("NopFarsi.Zarinpal.PaymentMethodDescription");
            }
        }


        private const string GenericAttributeAuthority = "ZarinpalAuthority";

        private readonly ILogger _logger;

        private readonly HttpContextBase _httpContext;


        private readonly ZarinpalSettings _zarinpalPaymentSettings;


        private readonly ILocalizationService _localizationService;


        private readonly ISettingService _settingService;


        private readonly IWebHelper _webHelper;


        private readonly IGenericAttributeService _genericAttributeService;


        private readonly IOrderTotalCalculationService _orderTotalCalculationService;


        private readonly IOrderService _orderService;


        private readonly IOrderProcessingService _orderProcessingService;
    }
}
