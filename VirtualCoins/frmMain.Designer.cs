namespace VirtualCoins
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnView = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExtRateUSD = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbBTC_E = new System.Windows.Forms.GroupBox();
            this.lblBTC = new System.Windows.Forms.Label();
            this.bgWorkThread = new System.ComponentModel.BackgroundWorker();
            this.lblLTC = new System.Windows.Forms.Label();
            this.lblNMC = new System.Windows.Forms.Label();
            this.chkIsRMB = new System.Windows.Forms.CheckBox();
            this.lblPPC = new System.Windows.Forms.Label();
            this.lblNVC = new System.Windows.Forms.Label();
            this.lblXPM = new System.Windows.Forms.Label();
            this.lblFTC = new System.Windows.Forms.Label();
            this.lblTRC = new System.Windows.Forms.Label();
            this.tmRefresh = new System.Windows.Forms.Timer(this.components);
            this.nudRefresh = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAutoRefresh = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbBTC_E.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(572, 18);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 0;
            this.btnView.Text = "手动刷新(&R)";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "人民币兑美元汇率：";
            // 
            // txtExtRateUSD
            // 
            this.txtExtRateUSD.Location = new System.Drawing.Point(128, 20);
            this.txtExtRateUSD.Name = "txtExtRateUSD";
            this.txtExtRateUSD.Size = new System.Drawing.Size(100, 21);
            this.txtExtRateUSD.TabIndex = 2;
            this.txtExtRateUSD.Text = "6.0668";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbBTC_E, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(832, 450);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAutoRefresh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudRefresh);
            this.groupBox1.Controls.Add(this.chkIsRMB);
            this.groupBox1.Controls.Add(this.btnView);
            this.groupBox1.Controls.Add(this.txtExtRateUSD);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(826, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "汇率";
            // 
            // gbBTC_E
            // 
            this.gbBTC_E.Controls.Add(this.label10);
            this.gbBTC_E.Controls.Add(this.label9);
            this.gbBTC_E.Controls.Add(this.lblTRC);
            this.gbBTC_E.Controls.Add(this.label8);
            this.gbBTC_E.Controls.Add(this.lblFTC);
            this.gbBTC_E.Controls.Add(this.label7);
            this.gbBTC_E.Controls.Add(this.lblXPM);
            this.gbBTC_E.Controls.Add(this.label6);
            this.gbBTC_E.Controls.Add(this.lblNVC);
            this.gbBTC_E.Controls.Add(this.label5);
            this.gbBTC_E.Controls.Add(this.lblPPC);
            this.gbBTC_E.Controls.Add(this.label4);
            this.gbBTC_E.Controls.Add(this.lblNMC);
            this.gbBTC_E.Controls.Add(this.label12);
            this.gbBTC_E.Controls.Add(this.label11);
            this.gbBTC_E.Controls.Add(this.label3);
            this.gbBTC_E.Controls.Add(this.label14);
            this.gbBTC_E.Controls.Add(this.lblLTC);
            this.gbBTC_E.Controls.Add(this.label13);
            this.gbBTC_E.Controls.Add(this.lblBTC);
            this.gbBTC_E.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBTC_E.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbBTC_E.Location = new System.Drawing.Point(3, 53);
            this.gbBTC_E.Name = "gbBTC_E";
            this.gbBTC_E.Size = new System.Drawing.Size(826, 394);
            this.gbBTC_E.TabIndex = 1;
            this.gbBTC_E.TabStop = false;
            this.gbBTC_E.Text = "虚拟币";
            // 
            // lblBTC
            // 
            this.lblBTC.AutoSize = true;
            this.lblBTC.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBTC.Location = new System.Drawing.Point(102, 50);
            this.lblBTC.Name = "lblBTC";
            this.lblBTC.Size = new System.Drawing.Size(28, 14);
            this.lblBTC.TabIndex = 0;
            this.lblBTC.Text = "BTC";
            // 
            // bgWorkThread
            // 
            this.bgWorkThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkThread_DoWork);
            this.bgWorkThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkThread_RunWorkerCompleted);
            // 
            // lblLTC
            // 
            this.lblLTC.AutoSize = true;
            this.lblLTC.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblLTC.Location = new System.Drawing.Point(194, 50);
            this.lblLTC.Name = "lblLTC";
            this.lblLTC.Size = new System.Drawing.Size(28, 14);
            this.lblLTC.TabIndex = 0;
            this.lblLTC.Text = "LTC";
            // 
            // lblNMC
            // 
            this.lblNMC.AutoSize = true;
            this.lblNMC.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNMC.Location = new System.Drawing.Point(286, 50);
            this.lblNMC.Name = "lblNMC";
            this.lblNMC.Size = new System.Drawing.Size(28, 14);
            this.lblNMC.TabIndex = 0;
            this.lblNMC.Text = "NMC";
            // 
            // chkIsRMB
            // 
            this.chkIsRMB.AutoSize = true;
            this.chkIsRMB.Checked = true;
            this.chkIsRMB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsRMB.Location = new System.Drawing.Point(236, 24);
            this.chkIsRMB.Name = "chkIsRMB";
            this.chkIsRMB.Size = new System.Drawing.Size(60, 16);
            this.chkIsRMB.TabIndex = 3;
            this.chkIsRMB.Text = "人民币";
            this.chkIsRMB.UseVisualStyleBackColor = true;
            // 
            // lblPPC
            // 
            this.lblPPC.AutoSize = true;
            this.lblPPC.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPPC.Location = new System.Drawing.Point(378, 50);
            this.lblPPC.Name = "lblPPC";
            this.lblPPC.Size = new System.Drawing.Size(28, 14);
            this.lblPPC.TabIndex = 0;
            this.lblPPC.Text = "PPC";
            // 
            // lblNVC
            // 
            this.lblNVC.AutoSize = true;
            this.lblNVC.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNVC.Location = new System.Drawing.Point(470, 50);
            this.lblNVC.Name = "lblNVC";
            this.lblNVC.Size = new System.Drawing.Size(28, 14);
            this.lblNVC.TabIndex = 0;
            this.lblNVC.Text = "NVC";
            // 
            // lblXPM
            // 
            this.lblXPM.AutoSize = true;
            this.lblXPM.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblXPM.Location = new System.Drawing.Point(562, 50);
            this.lblXPM.Name = "lblXPM";
            this.lblXPM.Size = new System.Drawing.Size(28, 14);
            this.lblXPM.TabIndex = 0;
            this.lblXPM.Text = "XPM";
            // 
            // lblFTC
            // 
            this.lblFTC.AutoSize = true;
            this.lblFTC.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFTC.Location = new System.Drawing.Point(654, 50);
            this.lblFTC.Name = "lblFTC";
            this.lblFTC.Size = new System.Drawing.Size(28, 14);
            this.lblFTC.TabIndex = 0;
            this.lblFTC.Text = "FTC";
            // 
            // lblTRC
            // 
            this.lblTRC.AutoSize = true;
            this.lblTRC.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTRC.Location = new System.Drawing.Point(746, 50);
            this.lblTRC.Name = "lblTRC";
            this.lblTRC.Size = new System.Drawing.Size(28, 14);
            this.lblTRC.TabIndex = 0;
            this.lblTRC.Text = "TRC";
            // 
            // tmRefresh
            // 
            this.tmRefresh.Interval = 5000;
            this.tmRefresh.Tick += new System.EventHandler(this.tmRefresh_Tick);
            // 
            // nudRefresh
            // 
            this.nudRefresh.Location = new System.Drawing.Point(323, 18);
            this.nudRefresh.Name = "nudRefresh";
            this.nudRefresh.Size = new System.Drawing.Size(79, 21);
            this.nudRefresh.TabIndex = 4;
            this.nudRefresh.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudRefresh.ValueChanged += new System.EventHandler(this.nudRefresh_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "秒(s)";
            // 
            // btnAutoRefresh
            // 
            this.btnAutoRefresh.Location = new System.Drawing.Point(449, 18);
            this.btnAutoRefresh.Name = "btnAutoRefresh";
            this.btnAutoRefresh.Size = new System.Drawing.Size(104, 23);
            this.btnAutoRefresh.TabIndex = 6;
            this.btnAutoRefresh.Text = "开始自动刷新";
            this.btnAutoRefresh.UseVisualStyleBackColor = true;
            this.btnAutoRefresh.Click += new System.EventHandler(this.btnAutoRefresh_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(102, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "BTC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(194, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "LTC";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(286, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "NMC";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(378, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "PPC";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(470, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "NVC";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(562, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "XPM";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(654, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "FTC";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(746, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "TRC";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(9, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 14);
            this.label11.TabIndex = 0;
            this.label11.Text = "BTC-E";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(9, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 14);
            this.label12.TabIndex = 0;
            this.label12.Text = "OKCoin";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(102, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 14);
            this.label13.TabIndex = 0;
            this.label13.Text = "BTC";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(194, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(28, 14);
            this.label14.TabIndex = 0;
            this.label14.Text = "LTC";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "控制面板";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbBTC_E.ResumeLayout(false);
            this.gbBTC_E.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRefresh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExtRateUSD;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbBTC_E;
        private System.Windows.Forms.Label lblBTC;
        private System.ComponentModel.BackgroundWorker bgWorkThread;
        private System.Windows.Forms.Label lblLTC;
        private System.Windows.Forms.Label lblNMC;
        private System.Windows.Forms.CheckBox chkIsRMB;
        private System.Windows.Forms.Label lblPPC;
        private System.Windows.Forms.Label lblTRC;
        private System.Windows.Forms.Label lblFTC;
        private System.Windows.Forms.Label lblXPM;
        private System.Windows.Forms.Label lblNVC;
        private System.Windows.Forms.Timer tmRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudRefresh;
        private System.Windows.Forms.Button btnAutoRefresh;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
    }
}

