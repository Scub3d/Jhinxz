using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Jinx.Article {
	// Fix all arrays that turn into dicts
	public class Article {
		public string Nid { get; set; }
		public string Uuid { get; set; }
		public string Tuuid { get; set; }
		public string Type { get; set; }
		public string Title { get; set; }
		public string Published { get; set; }
		public string Created { get; set; }
		public string Changed { get; set; }
		public int Status { get; set; }
		public string Region { get; set; }
		public string Locale { get; set; }
		public string Language { get; set; }
		public string ShortTitle { get; set; }
		public List<string> Tags { get; set; } // empty
		public Path Path { get; set; }
		public string ShowIn { get; set; } // null
		public Category Category { get; set; }
		public List<string> ExternalScripts { get; set; } // null
		public string CustomTemplate { get; set; }
		public List<string> Backdrop { get; set; } // null
		public List<string> Leagues { get; set; }
		public string Author { get; set; }
		public string BodySmall { get; set; } // null
		public string BodyMedium { get; set; } // null
		public string BodyFull { get; set; }
		public Media Media { get; set; }
		public string Redirect { get; set; } // null
		public List<string> Comments { get; set; } // Empty. Except where it became a dictionary
		
		public Article(string nid, string uuid, string tuuid, string type, string title, string published, string created, string changed, int status, string region, string locale, string language, string shortTitle, List<string> tags, Path path, string showIn, Category category, List<string> externalScripts, string customTemplate, List<string> backdrop, List<string> leagues, string author, string bodySmall, string bodyMedium, string bodyFull, Media media, string redirect, List<string> comments) {
			Nid = nid;
			Uuid = uuid;
			Tuuid = tuuid;
			Type = type;
			Title = title;
			Published = published;
			Created = created;
			Changed = changed;
			Status = status;
			Region = region;
			Locale = locale;
			Language = language;
			ShortTitle = shortTitle;
			Tags = tags;
			Path = path;
			ShowIn = showIn;
			Category = category;
			ExternalScripts = externalScripts;
			CustomTemplate = customTemplate;
			Backdrop = backdrop;
			Leagues = leagues;
			Author = author;
			BodySmall = bodySmall;
			BodyMedium = bodyMedium;
			BodyFull = bodyFull;
			Media = media;
			Redirect = redirect;
			Comments = comments;
		}
		
		// https://api.lolesports.com/api/v1/articles
		// https://api.lolesports.com/api/v1/articles?language=en
		// https://api.lolesports.com/api/v1/articles?from=100
		// http://api.lolesports.com/api/v1/marquees

	}
}