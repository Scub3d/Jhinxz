using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jhinx {
    public class League {
        private int id, drupalId;
        private string logoURL, region, slug, guid, createdAt, updatedAt;
        private List<string> tournaments;
        private Dictionary<string, string> names, abouts;

        public int Id {
            get { return this.id; }
            set {
                this.id = value;
            }
        }

        public int DrupalId {
            get { return this.drupalId; }
            set {
                this.drupalId = value;
            }
        }

        public string Guid {
            get { return this.guid; }
            set {
                this.guid = value;
            }
        }

        public string CreatedAt {
            get { return this.createdAt; }
            set {
                this.createdAt = value;
            }
        }

        public string UpdatedAt {
            get { return this.updatedAt; }
            set {
                this.updatedAt = value;
            }
        }

        public string LogoURL {
            get { return this.logoURL; }
            set {
                this.logoURL = value;
            }
        }

        public string Region {
            get { return this.region; }
            set {
                this.region = value;
            }
        }

        public string Slug {
            get { return this.slug; }
            set {
                this.slug = value;
            }
        }

        public List<string> Tournaments {
            get { return this.tournaments; }
            set {
                this.tournaments = value;
            }
        }

        public Dictionary<string, string> Names {
            get { return this.names; }
            set {
                this.names = value;
            }
        }

        public Dictionary<string, string> Abouts {
            get { return this.abouts; }
            set {
                this.abouts = value;
            }
        }

        public League(int id, int drupalId, string guid, string createdAt, string updatedAt, string logoURL, string region, string slug, List<string> tournaments, Dictionary<string, string> names, Dictionary<string, string> abouts) {
            Id = id;
            DrupalId = drupalId;
            Guid = guid;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            LogoURL = logoURL;
            Region = region;
            Slug = slug;
            Tournaments = tournaments;
            Names = names;
            Abouts = abouts;
        }

        public static League getLeague() {

        }

    }
}