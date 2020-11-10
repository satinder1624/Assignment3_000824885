﻿using System;
using System.Collections.Generic;
/*
 * Satinder Singh, 000824885
 * 10-11-2020
 * Statement of AuthorShip: This work is only done by me.
*/
namespace COMP10066_Lab3
{
    /**
     * Library of statistical functions using Generics for different statistical
     * calculations.
     * 
     * see http://www.calculator.net/standard-deviation-calculator.html
     * for sample standard deviation calculations
     *
     * @author Joey Programmer
     */

    /// <summary>
    /// This class contain the main method and methods which return sum,average,median and SD.
    /// </summary>
    public class Assignment3
    {
        
        /// <summary>
        /// This method return the Average of list elements in listData.
        /// </summary>
        public static double Average(List<double> x, bool incneg)
        {
            
            
            double s = Sum(x, incneg);
            
            int c = 0; //This variable stores the length of listData (list)
            for (int i = 0; i < x.Count; i++)
            {
                if (incneg || x[i] >= 0)
                {
                    c++;  //Increment whenever loop executes
                }
            }
            
            if (c == 0)
            {
                throw new ArgumentException("no values are > 0");
            }
            
            return s / c;
            //return average by diving sumOfList/count
        }

        /// <summary>
        /// This method return the Sum of elements which is in listData as list.
        /// </summary>
        public static double Sum(List<double> x, bool incneg)
        {
            if (x.Count < 0) //This block execute when list contain less than zero elements.
            {
                throw new ArgumentException("x cannot be empty"); //A exception will throw then.
            }

            double sum = 0.0;  //A sum variable is used to store the value of sum pf list elements with the help of foreach loop.
            foreach (double val in x)
            {
                if (incneg || val >= 0) //This block execute when either incneg or value must have to be true.
                {
                    sum += val; //Every time when value grater than zero then it add to sum
                }
            }
            return sum;  //return sum
        }

        /// <summary>
        /// This method return the Median of elements which is in listData as list.
        /// </summary>
        public static double Median(List<double> data)
        { 
            if (data.Count == 0)   //This block execute when list has 0 element
            {
                throw new ArgumentException("Size of array must be greater than 0");  //It throws an exception
            }

            data.Sort();  //This method sort the list in ascending order.

            double median = data[data.Count / 2];  //A median is calulated by getting that value which is at middle if the count is odd then only and store in median double type variable.
            if (data.Count % 2 == 0) //This block executes when list have a even count
                median = (data[data.Count / 2] + data[data.Count / 2 - 1]) / 2;  //This gets the avergae of middle elements from both sides and stored in middle variable

            return median;  //return median
        }

        /// <summary>
        /// This method return the Standard Deviation of elements which is in listData as list.
        /// </summary>
        public static double SD(List<double> data)
        {
            if (data.Count <= 1) //This block executes when list contain less than 2 elements
            {
                throw new ArgumentException("Size of array must be greater than 1"); //It throws a exception
            }

            int n = data.Count;  // A variable which store the length of list
            double s = 0;  //A variable to store sum of data values.
            double a = Average(data, true);  //A variable store the return average value from Average function

            for (int i = 0; i < n; i++)
            {
                double v = data[i];  // Store the value of list elements one by one.
                s += Math.Pow(v - a, 2);
            }
            double stdev = Math.Sqrt(s / (n - 1)); //calculate the Standard Deviation by squaring and store in standardDeviation double type variable.
            return stdev; //return standardDeviation
        }

        // Simple set of tests that confirm that functions operate correctly

        /// <summary>
        /// This is a Main Method from where program call other methods
        /// </summary>
        static void Main(string[] args)
        {
            List<Double> testDataD = new List<Double> { 2.2, 3.3, 66.2, 17.5, 30.2, 31.1 }; //A list of type double wihch is used to store a list of double elements in it.

            Console.WriteLine("The sum of the array = {0}", Sum(testDataD, true));  //This line print the statement as well as call the Sum function which contain testData(list) and true(flag) as parameter.

            Console.WriteLine("The average of the array = {0}", Average(testDataD, true)); //This line print the statement as well as call the Average function which contain testData(list) and true(flag) as parameter.

            Console.WriteLine("The median value of the Double data set = {0}", Median(testDataD)); //This line print the statement as well as call the Median function which contain testData(list) as parameter.

            Console.WriteLine("The sample standard deviation of the Double test set = {0}\n", SD(testDataD)); //This line print the statement as well as call the StandardDeviation function which contain testData(list) as parameter.
        }
    }
}
