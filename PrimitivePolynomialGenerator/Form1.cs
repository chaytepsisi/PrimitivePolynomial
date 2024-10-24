using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimitivePolynomialGenerator
{
    public partial class Form1 : Form
    {
        Wait waitForm;
        int maxCount = 10000;
        public Form1()
        {
            InitializeComponent();
            waitForm = new Wait();
        }
        private void CheckIsPrimitiveButton_Click(object sender, EventArgs e)
        {
            
            int[] polynomial = new int[1];
            bool isPrimitive = false;

            richTextBox1.BackColor = SystemColors.Control;

            string inputPolyStr = CheckIsPrimitiveRtbx.Text.Replace(" ", "").ToLower();
            inputPolyStr = inputPolyStr.Replace("^", "").Trim();
            inputPolyStr = inputPolyStr.Replace("\r", "").Replace("\n","");
            if (inputPolyStr.Length < 1)
                return;

            if (!inputPolyStr.Contains("+"))
            {
                try
                {
                    if (Commons.HexRegex.IsMatch(inputPolyStr))
                        inputPolyStr = Commons.HexStringToIntArray(inputPolyStr);
                    polynomial = new int[inputPolyStr.Length];
                    for (int i = 0; i < inputPolyStr.Length; i++)
                        polynomial[i] = int.Parse(inputPolyStr[i].ToString());

                    inputPolyStr = Commons.PolynomialArrToString(polynomial);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                try { 
                var tempStrArr = inputPolyStr.Split(new string[] { "+" }, StringSplitOptions.RemoveEmptyEntries);
                int constantTerm = 0;
                List<int> powers = new List<int>();
                for (int i = 0; i < tempStrArr.Length; i++)
                {
                    if (tempStrArr[i].Contains("x"))
                    {
                        if (tempStrArr[i].Trim().Length == 1)
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
                polynomial = new int[polyDegree + 1];
                for (int i = 0; i < polynomial.Length; i++)
                    polynomial[i] = 0;
                for (int i = 0; i < powers.Count; i++)
                {
                    polynomial[powers[i]] = 1;
                }

                polynomial[0] = constantTerm;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            string resultStr = inputPolyStr;
            if (polynomial[0] == 0)
            {
                isPrimitive = false;
                resultStr += " is NOT primitive or irreducible. It is divisible by x";
                richTextBox1.BackColor = Color.Red;
            }
            else
            {
                //polynomial = polynomial.Reverse().ToArray();
                GaloisField gf = new GaloisField();
                isPrimitive = gf.IsPrimitive(polynomial);



                if (isPrimitive)
                {
                    resultStr += " is PRIMITIVE.";
                    richTextBox1.BackColor = Color.Green;
                }
                else
                {
                    resultStr += " is NOT primitive";
                    if (gf.IsIrreducible)
                    {
                        resultStr += " but irreducible.";
                        richTextBox1.BackColor = Color.Yellow;
                    }
                    else
                    {
                        resultStr += " or irreducible. It is divisible by " + Commons.PolynomialArrToString(gf.Divisor);
                        richTextBox1.BackColor = Color.Red;
                    }
                }
            }
            richTextBox1.Text = resultStr;
        }


        bool generationResult = false;
        int n;
        int[] randomPoly;
        Stopwatch stp = new Stopwatch();
        private void GeneratePrimitiveButton_Click(object sender, EventArgs e)
        {
            if (!generatePolyBgw.IsBusy)
            {

                if (int.TryParse(PolynomialDegreeTbox.Text, out n))
                {
                    stp.Start();
                    GeneratePrimitiveButton.Text = "Stop";
                    generatePolyBgw.RunWorkerAsync();
                }
            }
            else
            {
                generatePolyBgw.CancelAsync();
                    waitForm.Show(this);
                GeneratePrimitiveButton.Enabled = false;
            }
        }

        bool GeneratePrimPoly(int degree)
        {
            randomPoly = Commons.GenerateBinaryArray(degree);
            GaloisField gf = new GaloisField();
            int tries = 0;
            generationResult = gf.IsPrimitive(randomPoly);

            double percentage = 100.0 / maxCount;
            while (!generationResult && tries < maxCount)
            {
                randomPoly = Commons.GenerateBinaryArray(degree);
                gf = new GaloisField();
                generationResult = gf.IsPrimitive(randomPoly);
                tries++;
                generatePolyBgw.ReportProgress((int)(percentage * tries));
                if (generatePolyBgw.CancellationPending)
                    return false;
            }

            return generationResult;
        }
    private void generatePolyBgw_DoWork(object sender, DoWorkEventArgs e)
        {
            GeneratePrimPoly(n);
            /*if (n < 33 || n%2==1)
            {
                GeneratePrimPoly(n);
            }
            else
            {
                if ((n % 2 == 0))
                {
                    if (GeneratePrimPoly(n / 2))
                    {
                        var poly1 = (int[])randomPoly.Clone();
                        if (GeneratePrimPoly(n / 2))
                        {
                            var poly2 = (int[])randomPoly.Clone();
                            GaloisField tempGF= new GaloisField(poly1);
                            randomPoly = tempGF.Multiply(poly1, poly2);
                        }
                    }
                }
            }*/
        }

        private void generatePolyBgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stp.Stop();
            if (generationResult)
            {
                PolynomialOutputRtbx.Text = Commons.PolynomialArrToString(randomPoly);
                richTextBox2.Text = Commons.PrintArray(randomPoly);
                randomPoly = randomPoly.Reverse().ToArray();
                PolynomialHexOutputRtbx.Text = Commons.BinaryStringToHexString(Commons.PrintArray(randomPoly));
            }
            else PolynomialOutputRtbx.Text = "Tekrar dene";
            progressBar1.Value = 100;
            GeneratePrimitiveButton.Text = "Generate";
            GeneratePrimitiveButton.Enabled = true;
            try
            {
                waitForm.Hide();
            }
            catch { }
        }

        private void generatePolyBgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] x16 = new int[] { 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 1 };
            int[] y7 = new int[] { 1,0,1,0,1,0,1,1 };

            GaloisField gf=new GaloisField();
            var poli = gf.GCD(x16, y7);
            //var poli= gf.ModReduce(gf.Multiply(x7, y7), new int[] { 1, 0, 1, 1, 1, 1, 1, 0, 1 });
            richTextBox1.Text = Commons.PolynomialArrToString(poli);
        }

        private void PolynomialDegreeTbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GeneratePrimitiveButton.PerformClick();
            }
        }

        private void CheckIsPrimitiveRtbx_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                CheckIsPrimitiveButton.PerformClick();
            }
        }
    }
}
