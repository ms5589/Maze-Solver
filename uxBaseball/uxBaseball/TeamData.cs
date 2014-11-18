/* TeamData.cs
 * Author: Sagar Mehta
 *Each instance of this class will be used to store data taken from a single line of 
 *the "TEAMABR.csv" file
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uxBaseball
{
    class TeamData: IComparable<TeamData>
    {
        public string teamAbbreviation;
        public string location;
        public string nickName;
        public string firstYear;
        public string lastYear;
        
        public TeamData(string[] str)
        {
            teamAbbreviation = str[0];
            location = str[1];
            nickName = str[2];
            firstYear= str[3];
            lastYear = str[4];
        }
        public override string ToString()
        {
            return (location+" "+nickName+" ("+firstYear+"-"+lastYear+") ") ;
        } //toString override
        
        public int CompareTo(TeamData td)
        {
            return this.ToString().CompareTo(td.ToString());
        }
        
    }
}
