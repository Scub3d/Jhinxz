using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinx.Jinx.Tournament {
	public class Roles {
		public List<Role> Owner { get; set; }
		public List<Role> Creator { get; set; }
		
		public Roles(List<Role> owner,List<Role> creator) {
			Owner = owner;
			Creator = creator;

		}

		public static Roles parseRolesJSON(JSONNode json) {
			List<Role> owner = Role.parseRolesJSON(json["owner"].AsArray);
			List<Role> creator = Role.parseRolesJSON(json["creator"].AsArray);

			return new Roles(owner, creator);
		}
	}
}