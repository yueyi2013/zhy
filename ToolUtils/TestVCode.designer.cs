namespace ToolUtils
{
    partial class TestVCode
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
            this.btn_getvcode = new System.Windows.Forms.Button();
            this.lab_pic = new System.Windows.Forms.Label();
            this.pic_code = new System.Windows.Forms.PictureBox();
            this.lab_result = new System.Windows.Forms.Label();
            this.linklab_result = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pic_code)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_getvcode
            // 
            this.btn_getvcode.Location = new System.Drawing.Point(286, 10);
            this.btn_getvcode.Name = "btn_getvcode";
            this.btn_getvcode.Size = new System.Drawing.Size(75, 23);
            this.btn_getvcode.TabIndex = 2;
            this.btn_getvcode.Text = "刷新";
            this.btn_getvcode.UseVisualStyleBackColor = true;
            this.btn_getvcode.Click += new System.EventHandler(this.btn_getvcode_Click);
            // 
            // lab_pic
            // 
            this.lab_pic.AutoSize = true;
            this.lab_pic.Location = new System.Drawing.Point(5, 15);
            this.lab_pic.Name = "lab_pic";
            this.lab_pic.Size = new System.Drawing.Size(77, 12);
            this.lab_pic.TabIndex = 4;
            this.lab_pic.Text = "验证码图片：";
            // 
            // pic_code
            // 
            this.pic_code.Location = new System.Drawing.Point(84, 8);
            this.pic_code.Name = "pic_code";
            this.pic_code.Size = new System.Drawing.Size(79, 34);
            this.pic_code.TabIndex = 5;
            this.pic_code.TabStop = false;
            // 
            // lab_result
            // 
            this.lab_result.AutoSize = true;
            this.lab_result.Location = new System.Drawing.Point(173, 15);
            this.lab_result.Name = "lab_result";
            this.lab_result.Size = new System.Drawing.Size(65, 12);
            this.lab_result.TabIndex = 7;
            this.lab_result.Text = "识别结果：";
            // 
            // linklab_result
            // 
            this.linklab_result.AutoSize = true;
            this.linklab_result.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linklab_result.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linklab_result.LinkColor = System.Drawing.Color.Red;
            this.linklab_result.Location = new System.Drawing.Point(235, 11);
            this.linklab_result.Name = "linklab_result";
            this.linklab_result.Size = new System.Drawing.Size(0, 16);
            this.linklab_result.TabIndex = 8;
            // 
            // TestVCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 78);
            this.Controls.Add(this.linklab_result);
            this.Controls.Add(this.lab_result);
            this.Controls.Add(this.pic_code);
            this.Controls.Add(this.lab_pic);
            this.Controls.Add(this.btn_getvcode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TestVCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "简单数字验证码识别";
            ((System.ComponentModel.ISupportInitialize)(this.pic_code)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_getvcode;
        private System.Windows.Forms.Label lab_pic;
        private System.Windows.Forms.PictureBox pic_code;
        private System.Windows.Forms.Label lab_result;
        private System.Windows.Forms.LinkLabel linklab_result;
    }
}

