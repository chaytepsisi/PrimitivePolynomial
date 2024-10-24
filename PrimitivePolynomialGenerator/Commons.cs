using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PrimitivePolynomialGenerator
{
    internal class Commons
    {

        public static int[] ONE_POLYNOMIAL = new int[] { 1 };
        public static Regex HexRegex = new Regex(@"[2-9A-Fa-f]+");
        public static string PolynomialArrToString(int[] poly)
        {
            StringBuilder polyString = new StringBuilder("");
            for (int i = poly.Length - 1; i > -1; i--)
            {
                if (i == 0 && poly[i]==1)
                    polyString.Append(" + " + poly[i]);

                else
                {
                    if (poly[i] != 0)
                    {
                        if (i != poly.Length - 1 || i != poly.Length - 1)
                            polyString.Append(" + ");
                        if (i == 1)
                            polyString.Append("x");
                        else polyString.Append("x^" + i);
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

        public static string PrintArray(int[] arr)
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
            return hours + "H " + minutes + "m " + seconds + "s";
        }

        public static int[] GetRow(int[,] matrice, int index)
        {
            int[] row = new int[matrice.GetLength(1)];
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
                sqrt[i] = poly[2 * i];
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

        public static void PrintMatrixRows(int[,] matrice, string name)
        {
            StreamWriter streamWriter = new StreamWriter(name + ".txt");
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                int[] tempPoly = new int[matrice.GetLength(1)];
                for (int j = 0; j < matrice.GetLength(1); j++)
                    tempPoly[j] = matrice[i, j];
                streamWriter.WriteLine(PolynomialArrToString(tempPoly));
            }

            streamWriter.Flush();
            streamWriter.Close();

        }

        public static void ReverseMatrixRows(int[,] matrice)
        {
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                int[] tempPoly = new int[matrice.GetLength(1)];
                for (int j = 0; j < matrice.GetLength(1); j++)
                    tempPoly[j] = matrice[i, j];
                tempPoly = tempPoly.Reverse().ToArray();
                for (int j = 0; j < matrice.GetLength(1); j++)
                    matrice[i, j] = tempPoly[j];
            }
        }

        public static int[,] TransposeMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int[,] transposed = new int[cols, rows];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    transposed[j, i] = matrix[i, j];

            return transposed;
        }

        public static double[,] ConvertToDoubleMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            double[,] converted = new double[cols, rows];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    converted[i, j] = (double)matrix[i, j];

            return converted;
        }

        public static HashSet<double> NoSums(HashSet<double> distincts)
        {
            List<double> result = distincts.OrderBy(x => x).ToList();
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = i + 1; j < result.Count; j++)
                    for (int t = j; t < result.Count; t++)
                        if (result[i] == result[j] + result[t])
                        {
                            result.RemoveAt(i);
                            j--;
                            i--;
                            break;
                        }
            }
            return result.ToHashSet<double>();
        }

        public static int[,] GenerateIdentityMatrix(int n)
        {
            int[,] temp = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        temp[i, j] = 1;
                    else temp[i, j] = 0;
                }
            }
            return temp;
        }

        public static string BinaryStringToHexString(string binary)
        {
            if (string.IsNullOrEmpty(binary))
                return binary;

            StringBuilder result = new StringBuilder(binary.Length / 4 + 1);

            int mod4Len = binary.Length % 4;
            if (mod4Len != 0)
            {
                // pad to length multiple of 8
                binary = binary.PadLeft(((binary.Length / 4) + 1) * 4, '0');
            }

            for (int i = 0; i < binary.Length; i += 4)
            {
                string eightBits = binary.Substring(i, 4);
                result.AppendFormat("{0:X}", Convert.ToByte(eightBits, 2));
            }

            return result.ToString();
        }

        public static string HexStringToIntArray(string hexStr)
        {
            var str = String.Join(String.Empty, hexStr.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            char[] charArray = str.ToCharArray();
            int firstIndex = Array.IndexOf(charArray, '1');
            charArray = charArray.Skip(firstIndex).ToArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}