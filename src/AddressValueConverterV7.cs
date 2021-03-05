using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Umbraco.Core;
using Umbraco.Core.PropertyEditors;
using Umbraco.Core.Models.PublishedContent;

namespace Vokseverk {
	[PropertyValueType(typeof(AddressData))]
	[PropertyValueCache(PropertyCacheValue.All, PropertyCacheLevel.Content)]
	public class AddressEditorPropertyConverter : PropertyValueConverterBase {
		
		public override bool IsConverter(PublishedPropertyType propertyType) {
			return propertyType.PropertyEditorAlias.Equals("Vokseverk.AddressEditor");
		}
		
		public override object ConvertDataToSource(PublishedPropertyType propertyType, object data, bool preview) {
			if (data == null) {
				return data;
			}
			
			var address = new AddressData();
			
			var source = data.ToString();
			if (source.DetectIsJson()) {
				try {
					address = JsonConvert.DeserializeObject<AddressData>(source);
				}
				catch { /* Hmm, not JSON after all ... */ }
			}
			
			return address;
		}
		
		public class AddressData {
			public string Name { get; set; }
			public string Address { get; set; }
			public string Address2 { get; set; }
			public string Zipcode { get; set; }
			public string City { get; set; }
			public string Country { get; set; }
		}
	}
}
