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
            Dictionary<string, string> abouts = Chompers.Chompers.parseStringStringDictionaryJSON(leagueJSON["abouts"]);
            Dictionary<string, string> names = Chompers.Chompers.parseStringStringDictionaryJSON(leagueJSON["names"]);
            List<string> tournaments = Chompers.Chompers.parseStringArrayJSON(leagueJSON["tournaments"].AsArray);
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
        
        public static IEnumerator getLeague(string slug) {
            using (UnityWebRequest www = UnityWebRequest.Get("https://api.lolesports.com/api/v1/leagues?slug=" + slug)) {
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
