using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uxBaseball
{
    struct TeamAndDate
    {
        /// <summary>
        /// 
        /// </summary>
        private DateTime date;
        /// <summary>
        /// 
        /// </summary>
        private string abbr;
        /// <summary>
        /// 
        /// </summary>
        private int hashCode;
        
        //stucture(2 param) YMD
        public TeamAndDate(string s, string time)
        {
            int year = Convert.ToInt32(time.Substring(0, 4));
            int month = Convert.ToInt32(time.Substring(4, 2));
            int day = Convert.ToInt32(time.Substring(6, 2));
            date = new DateTime(year, month, day);
            abbr = s;
            unchecked { 
            hashCode = Convert.ToInt32(abbr[0]);
            hashCode *= 39;
            hashCode += Convert.ToInt32(abbr[1]);
            hashCode *= 39;
            hashCode += Convert.ToInt32(abbr[2]);
            hashCode *= 39;
            hashCode += date.Year;
            hashCode *= 39;
            hashCode += date.Month;
            hashCode *= 39;
            hashCode += date.Day;
            hashCode *= 39;
            }
            //throw new Exception();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return hashCode;
        }
        public static bool operator ==(TeamAndDate x, TeamAndDate y)
        {
            if (x.date == y.date && x.abbr == y.abbr) return true;
            else return false;
        }
        public static bool operator !=(TeamAndDate x, TeamAndDate y)
        {
            return!(x==y);
        }
    }
}
