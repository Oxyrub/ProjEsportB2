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

        public Tournoi(int id, string nom, string lieu, int nbParticipants)
        {
            Id = id;
            Lieu = lieu;
            Nom = nom;
            NbParticiepants = nbParticipants;
        }
    }
}
