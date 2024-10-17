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
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.PolynomialBinaryOutputRtbx = new System.Windows.Forms.RichTextBox();
            this.PolynomialOutputRtbx = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PolynomialDegreeTbox = new System.Windows.Forms.TextBox();
            this.GeneratePrimitiveButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.CheckIsPrimitiveRtbx = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.generatePolyBgw = new System.ComponentModel.BackgroundWorker();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckIsPrimitiveButton
            // 
            this.CheckIsPrimitiveButton.Location = new System.Drawing.Point(346, 105);
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
            this.tabControl1.Size = new System.Drawing.Size(489, 264);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.PolynomialBinaryOutputRtbx);
            this.tabPage1.Controls.Add(this.PolynomialOutputRtbx);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.PolynomialDegreeTbox);
            this.tabPage1.Controls.Add(this.GeneratePrimitiveButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(481, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Generate";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(419, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 11);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 192);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(451, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // PolynomialBinaryOutputRtbx
            // 
            this.PolynomialBinaryOutputRtbx.Location = new System.Drawing.Point(18, 121);
            this.PolynomialBinaryOutputRtbx.Name = "PolynomialBinaryOutputRtbx";
            this.PolynomialBinaryOutputRtbx.Size = new System.Drawing.Size(451, 31);
            this.PolynomialBinaryOutputRtbx.TabIndex = 6;
            this.PolynomialBinaryOutputRtbx.Text = "";
            // 
            // PolynomialOutputRtbx
            // 
            this.PolynomialOutputRtbx.Location = new System.Drawing.Point(18, 50);
            this.PolynomialOutputRtbx.Name = "PolynomialOutputRtbx";
            this.PolynomialOutputRtbx.Size = new System.Drawing.Size(451, 65);
            this.PolynomialOutputRtbx.TabIndex = 5;
            this.PolynomialOutputRtbx.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "GF(2^p) => p:";
            // 
            // PolynomialDegreeTbox
            // 
            this.PolynomialDegreeTbox.Location = new System.Drawing.Point(116, 16);
            this.PolynomialDegreeTbox.Name = "PolynomialDegreeTbox";
            this.PolynomialDegreeTbox.Size = new System.Drawing.Size(98, 25);
            this.PolynomialDegreeTbox.TabIndex = 3;
            // 
            // GeneratePrimitiveButton
            // 
            this.GeneratePrimitiveButton.Location = new System.Drawing.Point(235, 12);
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
            this.tabPage2.Size = new System.Drawing.Size(481, 234);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Check";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(18, 143);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(451, 68);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // CheckIsPrimitiveRtbx
            // 
            this.CheckIsPrimitiveRtbx.Location = new System.Drawing.Point(18, 14);
            this.CheckIsPrimitiveRtbx.Name = "CheckIsPrimitiveRtbx";
            this.CheckIsPrimitiveRtbx.Size = new System.Drawing.Size(451, 85);
            this.CheckIsPrimitiveRtbx.TabIndex = 6;
            this.CheckIsPrimitiveRtbx.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(481, 234);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Divide";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // generatePolyBgw
            // 
            this.generatePolyBgw.WorkerReportsProgress = true;
            this.generatePolyBgw.WorkerSupportsCancellation = true;
            this.generatePolyBgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.generatePolyBgw_DoWork);
            this.generatePolyBgw.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.generatePolyBgw_ProgressChanged);
            this.generatePolyBgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.generatePolyBgw_RunWorkerCompleted);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(18, 155);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(451, 31);
            this.richTextBox2.TabIndex = 9;
            this.richTextBox2.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 264);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
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
        private RichTextBox PolynomialBinaryOutputRtbx;
        private RichTextBox CheckIsPrimitiveRtbx;
        private RichTextBox richTextBox1;
        private TabPage tabPage3;
        private ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker generatePolyBgw;
        private Label label2;
        private RichTextBox richTextBox2;
    }
}
