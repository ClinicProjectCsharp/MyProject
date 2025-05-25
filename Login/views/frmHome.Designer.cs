namespace ProjectCsharp.Login.views
{
    partial class frmHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbReport = new System.Windows.Forms.Label();
            this.pcMain = new System.Windows.Forms.PictureBox();
            this.mnMain = new System.Windows.Forms.MenuStrip();
            this.mnDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.mnEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSick = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMoalgat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDepartments = new System.Windows.Forms.MenuStrip();
            this.ManagerDepart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnLogo = new System.Windows.Forms.MenuStrip();
            this.Login = new System.Windows.Forms.ToolStripMenuItem();
            this.Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnEmployees = new System.Windows.Forms.MenuStrip();
            this.ManagerEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.ManagerDoctor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnDiseases = new System.Windows.Forms.MenuStrip();
            this.ManagerSick = new System.Windows.Forms.ToolStripMenuItem();
            this.ManagerMawaeed = new System.Windows.Forms.ToolStripMenuItem();
            this.mnMoalegats = new System.Windows.Forms.MenuStrip();
            this.ManagerMoalegat = new System.Windows.Forms.ToolStripMenuItem();
            this.ManagerStatment = new System.Windows.Forms.ToolStripMenuItem();
            this.mnUsers = new System.Windows.Forms.MenuStrip();
            this.Users = new System.Windows.Forms.ToolStripMenuItem();
            this.Perimision = new System.Windows.Forms.ToolStripMenuItem();
            this.CurrentUser = new System.Windows.Forms.ToolStripMenuItem();
            this.LogoOfAnutherUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSettings = new System.Windows.Forms.MenuStrip();
            this.SettingBase = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingImge = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingStatments = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.backUp = new System.Windows.Forms.ToolStripMenuItem();
            this.اعادةتعينكلمةالسرToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pcNotification = new System.Windows.Forms.PictureBox();
            this.pcPoint = new System.Windows.Forms.PictureBox();
            this.Notification = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcMain)).BeginInit();
            this.mnMain.SuspendLayout();
            this.mnDepartments.SuspendLayout();
            this.mnLogo.SuspendLayout();
            this.mnEmployees.SuspendLayout();
            this.mnDiseases.SuspendLayout();
            this.mnMoalegats.SuspendLayout();
            this.mnUsers.SuspendLayout();
            this.mnSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcNotification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcPoint)).BeginInit();
            this.Notification.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.lbReport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 605);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1197, 47);
            this.panel2.TabIndex = 2;
            // 
            // lbReport
            // 
            this.lbReport.AutoSize = true;
            this.lbReport.ForeColor = System.Drawing.Color.White;
            this.lbReport.Location = new System.Drawing.Point(535, 14);
            this.lbReport.Name = "lbReport";
            this.lbReport.Size = new System.Drawing.Size(96, 24);
            this.lbReport.TabIndex = 0;
            this.lbReport.Text = "كافة التقارير";
            // 
            // pcMain
            // 
            this.pcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcMain.Location = new System.Drawing.Point(0, 0);
            this.pcMain.Name = "pcMain";
            this.pcMain.Size = new System.Drawing.Size(1197, 652);
            this.pcMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcMain.TabIndex = 0;
            this.pcMain.TabStop = false;
            this.pcMain.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // mnMain
            // 
            this.mnMain.AutoSize = false;
            this.mnMain.BackColor = System.Drawing.Color.SteelBlue;
            this.mnMain.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnDepartment,
            this.mnEmployee,
            this.mnSick,
            this.mnMoalgat,
            this.mnUser,
            this.mnSetting,
            this.mnLogin});
            this.mnMain.Location = new System.Drawing.Point(0, 0);
            this.mnMain.Name = "mnMain";
            this.mnMain.Padding = new System.Windows.Forms.Padding(6, 10, 5, 2);
            this.mnMain.Size = new System.Drawing.Size(1197, 48);
            this.mnMain.TabIndex = 0;
            this.mnMain.Text = "menuStrip1";
            this.mnMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnMain_ItemClicked);
            this.mnMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.mnMain_DragDrop);
            // 
            // mnDepartment
            // 
            this.mnDepartment.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnDepartment.ForeColor = System.Drawing.Color.White;
            this.mnDepartment.Image = ((System.Drawing.Image)(resources.GetObject("mnDepartment.Image")));
            this.mnDepartment.Name = "mnDepartment";
            this.mnDepartment.Size = new System.Drawing.Size(114, 36);
            this.mnDepartment.Text = "الاقسام";
            this.mnDepartment.Click += new System.EventHandler(this.mnDepartment_Click);
            // 
            // mnEmployee
            // 
            this.mnEmployee.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnEmployee.ForeColor = System.Drawing.Color.White;
            this.mnEmployee.Image = ((System.Drawing.Image)(resources.GetObject("mnEmployee.Image")));
            this.mnEmployee.Name = "mnEmployee";
            this.mnEmployee.Size = new System.Drawing.Size(139, 36);
            this.mnEmployee.Text = "الموضفين";
            this.mnEmployee.Click += new System.EventHandler(this.mnEmployee_Click);
            // 
            // mnSick
            // 
            this.mnSick.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnSick.ForeColor = System.Drawing.Color.White;
            this.mnSick.Image = ((System.Drawing.Image)(resources.GetObject("mnSick.Image")));
            this.mnSick.Name = "mnSick";
            this.mnSick.Size = new System.Drawing.Size(128, 36);
            this.mnSick.Text = "المرضئ";
            this.mnSick.Click += new System.EventHandler(this.mnSick_Click);
            // 
            // mnMoalgat
            // 
            this.mnMoalgat.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnMoalgat.ForeColor = System.Drawing.Color.White;
            this.mnMoalgat.Image = ((System.Drawing.Image)(resources.GetObject("mnMoalgat.Image")));
            this.mnMoalgat.Name = "mnMoalgat";
            this.mnMoalgat.Size = new System.Drawing.Size(141, 36);
            this.mnMoalgat.Text = "المعالجات";
            this.mnMoalgat.Click += new System.EventHandler(this.mnMoalgat_Click);
            // 
            // mnUser
            // 
            this.mnUser.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnUser.ForeColor = System.Drawing.Color.White;
            this.mnUser.Image = ((System.Drawing.Image)(resources.GetObject("mnUser.Image")));
            this.mnUser.Name = "mnUser";
            this.mnUser.Size = new System.Drawing.Size(154, 36);
            this.mnUser.Text = "المستخدمين";
            this.mnUser.Click += new System.EventHandler(this.mnUser_Click);
            // 
            // mnSetting
            // 
            this.mnSetting.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnSetting.ForeColor = System.Drawing.Color.White;
            this.mnSetting.Image = ((System.Drawing.Image)(resources.GetObject("mnSetting.Image")));
            this.mnSetting.Name = "mnSetting";
            this.mnSetting.Size = new System.Drawing.Size(139, 36);
            this.mnSetting.Text = "الاعدادات";
            this.mnSetting.Click += new System.EventHandler(this.mnSetting_Click);
            // 
            // mnLogin
            // 
            this.mnLogin.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnLogin.ForeColor = System.Drawing.Color.White;
            this.mnLogin.Image = ((System.Drawing.Image)(resources.GetObject("mnLogin.Image")));
            this.mnLogin.Name = "mnLogin";
            this.mnLogin.Size = new System.Drawing.Size(178, 36);
            this.mnLogin.Text = "تسجيل الدخول";
            this.mnLogin.Click += new System.EventHandler(this.mnLogin_Click);
            // 
            // mnDepartments
            // 
            this.mnDepartments.AutoSize = false;
            this.mnDepartments.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnDepartments.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnDepartments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManagerDepart});
            this.mnDepartments.Location = new System.Drawing.Point(0, 48);
            this.mnDepartments.Name = "mnDepartments";
            this.mnDepartments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnDepartments.Size = new System.Drawing.Size(1197, 60);
            this.mnDepartments.TabIndex = 3;
            this.mnDepartments.Text = "menuStrip2";
            // 
            // ManagerDepart
            // 
            this.ManagerDepart.Image = ((System.Drawing.Image)(resources.GetObject("ManagerDepart.Image")));
            this.ManagerDepart.Name = "ManagerDepart";
            this.ManagerDepart.Size = new System.Drawing.Size(131, 56);
            this.ManagerDepart.Text = "إدارة الاقسام";
            this.ManagerDepart.Click += new System.EventHandler(this.ManagerDepart_Click);
            // 
            // mnLogo
            // 
            this.mnLogo.AutoSize = false;
            this.mnLogo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnLogo.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnLogo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Login,
            this.Logout});
            this.mnLogo.Location = new System.Drawing.Point(0, 108);
            this.mnLogo.Name = "mnLogo";
            this.mnLogo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnLogo.Size = new System.Drawing.Size(1197, 60);
            this.mnLogo.TabIndex = 4;
            this.mnLogo.Text = "menuStrip1";
            // 
            // Login
            // 
            this.Login.Image = ((System.Drawing.Image)(resources.GetObject("Login.Image")));
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(143, 56);
            this.Login.Text = "تسجيل الدخول";
            this.Login.Click += new System.EventHandler(this.تسجيلالدخولToolStripMenuItem_Click_1);
            // 
            // Logout
            // 
            this.Logout.Image = ((System.Drawing.Image)(resources.GetObject("Logout.Image")));
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(146, 56);
            this.Logout.Text = "تسجيل الخروج";
            this.Logout.Click += new System.EventHandler(this.تسجيلالخروجToolStripMenuItem_Click);
            // 
            // mnEmployees
            // 
            this.mnEmployees.AutoSize = false;
            this.mnEmployees.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnEmployees.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnEmployees.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManagerEmployee,
            this.ManagerDoctor});
            this.mnEmployees.Location = new System.Drawing.Point(0, 168);
            this.mnEmployees.Name = "mnEmployees";
            this.mnEmployees.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnEmployees.Size = new System.Drawing.Size(1197, 60);
            this.mnEmployees.TabIndex = 5;
            this.mnEmployees.Text = "menuStrip1";
            // 
            // ManagerEmployee
            // 
            this.ManagerEmployee.Image = ((System.Drawing.Image)(resources.GetObject("ManagerEmployee.Image")));
            this.ManagerEmployee.Name = "ManagerEmployee";
            this.ManagerEmployee.Size = new System.Drawing.Size(145, 56);
            this.ManagerEmployee.Text = "إدارة الموظفين";
            this.ManagerEmployee.Click += new System.EventHandler(this.ManagerEmployee_Click);
            // 
            // ManagerDoctor
            // 
            this.ManagerDoctor.Image = ((System.Drawing.Image)(resources.GetObject("ManagerDoctor.Image")));
            this.ManagerDoctor.Name = "ManagerDoctor";
            this.ManagerDoctor.Size = new System.Drawing.Size(130, 56);
            this.ManagerDoctor.Text = "ادارة الاطباء";
            this.ManagerDoctor.Click += new System.EventHandler(this.ManagerDoctor_Click);
            // 
            // mnDiseases
            // 
            this.mnDiseases.AutoSize = false;
            this.mnDiseases.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnDiseases.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnDiseases.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManagerSick,
            this.ManagerMawaeed});
            this.mnDiseases.Location = new System.Drawing.Point(0, 228);
            this.mnDiseases.Name = "mnDiseases";
            this.mnDiseases.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnDiseases.Size = new System.Drawing.Size(1197, 60);
            this.mnDiseases.TabIndex = 6;
            this.mnDiseases.Text = "menuStrip1";
            // 
            // ManagerSick
            // 
            this.ManagerSick.Image = ((System.Drawing.Image)(resources.GetObject("ManagerSick.Image")));
            this.ManagerSick.Name = "ManagerSick";
            this.ManagerSick.Size = new System.Drawing.Size(138, 56);
            this.ManagerSick.Text = "إدارة المريض";
            this.ManagerSick.Click += new System.EventHandler(this.ManagerSick_Click);
            // 
            // ManagerMawaeed
            // 
            this.ManagerMawaeed.Image = ((System.Drawing.Image)(resources.GetObject("ManagerMawaeed.Image")));
            this.ManagerMawaeed.Name = "ManagerMawaeed";
            this.ManagerMawaeed.Size = new System.Drawing.Size(140, 56);
            this.ManagerMawaeed.Text = "إدارة المواعيد";
            this.ManagerMawaeed.Click += new System.EventHandler(this.ManagerMawaeed_Click);
            // 
            // mnMoalegats
            // 
            this.mnMoalegats.AutoSize = false;
            this.mnMoalegats.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnMoalegats.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnMoalegats.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManagerMoalegat,
            this.ManagerStatment});
            this.mnMoalegats.Location = new System.Drawing.Point(0, 288);
            this.mnMoalegats.Name = "mnMoalegats";
            this.mnMoalegats.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnMoalegats.Size = new System.Drawing.Size(1197, 60);
            this.mnMoalegats.TabIndex = 7;
            this.mnMoalegats.Text = "menuStrip1";
            // 
            // ManagerMoalegat
            // 
            this.ManagerMoalegat.Image = ((System.Drawing.Image)(resources.GetObject("ManagerMoalegat.Image")));
            this.ManagerMoalegat.Name = "ManagerMoalegat";
            this.ManagerMoalegat.Size = new System.Drawing.Size(138, 56);
            this.ManagerMoalegat.Text = "ادارة المعالجة";
            this.ManagerMoalegat.Click += new System.EventHandler(this.ManagerMoalegat_Click);
            // 
            // ManagerStatment
            // 
            this.ManagerStatment.Image = ((System.Drawing.Image)(resources.GetObject("ManagerStatment.Image")));
            this.ManagerStatment.Name = "ManagerStatment";
            this.ManagerStatment.Size = new System.Drawing.Size(163, 56);
            this.ManagerStatment.Text = "الكشوفات الصحية";
            this.ManagerStatment.Click += new System.EventHandler(this.ManagerStatment_Click);
            // 
            // mnUsers
            // 
            this.mnUsers.AutoSize = false;
            this.mnUsers.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnUsers.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnUsers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Users,
            this.Perimision,
            this.CurrentUser,
            this.LogoOfAnutherUser});
            this.mnUsers.Location = new System.Drawing.Point(0, 348);
            this.mnUsers.Name = "mnUsers";
            this.mnUsers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnUsers.Size = new System.Drawing.Size(1197, 60);
            this.mnUsers.TabIndex = 8;
            this.mnUsers.Text = "menuStrip1";
            // 
            // Users
            // 
            this.Users.Image = ((System.Drawing.Image)(resources.GetObject("Users.Image")));
            this.Users.Name = "Users";
            this.Users.Size = new System.Drawing.Size(127, 56);
            this.Users.Text = "المستخدمين";
            this.Users.Click += new System.EventHandler(this.أضافةمستخدمToolStripMenuItem_Click);
            // 
            // Perimision
            // 
            this.Perimision.Image = ((System.Drawing.Image)(resources.GetObject("Perimision.Image")));
            this.Perimision.Name = "Perimision";
            this.Perimision.Size = new System.Drawing.Size(118, 56);
            this.Perimision.Text = "الصلاحيات";
            this.Perimision.Click += new System.EventHandler(this.صلاحياتالمستخدمينToolStripMenuItem_Click);
            // 
            // CurrentUser
            // 
            this.CurrentUser.Image = ((System.Drawing.Image)(resources.GetObject("CurrentUser.Image")));
            this.CurrentUser.Name = "CurrentUser";
            this.CurrentUser.Size = new System.Drawing.Size(153, 56);
            this.CurrentUser.Text = "المستخدم الحالي";
            this.CurrentUser.Click += new System.EventHandler(this.المستخدمالحاليToolStripMenuItem_Click);
            // 
            // LogoOfAnutherUser
            // 
            this.LogoOfAnutherUser.Image = ((System.Drawing.Image)(resources.GetObject("LogoOfAnutherUser.Image")));
            this.LogoOfAnutherUser.Name = "LogoOfAnutherUser";
            this.LogoOfAnutherUser.Size = new System.Drawing.Size(183, 56);
            this.LogoOfAnutherUser.Text = "الدخول بمستخدم اخر";
            this.LogoOfAnutherUser.Click += new System.EventHandler(this.الدخولبمستخدماخرToolStripMenuItem_Click);
            // 
            // mnSettings
            // 
            this.mnSettings.AutoSize = false;
            this.mnSettings.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnSettings.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.mnSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingBase,
            this.SettingImge,
            this.SettingStatments,
            this.SettingLanguage,
            this.backUp,
            this.اعادةتعينكلمةالسرToolStripMenuItem});
            this.mnSettings.Location = new System.Drawing.Point(0, 408);
            this.mnSettings.Name = "mnSettings";
            this.mnSettings.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnSettings.Size = new System.Drawing.Size(1197, 60);
            this.mnSettings.TabIndex = 9;
            this.mnSettings.Text = "menuStrip1";
            // 
            // SettingBase
            // 
            this.SettingBase.Image = ((System.Drawing.Image)(resources.GetObject("SettingBase.Image")));
            this.SettingBase.Name = "SettingBase";
            this.SettingBase.Size = new System.Drawing.Size(170, 56);
            this.SettingBase.Text = "الاعدادات الاساسية";
            this.SettingBase.Click += new System.EventHandler(this.الاعداداتالاساسيةToolStripMenuItem_Click);
            // 
            // SettingImge
            // 
            this.SettingImge.Image = ((System.Drawing.Image)(resources.GetObject("SettingImge.Image")));
            this.SettingImge.Name = "SettingImge";
            this.SettingImge.Size = new System.Drawing.Size(209, 56);
            this.SettingImge.Text = "اعدادات الصور والمضهر";
            this.SettingImge.Click += new System.EventHandler(this.اعداداتالصوروالمضهرToolStripMenuItem_Click);
            // 
            // SettingStatments
            // 
            this.SettingStatments.Image = ((System.Drawing.Image)(resources.GetObject("SettingStatments.Image")));
            this.SettingStatments.Name = "SettingStatments";
            this.SettingStatments.Size = new System.Drawing.Size(165, 56);
            this.SettingStatments.Text = "اعدادات الكشوفات";
            this.SettingStatments.Click += new System.EventHandler(this.اعداداتالكشوفاتToolStripMenuItem_Click);
            // 
            // SettingLanguage
            // 
            this.SettingLanguage.Image = ((System.Drawing.Image)(resources.GetObject("SettingLanguage.Image")));
            this.SettingLanguage.Name = "SettingLanguage";
            this.SettingLanguage.Size = new System.Drawing.Size(134, 56);
            this.SettingLanguage.Text = "اعدادات اللغة";
            this.SettingLanguage.Click += new System.EventHandler(this.اعداداتاللغةToolStripMenuItem_Click);
            // 
            // backUp
            // 
            this.backUp.Image = ((System.Drawing.Image)(resources.GetObject("backUp.Image")));
            this.backUp.Name = "backUp";
            this.backUp.Size = new System.Drawing.Size(153, 56);
            this.backUp.Text = "النسخ الاحتياطي";
            this.backUp.Click += new System.EventHandler(this.النسخالاحتياطيToolStripMenuItem_Click);
            // 
            // اعادةتعينكلمةالسرToolStripMenuItem
            // 
            this.اعادةتعينكلمةالسرToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("اعادةتعينكلمةالسرToolStripMenuItem.Image")));
            this.اعادةتعينكلمةالسرToolStripMenuItem.Name = "اعادةتعينكلمةالسرToolStripMenuItem";
            this.اعادةتعينكلمةالسرToolStripMenuItem.Size = new System.Drawing.Size(183, 56);
            this.اعادةتعينكلمةالسرToolStripMenuItem.Text = "اعادة تعين كلمة السر";
            this.اعادةتعينكلمةالسرToolStripMenuItem.Click += new System.EventHandler(this.اعادةتعينكلمةالسرToolStripMenuItem_Click);
            // 
            // pcNotification
            // 
            this.pcNotification.BackColor = System.Drawing.Color.SteelBlue;
            this.pcNotification.Image = ((System.Drawing.Image)(resources.GetObject("pcNotification.Image")));
            this.pcNotification.Location = new System.Drawing.Point(3, 9);
            this.pcNotification.Name = "pcNotification";
            this.pcNotification.Size = new System.Drawing.Size(40, 36);
            this.pcNotification.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcNotification.TabIndex = 10;
            this.pcNotification.TabStop = false;
            this.pcNotification.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // pcPoint
            // 
            this.pcPoint.BackColor = System.Drawing.Color.Black;
            this.pcPoint.Image = ((System.Drawing.Image)(resources.GetObject("pcPoint.Image")));
            this.pcPoint.Location = new System.Drawing.Point(23, 19);
            this.pcPoint.Name = "pcPoint";
            this.pcPoint.Size = new System.Drawing.Size(10, 16);
            this.pcPoint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcPoint.TabIndex = 11;
            this.pcPoint.TabStop = false;
            this.pcPoint.Click += new System.EventHandler(this.pcPoint_Click);
            // 
            // Notification
            // 
            this.Notification.BackColor = System.Drawing.Color.SteelBlue;
            this.Notification.Controls.Add(this.pcPoint);
            this.Notification.Controls.Add(this.pcNotification);
            this.Notification.Location = new System.Drawing.Point(12, 0);
            this.Notification.Name = "Notification";
            this.Notification.Size = new System.Drawing.Size(47, 48);
            this.Notification.TabIndex = 12;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1197, 652);
            this.Controls.Add(this.Notification);
            this.Controls.Add(this.mnSettings);
            this.Controls.Add(this.mnUsers);
            this.Controls.Add(this.mnMoalegats);
            this.Controls.Add(this.mnDiseases);
            this.Controls.Add(this.mnEmployees);
            this.Controls.Add(this.mnLogo);
            this.Controls.Add(this.mnDepartments);
            this.Controls.Add(this.mnMain);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pcMain);
            this.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnDepartments;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmHome";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHome";
            this.Load += new System.EventHandler(this.frmHome_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcMain)).EndInit();
            this.mnMain.ResumeLayout(false);
            this.mnMain.PerformLayout();
            this.mnDepartments.ResumeLayout(false);
            this.mnDepartments.PerformLayout();
            this.mnLogo.ResumeLayout(false);
            this.mnLogo.PerformLayout();
            this.mnEmployees.ResumeLayout(false);
            this.mnEmployees.PerformLayout();
            this.mnDiseases.ResumeLayout(false);
            this.mnDiseases.PerformLayout();
            this.mnMoalegats.ResumeLayout(false);
            this.mnMoalegats.PerformLayout();
            this.mnUsers.ResumeLayout(false);
            this.mnUsers.PerformLayout();
            this.mnSettings.ResumeLayout(false);
            this.mnSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcNotification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcPoint)).EndInit();
            this.Notification.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pcMain;
        private System.Windows.Forms.Label lbReport;
        private System.Windows.Forms.MenuStrip mnMain;
        private System.Windows.Forms.ToolStripMenuItem mnDepartment;
        private System.Windows.Forms.ToolStripMenuItem mnEmployee;
        private System.Windows.Forms.ToolStripMenuItem mnSick;
        private System.Windows.Forms.ToolStripMenuItem mnMoalgat;
        private System.Windows.Forms.ToolStripMenuItem mnUser;
        private System.Windows.Forms.ToolStripMenuItem mnSetting;
        private System.Windows.Forms.ToolStripMenuItem mnLogin;
        private System.Windows.Forms.MenuStrip mnDepartments;
        private System.Windows.Forms.ToolStripMenuItem ManagerDepart;
        private System.Windows.Forms.MenuStrip mnLogo;
        private System.Windows.Forms.ToolStripMenuItem Login;
        private System.Windows.Forms.ToolStripMenuItem Logout;
        private System.Windows.Forms.MenuStrip mnEmployees;
        private System.Windows.Forms.ToolStripMenuItem ManagerEmployee;
        private System.Windows.Forms.ToolStripMenuItem ManagerDoctor;
        private System.Windows.Forms.MenuStrip mnDiseases;
        private System.Windows.Forms.ToolStripMenuItem ManagerSick;
        private System.Windows.Forms.ToolStripMenuItem ManagerMawaeed;
        private System.Windows.Forms.MenuStrip mnMoalegats;
        private System.Windows.Forms.ToolStripMenuItem ManagerMoalegat;
        private System.Windows.Forms.ToolStripMenuItem ManagerStatment;
        private System.Windows.Forms.MenuStrip mnUsers;
        private System.Windows.Forms.ToolStripMenuItem Users;
        private System.Windows.Forms.ToolStripMenuItem Perimision;
        private System.Windows.Forms.MenuStrip mnSettings;
        private System.Windows.Forms.ToolStripMenuItem CurrentUser;
        private System.Windows.Forms.ToolStripMenuItem LogoOfAnutherUser;
        private System.Windows.Forms.ToolStripMenuItem SettingBase;
        private System.Windows.Forms.ToolStripMenuItem SettingImge;
        private System.Windows.Forms.ToolStripMenuItem SettingStatments;
        private System.Windows.Forms.ToolStripMenuItem SettingLanguage;
        private System.Windows.Forms.ToolStripMenuItem backUp;
        private System.Windows.Forms.ToolStripMenuItem اعادةتعينكلمةالسرToolStripMenuItem;
        private System.Windows.Forms.PictureBox pcNotification;
        private System.Windows.Forms.PictureBox pcPoint;
        private System.Windows.Forms.Panel Notification;
    }
}