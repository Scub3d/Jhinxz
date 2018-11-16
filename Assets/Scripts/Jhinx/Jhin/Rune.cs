using System.Collections.Generic;
using Jhinx.Chompers;
// ReSharper disable All

namespace Jhinx.Jhin {
	public class Rune {
		public int Id { get; set; }
		public string Name { get; set; }
		public Image Image { get; set; }
		public string Tier { get; set; }
		public string Type { get; set; }
		public Dictionary<string, float> Stats { get; set; }
		public List<string> Tags { get; set; }
		public string Colloq { get; set; } // Always null?
		public string Plaintext { get; set; } // Always null?
		
		public Rune(int id, string name, Image image, string tier, string type, Dictionary<string, float> stats, List<string> tags, string colloq, string plaintext) {
			Id = id;
			Name = name;
			Image = image;
			Tier = tier;
			Type = type;
			Stats = stats;
			Tags = tags;
			Colloq = colloq;
			Plaintext = plaintext;
		}
		
		// Todo
	}
}