using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Gestion
    {
        public int CountTeam { get; set; }
        public int CountJoeur { get; set; }
        public List<Team> ListTeam { get; set; } = new List<Team>();
        public List<Joueur> ListJoueur { get; set; } = List<Joueur>();
    }
}
