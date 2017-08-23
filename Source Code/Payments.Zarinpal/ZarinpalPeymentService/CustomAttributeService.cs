using System;
using System.Linq;
using Nop.Core.Data;
using Nop.Core.Domain.Common;
using Nop.Core.Infrastructure;

namespace NopFarsi.Payments.Zarinpal
{
	
	public class CustomAttributeService
	{
		
		public int? GetEntityIdForKeyValue(string keyGroup, string key, string value)
		{
			GenericAttribute expr_14B = (from ga in EngineContext.Current.Resolve<IRepository<GenericAttribute>>().Table
			where ga.KeyGroup == keyGroup && ga.Key == key && ga.Value == value
			orderby ga.Id descending
			select ga).FirstOrDefault<GenericAttribute>();
			if (expr_14B == null)
			{
				return null;
			}
			return new int?(expr_14B.EntityId);
		}
	}
}
