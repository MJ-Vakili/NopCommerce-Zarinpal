using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Nop.Core;
using Nop.Core.Domain.Payments;
using NopFarsi.Payments.Zarinpal.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Payments;
using Nop.Services.Stores;
using Nop.Web.Framework.Controllers;

namespace NopFarsi.Payments.Zarinpal.Controller
{
	
	public class ZarinpalNopFarsiController : BasePaymentController
	{
		
		public ZarinpalNopFarsiController(IWorkContext workContext, IStoreService storeService, ISettingService settingService, ILocalizationService localizationService, IPaymentService paymentService, PaymentSettings paymentSettings)
		{
			this._workContext = workContext;
			this._storeService = storeService;
			this._settingService = settingService;
			this._localizationService = localizationService;
			this._paymentService = paymentService;
			this._paymentSettings = paymentSettings;
		}

		
		[ChildActionOnly]
		public ActionResult PaymentInfo()
		{
            return base.View("~/Plugins/NopFarsi.Payments.Zarinpal/Views/PaymentInformation.cshtml");
		}

		
		public override IList<string> ValidatePaymentForm(FormCollection form)
		{
			return new List<string>();
		}
	
		public override ProcessPaymentRequest GetPaymentInfo(FormCollection form)
		{
			return new ProcessPaymentRequest();
		}

		
		[AdminAuthorize, ChildActionOnly]
		public ActionResult Configure()
		{
			int activeStoreScopeConfiguration = this.GetActiveStoreScopeConfiguration(this._storeService, this._workContext);
			ZarinpalSettings zarinpalPaymentSettings = this._settingService.LoadSetting<ZarinpalSettings>(activeStoreScopeConfiguration);
			ConfigurationModel configurationModel = new ConfigurationModel
			{
				
				MerchantId = zarinpalPaymentSettings.MerchantId,
				PayementUrl = zarinpalPaymentSettings.PayementUrl,
				WebServiceUrl = zarinpalPaymentSettings.WebServiceUrl,
                IsTomanForStore = zarinpalPaymentSettings.IsToman,
				ActiveStoreScopeConfiguration = activeStoreScopeConfiguration,
                
			};
			if (activeStoreScopeConfiguration > 0)
			{
				configurationModel.MerchantIdOverrideForStore = this._settingService.SettingExists<ZarinpalSettings, string>(zarinpalPaymentSettings, (ZarinpalSettings x) => x.MerchantId, activeStoreScopeConfiguration);
				configurationModel.PayementUrlOverrideForStore = this._settingService.SettingExists<ZarinpalSettings, string>(zarinpalPaymentSettings, (ZarinpalSettings x) => x.PayementUrl, activeStoreScopeConfiguration);
				configurationModel.WebServiceUrlOverrideForStore = this._settingService.SettingExists<ZarinpalSettings, string>(zarinpalPaymentSettings, (ZarinpalSettings x) => x.WebServiceUrl, activeStoreScopeConfiguration);
                configurationModel.IsTomanForStore = this._settingService.SettingExists<ZarinpalSettings, bool>(zarinpalPaymentSettings, (ZarinpalSettings x) => x.IsToman, activeStoreScopeConfiguration);
			}
            return base.View("~/Plugins/NopFarsi.Payments.Zarinpal/Views/Configure.cshtml", configurationModel);
		}

		
		[HttpPost, AdminAuthorize, ChildActionOnly]
		public ActionResult Configure(ConfigurationModel model)
		{
			if (!base.ModelState.IsValid)
			{
				return this.Configure();
			}
			int activeStoreScopeConfiguration = this.GetActiveStoreScopeConfiguration(this._storeService, this._workContext);
			ZarinpalSettings zarinpalPaymentSettings = this._settingService.LoadSetting<ZarinpalSettings>(activeStoreScopeConfiguration);
						
			
			zarinpalPaymentSettings.MerchantId = model.MerchantId;
			zarinpalPaymentSettings.PayementUrl = model.PayementUrl;
			zarinpalPaymentSettings.WebServiceUrl = model.WebServiceUrl;
            zarinpalPaymentSettings.IsToman = model.IsTomanForStore;
			
			this._settingService.SaveSettingOverridablePerStore<ZarinpalSettings, string>(zarinpalPaymentSettings, (ZarinpalSettings x) => x.MerchantId, model.MerchantIdOverrideForStore, activeStoreScopeConfiguration, false);
			this._settingService.SaveSettingOverridablePerStore<ZarinpalSettings, string>(zarinpalPaymentSettings, (ZarinpalSettings x) => x.PayementUrl, model.PayementUrlOverrideForStore, activeStoreScopeConfiguration, false);
			this._settingService.SaveSettingOverridablePerStore<ZarinpalSettings, string>(zarinpalPaymentSettings, (ZarinpalSettings x) => x.WebServiceUrl, model.WebServiceUrlOverrideForStore, activeStoreScopeConfiguration, false);
            this._settingService.SaveSettingOverridablePerStore<ZarinpalSettings, bool>(zarinpalPaymentSettings, (ZarinpalSettings x) => x.IsToman, model.IsTomanForStore, activeStoreScopeConfiguration, false);
			this._settingService.ClearCache();
			this.SuccessNotification(this._localizationService.GetResource("Admin.Plugins.Saved"), true);
			return this.Configure();
		}

		
		private readonly IWorkContext _workContext;

		
		private readonly IStoreService _storeService;

		
		private readonly ISettingService _settingService;

		
		private readonly ILocalizationService _localizationService;

		
		private readonly IPaymentService _paymentService;

		
		private readonly PaymentSettings _paymentSettings;
	}
}
