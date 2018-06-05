using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    [Serializable]
    public class Match
    {
        public int Id { get; set; }
        private Match _Suivant;
        public Match Suivant
        {
            get { return _Suivant; }
            set
            {
                _Suivant = value;
                if (_Suivant != null && Equipe1 == Equipe2 && Equipe1 != null) _Suivant.AddTeam(Equipe1);
            }
        }
        public Team Equipe1 { get; set; }
        public Team Equipe2 { get; set; }
        public int ScoreTeam1 { get; set; }
        public int ScoreTeam2 { get; set; }
        public bool Vrais { get; set; }

        public Match (int id, Team equipe1, Team equipe2, int score1, int score2, bool vrais)
        {
            Id = id;
            Equipe1 = equipe1;
            Equipe2 = equipe2;
            ScoreTeam1 = score1;
            ScoreTeam2 = score2;
            Suivant = null;
            Vrais = vrais;
        }
        public Match(int id, Team equipe1, Team equipe2, bool vrais)
        {
            Id = id;
            Equipe1 = equipe1;
            Equipe2 = equipe2;
            ScoreTeam1 = 0;
            ScoreTeam2 = 0;
            Suivant = null;
            Vrais = vrais;
        }
        public Match(int id, bool vrais)
        {
            Id = id;
            Equipe1 = null;
            Equipe2 = null;
            Suivant = null;
            Vrais = vrais;
        }

        public Team GetGagnant()
        {
            if (ScoreTeam1 > ScoreTeam2) return Equipe1;
            else if (ScoreTeam1 < ScoreTeam2) return Equipe2;
            else return null;
        }
        public Team GetPerdant()
        {
            if (ScoreTeam1 > ScoreTeam2) return Equipe2;
            else if (ScoreTeam1 < ScoreTeam2) return Equipe1;
            else return null;
        }
        public void SetScore(int score1, int score2)
        {
            ScoreTeam1 = score1;
            ScoreTeam2 = score2;
        }
        public void AddTeam(Team t)
        {
            if (Vrais)
            {
                if (Equipe1 == null) Equipe1 = t;
                else Equipe2 = t;
            }
            else
            {
                Equipe1 = t;
                Equipe2 = t;
                if (Suivant != null) _Suivant.AddTeam(Equipe1);
            }
        }
        public void RemoveTeam(Team t)
        {
            if (Equipe1 == t) Equipe1 = null;
            else if (Equipe2 == t) Equipe2 = null;
        }
    }
}
