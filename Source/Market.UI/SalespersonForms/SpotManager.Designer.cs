using System.ComponentModel;
namespace Market.UI.SalespersonForms
{
    partial class SpotManager
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
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(SpotManager));
            this.lvAllSpots = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.dtpSpotDateStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSpotMCAddress = new System.Windows.Forms.TextBox();
            this.txtSpotMCName = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSpotSTName = new System.Windows.Forms.TextBox();
            this.txtSpotSTCost = new System.Windows.Forms.TextBox();
            this.txtSpotSTGuards = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSpotNumber = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lvSelectedSpots = new System.Windows.Forms.ListView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvAllSpots
            // 
            this.lvAllSpots.LargeImageList = this.imageList1;
            this.lvAllSpots.Location = new System.Drawing.Point(12, 25);
            this.lvAllSpots.Name = "lvAllSpots";
            this.lvAllSpots.Size = new System.Drawing.Size(172, 347);
            this.lvAllSpots.SmallImageList = this.imageList1;
            this.lvAllSpots.TabIndex = 1;
            this.lvAllSpots.UseCompatibleStateImageBehavior = false;
            this.lvAllSpots.View = System.Windows.Forms.View.List;
            this.lvAllSpots.SelectedIndexChanged += new System.EventHandler(this.lvAllSpots_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Artdesigner-Webtoys-Cart.ico");
            this.imageList1.Images.SetKeyName(1, "Artdesigner-Webtoys-Flag.ico");
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(12, 378);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Выйти";
            this.toolTip1.SetToolTip(this.btnCancel, "Выход без сохранения.");
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(546, 378);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Сохранить";
            this.toolTip1.SetToolTip(this.btnOk, "Сохранить изменения.");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Доступные места:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выбраные места:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.dtpSpotDateStart);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtSpotNumber);
            this.groupBox2.Location = new System.Drawing.Point(190, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 318);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Детали";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Адрес:";
            // 
            // txtAddress
            // 
            this.txtAddress.Enabled = false;
            this.txtAddress.Location = new System.Drawing.Point(71, 58);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(157, 43);
            this.txtAddress.TabIndex = 9;
            // 
            // dtpSpotDateStart
            // 
            this.dtpSpotDateStart.Enabled = false;
            this.dtpSpotDateStart.Location = new System.Drawing.Point(107, 21);
            this.dtpSpotDateStart.Name = "dtpSpotDateStart";
            this.dtpSpotDateStart.Size = new System.Drawing.Size(121, 20);
            this.dtpSpotDateStart.TabIndex = 8;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSpotMCAddress);
            this.groupBox3.Controls.Add(this.txtSpotMCName);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(19, 204);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 92);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Изготовитель";
            // 
            // txtSpotMCAddress
            // 
            this.txtSpotMCAddress.Enabled = false;
            this.txtSpotMCAddress.Location = new System.Drawing.Point(67, 44);
            this.txtSpotMCAddress.Multiline = true;
            this.txtSpotMCAddress.Name = "txtSpotMCAddress";
            this.txtSpotMCAddress.ReadOnly = true;
            this.txtSpotMCAddress.Size = new System.Drawing.Size(136, 37);
            this.txtSpotMCAddress.TabIndex = 12;
            // 
            // txtSpotMCName
            // 
            this.txtSpotMCName.Enabled = false;
            this.txtSpotMCName.Location = new System.Drawing.Point(79, 18);
            this.txtSpotMCName.Name = "txtSpotMCName";
            this.txtSpotMCName.ReadOnly = true;
            this.txtSpotMCName.Size = new System.Drawing.Size(124, 20);
            this.txtSpotMCName.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 23);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(60, 13);
            this.label17.TabIndex = 11;
            this.label17.Text = "Название:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 44);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 13);
            this.label18.TabIndex = 13;
            this.label18.Text = "Адресс:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSpotSTName);
            this.groupBox4.Controls.Add(this.txtSpotSTCost);
            this.groupBox4.Controls.Add(this.txtSpotSTGuards);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(19, 125);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(209, 73);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Тип защиты";
            // 
            // txtSpotSTName
            // 
            this.txtSpotSTName.Enabled = false;
            this.txtSpotSTName.Location = new System.Drawing.Point(67, 20);
            this.txtSpotSTName.Name = "txtSpotSTName";
            this.txtSpotSTName.ReadOnly = true;
            this.txtSpotSTName.Size = new System.Drawing.Size(136, 20);
            this.txtSpotSTName.TabIndex = 4;
            // 
            // txtSpotSTCost
            // 
            this.txtSpotSTCost.Enabled = false;
            this.txtSpotSTCost.Location = new System.Drawing.Point(162, 46);
            this.txtSpotSTCost.Name = "txtSpotSTCost";
            this.txtSpotSTCost.ReadOnly = true;
            this.txtSpotSTCost.Size = new System.Drawing.Size(41, 20);
            this.txtSpotSTCost.TabIndex = 8;
            // 
            // txtSpotSTGuards
            // 
            this.txtSpotSTGuards.Enabled = false;
            this.txtSpotSTGuards.Location = new System.Drawing.Point(67, 46);
            this.txtSpotSTGuards.Name = "txtSpotSTGuards";
            this.txtSpotSTGuards.ReadOnly = true;
            this.txtSpotSTGuards.Size = new System.Drawing.Size(28, 20);
            this.txtSpotSTGuards.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 49);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Охрана:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 23);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 13);
            this.label14.TabIndex = 5;
            this.label14.Text = "Тип:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(125, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Цена:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(44, 13);
            this.label13.TabIndex = 3;
            this.label13.Text = "Номер:";
            // 
            // txtSpotNumber
            // 
            this.txtSpotNumber.Enabled = false;
            this.txtSpotNumber.Location = new System.Drawing.Point(71, 21);
            this.txtSpotNumber.Name = "txtSpotNumber";
            this.txtSpotNumber.ReadOnly = true;
            this.txtSpotNumber.Size = new System.Drawing.Size(30, 20);
            this.txtSpotNumber.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(231, 349);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "+";
            this.toolTip1.SetToolTip(this.btnAdd, "Добавить место.");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(368, 349);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(29, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "-";
            this.toolTip1.SetToolTip(this.btnRemove, "Удалить место.");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lvSelectedSpots
            // 
            this.lvSelectedSpots.LargeImageList = this.imageList1;
            this.lvSelectedSpots.Location = new System.Drawing.Point(449, 25);
            this.lvSelectedSpots.Name = "lvSelectedSpots";
            this.lvSelectedSpots.Size = new System.Drawing.Size(172, 347);
            this.lvSelectedSpots.SmallImageList = this.imageList1;
            this.lvSelectedSpots.TabIndex = 10;
            this.lvSelectedSpots.UseCompatibleStateImageBehavior = false;
            this.lvSelectedSpots.View = System.Windows.Forms.View.List;
            this.lvSelectedSpots.SelectedIndexChanged += new System.EventHandler(this.lvSelectedSpots_SelectedIndexChanged);
            // 
            // SpotManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(633, 413);
            this.Controls.Add(this.lvSelectedSpots);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lvAllSpots);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SpotManager";
            this.Text = "Управление местами";
            this.Load += new System.EventHandler(this.SpotManager_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvAllSpots;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtpSpotDateStart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSpotMCAddress;
        private System.Windows.Forms.TextBox txtSpotMCName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtSpotSTName;
        private System.Windows.Forms.TextBox txtSpotSTCost;
        private System.Windows.Forms.TextBox txtSpotSTGuards;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSpotNumber;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListView lvSelectedSpots;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddress;
    }
}