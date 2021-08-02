using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlignmentOptimization
{
    public class CharAlignment
    {
        public static string charTable =  "`1234567890-=qwertyuiop[]asdfghjkl;'zxcvbnm,./ ";
        public Dictionary<Tuple<char, char>, int> instance = new Dictionary<Tuple<char, char>, int>();

        Random ran = new Random();

        public CharAlignment()
        {
            for(int i=0;i<charTable.Length-1;i++)
            {
                for(int j=i+1;j< charTable.Length;j++)
                {
                    Tuple<char, char> a = new Tuple<char, char>(charTable[i], charTable[j]);
                    Tuple<char, char> b = new Tuple<char, char>(charTable[j], charTable[i]);
                    instance[a] = instance[b]=ran.Next(1, 20);
                }
            }
        }
    }
}
