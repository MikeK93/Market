using System.ComponentModel;
namespace Market.UI.DealerForms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bussinessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myMerchandiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myBanksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveInfo = new System.Windows.Forms.Button();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.panelMyMerchandise = new System.Windows.Forms.Panel();
            this.btnManageMerchandise = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStorage = new System.Windows.Forms.TextBox();
            this.btnSaveCost = new System.Windows.Forms.Button();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCostByDealer = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbCategories = new System.Windows.Forms.Label();
            this.txtMerchandiseName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lvAllMerchandise = new System.Windows.Forms.ListView();
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.panelMyClients = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lvMyClients = new System.Windows.Forms.ListView();
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCPN = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCEmail = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.lbSalespersonMerchandise = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSalespersonLN = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSalespersonMN = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSalespersonFN = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panelBanks = new System.Windows.Forms.Panel();
            this.btnBanksManage = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtBankAddress = new System.Windows.Forms.TextBox();
            this.lvBanks = new System.Windows.Forms.ListView();
            this.menuStrip1.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelMyMerchandise.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelMyClients.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelBanks.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.bussinessToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(559, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.accountToolStripMenuItem.Text = "Аккаунт";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.infoToolStripMenuItem.Text = "Информация";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // bussinessToolStripMenuItem
            // 
            this.bussinessToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myMerchandiseToolStripMenuItem,
            this.myClientsToolStripMenuItem,
            this.myBanksToolStripMenuItem});
            this.bussinessToolStripMenuItem.Name = "bussinessToolStripMenuItem";
            this.bussinessToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.bussinessToolStripMenuItem.Text = "Бизнесс";
            // 
            // myMerchandiseToolStripMenuItem
            // 
            this.myMerchandiseToolStripMenuItem.Name = "myMerchandiseToolStripMenuItem";
            this.myMerchandiseToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.myMerchandiseToolStripMenuItem.Text = "Мой товар";
            this.myMerchandiseToolStripMenuItem.Click += new System.EventHandler(this.myMerchandiseToolStripMenuItem_Click);
            // 
            // myClientsToolStripMenuItem
            // 
            this.myClientsToolStripMenuItem.Name = "myClientsToolStripMenuItem";
            this.myClientsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.myClientsToolStripMenuItem.Text = "Мои клиенты";
            this.myClientsToolStripMenuItem.Click += new System.EventHandler(this.myClientsToolStripMenuItem_Click);
            // 
            // myBanksToolStripMenuItem
            // 
            this.myBanksToolStripMenuItem.Name = "myBanksToolStripMenuItem";
            this.myBanksToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.myBanksToolStripMenuItem.Text = "Мои банки";
            this.myBanksToolStripMenuItem.Click += new System.EventHandler(this.myBanksToolStripMenuItem_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.Controls.Add(this.label18);
            this.panelInfo.Controls.Add(this.txtEmail);
            this.panelInfo.Controls.Add(this.label7);
            this.panelInfo.Controls.Add(this.txtPhoneNumber);
            this.panelInfo.Controls.Add(this.label4);
            this.panelInfo.Controls.Add(this.btnSaveInfo);
            this.panelInfo.Controls.Add(this.cbGender);
            this.panelInfo.Controls.Add(this.label3);
            this.panelInfo.Controls.Add(this.txtLName);
            this.panelInfo.Controls.Add(this.label2);
            this.panelInfo.Controls.Add(this.txtMName);
            this.panelInfo.Controls.Add(this.label1);
            this.panelInfo.Controls.Add(this.txtFName);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(559, 262);
            this.panelInfo.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(212, 142);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(253, 139);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(100, 20);
            this.txtEmail.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Номер тел.:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(253, 113);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(100, 20);
            this.txtPhoneNumber.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Пол:";
            // 
            // btnSaveInfo
            // 
            this.btnSaveInfo.Location = new System.Drawing.Point(392, 191);
            this.btnSaveInfo.Name = "btnSaveInfo";
            this.btnSaveInfo.Size = new System.Drawing.Size(75, 23);
            this.btnSaveInfo.TabIndex = 7;
            this.btnSaveInfo.Text = "Сохранить";
            this.btnSaveInfo.UseVisualStyleBackColor = true;
            this.btnSaveInfo.Click += new System.EventHandler(this.btnSaveInfo_Click);
            // 
            // cbGender
            // 
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Location = new System.Drawing.Point(253, 161);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(100, 21);
            this.cbGender.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Фамилия:";
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(253, 88);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(100, 20);
            this.txtLName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Отчество:";
            // 
            // txtMName
            // 
            this.txtMName.Location = new System.Drawing.Point(253, 62);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(100, 20);
            this.txtMName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя:";
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(253, 36);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(100, 20);
            this.txtFName.TabIndex = 0;
            // 
            // panelMyMerchandise
            // 
            this.panelMyMerchandise.Controls.Add(this.btnManageMerchandise);
            this.panelMyMerchandise.Controls.Add(this.groupBox1);
            this.panelMyMerchandise.Controls.Add(this.label5);
            this.panelMyMerchandise.Controls.Add(this.lvAllMerchandise);
            this.panelMyMerchandise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMyMerchandise.Location = new System.Drawing.Point(0, 0);
            this.panelMyMerchandise.Name = "panelMyMerchandise";
            this.panelMyMerchandise.Size = new System.Drawing.Size(559, 262);
            this.panelMyMerchandise.TabIndex = 2;
            // 
            // btnManageMerchandise
            // 
            this.btnManageMerchandise.Location = new System.Drawing.Point(12, 207);
            this.btnManageMerchandise.Name = "btnManageMerchandise";
            this.btnManageMerchandise.Size = new System.Drawing.Size(81, 23);
            this.btnManageMerchandise.TabIndex = 13;
            this.btnManageMerchandise.Text = "Управление";
            this.btnManageMerchandise.UseVisualStyleBackColor = true;
            this.btnManageMerchandise.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStorage);
            this.groupBox1.Controls.Add(this.btnSaveCost);
            this.groupBox1.Controls.Add(this.txtCost);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtCostByDealer);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbCategories);
            this.groupBox1.Controls.Add(this.txtMerchandiseName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(264, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 185);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация";
            // 
            // txtStorage
            // 
            this.txtStorage.Enabled = false;
            this.txtStorage.Location = new System.Drawing.Point(9, 140);
            this.txtStorage.Name = "txtStorage";
            this.txtStorage.Size = new System.Drawing.Size(268, 20);
            this.txtStorage.TabIndex = 13;
            // 
            // btnSaveCost
            // 
            this.btnSaveCost.Enabled = false;
            this.btnSaveCost.Location = new System.Drawing.Point(107, 96);
            this.btnSaveCost.Name = "btnSaveCost";
            this.btnSaveCost.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCost.TabIndex = 12;
            this.btnSaveCost.Text = "Сохранить";
            this.btnSaveCost.UseVisualStyleBackColor = true;
            this.btnSaveCost.Click += new System.EventHandler(this.btnSaveCost_Click);
            // 
            // txtCost
            // 
            this.txtCost.Enabled = false;
            this.txtCost.Location = new System.Drawing.Point(70, 43);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(112, 20);
            this.txtCost.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Цена:";
            // 
            // txtCostByDealer
            // 
            this.txtCostByDealer.Location = new System.Drawing.Point(70, 68);
            this.txtCostByDealer.Name = "txtCostByDealer";
            this.txtCostByDealer.Size = new System.Drawing.Size(112, 20);
            this.txtCostByDealer.TabIndex = 9;
            this.txtCostByDealer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCostByDealer_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Моя цена:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Склады:";
            // 
            // lbCategories
            // 
            this.lbCategories.Location = new System.Drawing.Point(6, 163);
            this.lbCategories.Name = "lbCategories";
            this.lbCategories.Size = new System.Drawing.Size(268, 19);
            this.lbCategories.TabIndex = 6;
            this.lbCategories.Text = "Категории:";
            // 
            // txtMerchandiseName
            // 
            this.txtMerchandiseName.Enabled = false;
            this.txtMerchandiseName.Location = new System.Drawing.Point(70, 16);
            this.txtMerchandiseName.Name = "txtMerchandiseName";
            this.txtMerchandiseName.Size = new System.Drawing.Size(112, 20);
            this.txtMerchandiseName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Название:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Товары:";
            // 
            // lvAllMerchandise
            // 
            this.lvAllMerchandise.LargeImageList = this.imageListSmall;
            this.lvAllMerchandise.Location = new System.Drawing.Point(12, 20);
            this.lvAllMerchandise.Name = "lvAllMerchandise";
            this.lvAllMerchandise.Size = new System.Drawing.Size(245, 181);
            this.lvAllMerchandise.SmallImageList = this.imageListSmall;
            this.lvAllMerchandise.TabIndex = 0;
            this.lvAllMerchandise.UseCompatibleStateImageBehavior = false;
            this.lvAllMerchandise.View = System.Windows.Forms.View.List;
            this.lvAllMerchandise.SelectedIndexChanged += new System.EventHandler(this.lvAllMerchandise_SelectedIndexChanged);
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "merchandise-icon.ico");
            this.imageListSmall.Images.SetKeyName(1, "Artdesigner-Webtoys-User-black.ico");
            this.imageListSmall.Images.SetKeyName(2, "Artdesigner-Webtoys-Visa.ico");
            // 
            // panelMyClients
            // 
            this.panelMyClients.Controls.Add(this.label11);
            this.panelMyClients.Controls.Add(this.lvMyClients);
            this.panelMyClients.Controls.Add(this.groupBox2);
            this.panelMyClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMyClients.Location = new System.Drawing.Point(0, 24);
            this.panelMyClients.Name = "panelMyClients";
            this.panelMyClients.Size = new System.Drawing.Size(559, 238);
            this.panelMyClients.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 4);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Клиенты:";
            // 
            // lvMyClients
            // 
            this.lvMyClients.LargeImageList = this.imageListLarge;
            this.lvMyClients.Location = new System.Drawing.Point(12, 20);
            this.lvMyClients.Name = "lvMyClients";
            this.lvMyClients.Size = new System.Drawing.Size(148, 206);
            this.lvMyClients.SmallImageList = this.imageListSmall;
            this.lvMyClients.TabIndex = 0;
            this.lvMyClients.UseCompatibleStateImageBehavior = false;
            this.lvMyClients.SelectedIndexChanged += new System.EventHandler(this.lvMyClients_SelectedIndexChanged);
            // 
            // imageListLarge
            // 
            this.imageListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLarge.ImageStream")));
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLarge.Images.SetKeyName(0, "merchandise-icon.ico");
            this.imageListLarge.Images.SetKeyName(1, "Artdesigner-Webtoys-User-black.ico");
            this.imageListLarge.Images.SetKeyName(2, "Artdesigner-Webtoys-Visa.ico");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCPN);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.txtCEmail);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.lbSalespersonMerchandise);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtSalespersonLN);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtSalespersonMN);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtSalespersonFN);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(169, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(387, 206);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Детали";
            // 
            // txtCPN
            // 
            this.txtCPN.Location = new System.Drawing.Point(263, 44);
            this.txtCPN.Name = "txtCPN";
            this.txtCPN.ReadOnly = true;
            this.txtCPN.Size = new System.Drawing.Size(109, 20);
            this.txtCPN.TabIndex = 15;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(189, 44);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "Номер тел.:";
            // 
            // txtCEmail
            // 
            this.txtCEmail.Location = new System.Drawing.Point(263, 17);
            this.txtCEmail.Name = "txtCEmail";
            this.txtCEmail.ReadOnly = true;
            this.txtCEmail.Size = new System.Drawing.Size(109, 20);
            this.txtCEmail.TabIndex = 13;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(222, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 13);
            this.label20.TabIndex = 12;
            this.label20.Text = "Email:";
            // 
            // lbSalespersonMerchandise
            // 
            this.lbSalespersonMerchandise.FormattingEnabled = true;
            this.lbSalespersonMerchandise.Location = new System.Drawing.Point(9, 113);
            this.lbSalespersonMerchandise.Name = "lbSalespersonMerchandise";
            this.lbSalespersonMerchandise.Size = new System.Drawing.Size(360, 82);
            this.lbSalespersonMerchandise.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 95);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Товар:";
            // 
            // txtSalespersonLN
            // 
            this.txtSalespersonLN.Location = new System.Drawing.Point(81, 69);
            this.txtSalespersonLN.Name = "txtSalespersonLN";
            this.txtSalespersonLN.ReadOnly = true;
            this.txtSalespersonLN.Size = new System.Drawing.Size(89, 20);
            this.txtSalespersonLN.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 72);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Фамилия:";
            // 
            // txtSalespersonMN
            // 
            this.txtSalespersonMN.Location = new System.Drawing.Point(80, 43);
            this.txtSalespersonMN.Name = "txtSalespersonMN";
            this.txtSalespersonMN.ReadOnly = true;
            this.txtSalespersonMN.Size = new System.Drawing.Size(89, 20);
            this.txtSalespersonMN.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "Отчество:";
            // 
            // txtSalespersonFN
            // 
            this.txtSalespersonFN.Location = new System.Drawing.Point(80, 17);
            this.txtSalespersonFN.Name = "txtSalespersonFN";
            this.txtSalespersonFN.ReadOnly = true;
            this.txtSalespersonFN.Size = new System.Drawing.Size(89, 20);
            this.txtSalespersonFN.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(33, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Имя:";
            // 
            // panelBanks
            // 
            this.panelBanks.Controls.Add(this.btnBanksManage);
            this.panelBanks.Controls.Add(this.label17);
            this.panelBanks.Controls.Add(this.label16);
            this.panelBanks.Controls.Add(this.txtBankAddress);
            this.panelBanks.Controls.Add(this.lvBanks);
            this.panelBanks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBanks.Location = new System.Drawing.Point(0, 0);
            this.panelBanks.Name = "panelBanks";
            this.panelBanks.Size = new System.Drawing.Size(559, 262);
            this.panelBanks.TabIndex = 11;
            // 
            // btnBanksManage
            // 
            this.btnBanksManage.Location = new System.Drawing.Point(336, 184);
            this.btnBanksManage.Name = "btnBanksManage";
            this.btnBanksManage.Size = new System.Drawing.Size(90, 23);
            this.btnBanksManage.TabIndex = 4;
            this.btnBanksManage.Text = "Управление";
            this.btnBanksManage.UseVisualStyleBackColor = true;
            this.btnBanksManage.Click += new System.EventHandler(this.btnBanksManage_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(331, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Адресс:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(104, 2);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Банки:";
            // 
            // txtBankAddress
            // 
            this.txtBankAddress.Enabled = false;
            this.txtBankAddress.Location = new System.Drawing.Point(334, 32);
            this.txtBankAddress.Multiline = true;
            this.txtBankAddress.Name = "txtBankAddress";
            this.txtBankAddress.Size = new System.Drawing.Size(106, 96);
            this.txtBankAddress.TabIndex = 1;
            // 
            // lvBanks
            // 
            this.lvBanks.LargeImageList = this.imageListLarge;
            this.lvBanks.Location = new System.Drawing.Point(107, 18);
            this.lvBanks.Name = "lvBanks";
            this.lvBanks.Size = new System.Drawing.Size(218, 188);
            this.lvBanks.SmallImageList = this.imageListSmall;
            this.lvBanks.TabIndex = 0;
            this.lvBanks.UseCompatibleStateImageBehavior = false;
            this.lvBanks.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvBanks_ItemCheck);
            this.lvBanks.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvBanks_ItemChecked);
            this.lvBanks.SelectedIndexChanged += new System.EventHandler(this.lvBanks_SelectedIndexChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 262);
            this.Controls.Add(this.panelMyClients);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelMyMerchandise);
            this.Controls.Add(this.panelBanks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelMyMerchandise.ResumeLayout(false);
            this.panelMyMerchandise.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelMyClients.ResumeLayout(false);
            this.panelMyClients.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelBanks.ResumeLayout(false);
            this.panelBanks.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem bussinessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myMerchandiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem myBanksToolStripMenuItem;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveInfo;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.Panel panelMyMerchandise;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lvAllMerchandise;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMerchandiseName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCostByDealer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbCategories;
        private System.Windows.Forms.Button btnSaveCost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Button btnManageMerchandise;
        private System.Windows.Forms.Panel panelMyClients;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListView lvMyClients;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSalespersonLN;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSalespersonMN;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSalespersonFN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ImageList imageListLarge;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox lbSalespersonMerchandise;
        private System.Windows.Forms.TextBox txtStorage;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panelBanks;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtBankAddress;
        private System.Windows.Forms.ListView lvBanks;
        private System.Windows.Forms.Button btnBanksManage;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtCPN;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtCEmail;
        private System.Windows.Forms.Label label20;
    }
}