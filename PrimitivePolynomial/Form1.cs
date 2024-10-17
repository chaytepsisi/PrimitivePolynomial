using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace PrimitivePolynomial
{
    public partial class Form1 : Form
    {
        int maxCount = 1000;
        public Form1()
        {
            InitializeComponent();

        }


        private void CheckIsPrimitiveButton_Click(object sender, EventArgs e)
        {


            /*int[] polynomial = { 1, 1, 0, 0, 1 }; // x^4 + x + 1 (Primitive polynomial for GF(2^4))
            GaloisField gf = new GaloisField(polynomial);

            bool isPrimitive = gf.IsPrimitive();

            if (isPrimitive)
                MessageBox.Show(Commons.PolynomialArrToString(polynomial) + " is PRIMITIVE");
            else MessageBox.Show(Commons.PolynomialArrToString(polynomial) + " is NOT primitive");
            */
            int[] polynomial = new int[1];
            bool isPrimitive = false;
            string inputPolyStr = CheckIsPrimitiveRtbx.Text;
            if (!inputPolyStr.Contains("+"))
            {
                polynomial = new int[inputPolyStr.Length];
                for (int i = 0; i < inputPolyStr.Length; i++)
                    polynomial[i] = int.Parse(inputPolyStr[i].ToString());

                inputPolyStr = Commons.PolynomialArrToString(polynomial);
            }
            else
            {
                var tempStrArr=inputPolyStr.Split(new string[] { "+" }, StringSplitOptions.RemoveEmptyEntries);
                int constantTerm = 0;
                List<int> powers = new List<int>();
                for (int i = 0; i < tempStrArr.Length; i++)
                {
                    if (tempStrArr[i].Contains("x"))
                    {
                        if (tempStrArr[i].Length == 1)
                            powers.Add(1);
                        else
                        {
                            int power = int.Parse(tempStrArr[i].Replace("x", ""));
                            if (!powers.Contains(power))
                                powers.Add(power);
                            else
                                MessageBox.Show("Tekrar eden kuvvet var: " + power);
                        }
                    }
                    else constantTerm = int.Parse(tempStrArr[i]);//birden fazla constatn term var mý?
                }

                int polyDegree = powers.Max();
                polynomial = new int[polyDegree+1];
                for (int i = 0; i < polynomial.Length; i++)
                    polynomial[i] = 0;
                for (int i = 0; i < powers.Count; i++)
                {
                    polynomial[powers[i]] = 1;
                }

                polynomial[0] = constantTerm;
            }

            if (polynomial[0] == 0)
            {
                isPrimitive = false;
            }
            else
            {
                polynomial = polynomial.Reverse().ToArray();
                GaloisField gf = new GaloisField(polynomial);
                isPrimitive = gf.IsPrimitive();

                string resultStr = inputPolyStr;
                if (isPrimitive)
                    resultStr += " is PRIMITIVE.";
                else
                {
                    resultStr += " is NOT primitive";
                    if (gf.isIrreducible)
                        resultStr += " but irreducible.";
                    else
                        resultStr += " or irreducible. It is divisible by "+ Commons.PolynomialArrToString(gf.divisor);
                }
                richTextBox1.Text = resultStr;
            }
        }
        
        private void GeneratePrimitiveButton_Click(object sender, EventArgs e)
        {
            int n = int.Parse(PolynomialDegreeTbox.Text);
            var randomPoly = Commons.GenerateBinaryArray(n);
            GaloisField gf = new GaloisField(randomPoly);
            int tries = 0;
            bool result = gf.IsPrimitive();
            while (!result && tries<maxCount)
            {
                randomPoly = Commons.GenerateBinaryArray(n);
                gf = new GaloisField(randomPoly);
                result= gf.IsPrimitive();
            }
            if (result)
            {
                PolynomialOutputRtbx.Text = Commons.PolynomialArrToString(randomPoly);
                randomPoly = randomPoly.Reverse().ToArray();
                PolynomialBinaryOutputRtbx.Text = Commons.PrintArray(randomPoly);
            }
            else PolynomialOutputRtbx.Text = "Tekrar dene";
        }
    }
}
