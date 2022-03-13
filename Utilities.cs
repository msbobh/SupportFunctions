using System;
using Accord.Math;
using System.Linq;
using System.IO;
using Accord.Neuro;

namespace Functions
{
    public class Util_Methods
    {
        static public int[] Predict(in double[][] input, Accord.Neuro.ActivationNetwork network)
        {
            double[][] predicted = new double[input.Length][];

            for (int i = 0; i <= input.Length - 1; i++)
            {
                predicted[i] = network.Compute(input[i]);
            }
            int[] intPredicted = new int[predicted.Length];
            for (int i = 0; i <= predicted.Length - 1; i++)
            {
                if (predicted[i][0] < 0.5)
                    intPredicted[i] = 0;
                else
                    intPredicted[i] = 1;
            }
            return intPredicted;
        }

        static public int[] Predict(in double[][] input, Accord.Neuro.Networks.DeepBeliefNetwork network)
        {
            double[][] predicted = new double[input.Length][];

            for (int i = 0; i <= input.Length - 1; i++)
            {
                predicted[i] = network.Compute(input[i]);
            }
            int[] intPredicted = new int[predicted.Length];
            for (int i = 0; i <= predicted.Length - 1; i++)
            {
                if (predicted[i][0] < 0.5)
                    intPredicted[i] = 0;
                else
                    intPredicted[i] = 1;
            }
            return intPredicted;
        }

        /*
         * Routines for processing data files, Converting from Matrices to (jagged array Matrices)
         * 
         */

        static public double[][] convertToJaggedArray(double[,] multiArray)
        {
            int numOfColumns = multiArray.Columns();
            int numOfRows = multiArray.Rows();

            double[][] jaggedArray = new double[numOfRows][];

            for (int r = 0; r < numOfRows; r++)
            {
                jaggedArray[r] = new double[numOfColumns];
                for (int c = 0; c < numOfColumns; c++)
                {
                    jaggedArray[r][c] = multiArray[r, c];
                }
            }

            return jaggedArray;
        }

        static public int[] convetToJaggedArray(double[,] inputmatrix)
        {
            int numOfRows = inputmatrix.Rows();
            int[] converted = new int[numOfRows];
            for (int r = 0; r < numOfRows; r++)
            {
                converted[r] = (int)inputmatrix[r, 0];
            }
            return converted;
        }

        static public int[] BoolToInt(bool[] input)
        {
            int[] result = new int[input.Rows()];
            int count = 0;
            foreach (var value in input)
            {
                result[count] = Convert.ToInt32(value);
                count++;
            }

            return result;
        }

        static public double[,] converRowtoColumn(double[] input)
        {
            double[,] done = new double[input.Length, 1];
            for (int i = 0; i < input.Length; i++)
            {
                done[i, 0] = input[i];

            }
            return done;
        }

        static public int parseCommandLine(string[] cLine, int maxArgs, int minArgs)
        {
            int numArgs = cLine.Length;
            if (numArgs > maxArgs | numArgs < minArgs)
            {
                return 0;
            }
            switch (numArgs)
            {
                case 1:
                    return 1;

                case 2:
                    return 2;
                case 3:
                    return 3;
                case 4:
                    return 4;

                default:
                    return 0;

            }

        }

        static public bool checkFile(string fname)
        {
            try
            {
                FileStream fs = File.Open(fname, FileMode.Open, FileAccess.Write, FileShare.None);
                fs.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        static public double CalculateAccuraccy(int[] labels, int[] Predictions)
        {

            int index = 0;
            double subtotal = 0;
            foreach (var result in Predictions)
            {
                if (result == labels[index])
                {
                    subtotal = subtotal + 1;
                }
                index++;
            }

            double Accuracy = subtotal / Predictions.Count();
            return Accuracy;
        }

        static public void Printcolor(int value, ConsoleColor color, bool addpercent)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            if (!addpercent)
                Console.WriteLine(value);
            else
                Console.WriteLine("{0}%", value);
            Console.ForegroundColor = originalColor;
        }
        static public void Printcolor(double value, ConsoleColor color, bool addpercent)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            if (!addpercent)
                Console.WriteLine(value);
            else
                Console.WriteLine("{0}%", value);
            Console.ForegroundColor = originalColor;
        }

        static public void Printcolor(string value, ConsoleColor color)
        {
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = originalColor;
        }
    }
}
