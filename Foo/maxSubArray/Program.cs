/* 
 * @auth Steven J Carver
 * 
 * Determine the max value of a continuous subarray
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxSubArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int x = contSubArray(array);

            Console.WriteLine(x);
            Console.ReadLine();
        }

        public static int contSubArray(int[] array)
        {

            //Base case 
            if (array.Length < 1){

                return 0;
            }
            if (array.Length < 2){

                return array[0];
            }

            //initial max value
            int max = array[0];

            //Iteriate through for each available index
            for (int i = 0; i < array.Length; i++){

                int sum = 0; // sum for current subarray

                //Iteriate through from i and determine sum of current subarray
                for (int j = i; j < array.Length; j++){

                    sum += array[j];

                    //If sum greater than current max switch values and proceed
                    if (sum > max){

                        max = sum;
                    }
                }
            }
            return max;

        }
    }
}
