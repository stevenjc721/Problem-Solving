/* 
 * @auth Steven J Carver
 * 
 * Practical Application of the relationship between the running time of insertion sort and the number of inversions in an input array
 * 
 * Inversion Comparison
 *  - number of inversions for a running time of O(n * lg n)
 *  - number of inversions for a running time of O(n^2)
 */

using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;

namespace InversionComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iArray = new int[] { 2, 3, 8, 6, 1 };

            // Create new stopwatch.
            Stopwatch stopwatch = new Stopwatch();

            // Begin timing.
            stopwatch.Start();
            int value = mergeSort(iArray, 0, iArray.Length - 1); // Time Complexity O(nln(n))
            stopwatch.Stop();

            Console.WriteLine("Inversion: " + value + " Time((O(n*ln(n))): " + stopwatch.ElapsedMilliseconds.ToString() + " ms");
            Console.ReadLine();

            int[] iArray2 = new int[] { 1, 20, 6, 4, 5 };

            stopwatch.Reset();

            // Begin timing.
            stopwatch.Start();
            int value2 = getInvCountnSqr(iArray2); // Time Complexity O(n^2)
            stopwatch.Stop();

            Console.WriteLine("Inversion: " + value2 + " Time(O(n^2)): " + stopwatch.ElapsedMilliseconds.ToString() + " ms");
            Console.ReadLine();

        }

        //MergeSort
        //@param array: array to be sorted
        //@param left: left most index of current subarray
        //@param right: right most index of current subarray
        private static int mergeSort(int[] array, int left, int right){

            //catching base case
            if (array.Length < 1){
                return 0;
            }
            // validating input for recursive calls
            if (left < right){

                int inversions = 0;
                int mid = (left + right) / 2;

                inversions += mergeSort(array, left, mid); // recursive call for first half
                inversions += mergeSort(array, mid + 1, right); // recursive call for second half
                inversions += mergeNLogN(array, left, mid, right); // merge
                return inversions; // current inversion count
            }else{

                return 0; //catching all other cases
            }
        }

        //@param array: subarray to be sorted
        //@param left: left most index of current subarray
        //@param mid: middle index of current subarray
        //@param right: right most index of current subarray
        private static int mergeNLogN(int[] array, int left, int mid, int right){

            int i, j, k, inversions = 0;

            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] lArray = new int[n1];
            int[] rArray = new int[n2];

            //Create left subarray
            for (i = 0; i < n1; i++){

                lArray[i] = array[left + i];
            }
            //Create right subarray
            for (j = 0; j < n2; j++){

                rArray[j] = array[mid + j + 1];
            }

            for (i = 0, j = 0, k = left; k <= right; k++){

                //conditionals to order input array & track inversions
                if (i == n1){

                    array[k] = rArray[j++];
                }
                else if (j == n2){

                    array[k] = lArray[i++];
                }
                else if (lArray[i] <= rArray[j]){
                    array[k] = lArray[i++];
                }
                else{
                    array[k] = rArray[j++];
                    inversions += n1 - i;
                }
            }

            return inversions; // return inversion count
        }


        // Simple inversion counter
        private static int getInvCountnSqr(int[] array){

            int iCount = 0;

            //Step through all indexes
            for (int i = 0; i < array.Length - 1; i++){

                //step through all indexes greater than current
                for (int j = i + 1; j < array.Length; j++){


                    //if greater counter + 1
                    if (array[i] > array[j]){

                        iCount++;
                    }
                }
            }
            return iCount;
        }
    }
}
