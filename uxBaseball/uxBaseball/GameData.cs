using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uxBaseball
{
    class GameData
    {
        public DateTime gameData;
        public string homeTeam;
        public string homeAbr;//home team's abb
        public int homeScore;//home team score
        public string visitingTeam;
        public string visitAbr;//visiting team abb
        public int visitScore;//visiting team score
        public string winningPitcher;
        public string losingPitcher;
        public string save;
        public string mvp;
        
        public GameData(string[] s, Dictionary<string, TeamData> _teamInfo)
        {
            int year = Convert.ToInt32(s[0].Substring(0,4));
            int month = Convert.ToInt32(s[0].Substring(4, 2));
            int day = Convert.ToInt32(s[0].Substring(6, 2));
            gameData = new DateTime(year, month, day);
            homeAbr = s[6];
            homeScore= Convert.ToInt32(s[10]);
            visitAbr = s[3];
            visitScore = Convert.ToInt32(s[9]);
            winningPitcher = s[94];
            losingPitcher = s[96];
            save = s[98];
            mvp = s[100];
            homeTeam = _teamInfo[homeAbr].location+" "+_teamInfo[homeAbr].nickName;
            visitingTeam = _teamInfo[visitAbr].location + " " + _teamInfo[visitAbr].nickName;
        }
    }
}