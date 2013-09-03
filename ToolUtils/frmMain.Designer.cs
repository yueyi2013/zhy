namespace ToolUtils
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
            this.tmAdview = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnTestProxy = new System.Windows.Forms.Button();
            this.txtProxy = new System.Windows.Forms.TextBox();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.19831F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.80169F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(904, 474);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // wbHTML
            // 
            this.wbHTML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbHTML.Location = new System.Drawing.Point(3, 94);
            this.wbHTML.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbHTML.Name = "wbHTML";
            this.wbHTML.Size = new System.Drawing.Size(898, 377);
            this.wbHTML.TabIndex = 0;
            // 
            // tmAdview
            // 
            this.tmAdview.Interval = 60000;
            this.tmAdview.Tick += new System.EventHandler(this.tmAdview_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProxy);
            this.groupBox1.Controls.Add(this.btnTestProxy);
            this.groupBox1.Controls.Add(this.btnReg);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 85);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(28, 31);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(75, 23);
            this.btnReg.TabIndex = 2;
            this.btnReg.Text = "注册";
            this.btnReg.UseVisualStyleBackColor = true;
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
            // txtProxy
            // 
            this.txtProxy.Location = new System.Drawing.Point(383, 31);
            this.txtProxy.Name = "txtProxy";
            this.txtProxy.Size = new System.Drawing.Size(100, 21);
            this.txtProxy.TabIndex = 4;
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
        private System.Windows.Forms.TextBox txtProxy;

    }
}

