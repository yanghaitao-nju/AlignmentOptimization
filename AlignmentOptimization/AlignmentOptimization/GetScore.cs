using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlignmentOptimization
{
    class GetScore
    {

        static Random ran = new Random();
        static Dictionary<char, int> charmap = new Dictionary<char, int>();

        static double defaultDistance = 400;
        public double score = 0;

        static string clean(string s)
        {
            string a = string.Empty;
            for(int i=0;i<s.Length;i++)
            {
                if(charmap.ContainsKey(s[i]))
                {
                    a += s[i];
                }
                else
                {
                    char b = charmap.ElementAt(ran.Next(0, 30)).Key;
                    a += b;
                }
            }
            return a;
        }
        public static void CharmapInit()
        {
            if (charmap.Count == 0)
            {
                for (int i = 0; i < CharAlignment.charTable.Length; i++)
                {
                    charmap[CharAlignment.charTable[i]] = 0;
                }
            }
        }
        GetScore(CharAlignment alignment)
        {
            CharmapInit();


        }
        public static double Getdistance(ref CharAlignment alignment,string a,string b)
        {
            a = clean(a);
            b = clean(b);
            double[,] distance = new double[a.Length + 1, b.Length + 1];

            for(int i=0;i<b.Length+1;i++)
            {
                distance[0,i] = i;
            }//初始化第一行
            for(int i=1;i<a.Length+1;i++)
            {
                distance[i,0] = i;
                for (int j = 1; j < b.Length + 1; j++)
                {
                    if (a[i - 1] == b[j - 1])
                    {
                        distance[i, j] = distance[i - 1, j - 1];
                    }
                    else
                    {
                        Tuple<char, char> pair = new Tuple<char, char>(a[i - 1], b[j - 1]);
                        Tuple<char, char> delete = new Tuple<char, char>(a[i - 1], ' ');
                        Tuple<char, char> insert = new Tuple<char, char>(b[j - 1], ' ');
                        double dis = defaultDistance;

                        dis = distance[i - 1, j - 1] + alignment.instance[pair];
                        double m = distance[i - 1, j] + alignment.instance[delete];
                        dis = m < dis ? m : dis;
                        m = distance[i, j - 1] + alignment.instance[insert];
                        distance[i, j] = m < dis ? m : dis;

                    }
                    Console.Write(distance[i, j].ToString() + " ");

                }
                Console.Write('\n');

            }
            return distance[a.Length, b.Length];

        }
           
    }
}
