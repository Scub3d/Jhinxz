// ReSharper disable All
namespace Jhinx.Jhin.Champion {
	public class Item {
		public string Id { get; set; }
		public int Count { get; set; }
		public bool HideCount { get; set; }
		
		public Item(string id, int count, bool hideCount) {
			Id = id;
			Count = count;
			HideCount = hideCount;
		}
	}
}