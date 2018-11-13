using System.Collections.Generic;

namespace APIv2 {
	public class RuneReforged {
		private int id;
		private string iconURL, name;
		private List<RunesReforgedRune> slots;
	}

	public struct RunesReforgedRune {
		private int id, slotRow;
		private string name, longDesc, shortDesc, iconURL;
	}
}