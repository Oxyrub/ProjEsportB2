using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    [Serializable]
    class Team
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<Player> ListPlayers { get; set; } = new List<Player>(); 

        public Team(string name)
        {
            Name = name;
        }
        public void Add(Player p)
        {
            ListPlayers.Add(p);
        }


    }
}
