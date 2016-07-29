/* 
 * @auth Steven J Carver
 * 
 * generic radix sort for strings and ints
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRadix
{
    class Program
    {
        static void Main(string[] args){

            int[] l1 = new int[] { 123, 151, 234, 701, 181, 401, 924, 155, 233, 456, 735, 412, 6 };
            int[] l2 = new int[] { 100, 191, 101, 192, 222, 245, 222, 235 };
            string[] l3 = new string[] { "MEL", "TOD", "TOM", "JAC", "CUB", "KOB", "KID", "PLY", "MIC", "ABC" };

            int[] resultsl1 = radixSort(l1, 3);
            Console.Out.WriteLine("\n");
            Console.Out.Write("Radix Sort list 1: ");
            foreach (var e in resultsl1){
                Console.Out.Write(e + " ");
            }

            int[] resultsl2 = radixSort(l2, 3);
            Console.Out.WriteLine("\n");
            Console.Out.Write("Radix Sort list 2: ");
            foreach (var e in resultsl2){
                Console.Out.Write(e + " ");
            }

            string[] resultsl3 = radixSort(l3, 3);
            Console.Out.WriteLine("\n");
            Console.Out.Write("Radix Sort list 3: ");
            foreach (var e in resultsl3){
                Console.Out.Write(e + " ");
            }

            Console.Out.WriteLine("\n");
            Console.ReadLine();
            
        }
        //radixSort for int[] 
        public static int[] radixSort(int[] array, int dimension){

            bool toEnd = true;
            record[] toPass = new record[array.Length]; // use precreated struct
            int[] toReturn = new int[array.Length]; //value to return

            //Iterate through all values and add record in struct array
            for (int i = 0; i < array.Length; i++){

                toPass[i] = new record();
                toPass[i].Key = i;
                toPass[i].Value = (array[i] / dimension) % 10;
                if (array[i] / dimension != 0){
                    toEnd = false;
                }
            }

            if (toEnd){

                return array;
            }
            //Implement countingSort
            record[] SortedDigits = CountingSort(toPass);

            //Iterate through returned array and assign values to array to be returned
            for (int i = 0; i < toReturn.Length; i++){

                toReturn[i] = array[SortedDigits[i].Key];
            }
            return radixSort(toReturn, dimension * 10);
        }

        //radixSort for string[] 
        public static string[] radixSort(string[] sArray, int dimension){

            bool toEnd = true;
            record[] toPass = new record[sArray.Length]; // use precreated struct
            string[] toReturn = new string[sArray.Length]; //value to return
            // Starting at d and iterating backwards
            for (int i = dimension; i > 0; i--){

                //Convert each string at a given position to a char[] then pull the specific char located at i
                for (int x = 0; x < sArray.Length; x++){

                    char[] c = sArray[x].ToCharArray();
                    toPass[x] = new record();
                    toPass[x].Key = x;
                    toPass[x].Value = (((int)c[i - 1] - 64) / dimension) % 10;
                    if ((((int)c[i - 1] - 64) / dimension) != 0){
                        toEnd = false;
                    }

                }
                if (toEnd){

                    return sArray;
                }
                //Implement countingSort
                record[] SortedDigits = CountingSort(toPass);

                for (int x = 0; x < sArray.Length; x++){

                    toReturn[x] = sArray[SortedDigits[x].Key];
                }
            }
            return toReturn;
        }

        // Basic counting sort for created struct
        public static record[] CountingSort(record[] A){

            int[] B = new int[MaxValue(A) + 1];
            record[] C = new record[A.Length];

            for (int i = 0; i < B.Length; i++)
                B[i] = 0;

            for (int i = 0; i < A.Length; i++)
                B[A[i].Value]++;

            for (int i = 1; i < B.Length; i++)
                B[i] += B[i - 1];

            for (int i = A.Length - 1; i >= 0; i--){

                int value = A[i].Value;
                int index = B[value];
                B[value]--;
                C[index - 1] = new record();
                C[index - 1].Key = i;
                C[index - 1].Value = value;
            }
            return C;
        }

        // Finding max value in array
        static int MaxValue(record[] array){

            int Max = array[0].Value;
            for (int i = 1; i < array.Length; i++){

                if (array[i].Value > Max){

                    Max = array[i].Value;
                }
            }
            return Max;
        }

    }

    //struct for int/string manipulation
    struct record{

        int key;
        int value;

        public int Key{

            get{
                return key;
            }
            set{
                key = value;
            }
        }

        public int Value{
            
            get{
                return value;
            }
            set{
                this.value = value;
            }
        }
    }
}