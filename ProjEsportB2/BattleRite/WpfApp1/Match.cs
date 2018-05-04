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
        public Match Suivant { get; set; }
        public Team Equipe1 { get; set; }
        public Team Equipe2 { get; set; }
        public int ScoreTeam1 { get; set; }
        public int ScoreTeam2 { get; set; }

        public Match (Team equipe1, Team equipe2, int score1, int score2)
        {
            Equipe1 = equipe1;
            Equipe2 = equipe2;
            ScoreTeam1 = score1;
            ScoreTeam2 = score2;
            Suivant = null;
        }
        public Match(Team equipe1, Team equipe2)
        {
            Equipe1 = equipe1;
            Equipe2 = equipe2;
            ScoreTeam1 = 0;
            ScoreTeam2 = 0;
            Suivant = null;
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
        public void SetScore(Team equipe1, int score1, Team equipe2, int score2)
        {
            if (Equipe1 == equipe1)
            {
                ScoreTeam1 = score1;
                ScoreTeam2 = score2;
            }
            else
            {
                ScoreTeam1 = score2;
                ScoreTeam2 = score1;
            }
        }
    }
}
