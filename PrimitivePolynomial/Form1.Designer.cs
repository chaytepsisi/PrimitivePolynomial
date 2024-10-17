namespace PrimitivePolynomial
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
            CheckIsPrimitiveButton = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            PolynomialBinaryOutputRtbx = new RichTextBox();
            PolynomialOutputRtbx = new RichTextBox();
            label1 = new Label();
            PolynomialDegreeTbox = new TextBox();
            GeneratePrimitiveButton = new Button();
            tabPage2 = new TabPage();
            richTextBox1 = new RichTextBox();
            CheckIsPrimitiveRtbx = new RichTextBox();
            tabPage3 = new TabPage();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // CheckIsPrimitiveButton
            // 
            CheckIsPrimitiveButton.Location = new Point(346, 105);
            CheckIsPrimitiveButton.Name = "CheckIsPrimitiveButton";
            CheckIsPrimitiveButton.Size = new Size(123, 32);
            CheckIsPrimitiveButton.TabIndex = 0;
            CheckIsPrimitiveButton.Text = "Is Primitive";
            CheckIsPrimitiveButton.UseVisualStyleBackColor = true;
            CheckIsPrimitiveButton.Click += CheckIsPrimitiveButton_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(507, 249);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(PolynomialBinaryOutputRtbx);
            tabPage1.Controls.Add(PolynomialOutputRtbx);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(PolynomialDegreeTbox);
            tabPage1.Controls.Add(GeneratePrimitiveButton);
            tabPage1.Location = new Point(4, 26);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(499, 219);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Generate";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // PolynomialBinaryOutputRtbx
            // 
            PolynomialBinaryOutputRtbx.Location = new Point(18, 121);
            PolynomialBinaryOutputRtbx.Name = "PolynomialBinaryOutputRtbx";
            PolynomialBinaryOutputRtbx.Size = new Size(451, 65);
            PolynomialBinaryOutputRtbx.TabIndex = 6;
            PolynomialBinaryOutputRtbx.Text = "";
            // 
            // PolynomialOutputRtbx
            // 
            PolynomialOutputRtbx.Location = new Point(18, 50);
            PolynomialOutputRtbx.Name = "PolynomialOutputRtbx";
            PolynomialOutputRtbx.Size = new Size(451, 65);
            PolynomialOutputRtbx.TabIndex = 5;
            PolynomialOutputRtbx.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 20);
            label1.Name = "label1";
            label1.Size = new Size(92, 17);
            label1.TabIndex = 4;
            label1.Text = "GF(2^p) => p:";
            // 
            // PolynomialDegreeTbox
            // 
            PolynomialDegreeTbox.Location = new Point(116, 16);
            PolynomialDegreeTbox.Name = "PolynomialDegreeTbox";
            PolynomialDegreeTbox.Size = new Size(98, 25);
            PolynomialDegreeTbox.TabIndex = 3;
            // 
            // GeneratePrimitiveButton
            // 
            GeneratePrimitiveButton.Location = new Point(235, 12);
            GeneratePrimitiveButton.Name = "GeneratePrimitiveButton";
            GeneratePrimitiveButton.Size = new Size(123, 32);
            GeneratePrimitiveButton.TabIndex = 2;
            GeneratePrimitiveButton.Text = "Generate Primitive";
            GeneratePrimitiveButton.UseVisualStyleBackColor = true;
            GeneratePrimitiveButton.Click += GeneratePrimitiveButton_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(richTextBox1);
            tabPage2.Controls.Add(CheckIsPrimitiveRtbx);
            tabPage2.Controls.Add(CheckIsPrimitiveButton);
            tabPage2.Location = new Point(4, 26);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(499, 219);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Check";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(18, 143);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(451, 68);
            richTextBox1.TabIndex = 8;
            richTextBox1.Text = "";
            // 
            // CheckIsPrimitiveRtbx
            // 
            CheckIsPrimitiveRtbx.Location = new Point(18, 14);
            CheckIsPrimitiveRtbx.Name = "CheckIsPrimitiveRtbx";
            CheckIsPrimitiveRtbx.Size = new Size(451, 85);
            CheckIsPrimitiveRtbx.TabIndex = 6;
            CheckIsPrimitiveRtbx.Text = "";
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 26);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(499, 219);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Divide";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 249);
            Controls.Add(tabControl1);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 162);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
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
    }
}
