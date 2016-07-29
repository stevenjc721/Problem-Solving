/* 
 * @auth Steven J Carver
 * 
 * Basic brute force matrix multiplication for square matrix
 *  Generating square matrix based off of even int
 * 
 */
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace MatrixMultiplication
{
    class Program
    {
        static void Main(string[] args){

            #region Part1
            int[,] test1 = new int[2, 2];
            test1[0, 0] = 1;
            test1[0, 1] = 2;
            test1[1, 0] = 3;
            test1[1, 1] = 4;

            int[,] test2 = new int[2, 2];
            test2[0, 0] = 5;
            test2[0, 1] = 6;
            test2[1, 0] = 7;
            test2[1, 1] = 8;

            int[,] test3 = matrixMulti(test1, test2);

            foreach (var e in test3){

                Console.Out.WriteLine(e);
            }

            #endregion

            #region Part2

            int[] toGen = new int[] { 10, 20, 50, 100, 400, 2500 };

            foreach (var x in toGen){


                int[,] g1 = matrixGen(x);
                int[,] g2 = matrixGen(x);

                Console.Out.WriteLine("Generated n = " + x + " matrixes");

                // Create new stopwatch.
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();

                int[,] results = matrixMulti(g1, g2);

                stopwatch.Stop();

                Console.Out.WriteLine("For matrix size " + x + "; Runing time equals " + stopwatch.Elapsed.Milliseconds.ToString() +" ms");

            }

            #endregion

            Console.ReadLine();

        }

        //input : 2 square matrix
        //output: product of matrix multiplication
        //error: returns empty matrix if either matrix isn't square, or if matrixes are different sizes
        public static int[,] matrixMulti(int[,] m1, int[,] m2){

            int[,] product = new int[m1.GetLength(0), m1.GetLength(1)];

            //Validate appropriate input
            if (m1.GetLength(0) != m1.GetLength(1) || m2.GetLength(0) != m2.GetLength(1)){

                return product;

            }
            else if (m1.GetLength(0) != m2.GetLength(0)){

                return product;
            }

            //Matrix Multiplication
            for (int i = 0; i < m1.GetLength(0); i++){

                for (int j = 0; j < m2.GetLength(1); j++){

                    //temporary storage for product value
                    int sum = 0;

                    for (int k = 0; k < m1.GetLength(1); k++){

                        sum += m1[i, k] * m2[k, j];
                    }
                    //Assign calculated value
                    product[i, j] = sum;
                }
            }
            return product;
        }

        //input: positive even int used to create a square matrix with random values
        //output: square int of size n with random ints
        //error: if n is not even or positive will return emptry matrix
        public static int[,] matrixGen(int n){

            int[,] mGen = new int[n, n];
            Random rGen = new Random();

            //Validate appropriate input
            if (n % 2 != 0){

                return mGen;
            }
            for (int i = 0; i < n; i++){

                for (int j = 0; j < n; j++){

                    //Generate random int and assign it to appropriate position
                    int r = rGen.Next();
                    mGen[i, j] = r;
                }

            }
            return mGen;
        }
    }
}
