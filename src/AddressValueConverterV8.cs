using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Umbraco.Core;
using Umbraco.Core.PropertyEditors;
using Umbraco.Core.Models.PublishedContent;

namespace Vokseverk {
	public class AddressEditorPropertyConverter : PropertyValueConverterBase {
		
		public override Type GetPropertyValueType(IPublishedPropertyType propertyType) {
			return typeof(AddressData);
		}
		
		public override PropertyCacheLevel GetPropertyCacheLevel(IPublishedPropertyType propertyType) {
			return PropertyCacheLevel.Element;
		}
		
		public override bool IsConverter(IPublishedPropertyType propertyType) {
			return propertyType.EditorAlias.Equals("Vokseverk.AddressEditor");
		}
		
		public override object ConvertSourceToIntermediate(IPublishedElement owner, IPublishedPropertyType propertyType, object source, bool preview) {
			if (source == null) {
				return source;
			}
			
			var address = new AddressData();
			
			var ssource = source.ToString();
			if (ssource.DetectIsJson()) {
				try {
					address = JsonConvert.DeserializeObject<AddressData>(ssource);
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
