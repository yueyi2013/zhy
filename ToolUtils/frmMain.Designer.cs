﻿namespace ToolUtils
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.wbHTML = new System.Windows.Forms.WebBrowser();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnProxyList = new System.Windows.Forms.Button();
            this.txtProxy = new System.Windows.Forms.TextBox();
            this.lsProxy = new System.Windows.Forms.ListBox();
            this.btnPsnInfo = new System.Windows.Forms.Button();
            this.btnViewAd = new System.Windows.Forms.Button();
            this.btnTestProxy = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.tmAdview = new System.Windows.Forms.Timer(this.components);
            this.btnCnty = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.wbHTML, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.81013F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.18987F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(904, 474);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // wbHTML
            // 
            this.wbHTML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbHTML.Location = new System.Drawing.Point(3, 168);
            this.wbHTML.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHTML.Name = "wbHTML";
            this.wbHTML.Size = new System.Drawing.Size(898, 303);
            this.wbHTML.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCnty);
            this.groupBox1.Controls.Add(this.btnProxyList);
            this.groupBox1.Controls.Add(this.txtProxy);
            this.groupBox1.Controls.Add(this.lsProxy);
            this.groupBox1.Controls.Add(this.btnPsnInfo);
            this.groupBox1.Controls.Add(this.btnViewAd);
            this.groupBox1.Controls.Add(this.btnTestProxy);
            this.groupBox1.Controls.Add(this.btnReg);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 159);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnProxyList
            // 
            this.btnProxyList.Location = new System.Drawing.Point(28, 77);
            this.btnProxyList.Name = "btnProxyList";
            this.btnProxyList.Size = new System.Drawing.Size(75, 23);
            this.btnProxyList.TabIndex = 9;
            this.btnProxyList.Text = "代理地址获取";
            this.btnProxyList.UseVisualStyleBackColor = true;
            this.btnProxyList.Click += new System.EventHandler(this.btnProxyList_Click);
            // 
            // txtProxy
            // 
            this.txtProxy.Location = new System.Drawing.Point(700, 32);
            this.txtProxy.Name = "txtProxy";
            this.txtProxy.Size = new System.Drawing.Size(100, 21);
            this.txtProxy.TabIndex = 8;
            // 
            // lsProxy
            // 
            this.lsProxy.FormattingEnabled = true;
            this.lsProxy.ItemHeight = 12;
            this.lsProxy.Location = new System.Drawing.Point(496, 31);
            this.lsProxy.Name = "lsProxy";
            this.lsProxy.Size = new System.Drawing.Size(120, 88);
            this.lsProxy.TabIndex = 7;
            // 
            // btnPsnInfo
            // 
            this.btnPsnInfo.Location = new System.Drawing.Point(348, 30);
            this.btnPsnInfo.Name = "btnPsnInfo";
            this.btnPsnInfo.Size = new System.Drawing.Size(75, 23);
            this.btnPsnInfo.TabIndex = 6;
            this.btnPsnInfo.Text = "生成身份";
            this.btnPsnInfo.UseVisualStyleBackColor = true;
            this.btnPsnInfo.Click += new System.EventHandler(this.btnPsnInfo_Click);
            // 
            // btnViewAd
            // 
            this.btnViewAd.Location = new System.Drawing.Point(119, 31);
            this.btnViewAd.Name = "btnViewAd";
            this.btnViewAd.Size = new System.Drawing.Size(75, 23);
            this.btnViewAd.TabIndex = 5;
            this.btnViewAd.Text = "看广告";
            this.btnViewAd.UseVisualStyleBackColor = true;
            this.btnViewAd.Click += new System.EventHandler(this.btnViewAd_Click);
            // 
            // btnTestProxy
            // 
            this.btnTestProxy.Location = new System.Drawing.Point(210, 31);
            this.btnTestProxy.Name = "btnTestProxy";
            this.btnTestProxy.Size = new System.Drawing.Size(105, 23);
            this.btnTestProxy.TabIndex = 3;
            this.btnTestProxy.Text = "测试代理地址";
            this.btnTestProxy.UseVisualStyleBackColor = true;
            this.btnTestProxy.Click += new System.EventHandler(this.btnTestProxy_Click);
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(28, 31);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(75, 23);
            this.btnReg.TabIndex = 2;
            this.btnReg.Text = "注册";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // tmAdview
            // 
            this.tmAdview.Interval = 60000;
            this.tmAdview.Tick += new System.EventHandler(this.tmAdview_Tick);
            // 
            // btnCnty
            // 
            this.btnCnty.Location = new System.Drawing.Point(119, 76);
            this.btnCnty.Name = "btnCnty";
            this.btnCnty.Size = new System.Drawing.Size(75, 23);
            this.btnCnty.TabIndex = 10;
            this.btnCnty.Text = "国家获取";
            this.btnCnty.UseVisualStyleBackColor = true;
            this.btnCnty.Click += new System.EventHandler(this.btnCnty_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 474);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmMain";
            this.Text = "主窗体";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.WebBrowser wbHTML;
        private System.Windows.Forms.Timer tmAdview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTestProxy;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnViewAd;
        private System.Windows.Forms.Button btnPsnInfo;
        private System.Windows.Forms.ListBox lsProxy;
        private System.Windows.Forms.TextBox txtProxy;
        private System.Windows.Forms.Button btnProxyList;
        private System.Windows.Forms.Button btnCnty;

    }
}

