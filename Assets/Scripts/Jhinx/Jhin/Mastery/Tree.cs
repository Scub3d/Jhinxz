using System.Collections.Generic;
using SimpleJSON;
// ReSharper disable All

namespace Jhinx.Jhin.Mastery {
	public class Tree {
		public List<Branch> Branches;
		
		public Tree(List<Branch> branches) {
			Branches = branches;
		}
		
		public static Tree parseTreeJSON(JSONNode treeJSON) {
			List<Branch> branches = new List<Branch>();
			foreach (string branchKey in treeJSON.Keys) {
				List<List<Entry>> entries = new List<List<Entry>>();
				foreach (JSONArray row in treeJSON[branchKey]) {
					List<Entry> row_entries = new List<Entry>();
					foreach (JSONNode entry in row) {
						row_entries.Add(new Entry(entry["masteryID"], entry["prereq"]));
					}
					entries.Add(row_entries);
				}
				branches.Add(new Branch(branchKey, entries));
			}
			return new Tree(branches);
		}
	}
}