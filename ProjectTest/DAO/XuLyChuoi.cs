using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectTest.DAO
{
    public class XuLyChuoi
    {
        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        public static string GetMetaTitle(string a)
        {
            string b = convertToUnSign3(a);
            string c = b.ToLower();
            string d = c.Replace(" ", "-");
            return d;
        }
    }
}
