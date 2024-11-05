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

        public static int[] GenerateBinaryArray(int n, int numberOfTapPoints = 0)
        {
            Random rnd = new Random();
            int[] arr = new int[n + 1];
            arr[0] = arr[n] = 1;
            if (numberOfTapPoints == 0)
            {
                for (int i = 1; i < n; i++)
                    arr[i] = rnd.Next(2);
            }
            else
            {
                bool toBeReversed = false;

                if (numberOfTapPoints > n / 2)
                {
                    numberOfTapPoints = n - numberOfTapPoints;
                    toBeReversed = true;
                }
                for (int i = 1; i < n; i++)
                    arr[i] = 0;
                HashSet<int> tapPointSet = new HashSet<int>();

                while (tapPointSet.Count < numberOfTapPoints - 2)
                {
                    int tapPoint = rnd.Next(1, n);
                    if (!tapPointSet.Contains(tapPoint))
                    {
                        arr[tapPoint] = 1;
                        tapPointSet.Add(tapPoint);
                    }
                }

                if (toBeReversed)
                    for (int i = 1; i < n; i++)
                        arr[i] = (arr[i] + 1) % 2;
            }
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

        public static ulong PolynomialToInt(int[] poly)
        {
            ulong result = 0;
            for (int i = 0; i < poly.Length; i++)
            {
                if (poly[i] != 0)
                {
                    result |= (ulong)1 << i;
                }
            }
            return result;
        }
        public static List<int> FindDivisors(int n)
        {
            List<int> divisors = new List<int>();
            int limit = (int)Math.Sqrt(n);
            for (int i = 1; i <= limit; i++)
            {
                if (n % i == 0)
                {
                    divisors.Add(i);
                    divisors.Add(n / i);
                }
            }
            return divisors;
        }
        
        public static List<long> GetDivisors(long value=0)
        {
             if(value==0)
                return new List<long>(){1, 3, 5, 15, 17, 51, 85, 255, 257, 641, 771, 1285, 1923, 3205, 3855, 4369,
            9615, 10897, 13107, 21845, 32691, 54485, 65535, 65537, 163455, 164737, 196611, 327685, 494211, 823685, 983055,
            1114129, 2471055, 2800529, 3342387, 5570645, 6700417, 8401587, 14002645, 16711935, 16843009, 20101251, 33502085,
            42007935, 42009217, 50529027, 84215045, 100506255, 113907089, 126027651, 210046085, 252645135, 286331153, 341721267,
            569535445, 630138255, 714156689, 858993459, 1431655765, 1708606335, 1722007169, 2142470067, 3570783445, 4294967295,
            4294967297, 5166021507, 8610035845, 10712350335, 10796368769, 12884901891, 21474836485, 25830107535, 29274121873,
            32389106307, 53981843845, 64424509455, 73014444049, 87822365619, 146370609365, 161945531535, 183538269073, 219043332147,
            365072220245, 439111828095, 439125228929, 550614807219, 917691345365, 1095216660735, 1103806595329, 1317375686787,
            2195626144645, 2753074036095, 3311419785987, 5519032976645, 6586878433935, 7465128891793, 16557098929935,
            18764712120593, 22395386675379, 37325644458965, 56294136361779, 93823560602965, 111976933376895, 112855183834753,
            281470681808895, 281479271743489, 338565551504259, 564275919173765, 844437815230467, 1407396358717445, 1692827757521295,
            1918538125190801, 4222189076152335, 4785147619639313, 5755614375572403, 9592690625954005, 14355442858917939,
            23925738098196565, 28778071877862015, 71777214294589695, 72340172838076673, 217020518514230019, 361700864190383365,
            1085102592571150095, 1229782938247303441, 3689348814741910323, 6148914691236517205 };
            else
            {
                List<long> factorList = new List<long>();
                long limit = (long)Math.Sqrt(value) + 1;
                for (long i = 2; i < limit; i++)
                {
                    if (value % i == 0)
                    {
                        factorList.Add(i);
                        factorList.Add(value / i);
                    }
                }

                return factorList;
            }
        }
    }
}
