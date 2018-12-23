// ReSharper disable All

using SimpleJSON;

namespace Jhinxz.Jinx.Player {
	public class PhotoInformation {
		public int Width { get; set; }
		public int Height { get; set; }
		public int Type { get; set; }
		public string URL { get; set; }
		public int Transferred { get; set; }
		public int Size { get; set; }
		public float Time { get; set; }

		public PhotoInformation(int width, int height, int type, string url, int transferred, int size, float time) {
			Width = width;
			Height = height;
			Type = type;
			URL = url;
			Transferred = transferred;
			Size = size;
			Time = time;
		}

		public static PhotoInformation parsePhotoInformationJSON(JSONNode json) {
			return new PhotoInformation(json["width"], json["height"], json["type"], json["url"], 
				json["transferred"], json["size"], json["time"]);
		}
	}
}