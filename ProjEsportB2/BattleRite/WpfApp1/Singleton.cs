using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class MonSingleton
    {

        public string Name { get; set; }
        public int NbBo { get; set; }
        public string TypeMatch { get; set; }
        public string TypeTournoi { get; set; }
        public bool Remplacement { get; set; }
        public string Lieu { get; set; }
        public string Date { get; set; }
        public string Heure { get; set; }
        public int NbEquipe { get; set; }
        public string DescRegle { get; set; }
        public string DescInfo { get; set; }
        public List<Team> ListTeam { get; set; } = new List<Team>();
        public string NomEquipe { get; set; }

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
