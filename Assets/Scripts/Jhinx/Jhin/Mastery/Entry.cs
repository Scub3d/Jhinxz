// ReSharper disable All
namespace Jhinx.Jhin.Mastery {
	public class Entry {
		public string MasteryId { get; set; }
		public string Prereq { get; set; }
		
		public Entry(string masteryId, string prereq) {
			MasteryId = masteryId;
			Prereq = prereq;
		}
	}
}