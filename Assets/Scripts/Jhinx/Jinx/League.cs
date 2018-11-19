using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
// ReSharper disable All

namespace Jhinx.Jinx {
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
        public List<string> TournamentIds  { get; set; }
        
        // Optional Extra. Lmao
        public List<Tournament> Tournaments { get; set; }
        public List<HighlandRecord> HighlandRecords { get; set; }
        public List<Team> Teams { get; set; }
        
        public League(int id, string slug, string name, string guid, string region, int drupalId, string logoUrl, string createdAt, string updatedAt, Dictionary<string, string> abouts, Dictionary<string, string> names, List<string> tournamentIds) {
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
            TournamentIds = tournamentIds;
        }
        
        public League(int id, string slug, string name, string guid, string region, int drupalId, string logoUrl, string createdAt, string updatedAt, Dictionary<string, string> abouts, Dictionary<string, string> names, List<string> tournamentIds, List<Tournament> tournaments, List<HighlandRecord> highlandRecords, List<Team> teams) {
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
            TournamentIds = tournamentIds;
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

    public struct HighlandRecord {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public int Score { get; set; }
        public string Roster { get; set; }
        public string Tournament { get; set; }
        public string Bracket { get; set; }
        public string Id { get; set; }
        
        public HighlandRecord(int wins, int losses, int ties, int score, string roster, string tournament, string bracket, string id) {
            Wins = wins;
            Losses = losses;
            Ties = ties;
            Score = score;
            Roster = roster;
            Tournament = tournament;
            Bracket = bracket;
            Id = id;
        }
    }
}
