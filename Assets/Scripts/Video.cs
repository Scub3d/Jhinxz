namespace Jhinx {
	public class Video {
        private string id, gameId, locale, url;
       
        public string Id { get; set; }
        public string GameId { get; set; }
        public string Locale { get; set; }
        public string URL { get; set; }

        public Video(string id, string gameId, string locale, string uRL) {
            Id = id;
            GameId = gameId;
            Locale = locale;
            URL = uRL;
        }
    }
}