using System.Collections.Generic;
using SimpleJSON;

namespace Jhinx.Jinx.Article {
	public class Category {
		public string MachineName { get; set; }
		public string DisplayName { get; set; }
		
		public Category(string machineName, string displayName) {
			MachineName = machineName;
			DisplayName = displayName;
		}

		public static Category parseCategoryJSON(JSONNode json) {
			return  new Category(json["machineName"], json["displayName"]);
		}

		public static List<Category> parseCategoriesJSON(JSONArray json) {
			List<Category> categories = new List<Category>();
			foreach (JSONNode categoryJSON in json) {
				categories.Add(parseCategoryJSON(categoryJSON));
			}

			return categories;
		}
	}
}