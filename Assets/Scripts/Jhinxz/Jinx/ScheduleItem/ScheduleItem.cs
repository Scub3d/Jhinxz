using System.Collections.Generic;
using SimpleJSON;
// ReSharper disable All

namespace Jhinxz.Jinx {
	public class ScheduleItem {



		public static ScheduleItem parseScheduleItemJSON(JSONNode json) {
			return new ScheduleItem();
		}

		public static List<ScheduleItem> parseScheduleItemsJSON(JSONArray json) {
			List<ScheduleItem> scheduleItems = new List<ScheduleItem>();
			foreach (JSONNode scheduleItemJSON in json) {
				scheduleItems.Add(parseScheduleItemJSON(scheduleItemJSON));
			}

			return scheduleItems;
		}
	}
}