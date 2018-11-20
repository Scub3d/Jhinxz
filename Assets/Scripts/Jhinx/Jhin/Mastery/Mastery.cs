using System.Collections;
using System.Collections.Generic;
using Jhinx.Chompers;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

// ReSharper disable All

namespace Jhinx.Jhin.Mastery {
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

		private static Mastery parseMasteryjson(JSONNode json) {
			List<string> descriptions = Chompers.Chompers.parseStringArrayJSON(json["description"].AsArray);
			Image image = new Image(Chompers.Image.ParseImageJson(json["image"]));
			return new Mastery(json["id"], json["name"], descriptions, image, json["ranks"], json["prereq"]);
		}

		public static List<Mastery> parseMasteriesJSON(JSONNode json) {
			List<Mastery> masteries = new List<Mastery>();
			foreach (JSONNode masteryJSON in json) {
				masteries.Add(parseMasteryjson(masteryJSON));
			}

			return masteries;
		}
	}
}