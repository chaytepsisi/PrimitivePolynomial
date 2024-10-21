using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitivePolynomialGenerator
{
    internal class Commons
    {

        public static int[] ONE_POLYNOMIAL=new int[]{1};
        public static string PolynomialArrToString(int[] poly)
        {
            StringBuilder polyString = new StringBuilder("");
            for (int i = poly.Length-1; i > -1; i--)
            {
                if (i == 0)
                    polyString.Append(" + " + poly[i]);
                
                else
                {
                    if (poly[i] != 0) {
                        if (i != poly.Length - 1)
                            polyString.Append(" + ");
                        if (i==1)
                            polyString.Append("x" );
                        else polyString.Append("x^"+i);
                    }
                }
            }
            return polyString.ToString();
        }

        public static int[] CopyArray(int[] arr)
        {
            int[] copyPolynomial = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                copyPolynomial[i] = arr[i];

            return copyPolynomial;
        }

        public static int[] GenerateBinaryArray(int n)
        {
            Random rnd = new Random();
            int[] arr = new int[n + 1]; 
            for (int i = 1; i < n; i++)
                arr[i] = rnd.Next(2);
            arr[0] = arr[n] = 1;
            return arr;
        }

        public static string PrintArray(int[] arr )
        {
            string arrStr = "";
            for (int i = 0; i < arr.Length; i++)
                arrStr += arr[i];
            return arrStr;
        }

        public static string MilliSecondsToTimeStr(long ms)
        {
            int seconds = (int)ms / 1000;
            int hours = seconds / 3600;
            seconds %= 3600;
            int minutes = seconds / 60;
            seconds %= 60;
            return hours+"H " + minutes + "m " + seconds + "s";
        }

        public static int[] GetRow(int[,] matrice, int index)
        {
            int[] row=new int[matrice.GetLength(1)];
            for (int i = 0; i < row.Length; i++)
                row[i] = matrice[index, i];
            return row;
        }
        public static bool IsZeroPolynomial(int[] poly)
        {
            for (int i = 0; i < poly.Length; i++)
                if (poly[i] != 0)
                    return false;
            return true;
        }

        public static int[] SquareRootPoly(int[] poly)
        {
            int[] sqrt = new int[(poly.Length + 2) / 2];
            for (int i = 0; i < sqrt.Length; i++)
                sqrt[i] = poly[2*i];
            return sqrt;
        }

        public static void PrintMatrix(int[,] matrice, string name)
        {
            StreamWriter streamWriter = new StreamWriter(name + ".txt");
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                    streamWriter.Write(matrice[i, j] + " ");
                streamWriter.WriteLine();   
            }
            streamWriter.Flush();
            streamWriter.Close();

        }
    }
}
