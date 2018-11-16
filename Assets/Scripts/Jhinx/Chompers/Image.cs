using System.Collections;
using System.Diagnostics.CodeAnalysis;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
// ReSharper disable All

namespace Jhinx.Chompers {
	public class Image {
		public string Full { get; set; }
		public string Sprite { get; set; }
		public string Group { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public int W { get; set; }
		public int H { get; set; }

		public Image(string full, string sprite, string group, int x, int y, int w, int h) {
			Full = full;
			Sprite = sprite;
			Group = group;
			X = x;
			Y = y;
			W = w;
			H = h;
		}

		public Image(Image image) {
			Full = image.Full;
			Sprite = image.Sprite;
			Group = image.Group;
			X = image.X;
			Y = image.Y;
			W = image.W;
			H = image.H;
		}

		public static Image ParseImageJson(JSONNode stickerJSON) {
			return new Image(stickerJSON["full"], stickerJSON["sprite"], stickerJSON["group"], stickerJSON["x"], stickerJSON["y"], stickerJSON["w"], stickerJSON["h"]);
		}
	}
}