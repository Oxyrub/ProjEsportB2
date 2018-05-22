using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    [Serializable]
    public class Tournoi
    {
        public int Id { get; set; }
        public string Lieu { get; set; }
        public string Nom { get; set; }
        public string TypeTournoi { get; set; }
        public bool Remplacement { get; set; }
        public string Date { get; set; }
        public string Heure { get; set; }
        public string Regle { get; set; }
        public string Info { get; set; }
        public List<Team> ListTeam { get; set; } = new List<Team>();
        public List<Match> ListMatch { get; set; } = new List<Match>();
        public Team EquipeDeTrop { get; set; }
        public int Bo { get; set; }

        public Tournoi(int id, string nom, string lieu, int bo, string typeTournoi, bool remplacement, string date, string heure, string regle, string info)
        {
            Id = id;
            Lieu = lieu;
            Nom = nom;
            Bo = bo;
            TypeTournoi = typeTournoi;
            Remplacement = remplacement;
            Date = date;
            Heure = heure;
            Regle = regle;
            Info = info;
        }

        public void AddTeam (Team t)
        {
            ListTeam.Add(t);
        }
        public Match GetMatch(int id)
        {
            for (int i = 0; i<ListMatch.Count; i++)
            {
                if (ListMatch[i].Id == id) return ListMatch[i];
            }
            return null;
        }
        public void Start()
        {
            int i = 0;
            int rest = 0;
            Random rng = new Random();
            ListTeam = ListTeam.OrderBy(item => rng.Next()).ToList();
            while (i + 1 < ListTeam.Count)
            {
                ListMatch.Add(new Match(ListMatch.Count, ListTeam[i], ListTeam[i + 1], true));
                i += 2;
            }
            if (i < ListTeam.Count)
            {
                ListMatch.Add(new Match(ListMatch.Count, ListTeam[i], ListTeam[i], false));
                rest = ListTeam[i].Id;
            }
            List<Match> LastMatch = GetLastMatch().OrderBy(item => rng.Next()).ToList();
            while (LastMatch.Count > 1)
            {
                Match NewMatch;
                i = 0;
                while (i + 1 < LastMatch.Count)
                {
                    NewMatch = new Match(ListMatch.Count, true);
                    GetMatch(LastMatch[i].Id).Suivant = NewMatch;
                    GetMatch(LastMatch[i + 1].Id).Suivant = NewMatch;
                    ListMatch.Add(NewMatch);
                    i += 2;
                }
                if (i < LastMatch.Count)
                {
                    NewMatch = new Match(ListMatch.Count, false);
                    GetMatch(LastMatch[i].Id).Suivant = NewMatch;
                    ListMatch.Add(NewMatch);
                    rest = ListTeam[i].Id;
                }
                do { LastMatch = GetLastMatch().OrderBy(item => rng.Next()).ToList(); } while (LastMatch[LastMatch.Count - 1].Id == rest);
            }
        }
        public List<Team> GetTeamRestant()
        {
            List<Match> ListLastMatch = GetLastMatch();
            List<Team> ListTeamRestant = new List<Team>();
            for (int i = 0; i < ListLastMatch.Count; i++)
            {
                ListTeamRestant.Add(ListLastMatch[i].GetGagnant());
            }
            return ListTeamRestant;
        }
        public List<Match> GetLastMatch()
        {
            List<Match> ListLastMatch = new List<Match>();
            for (int i = 0; i < ListMatch.Count; i++)
            {
                if (ListMatch[i].Suivant == null)
                {
                    ListLastMatch.Add(ListMatch[i]);
                }
            }
            return ListLastMatch;
        }
        public Boolean AllMatchEnded()
        {
            for (int i = 0; i<ListMatch.Count; i++)
            {
                if (ListMatch[i].GetGagnant() == null) return false;
            }
            return true;
        }
        public List<Match> GetMatchNotEnded()
        {
            List<Match> NotEnded = new List<Match>();
            for (int i = 0; i<ListMatch.Count; i++)
            {
                if (ListMatch[i].Equipe1 != ListMatch[i].Equipe2 && ListMatch[i].Equipe1 != null && ListMatch[i].Equipe2 != null && ListMatch[i].GetGagnant() == null) NotEnded.Add(ListMatch[i]);
            }
            return NotEnded;
        }
        public bool Participe(int id)
        {
            for (int i = 0; i < ListTeam.Count; i++)
            {
                if (ListTeam[i].Id == id) return true;
            }
            return false;
        }
    }
}
