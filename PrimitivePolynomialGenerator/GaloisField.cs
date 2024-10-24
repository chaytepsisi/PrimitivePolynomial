using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimitivePolynomialGenerator
{
    class GaloisField
    {
        //private readonly int degree;
        //private int[] polynomial;

        public bool IsIrreducible { get; set; }
        public int[] Divisor { get; set; }

        int[,] identityMatrix;

        public GaloisField()
        {
            //degree = deg;
            //polynomial = poly;
            IsIrreducible = false;
            Divisor = new int[0];
        }

        // Multiply two polynomials in GF(2)
        public int[] Multiply(int[] a, int[] b)
        {
            int[] result = new int[a.Length + b.Length - 1];
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < b.Length; j++)
                {
                    result[i + j] ^= a[i] * b[j]; // XOR for addition in GF(2)
                }
            }
            return result;
        }

        // Modular reduction of the polynomial over GF(2^m)
        public int[] ModReduce(int[] polinom, int[] modPoly)
        {
            int[] poly = (int[])polinom.Clone(); // Clone to avoid modifying the original poly
            int polyDeg = poly.Length - 1;
            while (polyDeg >= modPoly.Length - 1)
            {
                if (poly[polyDeg] == 1)
                {
                    for (int i = 0; i < modPoly.Length; i++)
                    {
                        poly[polyDeg - i] ^= modPoly[modPoly.Length - 1 - i];
                    }
                }
                polyDeg--;
            }
            // Trim leading zeros
            int newLen = poly.Length;
            while (newLen > 1 && poly[newLen - 1] == 0) newLen--;
            int[] result = new int[newLen];
            Array.Copy(poly, result, newLen);
            return result;
        }

        // Modular exponentiation in GF(2^m)
        private int[] ModExp(int[] basePoly, int exp, int[] modPoly)
        {
            int[] result = { 1 }; // Start with polynomial '1'
            int[] basePower = (int[])basePoly.Clone(); // Clone to avoid modification

            while (exp > 0)
            {
                if ((exp & 1) == 1) // If the exponent bit is set
                {
                    result = ModReduce(Multiply(result, basePower), modPoly);
                }
                basePower = ModReduce(Multiply(basePower, basePower), modPoly);
                exp >>= 1;
            }
            return result;
        }

        // GCD of two polynomials over GF(2)
        public int[] GCD(int[] a, int[] b)
        {
            while (b.Length > 1 || b[0] != 0)
            {
                int[] temp = ModReduce(a, b);
                a = b;
                b = temp;
            }
            return a.ToArray();
        }

        // Check if a polynomial is irreducible over GF(2)
        public bool IsIrreduciblePoly(int[] polinom)
        {
            var factors = BerlekampFactorization(polinom);
            if (factors.Count == 1)
                return true; // Irreducible
            else
            {
                Divisor = factors[0];
                return false; // Irreducible
            }
            // Generate all polynomials of degree <= degree/2
            /*for (int d = 1; d <= degree / 2; d++)
            {
                List<int[]> lowerDegreePolynomials = GeneratePolynomials(d);
                foreach (var poly in lowerDegreePolynomials)
                {
                    if (ModReduce((int[])polinom.Clone(), poly).Length == 1 && ModReduce((int[])polinom.Clone(), poly)[0] == 0)
                    {
                        divisor = poly;
                        return false; // Polynomial is divisible by a smaller degree polynomial
                    }
                }
            }
            return true; // Irreducible
            */

        }

        // Find divisors of a number
        private List<int> FindDivisors(int n)
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

        // Check if the polynomial is primitive over GF(2^m)
        public bool IsPrimitive(int[] polinom)
        {
            int m = polinom.Length - 1;

            // Check if the polynomial is irreducible first
            if (!IsIrreduciblePoly(polinom))
            {
                return false; // Not primitive if not irreducible
            }

            IsIrreducible = true;
            // Now check for primitivity: order should be 2^m - 1
            int order = (1 << m) - 1; // 2^m - 1

            // Find all divisors of the order
            List<int> divisors = FindDivisors(order);

            // Check for each divisor whether x^d ≡ 1 (mod p(x)) for any divisor < 2^m - 1
            foreach (int d in divisors)
            {
                if (d < order)
                {
                    int[] modExpResult = ModExp(new int[] { 0, 1 }, d, (int[])polinom.Clone());
                    if (modExpResult.Length == 1 && modExpResult[0] == 1)
                    {
                        return false; // Not primitive if x^d ≡ 1 for any divisor d < 2^m - 1
                    }
                }
            }

            // If no such d was found, the polynomial is primitive
            return true;
        }

        // Polynomial division over GF(2)
        public (int[] quotient, int[] remainder) PolynomialDivide(int[] dividend, int[] divisor)
        {
            int[] quotient = new int[dividend.Length - divisor.Length + 1];
            int[] remainder = (int[])dividend.Clone();

            for (int i = dividend.Length - 1; i >= divisor.Length - 1; i--)
            {
                if (remainder[i] == 1)
                {
                    quotient[i - divisor.Length + 1] = 1;
                    for (int j = 0; j < divisor.Length; j++)
                    {
                        remainder[i - j] ^= divisor[divisor.Length - 1 - j];
                    }
                }
            }
            return (quotient, remainder);
        }

        public int[] IsSquareFree(int[] polinom)
        {
            var derivative = new int[polinom.Length - 1];
            for (int i = 0; i < derivative.Length; i++)
            {
                derivative[i] = polinom[i + 1] * (i + 1) % 2; ;
            }

            if (Commons.IsZeroPolynomial(derivative))
            {
                return Commons.SquareRootPoly(polinom);
            }

            return GCD(polinom, derivative);
        }

        // Solve the linear system using Berlekamp's algorithm to factorize polynomials
        public List<int[]> BerlekampFactorization(int[] polinom)
        {
            List<int[]> factors = new List<int[]>();

            var gcdDerivative = IsSquareFree(polinom);
            if (gcdDerivative.Length != 1)
            {
                factors.Add(gcdDerivative);
                factors.Add(polinom);
                return factors;
            }


            int m = polinom.Length - 1;

            // Compute Q(x) = x^(2^i) mod polynomial for all i
            int[,] Q = new int[m, m];
            for (int i = 0; i < m; i++)
            {
                int[] xPow2i = ModExp(new int[] { 0, 1 }, 2 * i, polinom); // x^(2^i)
                for (int j = 0; j < xPow2i.Length; j++)
                {
                    Q[i, j] = xPow2i[j];
                }
            }
            Commons.PrintMatrix(Q, "Q");
            int[,] berlekampMatrix = new int[m, m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    berlekampMatrix[i, j] = Q[i, j];
                    if (i == j)
                    {
                        berlekampMatrix[i, j] ^= 1; // Q(x) - I
                    }
                }
            }

            Commons.PrintMatrixRows(berlekampMatrix, "Berlekamp_Polynomials");

            List<int[]> solutionSpaceBasis = GetSolutionSpaceBasis(berlekampMatrix);

            foreach (int[] solutionVector in solutionSpaceBasis)
            {
                int[] gcdResult;
                if (!Commons.IsZeroPolynomial(solutionVector))
                {
                    gcdResult = GCD(polinom, solutionVector);
                    if (gcdResult.Length > 1 && PolynomialToInt(gcdResult) != 1)
                    {
                        factors.Add(gcdResult);
                    }
                }
                solutionVector[0] ^= 1;
                if (!Commons.IsZeroPolynomial(solutionVector))
                {
                    gcdResult = GCD(polinom, solutionVector);
                    if (gcdResult.Length > 1 && PolynomialToInt(gcdResult) != 1)
                    {
                        factors.Add(gcdResult);
                    }
                }
            }

            factors.Add(polinom);
            return factors;
        }

        private ulong PolynomialToInt(int[] poly)
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

        public List<int[]> GetSolutionSpaceBasis(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            identityMatrix = Commons.GenerateIdentityMatrix(rows);
            matrix = ToRowEchelonForm(matrix);
            Commons.PrintMatrix(matrix, "matrix");
            Commons.PrintMatrix(identityMatrix, "identityMatrix");

            List<int[]> solutionSpace = new List<int[]>();

            for (int i = 0; i < rows; i++)
            {
                if (Commons.IsZeroPolynomial(Commons.GetRow(matrix, i)))
                    solutionSpace.Add(Commons.GetRow(identityMatrix, i));
            }

            return solutionSpace;
        }

        int[,] ToRowEchelonForm(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int lead = 0;


            for (int r = 0; r < rows; r++)
            {
                if (lead >= cols) break;

                // Find the pivot column
                int pivotRow = r;
                while (pivotRow < rows && matrix[pivotRow, lead] == 0)
                {
                    pivotRow++;
                }

                if (pivotRow == rows)
                {
                    lead++;
                    continue;
                }

                // Swap to get the pivot in place
                if (pivotRow != r)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        int temp = matrix[r, j];
                        matrix[r, j] = matrix[pivotRow, j];
                        matrix[pivotRow, j] = temp;


                        temp = identityMatrix[r, j];
                        identityMatrix[r, j] = identityMatrix[pivotRow, j];
                        identityMatrix[pivotRow, j] = temp;
                    }
                }

                // Eliminate using column operations
                for (int i = 0; i < rows; i++)
                {
                    if (i != r && matrix[i, lead] == 1)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            matrix[i, j] ^= matrix[r, j]; // Modulo for binary
                            identityMatrix[i, j] ^= identityMatrix[r, j]; // Modulo for binary
                        }
                    }
                }
                lead++;
            }

            return matrix;
        }
    }
}
