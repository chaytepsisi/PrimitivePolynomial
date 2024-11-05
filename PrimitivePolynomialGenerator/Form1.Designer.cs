using System.Drawing;
using System.Windows.Forms;

namespace PrimitivePolynomialGenerator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CheckIsPrimitiveButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PolynomialHexOutputRtbx = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.PolynomialOutputRtbx = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PolynomialDegreeTbox = new System.Windows.Forms.TextBox();
            this.GeneratePrimitiveButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.CheckIsPrimitiveRtbx = new System.Windows.Forms.RichTextBox();
            this.generatePolyBgw = new System.ComponentModel.BackgroundWorker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.DividentRtbx = new System.Windows.Forms.RichTextBox();
            this.DivisorRtbx = new System.Windows.Forms.RichTextBox();
            this.QuotientTbx = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.RemainderRtbx = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckIsPrimitiveButton
            // 
            this.CheckIsPrimitiveButton.Location = new System.Drawing.Point(350, 120);
            this.CheckIsPrimitiveButton.Name = "CheckIsPrimitiveButton";
            this.CheckIsPrimitiveButton.Size = new System.Drawing.Size(123, 32);
            this.CheckIsPrimitiveButton.TabIndex = 0;
            this.CheckIsPrimitiveButton.Text = "Is Primitive";
            this.CheckIsPrimitiveButton.UseVisualStyleBackColor = true;
            this.CheckIsPrimitiveButton.Click += new System.EventHandler(this.CheckIsPrimitiveButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(489, 306);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.PolynomialHexOutputRtbx);
            this.tabPage1.Controls.Add(this.richTextBox2);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.PolynomialOutputRtbx);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.PolynomialDegreeTbox);
            this.tabPage1.Controls.Add(this.GeneratePrimitiveButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(481, 276);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generate";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PolynomialHexOutputRtbx
            // 
            this.PolynomialHexOutputRtbx.Location = new System.Drawing.Point(6, 216);
            this.PolynomialHexOutputRtbx.Name = "PolynomialHexOutputRtbx";
            this.PolynomialHexOutputRtbx.Size = new System.Drawing.Size(467, 28);
            this.PolynomialHexOutputRtbx.TabIndex = 10;
            this.PolynomialHexOutputRtbx.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(6, 155);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(467, 55);
            this.richTextBox2.TabIndex = 9;
            this.richTextBox2.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 250);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(467, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // PolynomialOutputRtbx
            // 
            this.PolynomialOutputRtbx.Location = new System.Drawing.Point(6, 50);
            this.PolynomialOutputRtbx.Name = "PolynomialOutputRtbx";
            this.PolynomialOutputRtbx.Size = new System.Drawing.Size(467, 100);
            this.PolynomialOutputRtbx.TabIndex = 5;
            this.PolynomialOutputRtbx.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "GF(2^p) => p:";
            // 
            // PolynomialDegreeTbox
            // 
            this.PolynomialDegreeTbox.Location = new System.Drawing.Point(107, 12);
            this.PolynomialDegreeTbox.Name = "PolynomialDegreeTbox";
            this.PolynomialDegreeTbox.Size = new System.Drawing.Size(98, 25);
            this.PolynomialDegreeTbox.TabIndex = 3;
            this.PolynomialDegreeTbox.TextChanged += new System.EventHandler(this.PolynomialDegreeTbox_TextChanged);
            this.PolynomialDegreeTbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PolynomialDegreeTbox_KeyDown);
            // 
            // GeneratePrimitiveButton
            // 
            this.GeneratePrimitiveButton.Location = new System.Drawing.Point(314, 8);
            this.GeneratePrimitiveButton.Name = "GeneratePrimitiveButton";
            this.GeneratePrimitiveButton.Size = new System.Drawing.Size(123, 32);
            this.GeneratePrimitiveButton.TabIndex = 2;
            this.GeneratePrimitiveButton.Text = "Generate Primitive";
            this.GeneratePrimitiveButton.UseVisualStyleBackColor = true;
            this.GeneratePrimitiveButton.Click += new System.EventHandler(this.GeneratePrimitiveButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox1);
            this.tabPage2.Controls.Add(this.CheckIsPrimitiveRtbx);
            this.tabPage2.Controls.Add(this.CheckIsPrimitiveButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(481, 276);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Check";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 158);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(467, 110);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // CheckIsPrimitiveRtbx
            // 
            this.CheckIsPrimitiveRtbx.Location = new System.Drawing.Point(6, 14);
            this.CheckIsPrimitiveRtbx.Name = "CheckIsPrimitiveRtbx";
            this.CheckIsPrimitiveRtbx.Size = new System.Drawing.Size(467, 100);
            this.CheckIsPrimitiveRtbx.TabIndex = 6;
            this.CheckIsPrimitiveRtbx.Text = "";
            this.CheckIsPrimitiveRtbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CheckIsPrimitiveRtbx_KeyDown);
            // 
            // generatePolyBgw
            // 
            this.generatePolyBgw.WorkerReportsProgress = true;
            this.generatePolyBgw.WorkerSupportsCancellation = true;
            this.generatePolyBgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.generatePolyBgw_DoWork);
            this.generatePolyBgw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.generatePolyBgw_ProgressChanged);
            this.generatePolyBgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.generatePolyBgw_RunWorkerCompleted);
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(211, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(97, 25);
            this.comboBox1.TabIndex = 11;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.RemainderRtbx);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.QuotientTbx);
            this.tabPage3.Controls.Add(this.DivisorRtbx);
            this.tabPage3.Controls.Add(this.DividentRtbx);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(481, 276);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DividentRtbx
            // 
            this.DividentRtbx.Location = new System.Drawing.Point(75, 13);
            this.DividentRtbx.Name = "DividentRtbx";
            this.DividentRtbx.Size = new System.Drawing.Size(398, 58);
            this.DividentRtbx.TabIndex = 0;
            this.DividentRtbx.Text = "";
            // 
            // DivisorRtbx
            // 
            this.DivisorRtbx.Location = new System.Drawing.Point(75, 77);
            this.DivisorRtbx.Name = "DivisorRtbx";
            this.DivisorRtbx.Size = new System.Drawing.Size(398, 58);
            this.DivisorRtbx.TabIndex = 1;
            this.DivisorRtbx.Text = "";
            // 
            // QuotientTbx
            // 
            this.QuotientTbx.Location = new System.Drawing.Point(80, 178);
            this.QuotientTbx.Name = "QuotientTbx";
            this.QuotientTbx.Size = new System.Drawing.Size(398, 36);
            this.QuotientTbx.TabIndex = 2;
            this.QuotientTbx.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(396, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // RemainderRtbx
            // 
            this.RemainderRtbx.Location = new System.Drawing.Point(80, 220);
            this.RemainderRtbx.Name = "RemainderRtbx";
            this.RemainderRtbx.Size = new System.Drawing.Size(398, 36);
            this.RemainderRtbx.TabIndex = 4;
            this.RemainderRtbx.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 306);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Pi-Po";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button CheckIsPrimitiveButton;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private RichTextBox PolynomialOutputRtbx;
        private Label label1;
        private TextBox PolynomialDegreeTbox;
        private Button GeneratePrimitiveButton;
        private TabPage tabPage2;
        private RichTextBox CheckIsPrimitiveRtbx;
        private RichTextBox richTextBox1;
        private ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker generatePolyBgw;
        private RichTextBox richTextBox2;
        private RichTextBox PolynomialHexOutputRtbx;
        private ComboBox comboBox1;
        private TabPage tabPage3;
        private Button button1;
        private RichTextBox QuotientTbx;
        private RichTextBox DivisorRtbx;
        private RichTextBox DividentRtbx;
        private RichTextBox RemainderRtbx;
    }
}
