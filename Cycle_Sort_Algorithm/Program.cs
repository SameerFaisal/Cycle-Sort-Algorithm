using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycle_Sort_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t  xx====== Cycle Sort Algorithm ======xx\n");
            Console.WriteLine("\n\t\t\t\txx====== Made by: ======xx\n");
            Console.WriteLine("\t\t\t\t Sameer Faisal (17B-129-SE)\n\t\t\t\tAbdul Rehman Shaikh (17B-067-SE)\n\t\t\t\t Usman Saeed (17B-079-SE)\n");
            // Asking the user to enter how many values to sort
            Console.WriteLine("How many values you want to get sorted??");
            int NumOfValues = Convert.ToInt16(Console.ReadLine());
            //Array declaration
            int[] Values =new int[NumOfValues];
            //Storing length of the array
            int n = NumOfValues;
            // Taking unsorted array as input
            Console.WriteLine("Enter the values: ");
            for (int a = 0; a < n; a++)
            {
               Console.Write("[{0}]: ",a+1);
                Values[a] = Convert.ToInt32(Console.ReadLine());
            }

                Console.WriteLine("Unsorted Elements:");
            //Traversing the unsorted array
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0}: {1}", i+1, Values[i]);
            }
            CycleSort cs = new CycleSort();
            cs.cycleSort(Values, n);
            Console.WriteLine("Sorted Elements:");
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine("{0}: {1}", j+1, Values[j]);
            }
        }
        public class CycleSort
        {
            //Function sorting the array using cycle sort
            public void cycleSort(int[] Values, int n)
            {
                //Index where swapping is done
                int writes = 0;
                //Main loop
                //Traversing array elements to sort them
                for (int cycle_start = 0; cycle_start <= n - 2; cycle_start++)
                {
                    //Initialize the element as starting point
                    //It whill change iteration to iteration
                    int element = Values[cycle_start];
                    // Find correct postion of the values.  
                    // We count the elements smaller than the starting element 
                    int location = cycle_start;
                    for (int i = cycle_start + 1; i < n; i++)
                        if (Values[i] < element)
                            location++;
                    // If the value is in the correct position
                    if (location == cycle_start)
                        continue;
                    // Ignoring the duplicate elements
                    while (element == Values[location])
                        location++;
                    // Put the element to it's right position
                    // Through swapping
                    if (location != cycle_start)
                    {
                        int temp = element;
                        element = Values[location];
                        Values[location] = temp;
                        writes++;
                    }
                    // Rotation of the cycle
                    while (location != cycle_start)
                    {
                        location = cycle_start;
                        // Find the location where we put the element
                        for (int i = cycle_start + 1; i < n; i++)
                            if (Values[i] < element)
                                location++;
                        // Ignoring the duplicate elements

                        while (element == Values[location])
                            location++;
                        // Put the element to it's right position
                        // Through swapping
                        if (element != Values[location])
                        {
                            int temp = element;
                            element = Values[location];
                            Values[location] = temp;
                            writes++;
                            Console.WriteLine("Swapping is done on index[{0}]", writes);
                        }     
                    }
                }
            }
        }
    }
}
