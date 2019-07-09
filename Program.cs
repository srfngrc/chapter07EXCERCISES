using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter07Excercises
{
    //Exercise1 Ch07Ex01
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        int[] testArray = { 4, 7, 4, 2, 7, 3, 7, 8, 3, 9, 1, 9 };
    //        int[] maxValIndices;
    //        int maxVal = Maxima(testArray, out maxValIndices);
    //        Console.WriteLine("Maximum value {0} found at element indices:",maxVal);
    //        while (true)
    //        {
    //            Console.WriteLine("Simulating operation taking long time");
    //            System.Threading.Thread.Sleep(1000);
    //        }
    //        //foreach (int index in maxValIndices)
    //        //{
    //        //    Console.WriteLine(index);
    //        //}
    //        //Console.ReadKey();
    //    }
    //    static int Maxima(int[] integers, out int[] indices)
    //    {
    //        Debug.WriteLine("Maximum value search started.");
    //        indices = new int[1];
    //        int maxVal = integers[0];
    //        indices[0] = 0;
    //        int count = 1;
    //        Debug.WriteLine(string.Format(
    //        "Maximum value initialized to {0}, at element index 0.", maxVal));
    //        for (int i = 1; i < integers.Length; i++)
    //        {
    //            Debug.WriteLine(string.Format(
    //            "Now looking at element at index {0}.", i));
    //            if (integers[i] > maxVal)
    //            {
    //                maxVal = integers[i];
    //                count = 1;
    //                indices = new int[1];
    //                indices[0] = i;
    //                Debug.WriteLine(string.Format(
    //                "New maximum found. New value is {0}, at element index {1}.",maxVal, i));
    //            }
    //            else
    //            {
    //                if (integers[i] == maxVal)
    //                {
    //                    count++;
    //                    int[] oldIndices = indices;
    //                    indices = new int[count];
    //                    oldIndices.CopyTo(indices, 0);
    //                    indices[count - 1] = i;
    //                    Debug.WriteLine(string.Format(
    //                    "Duplicate maximum found at element index {0}.", i));
    //                }
    //            }
    //        }
    //        Trace.WriteLine(string.Format(
    //        "Maximum value {0} found, with {1} occurrences.", maxVal, count));
    //        Debug.WriteLine("Maximum value search completed.");
    //        return maxVal;
    //    }
    //}

    //Ch07Ex02
    class Program
    {
        static string[] eTypes = { "none", "simple", "index", "nested index" };
        static void Main(string[] args)
        {
            foreach (string eType in eTypes)
            {
                try
                {
                    Console.WriteLine("Main() try block reached."); // Line 19
                    Console.WriteLine("ThrowException(\"{0}\") called.", eType);
                    ThrowException(eType);
                    Console.WriteLine("Main() try block continues."); // Line 22
                }
                catch (System.IndexOutOfRangeException e) // Line 24
                {
                    Console.WriteLine("Main() System.IndexOutOfRangeException catch"
                    + " block reached. Message:\n\"{0}\"",
                    e.Message);
                }
                catch // Line 30
                {
                    Console.WriteLine("Main() general catch block reached.");
                }
                finally
                {
                    Console.WriteLine("Main() finally block reached.");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void ThrowException(string exceptionType)
        {
            Console.WriteLine("ThrowException(\"{0}\") reached.", exceptionType);
            switch (exceptionType)
            {
                case "none":
                    Console.WriteLine("Not throwing an exception.");
                    break; // Line 50
                case "simple":
                    Console.WriteLine("Throwing System.Exception.");
                    throw new System.Exception(); // Line 53
                case "index":
                    Console.WriteLine("Throwing System.IndexOutOfRangeException.");
                    eTypes[4] = "error"; // Line 56
                    break;
                case "nested index":
                    try // Line 59
                    {
                        Console.WriteLine("ThrowException(\"nested index\") " +
                        "try block reached.");
                        Console.WriteLine("ThrowException(\"index\") called.");
                        ThrowException("index"); // Line 64
                    }
                    catch // Line 66
                    {
                        Console.WriteLine("ThrowException(\"nested index\") general"
                        + " catch block reached.");
                    }
                    finally
                    {
                        Console.WriteLine("ThrowException(\"nested index\") finally"
                        + " block reached.");
                    }
                    break;
            }
        }
    }
}


