using System.Collections.Generic;
// ReSharper disable All

namespace Jhinx.Jinx.Game {
	public class GameTimline {
		public int FrameInterval { get; set; }
		public List<Frame> Frames { get; set; }

		public GameTimline(int frameInterval, List<Frame> frames) {
			FrameInterval = frameInterval;
			Frames = frames;
		}
	}
}