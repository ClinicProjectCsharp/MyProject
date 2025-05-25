namespace ProjectCsharp.Login.views.Setting
{
    partial class frmSettingImge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettingImge));
            this.pcMain = new System.Windows.Forms.PictureBox();
            this.pcLogin = new System.Windows.Forms.PictureBox();
            this.pcIcon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnUpdateIcon = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.UpdateLogin = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pcMain
            // 
            this.pcMain.Image = ((System.Drawing.Image)(resources.GetObject("pcMain.Image")));
            this.pcMain.Location = new System.Drawing.Point(55, 71);
            this.pcMain.Name = "pcMain";
            this.pcMain.Size = new System.Drawing.Size(313, 196);
            this.pcMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcMain.TabIndex = 0;
            this.pcMain.TabStop = false;
            // 
            // pcLogin
            // 
            this.pcLogin.Image = ((System.Drawing.Image)(resources.GetObject("pcLogin.Image")));
            this.pcLogin.Location = new System.Drawing.Point(442, 71);
            this.pcLogin.Name = "pcLogin";
            this.pcLogin.Size = new System.Drawing.Size(313, 196);
            this.pcLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcLogin.TabIndex = 1;
            this.pcLogin.TabStop = false;
            // 
            // pcIcon
            // 
            this.pcIcon.Image = ((System.Drawing.Image)(resources.GetObject("pcIcon.Image")));
            this.pcIcon.Location = new System.Drawing.Point(309, 296);
            this.pcIcon.Name = "pcIcon";
            this.pcIcon.Size = new System.Drawing.Size(193, 123);
            this.pcIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcIcon.TabIndex = 2;
            this.pcIcon.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(338, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "اعدادات الصور";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(139, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "الصفحة الرئيسية";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(519, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "صفحة تسجيل الدخول";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(372, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 29);
            this.label4.TabIndex = 4;
            this.label4.Text = "الشعار";
            // 
            // btnUpdateIcon
            // 
            this.btnUpdateIcon.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateIcon.Image")));
            this.btnUpdateIcon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateIcon.Location = new System.Drawing.Point(354, 425);
            this.btnUpdateIcon.Name = "btnUpdateIcon";
            this.btnUpdateIcon.Size = new System.Drawing.Size(115, 40);
            this.btnUpdateIcon.TabIndex = 20;
            this.btnUpdateIcon.Text = "تعديل";
            this.btnUpdateIcon.UseVisualStyleBackColor = true;
            this.btnUpdateIcon.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(133, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 40);
            this.button1.TabIndex = 20;
            this.button1.Text = "تعديل";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.UpdateMainScreenClick);
            // 
            // UpdateLogin
            // 
            this.UpdateLogin.Image = ((System.Drawing.Image)(resources.GetObject("UpdateLogin.Image")));
            this.UpdateLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.UpdateLogin.Location = new System.Drawing.Point(547, 273);
            this.UpdateLogin.Name = "UpdateLogin";
            this.UpdateLogin.Size = new System.Drawing.Size(115, 40);
            this.UpdateLogin.TabIndex = 20;
            this.UpdateLogin.Text = "تعديل";
            this.UpdateLogin.UseVisualStyleBackColor = true;
            this.UpdateLogin.Click += new System.EventHandler(this.UpdateLoginClic);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(487, 492);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 40);
            this.button2.TabIndex = 21;
            this.button2.Text = "حفظ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(213, 492);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 40);
            this.button3.TabIndex = 21;
            this.button3.Text = "خروج";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmSettingImge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 544);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.UpdateLogin);
            this.Controls.Add(this.btnUpdateIcon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pcIcon);
            this.Controls.Add(this.pcLogin);
            this.Controls.Add(this.pcMain);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmSettingImge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSettingImge";
            this.Load += new System.EventHandler(this.frmSettingImge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pcMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcMain;
        private System.Windows.Forms.PictureBox pcLogin;
        private System.Windows.Forms.PictureBox pcIcon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnUpdateIcon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button UpdateLogin;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.OpenFileDialog openFileDialog3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}