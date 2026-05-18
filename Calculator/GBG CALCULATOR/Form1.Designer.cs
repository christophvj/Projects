namespace GBG_CALCULATOR
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.PnlTitle = new System.Windows.Forms.Panel();
            this.BtnMenu = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.lblNoHistory = new System.Windows.Forms.Label();
            this.lstHistory = new System.Windows.Forms.ListBox();
            this.btnHistoryClear = new System.Windows.Forms.Button();
            this.btnReciprocal = new System.Windows.Forms.Button();
            this.txtSumDisplay = new System.Windows.Forms.TextBox();
            this.txtMainDisplay = new System.Windows.Forms.TextBox();
            this.btnPercentage = new System.Windows.Forms.Button();
            this.btnClearEntry = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBackSpace = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnSquareRoot = new System.Windows.Forms.Button();
            this.btnPower = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btnEqual = new System.Windows.Forms.Button();
            this.btnDecimal = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btnPM = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.PnlTitle.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTitle
            // 
            this.PnlTitle.Controls.Add(this.BtnMenu);
            this.PnlTitle.Controls.Add(this.btnHistory);
            this.PnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTitle.Location = new System.Drawing.Point(0, 0);
            this.PnlTitle.Margin = new System.Windows.Forms.Padding(0);
            this.PnlTitle.Name = "PnlTitle";
            this.PnlTitle.Size = new System.Drawing.Size(350, 35);
            this.PnlTitle.TabIndex = 0;
            // 
            // BtnMenu
            // 
            this.BtnMenu.BackColor = System.Drawing.Color.Transparent;
            this.BtnMenu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.BtnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMenu.Image = ((System.Drawing.Image)(resources.GetObject("BtnMenu.Image")));
            this.BtnMenu.Location = new System.Drawing.Point(3, 3);
            this.BtnMenu.Name = "BtnMenu";
            this.BtnMenu.Size = new System.Drawing.Size(31, 28);
            this.BtnMenu.TabIndex = 1;
            this.BtnMenu.UseVisualStyleBackColor = false;
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnHistory.Image")));
            this.btnHistory.Location = new System.Drawing.Point(316, 4);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(31, 28);
            this.btnHistory.TabIndex = 0;
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // pnlHistory
            // 
            this.pnlHistory.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHistory.Controls.Add(this.lblNoHistory);
            this.pnlHistory.Controls.Add(this.lstHistory);
            this.pnlHistory.Controls.Add(this.btnHistoryClear);
            this.pnlHistory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlHistory.Location = new System.Drawing.Point(0, 137);
            this.pnlHistory.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(350, 386);
            this.pnlHistory.TabIndex = 1;
            // 
            // lblNoHistory
            // 
            this.lblNoHistory.AutoSize = true;
            this.lblNoHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(96)))));
            this.lblNoHistory.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoHistory.ForeColor = System.Drawing.Color.White;
            this.lblNoHistory.Location = new System.Drawing.Point(-3, -2);
            this.lblNoHistory.Name = "lblNoHistory";
            this.lblNoHistory.Size = new System.Drawing.Size(179, 19);
            this.lblNoHistory.TabIndex = 4;
            this.lblNoHistory.Text = "There\'s no History yet.";
            // 
            // lstHistory
            // 
            this.lstHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(96)))));
            this.lstHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstHistory.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstHistory.ForeColor = System.Drawing.Color.White;
            this.lstHistory.FormattingEnabled = true;
            this.lstHistory.ItemHeight = 19;
            this.lstHistory.Location = new System.Drawing.Point(0, 0);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(346, 228);
            this.lstHistory.TabIndex = 3;
            // 
            // btnHistoryClear
            // 
            this.btnHistoryClear.BackColor = System.Drawing.Color.DarkGreen;
            this.btnHistoryClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnHistoryClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnHistoryClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnHistoryClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistoryClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnHistoryClear.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoryClear.Image")));
            this.btnHistoryClear.Location = new System.Drawing.Point(0, 354);
            this.btnHistoryClear.Name = "btnHistoryClear";
            this.btnHistoryClear.Size = new System.Drawing.Size(346, 28);
            this.btnHistoryClear.TabIndex = 2;
            this.btnHistoryClear.UseVisualStyleBackColor = false;
            this.btnHistoryClear.Click += new System.EventHandler(this.btnHistoryClear_Click);
            // 
            // btnReciprocal
            // 
            this.btnReciprocal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnReciprocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReciprocal.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReciprocal.ForeColor = System.Drawing.Color.Black;
            this.btnReciprocal.Location = new System.Drawing.Point(10, 206);
            this.btnReciprocal.Name = "btnReciprocal";
            this.btnReciprocal.Size = new System.Drawing.Size(79, 56);
            this.btnReciprocal.TabIndex = 8;
            this.btnReciprocal.Text = "1/𝑥";
            this.btnReciprocal.UseVisualStyleBackColor = false;
            this.btnReciprocal.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // txtSumDisplay
            // 
            this.txtSumDisplay.Location = new System.Drawing.Point(3, 38);
            this.txtSumDisplay.Name = "txtSumDisplay";
            this.txtSumDisplay.Size = new System.Drawing.Size(344, 29);
            this.txtSumDisplay.TabIndex = 2;
            this.txtSumDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtMainDisplay
            // 
            this.txtMainDisplay.Font = new System.Drawing.Font("Gadugi", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMainDisplay.Location = new System.Drawing.Point(3, 73);
            this.txtMainDisplay.Multiline = true;
            this.txtMainDisplay.Name = "txtMainDisplay";
            this.txtMainDisplay.Size = new System.Drawing.Size(344, 52);
            this.txtMainDisplay.TabIndex = 3;
            this.txtMainDisplay.Text = "0";
            this.txtMainDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnPercentage
            // 
            this.btnPercentage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPercentage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPercentage.Font = new System.Drawing.Font("Gadugi", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPercentage.ForeColor = System.Drawing.Color.Black;
            this.btnPercentage.Location = new System.Drawing.Point(10, 144);
            this.btnPercentage.Name = "btnPercentage";
            this.btnPercentage.Size = new System.Drawing.Size(79, 56);
            this.btnPercentage.TabIndex = 4;
            this.btnPercentage.Text = "%";
            this.btnPercentage.UseVisualStyleBackColor = false;
            this.btnPercentage.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // btnClearEntry
            // 
            this.btnClearEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnClearEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearEntry.ForeColor = System.Drawing.Color.Black;
            this.btnClearEntry.Location = new System.Drawing.Point(95, 144);
            this.btnClearEntry.Name = "btnClearEntry";
            this.btnClearEntry.Size = new System.Drawing.Size(79, 56);
            this.btnClearEntry.TabIndex = 5;
            this.btnClearEntry.Text = "CE";
            this.btnClearEntry.UseVisualStyleBackColor = false;
            this.btnClearEntry.Click += new System.EventHandler(this.btnClearEntry_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(180, 144);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(79, 56);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "C";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBackSpace
            // 
            this.btnBackSpace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBackSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackSpace.ForeColor = System.Drawing.Color.Black;
            this.btnBackSpace.Image = ((System.Drawing.Image)(resources.GetObject("btnBackSpace.Image")));
            this.btnBackSpace.Location = new System.Drawing.Point(265, 144);
            this.btnBackSpace.Name = "btnBackSpace";
            this.btnBackSpace.Size = new System.Drawing.Size(79, 56);
            this.btnBackSpace.TabIndex = 7;
            this.btnBackSpace.UseVisualStyleBackColor = false;
            this.btnBackSpace.Click += new System.EventHandler(this.btnBackSpace_Click);
            // 
            // btnDivide
            // 
            this.btnDivide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDivide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDivide.Font = new System.Drawing.Font("Gadugi", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDivide.ForeColor = System.Drawing.Color.Black;
            this.btnDivide.Location = new System.Drawing.Point(265, 206);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(79, 56);
            this.btnDivide.TabIndex = 11;
            this.btnDivide.Text = "÷";
            this.btnDivide.UseVisualStyleBackColor = false;
            this.btnDivide.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // btnSquareRoot
            // 
            this.btnSquareRoot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSquareRoot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSquareRoot.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSquareRoot.ForeColor = System.Drawing.Color.Black;
            this.btnSquareRoot.Location = new System.Drawing.Point(180, 206);
            this.btnSquareRoot.Name = "btnSquareRoot";
            this.btnSquareRoot.Size = new System.Drawing.Size(79, 56);
            this.btnSquareRoot.TabIndex = 10;
            this.btnSquareRoot.Text = "√";
            this.btnSquareRoot.UseVisualStyleBackColor = false;
            this.btnSquareRoot.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // btnPower
            // 
            this.btnPower.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPower.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPower.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPower.ForeColor = System.Drawing.Color.Black;
            this.btnPower.Location = new System.Drawing.Point(95, 206);
            this.btnPower.Name = "btnPower";
            this.btnPower.Size = new System.Drawing.Size(79, 56);
            this.btnPower.TabIndex = 9;
            this.btnPower.Text = "x²";
            this.btnPower.UseVisualStyleBackColor = false;
            this.btnPower.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // btnMultiply
            // 
            this.btnMultiply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnMultiply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMultiply.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiply.ForeColor = System.Drawing.Color.Black;
            this.btnMultiply.Location = new System.Drawing.Point(265, 268);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(79, 56);
            this.btnMultiply.TabIndex = 15;
            this.btnMultiply.Text = "X";
            this.btnMultiply.UseVisualStyleBackColor = false;
            this.btnMultiply.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // btn9
            // 
            this.btn9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9.ForeColor = System.Drawing.Color.Black;
            this.btn9.Location = new System.Drawing.Point(180, 268);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(79, 56);
            this.btn9.TabIndex = 14;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = false;
            this.btn9.Click += new System.EventHandler(this.btnNum_click);
            // 
            // btn8
            // 
            this.btn8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn8.ForeColor = System.Drawing.Color.Black;
            this.btn8.Location = new System.Drawing.Point(95, 268);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(79, 56);
            this.btn8.TabIndex = 13;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = false;
            this.btn8.Click += new System.EventHandler(this.btnNum_click);
            // 
            // btn7
            // 
            this.btn7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn7.ForeColor = System.Drawing.Color.Black;
            this.btn7.Location = new System.Drawing.Point(10, 268);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(79, 56);
            this.btn7.TabIndex = 12;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = false;
            this.btn7.Click += new System.EventHandler(this.btnNum_click);
            // 
            // btnEqual
            // 
            this.btnEqual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnEqual.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEqual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqual.Font = new System.Drawing.Font("Gadugi", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEqual.ForeColor = System.Drawing.Color.White;
            this.btnEqual.Location = new System.Drawing.Point(265, 456);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(79, 56);
            this.btnEqual.TabIndex = 27;
            this.btnEqual.Text = "=";
            this.btnEqual.UseVisualStyleBackColor = false;
            this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);
            // 
            // btnDecimal
            // 
            this.btnDecimal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDecimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecimal.Font = new System.Drawing.Font("Gadugi", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecimal.ForeColor = System.Drawing.Color.Black;
            this.btnDecimal.Location = new System.Drawing.Point(180, 456);
            this.btnDecimal.Name = "btnDecimal";
            this.btnDecimal.Size = new System.Drawing.Size(79, 56);
            this.btnDecimal.TabIndex = 26;
            this.btnDecimal.Text = ".";
            this.btnDecimal.UseVisualStyleBackColor = false;
            this.btnDecimal.Click += new System.EventHandler(this.btnNum_click);
            // 
            // btn0
            // 
            this.btn0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn0.ForeColor = System.Drawing.Color.Black;
            this.btn0.Location = new System.Drawing.Point(95, 456);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(79, 56);
            this.btn0.TabIndex = 25;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = false;
            this.btn0.Click += new System.EventHandler(this.btnNum_click);
            // 
            // btnPM
            // 
            this.btnPM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPM.Font = new System.Drawing.Font("Gadugi", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPM.ForeColor = System.Drawing.Color.Black;
            this.btnPM.Location = new System.Drawing.Point(10, 456);
            this.btnPM.Name = "btnPM";
            this.btnPM.Size = new System.Drawing.Size(79, 56);
            this.btnPM.TabIndex = 24;
            this.btnPM.Text = "±";
            this.btnPM.UseVisualStyleBackColor = false;
            this.btnPM.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlus.Font = new System.Drawing.Font("Gadugi", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlus.ForeColor = System.Drawing.Color.Black;
            this.btnPlus.Location = new System.Drawing.Point(265, 394);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(79, 56);
            this.btnPlus.TabIndex = 23;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = false;
            this.btnPlus.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn3.ForeColor = System.Drawing.Color.Black;
            this.btn3.Location = new System.Drawing.Point(180, 394);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(79, 56);
            this.btn3.TabIndex = 22;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Click += new System.EventHandler(this.btnNum_click);
            // 
            // btn2
            // 
            this.btn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn2.ForeColor = System.Drawing.Color.Black;
            this.btn2.Location = new System.Drawing.Point(95, 394);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(79, 56);
            this.btn2.TabIndex = 21;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = false;
            this.btn2.Click += new System.EventHandler(this.btnNum_click);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1.ForeColor = System.Drawing.Color.Black;
            this.btn1.Location = new System.Drawing.Point(10, 394);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(79, 56);
            this.btn1.TabIndex = 20;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Click += new System.EventHandler(this.btnNum_click);
            // 
            // btnMinus
            // 
            this.btnMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinus.Font = new System.Drawing.Font("Gadugi", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinus.ForeColor = System.Drawing.Color.Black;
            this.btnMinus.Location = new System.Drawing.Point(265, 332);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(79, 56);
            this.btnMinus.TabIndex = 19;
            this.btnMinus.Text = "−";
            this.btnMinus.UseVisualStyleBackColor = false;
            this.btnMinus.Click += new System.EventHandler(this.btnOperator_Click);
            // 
            // btn6
            // 
            this.btn6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn6.ForeColor = System.Drawing.Color.Black;
            this.btn6.Location = new System.Drawing.Point(180, 332);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(79, 56);
            this.btn6.TabIndex = 18;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = false;
            this.btn6.Click += new System.EventHandler(this.btnNum_click);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.ForeColor = System.Drawing.Color.Black;
            this.btn5.Location = new System.Drawing.Point(95, 332);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(79, 56);
            this.btn5.TabIndex = 17;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.btnNum_click);
            // 
            // btn4
            // 
            this.btn4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn4.ForeColor = System.Drawing.Color.Black;
            this.btn4.Location = new System.Drawing.Point(10, 330);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(79, 56);
            this.btn4.TabIndex = 16;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = false;
            this.btn4.Click += new System.EventHandler(this.btnNum_click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(96)))));
            this.ClientSize = new System.Drawing.Size(350, 523);
            this.Controls.Add(this.btnEqual);
            this.Controls.Add(this.btnDecimal);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btnReciprocal);
            this.Controls.Add(this.btnPM);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.btnSquareRoot);
            this.Controls.Add(this.btnPower);
            this.Controls.Add(this.btnBackSpace);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnClearEntry);
            this.Controls.Add(this.btnPercentage);
            this.Controls.Add(this.txtMainDisplay);
            this.Controls.Add(this.txtSumDisplay);
            this.Controls.Add(this.pnlHistory);
            this.Controls.Add(this.PnlTitle);
            this.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(67)))), ((int)(((byte)(96)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(366, 562);
            this.MinimumSize = new System.Drawing.Size(366, 562);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GBG Calculator";
            this.PnlTitle.ResumeLayout(false);
            this.pnlHistory.ResumeLayout(false);
            this.pnlHistory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlTitle;
        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button BtnMenu;
        private System.Windows.Forms.TextBox txtSumDisplay;
        private System.Windows.Forms.TextBox txtMainDisplay;
        private System.Windows.Forms.Button btnHistoryClear;
        private System.Windows.Forms.Button btnPercentage;
        private System.Windows.Forms.Button btnClearEntry;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBackSpace;
        private System.Windows.Forms.Button btnDivide;
        private System.Windows.Forms.Button btnSquareRoot;
        private System.Windows.Forms.Button btnPower;
        private System.Windows.Forms.Button btnReciprocal;
        private System.Windows.Forms.Button btnMultiply;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btnEqual;
        private System.Windows.Forms.Button btnDecimal;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btnPM;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.ListBox lstHistory;
        private System.Windows.Forms.Label lblNoHistory;
    }
}

