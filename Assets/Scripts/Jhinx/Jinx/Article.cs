using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Jinx {
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
		public ArticlePath Path { get; set; }
		public string ShowIn { get; set; } // null
		public ArticleCategory Category { get; set; }
		public List<string> ExternalScripts { get; set; } // null
		public string CustomTemplate { get; set; }
		public List<string> Backdrop { get; set; } // null
		public List<string> Leagues { get; set; }
		public string Author { get; set; }
		public string BodySmall { get; set; } // null
		public string BodyMedium { get; set; } // null
		public string BodyFull { get; set; }
		public ArticleMedia Media { get; set; }
		public string Redirect { get; set; } // null
		public List<string> Comments { get; set; } // Empty. Except where it became a dictionary
		
		public Article(string nid, string uuid, string tuuid, string type, string title, string published, string created, string changed, int status, string region, string locale, string language, string shortTitle, List<string> tags, ArticlePath path, string showIn, ArticleCategory category, List<string> externalScripts, string customTemplate, List<string> backdrop, List<string> leagues, string author, string bodySmall, string bodyMedium, string bodyFull, ArticleMedia media, string redirect, List<string> comments) {
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

	public struct ArticlePath {
		public string Canonical { get; set; }
		public List<string> Alternate { get; set; }
		
		public ArticlePath(string canonical, List<string> alternate) {
			Canonical = canonical;
			Alternate = alternate;
		}
	}

	public struct ArticleCategory {
		public ArticleCategoryCategory Category { get; set; }
		
		public ArticleCategory(ArticleCategoryCategory category) {
			Category = category;
		}
	}
	
	public struct ArticleCategoryCategory {
		public string MachineName { get; set; }
		public string DisplayName { get; set; }
		
		public ArticleCategoryCategory(string machineName, string displayName) {
			MachineName = machineName;
			DisplayName = displayName;
		}
	}
	
	public struct ArticleMedia {
		public List<string> Video { get; set; }
		public ArticleMediaImage Image { get; set; }
		public List<string> Marquee { get; set; }
		
		public ArticleMedia(List<string> video, ArticleMediaImage image, List<string> marquee) {
			Video = video;
			Image = image;
			Marquee = marquee;
		}
	}

	public struct ArticleMediaImage {
		public string Type { get; set; }
		public string Original { get; set; }
		public ArticleMediaImageVariants Variants { get; set; }
		
		public ArticleMediaImage(string type, string original, ArticleMediaImageVariants variants) {
			Type = type;
			Original = original;
			Variants = variants;
		}
	}

	public struct ArticleMediaImageVariants {
		public string ArticleThumbnail { get; set; }
		public string ArticleImage { get; set; }
		public string Marquee { get; set; }
		public string Hero { get; set; }
		
		public ArticleMediaImageVariants(string articleThumbnail, string articleImage, string marquee, string hero) {
			ArticleThumbnail = articleThumbnail;
			ArticleImage = articleImage;
			Marquee = marquee;
			Hero = hero;
		}
	}
}