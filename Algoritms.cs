using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_benchmark_Morozova
{
    class Algoritms
    {
        public void FillZnach(int[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
                arr[i] = rnd.Next(-10, 10);
        }

        //адгоритмы поиска максимальной суммы последовательности
        // O(n^2)
        public int O_n2(int[] arr)
        {
            int maxSum = 0, sum;
            for(int i=0; i<arr.Length; i++)
            {
                sum = 0;
                for(int j=0; j<arr.Length; j++)
                {
                    sum += arr[j];
                    maxSum = Math.Max(maxSum, sum);
                }
            }
            return maxSum;
        }

        // O(nlogn)
        public int O_nlogn(int[] arr, int l, int r)
        {
            if (l > r) return 0;
            if (l == r) return arr[l];

            int middle = (l + r) / 2, lmax = 0, sum = 0;
            //максимальная сумма на промежутке [лево, середина]
            for(int i=middle; i>=l; i--)
            {
                sum += arr[i];
                lmax = Math.Max(lmax, sum);
            }
            int rmax = sum = 0;
            //максимальная сумма на промежутке [серединаб право]
            for(int i=middle+1; i <= r; i++)
            {
                sum += arr[i];
                rmax = Math.Max(rmax, sum);
            }
            int rez = new[]
            {
                lmax+rmax, O_nlogn(arr, l, middle),
                O_nlogn(arr,middle+1, r)
            }.Max();
            return rez;
        }
        //O(n)
        public int O_n(int[] arr)
        {
            int max = 0, sum = 0;
            for(int i=0; i<arr.Length; i++)
            {
                sum = Math.Max(sum + arr[i], 0);
                max = Math.Max(max, sum);
            }
            return max;
        }
    }
}
