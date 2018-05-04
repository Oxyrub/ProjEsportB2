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
        public int NbParticiepants { get; set; }
        public List<Team> ListTeam { get; set; } = new List<Team>();
        public List<Match> ListMatch { get; set; } = new List<Match>();
        public Team EquipeDeTrop { get; set; }

        public Tournoi(int id, string nom, string lieu, int nbParticipants)
        {
            Id = id;
            Lieu = lieu;
            Nom = nom;
            NbParticiepants = nbParticipants;
        }

        public void AddTeam (Team t)
        {
            ListTeam.Add(t);
        }
        public void MancheProchaine()
        {
            List<Match> ListLastMatch = GetLastMatch();
            int i = 0;
            while (i + 1 < ListLastMatch.Count)
            {
                Match NewMatch;
                if (EquipeDeTrop != null)
                {
                    NewMatch = new Match(EquipeDeTrop, ListLastMatch[i].GetGagnant());
                    ListLastMatch[i].Suivant = NewMatch;
                    i++;
                }
                else
                {
                    NewMatch = new Match(ListLastMatch[i].GetGagnant(), ListLastMatch[i + 1].GetGagnant());
                    ListLastMatch[i].Suivant = NewMatch;
                    ListLastMatch[i + 1].Suivant = NewMatch;
                    i += 2;
                }
                ListMatch.Add(NewMatch);
            }
            if (i < ListLastMatch.Count)
            {
                EquipeDeTrop = ListLastMatch[i].GetGagnant();
            }
        }
        public void Start()
        {
            int i = 0;
            while (i + 1 < ListTeam.Count)
            {
                ListMatch.Add(new Match(ListTeam[i], ListTeam[i + 1]));
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
            if (AllMatchEnded())
            {
                for (int i = 0; i < ListMatch.Count; i++)
                {
                    if (ListMatch[i].Suivant == null)
                    {
                        ListLastMatch.Add(ListMatch[i]);
                    }
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
            List<Match> ListMatchNotEnded = new List<Match>();
            for (int i = 0; i<ListMatch.Count; i++)
            {
                if (ListMatch[i].GetGagnant() == null) ListMatchNotEnded.Add(ListMatch[i]);
            }
            return ListMatchNotEnded;
        }
    }
}
