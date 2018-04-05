using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    [Serializable]
    class Gestion
    {
        public int CountTeam { get; set; }
        public int CountJoeur { get; set; }
        public List<Team> ListTeams { get; set; } = new List<Team>();
        public List<Player> ListPlayers { get; set; } = new List<Player>();

        public Gestion()
        {
            CountTeam = 0;
            CountJoeur = 0;
        }
        public void Add(Team t)
        {
            ListTeams.Add(t);
        }
        public void Add(Player p)
        {
            ListPlayers.Add(p);
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
    }
}
