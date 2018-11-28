using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
// ReSharper disable All

namespace Jhinx.Jinx.League {
    public class League {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string Guid { get; set; }
        public string Region { get; set; }
        public int DrupalId { get; set; }
        public string LogoURL { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public Dictionary<string, string> Abouts  { get; set; }
        public Dictionary<string, string> Names { get; set; }
        public List<string> Tournaments  { get; set; }
        
        // Optional Extra. Lmao
        //public List<Tournament> Tournaments { get; set; }
        //public List<HighlanderRecord> HighlandRecords { get; set; }
        //public List<Team> Teams { get; set; }
        
        public League(int id, string slug, string name, string guid, string region, int drupalId, string logoUrl, string createdAt, string updatedAt, Dictionary<string, string> abouts, Dictionary<string, string> names, List<string> tournaments) {
            Id = id;
            Slug = slug;
            Name = name;
            Guid = guid;
            Region = region;
            DrupalId = drupalId;
            LogoURL = logoUrl;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Abouts = abouts;
            Names = names;
            Tournaments = tournaments;
        }
       
        private static League parseLeagueJSON(JSONNode leagueJSON) {
            Dictionary<string, string> abouts = new Dictionary<string, string>();
            foreach (string aboutLanguageCode in leagueJSON["abouts"].Keys) {
                abouts.Add(aboutLanguageCode, leagueJSON["abouts"][aboutLanguageCode]);
            }
            
            Dictionary<string, string> names = new Dictionary<string, string>();
            foreach (string nameLanguageCode in leagueJSON["names"].Keys) {
                names.Add(nameLanguageCode, leagueJSON["names"][nameLanguageCode]);
            }
            
            List<string> tournaments = new List<string>();
            foreach(JSONString tournamentId in leagueJSON["tournaments"].AsArray) {
                tournaments.Add(tournamentId);
            }                
            
            return new League(leagueJSON["id"], leagueJSON["slug"], leagueJSON["name"], leagueJSON["guid"], leagueJSON["region"], leagueJSON["drupalId"], leagueJSON["logoUrl"], leagueJSON["createdAt"], leagueJSON["updatedAt"], abouts, names, tournaments);
        }

        public static IEnumerator getLeague(int leagueId) {
            using (UnityWebRequest www = UnityWebRequest.Get("https://api.lolesports.com/api/v1/leagues?id=" + leagueId)) {
                yield return www.Send();
                if (www.isNetworkError || www.isHttpError) {
                    Debug.Log(www.error);
                    yield return null;
                } else {
                    yield return parseLeagueJSON(JSON.Parse(www.downloadHandler.text)["leagues"][0]);                       
                }
            }
        }
        
         /*
         public static IEnumerator getLeague(System.Action<League> callback, int leagueId) {
            using (UnityWebRequest www = UnityWebRequest.Get("https://api.lolesports.com/api/v1/leagues?id=" + leagueId)) {
                yield return www.Send();
                if (www.isNetworkError || www.isHttpError) {
                    Debug.Log(www.error);
                    callback(null);
                } else {
                    callback(parseLeagueJSON(JSON.Parse(www.downloadHandler.text)["leagues"][0]));                       
                }
            }
        }         
        */  
       
    }
}
