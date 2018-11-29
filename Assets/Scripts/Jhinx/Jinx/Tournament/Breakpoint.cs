using System.Collections.Generic;
using SimpleJSON;

// ReSharper disable All

namespace Jhinx.Jinx.Tournament {	
	public class Breakpoint {
		public string Id { get; set; }
		public string Name { get; set; }
		public int Position { get; set; }
		public List<Input> Input { get; set; }
		public Standings Standingses { get; set; }
		public string Scores { get; set; } // null?
		public Roles Roles { get; set; }
		public Generator Generator { get; set; }
		
		public Breakpoint(string id, string name, int position, List<Input> input, Standings standingses, string scores, Roles roles, Generator generator) {
			Id = id;
			Name = name;
			Position = position;
			Input = input;
			Standingses = standingses;
			Scores = scores;
			Roles = roles;
			Generator = generator;
		}

		public static Breakpoint parseBreakpointJSON(JSONNode json) {
			List<Input> input = Jinx.Tournament.Input.parseInputsArrayJSON(json["input"].AsArray);
			Standings standings = Standings.parseStandingsJSON(json["standings"]);
			Roles roles = Jinx.Tournament.Roles.parseRolesJSON(json["roles"]); 
			Generator generator = Generator.parseGeneratorJSON(json["generator"]);
			return new Breakpoint(json["id"], json["name"], json["position"], input, standings, null, roles, generator);
		}

		public static List<Breakpoint> parseBreakpointsJSON(JSONArray json) {
			List<Breakpoint> breakpoints = new List<Breakpoint>();
			foreach (JSONNode breakpointJSON in json) {
				breakpoints.Add(parseBreakpointJSON(breakpointJSON));	
			}
			
			return breakpoints;
		}
	}
}