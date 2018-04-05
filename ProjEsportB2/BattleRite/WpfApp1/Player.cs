using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public enum Rank
    {
        bronze1, bronze2, bronze3, bronze4, bronze5, silver1, silver2, silver3, silver4, silver5, gold1, gold2, gold3, gold4, gold5, platinium1, platinium2, platinium3, platinium4, platinium5

    }

    class Player
    {
        public int Id { get; set; }
        public string PseudoBattlerite { get; set; }
        public string PseudoSteam { get; set; }
        public Rank rank { get; set; }
    
    }
}
