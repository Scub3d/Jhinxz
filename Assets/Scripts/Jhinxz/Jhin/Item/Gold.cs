// ReSharper disable All

using SimpleJSON;

namespace Jhinxz.Jhin.Item {
	public class Gold {
		public int Base { get; set; }
		public bool Purchasable { get; set; }
		public int Total { get; set; }
		public int Sell { get; set; }
		
		public Gold(int @base, bool purchasable, int total, int sell) {
			Base = @base;
			Purchasable = purchasable;
			Total = total;
			Sell = sell;
		}

		public static Gold parseGoldJSON(JSONNode json) {
			return new Gold(json["base"], json["purchasable"], json["total"], json["sell"]);
		}
	}
}