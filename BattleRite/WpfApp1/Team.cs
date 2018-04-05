using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Team
    {
        static int NbTeam { get; }
        public string Name { get; set; }
        public int Id { get; set; }

        public Team(string name)
        {
            Name = name;
        }


    }
}
