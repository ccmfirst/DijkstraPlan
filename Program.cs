using System;

namespace DijkstraPlan
{  
    // struct Data
    // {
    //     public int[,] positions;
    //     public int[,] sign;
    // }

    public class Data
    {   
        // public Cost int[,];
       
        public Data(double[][] positions, int[][] sign)
        {
            Positions = positions;
            Sign = sign;
            Cost = new double[sign.Length][];
            for (int i = 0; i < Sign.Length; i++)
            {   
                Cost[i] = new double[sign[0].Length];
                 for (int j = 0; j < Sign[0].Length; j++)
                {
                    if (sign[i][j] == 1)
                    {
                        Cost[i][j] = Math.Sqrt(Math.Pow(positions[i][0] - positions[j][0], 2) + Math.Pow(positions[i][1] - positions[j][1], 2));
                    }
                    else
                    {
                        Cost[i][j] = 1000;
                    }
                }
            }
        }
        public double[][] Positions;
        public int[][] Sign;
        public double[][] Cost;
    }
    class Program
    {
        static void Main(string[] args)
        {   
            double[][] positions = new double[4][];
            positions[0] = new double[] {0, 0};
            positions[1] = new double[] {1, 0};
            positions[2] = new double[] {1, 1};
            positions[3] = new double[] {0, 1};

            int[][] sign = {new int[] {0, 1, 0, 1 }, new int[] {1, 0, 1, 0}, new int[] {0, 1, 0, 1}, new int[] {1, 0, 1, 0}};
            
            Data data = new Data(positions, sign);
            Console.WriteLine(data.Cost[0][0]);
            double[] dist = data.Cost[0];
            int[] s = new int[dist.Length];
            s[0] = 0;
            dist[0] = 0;
            int[] path = new int[dist.Length];

            for (int i = 1; i < sign.Length; i++)
            {   
                int u = new int;
                double mindist = 10000;
                for (int j = 1; j < dist.Length; j++)
                {
                    if (s[i] == 0)
                    {
                        if  dist[i] < mindist
                        {
                            mindist = dist[i];
                            u = i;
                        }
                    }
                }

                s[u] = 1;
                for (int k = 0; k < dist.Length; k++)
                {
                    if (s[i] == 0)
                    {
                        if (dist[u] + data.Cost[u][k] < dist[k])
                        {
                            dist[k] = dist[u] + data.Cost[u][k];
                            path[k] = u;
                        }
                    }
                }
            }
        }

        foreach (int a in path) 
        {
            Console.WriteLine(a);
        }
    }
}
