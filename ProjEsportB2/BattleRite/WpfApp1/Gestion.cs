using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    [Serializable]
    public class Gestion
    {
        public int CountTeam { get; set; }
        public int CountJoeur { get; set; }
        public int CountTournoi { get; set; }
        public List<Team> ListTeams { get; set; } = new List<Team>();
        public List<Player> ListPlayers { get; set; } = new List<Player>();
        public List<Tournoi> ListTournoi { get; set; } = new List<Tournoi>();

        public Gestion()
        {
            CountTeam = 0;
            CountJoeur = 0;
        }
        public void AddTeam(string name)
        {
            ListTeams.Add(new Team(CountTeam, name, this));
            CountTeam++;
        }
        public int AddPlayer(string pseudoSteam, string pseudoBattlerite, Rank rank)
        {
            ListPlayers.Add(new Player(CountJoeur, pseudoSteam, pseudoBattlerite, rank));
            CountJoeur++;
            return CountJoeur - 1;
        }
        public int AddTournoi(string nom, string lieu, int bo, string typeTournoi, bool remplacement, string date, string heure, string regle, string info)
        {
            ListTournoi.Add(new Tournoi(CountTournoi, nom, lieu, bo, typeTournoi, remplacement, date, heure, regle, info));
            CountTournoi++;
            return CountTournoi - 1;
        }
        public Team GetTeam(int id)
        {
            foreach (Team t in ListTeams)
            {
                if (t.Id == id) return t;
            }
            return null;
        }
        public Player GetPlayer(int id)
        {
            foreach (Player p in ListPlayers)
            {
                if (p.Id == id) return p;
            }
            return null;
        }
        public Tournoi GetTournoi(int id)
        {
            foreach (Tournoi t in ListTournoi)
            {
                if (t.Id == id) return t;
            }
            return null;
        }
        public bool Exist(Player player)
        {
            foreach (Player p in ListPlayers)
            {
                if (p == player) return true;
            }
            return false;
        }
        public override string ToString()
        {
            string retour = "Teams :\n";
            foreach(Team t in ListTeams)
            {
                retour += string.Format("  - {0}\n", t.Name);
            }
            retour += "Players :\n";
            foreach (Player p in ListPlayers)
            {
                retour += string.Format("  - {0}\n", p.PseudoSteam);
            }
            retour += "Tournois :\n";
            foreach (Tournoi t in ListTournoi)
            {
                retour += string.Format("  - {0}\n", t.Nom);
            }
            return retour;
        }
    }
}
