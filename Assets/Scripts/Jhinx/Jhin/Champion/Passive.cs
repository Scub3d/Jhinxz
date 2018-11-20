using Jhinx.Chompers;
// ReSharper disable All

namespace Jhinx.Jhin.Champion {
	public class Passive {
		public string Name { get; set; }
		public string Description { get; set; }
		public Image Image { get; set; }
		
		public Passive(string name, string description, Image image) {
			Name = name;
			Description = description;
			Image = image;
		}
	}
}