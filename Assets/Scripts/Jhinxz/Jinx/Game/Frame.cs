using System.Collections.Generic;
// ReSharper disable All

namespace Jhinxz.Jinx.Game {
	public class Frame {
		public long Timestamp { get; set; }
		public List<Event> Events { get; set; }
		public List<ParticipantFrame> ParticipantFrames { get; set; }

		public Frame(long timestamp, List<Event> events, List<ParticipantFrame> participantFrames) {
			this.Timestamp = timestamp;
			this.Events = events;
			this.ParticipantFrames = participantFrames;
		}
	}
}