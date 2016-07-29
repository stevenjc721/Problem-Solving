/* 
 * @auth Steven J Carver
 * 
 * Solution to CutRod problem with recurision and without recurision
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutRod
{
    class Program
    {
        static void Main(string[] args){

            int[] x = new int[]{ 1, 5, 8, 9, 10, 17, 17, 20, 24, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30};

            Console.Out.WriteLine("Algorithm With Recurison");
            Console.Out.WriteLine("N Value " + " | " + " Optimal Value" + " | " + " Run-Time");
            for (int n = 1; n < 41; n++){

                var watch = System.Diagnostics.Stopwatch.StartNew();
                int optimal = cutRod(x, n);
                watch.Stop();
                Console.Out.WriteLine(n + "       | " + optimal + "              | " + watch.ElapsedMilliseconds + "  ms");

            }

            Console.Out.WriteLine("\nAlgorithm Without Recurison");
            Console.Out.WriteLine("N Value " + " | " + " Optimal Value" + " | " + " Run-Time");
            for (int n = 1; n < 41; n++){

                var watch = System.Diagnostics.Stopwatch.StartNew();
                int optimal = cutRod2(x, n);
                watch.Stop();
                Console.Out.WriteLine(n + "       | " + optimal + "              | " + watch.ElapsedMilliseconds + "  ms");

            }
            Console.ReadLine();
        }

        //Recursive cutRod call
        public static int cutRod(int[] p, int n){

            //Base case
            if (n <= 0){
                return n;
            }
            int q = -1;
            for (int i = 0; i < n; i++){

                //Recursive call & comparision
                q = Math.Max(q, p[i] + cutRod(p, n - (i + 1)));
            }
            return q;
        }

        //Non-Recursive cutRod
        public static int cutRod2(int[] p, int n){

            //End if basecase not met
            if (n <= 0 || p.Length < n){
                return n;
            }
            //Avoid unnecessary calculation
            if (n == 1){

                return p[n - 1];
            }
            // Initialize array for storage of previous max
            int[] previousVal = new int[n + 1];
            previousVal[0] = 0; // since n!= 0 value of n=0 is 0

            //Iterate through all n
            for (int i = 1; i <= n; i++){

                int q = -1; // set min value for Max comparision
                //Populate previousVal array and use previousVal array to determine max value of next step
                for (int j = 0; j < i; j++){

                    q = Math.Max(q, p[j] + previousVal[i - j - 1]); // comparison

                }
                previousVal[i] = q; // assign current value
            }

            return previousVal[n];
        }
    }
}
