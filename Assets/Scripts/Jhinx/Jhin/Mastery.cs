using System.Collections;
using System.Collections.Generic;
using Jhinx.Chompers;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

// ReSharper disable All

namespace Jhinx.Jhin {

	public struct _Masteries {
		public List<Mastery> Masteries { get; set; }
		public MasteryTree Tree { get; set; }
		
		public _Masteries(List<Mastery> masteries, MasteryTree tree) {
			Masteries = masteries;
			Tree = tree;
		}
	}
	
	public class Mastery {
		public string Id { get; set; }
		public string Name { get; set; }
		public List<string> Description { get; set; }
		public Image Image { get; set; }
		public int Ranks { get; set; }
		public string Prereq { get; set; }
	
		public Mastery(string id, string name, List<string> description, Image image, int ranks, string prereq) {
			Id = id;
			Name = name;
			Description = description;
			Image = image;
			Ranks = ranks;
			Prereq = prereq;
		}

		private static Mastery parseMasteryJSON(JSONNode masteryJSON) {
			List<string> descriptions = new List<string>();
			foreach (JSONString description in masteryJSON["description"]) {
					descriptions.Add(description);
			}
			Image image = new Image(Chompers.Image.ParseImageJson(masteryJSON["image"]));
			return new Mastery(masteryJSON["id"], masteryJSON["name"], descriptions, image, masteryJSON["ranks"], masteryJSON["prereq"]);
		}
		
		private static MasteryTree parseMasteryTreeJSON(JSONNode treeJSON) {
			List<MasteryTreeBranch> branches = new List<MasteryTreeBranch>();
			foreach (string branchKey in treeJSON.Keys) {
				List<List<MasteryTreeBranchRowEntry>> entries = new List<List<MasteryTreeBranchRowEntry>>();
				foreach (JSONArray row in treeJSON[branchKey]) {
					List<MasteryTreeBranchRowEntry> row_entries = new List<MasteryTreeBranchRowEntry>();
					foreach (JSONNode entry in row) {
						row_entries.Add(new MasteryTreeBranchRowEntry(entry["masteryID"], entry["prereq"]));
					}
					entries.Add(row_entries);
				}
				branches.Add(new MasteryTreeBranch(branchKey, entries));
			}
			return new MasteryTree();
		}

		public static IEnumerator getMasteries(string patchNumber, string languageCode) {
			using (UnityWebRequest www = UnityWebRequest.Get("https://ddragon.leagueoflegends.com/cdn/" + patchNumber + "/data/" + languageCode + "/mastery.json")) {
				yield return www.Send();
				if (www.isNetworkError || www.isHttpError) {
					Debug.Log(www.error);
					yield return null;
				} else {
					JSONNode masteriesJSON = JSON.Parse(www.downloadHandler.text);

					MasteryTree tree = parseMasteryTreeJSON(masteriesJSON["tree"]);
					
					List<Mastery> masteries = new List<Mastery>();
					foreach (JSONNode masteryJSON in masteriesJSON["data"]) {
						masteries.Add(parseMasteryJSON(masteryJSON));
					}				
					
					yield return new _Masteries(masteries, tree);                       
				}
			}
		}
	}
	
	public struct MasteryTree {
		public List<MasteryTreeBranch> Branches;
		
		public MasteryTree(List<MasteryTreeBranch> branches) {
			Branches = branches;
		}
	}

	public struct MasteryTreeBranch {
		public string Name { get; set; }
		public List<List<MasteryTreeBranchRowEntry>> Entries { get; set; }
		
		public MasteryTreeBranch(string name, List<List<MasteryTreeBranchRowEntry>> entries) {
			Name = name;
			Entries = entries;
		}
	}

	public struct MasteryTreeBranchRowEntry {
		public string MasteryId { get; set; }
		public string Prereq { get; set; }
		
		public MasteryTreeBranchRowEntry(string masteryId, string prereq) {
			MasteryId = masteryId;
			Prereq = prereq;
		}
	}
}