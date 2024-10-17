using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitivePolynomialGenerator
{
    class GaloisField
    {
        private int degree;
        private int[] polynomial;

        public bool isIrreducible { get; set; }
        public int[] divisor { get; set; }
        public GaloisField(int[] poly)
        {
            degree = poly.Length - 1;
            polynomial = poly;
            isIrreducible = false;
            divisor = new int[0];
        }

        // Multiply two polynomials in GF(2)
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
        private int[] ModReduce(int[] poly, int[] modPoly)
        {
            poly = (int[])poly.Clone(); // Clone to avoid modifying the original poly
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
        private int[] GCD(int[] a, int[] b)
        {
            while (b.Length > 1 || b[0] != 0)
            {
                int[] temp = ModReduce(a, b);
                a = b;
                b = temp;
            }
            return a;
        }

        // Generate all polynomials of degree <= n over GF(2)
        private List<int[]> GeneratePolynomials(int degree)
        {
            List<int[]> polynomials = new List<int[]>();
            int limit = 1 << (degree + 1); // 2^(degree+1)
            for (int i = 1; i < limit; i++)
            {
                List<int> poly = new List<int>();
                for (int j = 0; j <= degree; j++)
                {
                    poly.Add((i >> j) & 1); // Get each bit
                }
                polynomials.Add(poly.ToArray());
            }
            return polynomials;
        }

        // Check if a polynomial is irreducible over GF(2)
        public bool IsIrreducible()
        {
            // Generate all polynomials of degree <= degree/2
            for (int d = 1; d <= degree / 2; d++)
            {
                List<int[]> lowerDegreePolynomials = GeneratePolynomials(d);
                foreach (var poly in lowerDegreePolynomials)
                {
                    if (ModReduce((int[])polynomial.Clone(), poly).Length == 1 && ModReduce((int[])polynomial.Clone(), poly)[0] == 0)
                    {
                        divisor = poly;
                        return false; // Polynomial is divisible by a smaller degree polynomial
                    }
                }
            }
            return true; // Irreducible
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
                    divisors.Add(n/i);
                }
            }
            return divisors;
        }

        // Check if the polynomial is primitive over GF(2^m)
        public bool IsPrimitive()
        {
            int m = polynomial.Length - 1;

            // Check if the polynomial is irreducible first
            if (!IsIrreducible())
            {
                return false; // Not primitive if not irreducible
            }

            isIrreducible = true;
            // Now check for primitivity: order should be 2^m - 1
            int order = (1 << m) - 1; // 2^m - 1

            // Find all divisors of the order
            List<int> divisors = FindDivisors(order);

            // Check for each divisor whether x^d ≡ 1 (mod p(x)) for any divisor < 2^m - 1
            foreach (int d in divisors)
            {
                if (d < order)
                {
                    int[] modExpResult = ModExp(new int[] { 0, 1 }, d, (int[])polynomial.Clone());
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

        // Solve the linear system using Berlekamp's algorithm to factorize polynomials
        public List<int[]> BerlekampFactorization()
        {
            List<int[]> factors = new List<int[]>();
            int m = polynomial.Length - 1;

            // Compute Q(x) = x^(2^i) mod polynomial for all i
            int[,] Q = new int[m, m];
            for (int i = 0; i < m; i++)
            {
                int[] xPow2i = ModExp(new int[] { 0, 1 }, 1 << i, polynomial); // x^(2^i)
                for (int j = 0; j < m; j++)
                {
                    Q[j, i] = xPow2i[j];
                }
            }

            // Create Berlekamp matrix (Q(x) - I)
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

            // Find null space of the matrix to get factors
            // (We can use Gaussian elimination here)
            List<int[]> nullSpace = GaussianElimination(berlekampMatrix);

            // Use GCD to find factors from the null space
            foreach (int[] nullVector in nullSpace)
            {
                int[] factorCandidate = new int[] { 1 }; // Start with polynomial 1
                for (int i = 0; i < nullVector.Length; i++)
                {
                    if (nullVector[i] == 1)
                    {
                        factorCandidate = Multiply(factorCandidate, new int[] { 0, 1 }); // Multiply by x^i
                    }
                }
                int[] gcdResult = GCD(polynomial, factorCandidate);
                if (gcdResult.Length > 1 && PolynomialToInt(gcdResult) != 1)
                {
                    factors.Add(gcdResult);
                }
            }

            return factors;
        }


        // Gaussian elimination to find the null space
        private List<int[]> GaussianElimination(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            List<int[]> nullSpace = new List<int[]>();

            // TODO: Implement the Gaussian elimination logic to find null space

            return nullSpace;
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
    }
}
