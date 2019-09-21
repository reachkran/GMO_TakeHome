using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeekClosestToAvge
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test cases
            //int[] arrayList = { 1, 2, 3, 5, -1, 7, 145, -33, 22, 14 };
            int[] arrayList = { 8,33,22,9,44,33,-7 };

            int result = GetClosestValue(arrayList);

        }
        public static int GetClosestValue(int[] array)
        {
            int val = 0;
            try
            {
                int sum = 0, avge = 0, temp;
                int len = array.Length - 1;
                

                for (int i = 0; i < len; i++)
                {
                    sum += array[i];
                }
                avge = sum / array.Length;

                //using LINQ
                //array = array.OrderByDescending(c => c).ToArray();

                //sort array
                for (int k = 0; k < len; k++)
                {
                    for (int j = k+1; j < array.Length; j++)
                    {
                        if (array[k] > array[j])
                        {
                            temp = array[j];
                            array[j] = array[k];
                            array[k] = temp;
                        }
                    }

                }
                val = GetValue(array, avge);
                Console.WriteLine(val);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception occured {0}", ex.Message));
            }

            return val;
        }
        public static int GetValue(int[] arr, int key)
        {
            int low = 0, high = arr.Length;
             
            int mid = 0;

            //Base cases 
            if (key <= arr[0])
                return arr[0];
            if (key >= arr[arr.Length - 1])
                return arr[arr.Length - 1];

            //search for closest value
                while(low<high)
                {
                    mid = (low + high) / 2;

                    if (key < arr[mid])
                    {
                         if(mid >0 && key> arr[mid-1])
                         {
                             return GetResult(arr[mid - 1], arr[mid], key);
                         }
                         high = mid;
                    }
                    else
                    {
                        if(mid < high && key < arr[mid+1])
                        {
                            return GetResult(arr[mid], arr[mid + 1], key);
                        }
                        low = mid + 1;
                    }
                    
                }
                return arr[mid];
        }
        public static int GetResult(int val1, int val2, int searchKey)
        {
            if (searchKey - val1 >= val2 - searchKey)
                return val2;
            else
                return val1;
        }
    }
}
