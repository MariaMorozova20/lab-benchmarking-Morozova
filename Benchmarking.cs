using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace lab_benchmark_Morozova
{
    class Benchmarking //измерение времени работы алгоритмов решения задачи о суммме макс последовательности
    {
        Stopwatch time;
        Algoritms algs; 
        int[] ARR; //размеры последовательностей
        string[][] result; //таблица результатов измерения

        public Benchmarking(int[] arr)
        {
            time = new Stopwatch();
            algs = new Algoritms(); 
            ARR = arr;
            result = new string[arr.Length][];
            for (int i = 0; i < arr.Length; i++) result[i] = new string[3];
        }
        //выполнение 3 алгоритмов для каждой последовательности
        public void Benchmark()
        {
            for(int i=0; i<ARR.Length; i++)
            {
                int size = ARR[i];
                int[] mas = new int[size];
                algs.FillZnach(mas);

                //O(n^2)
                time.Start();
                algs.O_n2(mas);
                time.Stop();
                result[i][0] = time.Elapsed.ToString();
                time.Restart();

                //O(nlogn)
                time.Start();
                algs.O_nlogn(mas, 0, size - 1);
                time.Stop();
                result[i][1] = time.Elapsed.ToString();
                time.Restart();

                //O(n)
                time.Start();
                algs.O_n(mas);
                time.Stop();
                result[i][2] = time.Elapsed.ToString();
                time.Restart();
            }
        }
        public string ResultOut()
        {
            string res = "";
            res += "\t\tO(n^2)\t\t\t\tO(nlogn)\t\t\tO(n)\t\t\n";
            for(int i=0; i<ARR.Length; i++)
            {
                res += ARR[i].ToString() + "\t\t";
                for(int j=0; j<3; j++)
                {
                    res += result[i][j]; res += "\t\t";
                }
                res += "\n";
            }
            return res;
        }
    }
}
