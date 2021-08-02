using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlignmentOptimization
{
    class Genetic
    {
        int generations = 20;
        double crossrate = 0.4;
        double variation = 0.05;

        Genetic()
        {
            
            InitialPopulation();
            Random ran = new Random();
            for (int i = 0; i < 20; i++)
            {
                Onegeneration();
            }
        }

        public void Onegeneration()
        {
            int PopulationNum = 0;//当前种群数量
            while (PopulationNum < generations)
            {
                Population[PopulationNum++]=BuildChild(ChooseParent());
            }
        }

        public List<CharAlignment> Population = new List<CharAlignment>();

        List<double> aLiveRate = new List<double>();

        void InitialPopulation()
        {
            for (int i = 0; i < 20; i++)
            {
                Population.Add(new CharAlignment());
            }
        }

        static public double NextDouble(Random ran, double minValue, double maxValue)
        {
            return ran.NextDouble() * (maxValue - minValue) + minValue;
        }

        Tuple<int, int> ChooseParent()
        {
            Random ran = new Random();
            double max = aLiveRate[aLiveRate.Count - 1];
            double f = NextDouble(ran, 0, max);
            double m = NextDouble(ran, 0, max);
            int father, mother;
            int i;
            for (i = 0; i < aLiveRate.Count; i++)
            {
                if (aLiveRate[i] < f)
                    break;
            }
            father = i - 1;
            for (i = 0; i < aLiveRate.Count; i++)
            {
                if (aLiveRate[i] < m)
                    break;
            }
            mother = i - 1;

            Tuple<int, int> result = new Tuple<int, int>(father, mother);
            return result;

        }

        CharAlignment BuildChild(Tuple<int, int> parent)
        {
            Random ran = new Random();
            CharAlignment child1 = Population[parent.Item1];
            CharAlignment child2 = Population[parent.Item2];
            for (int i = 0; i < child1.instance.Count; i++)
            {
                var item = child1.instance.ElementAt(i);
                double var1 = NextDouble(ran, 0, 1);//变异
                if (var1 <= variation)
                {
                    child1.instance[item.Key] = ran.Next(1, 20);
                }

                double var2 = NextDouble(ran, 0, 1);//变异
                if (var2 <= variation)
                {
                    child2.instance[item.Key] = ran.Next(1, 20);
                }

                double cro = NextDouble(ran, 0, 1);//交叉
                if (cro <= crossrate)
                {
                    int a = child1.instance[item.Key];
                    child1.instance[item.Key] = child2.instance[item.Key];
                    child2.instance[item.Key] = a;
                }
                


            }
            if (GetScore(child1) > GetScore(child2))
                return child1;
            return child2;

            

        }
        double GetScore(CharAlignment align)//Important Function ,Calculate Score by charalignment
        {
            return 0;
        }
    }
}
