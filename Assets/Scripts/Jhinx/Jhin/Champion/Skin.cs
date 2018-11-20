// ReSharper disable All
namespace Jhinx.Jhin.Champion {
	public class Skin {
		public string Id { get; set; }
		public int Num { get; set; }
		public string Name { get; set; }
		public bool Chromas { get; set; }
		
		public Skin(string id, int num, string name, bool chromas) {
			Id = id;
			Num = num;
			Name = name;
			Chromas = chromas;
		}
	}
}