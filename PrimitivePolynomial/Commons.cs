using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitivePolynomial
{
    internal class Commons
    {
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
    }
}
