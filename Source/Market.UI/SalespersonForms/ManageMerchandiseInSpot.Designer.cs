using System.ComponentModel;
namespace Market.UI.SalespersonForms
{
    partial class ManageMerchandiseInSpot
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ManageMerchandiseInSpot));
            this.lvAllMerchandise = new System.Windows.Forms.ListView();
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.lvSelectedMerchandise = new System.Windows.Forms.ListView();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDLN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDMN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDFN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMCost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvAllMerchandise
            // 
            this.lvAllMerchandise.LargeImageList = this.imageListLarge;
            this.lvAllMerchandise.Location = new System.Drawing.Point(12, 23);
            this.lvAllMerchandise.Name = "lvAllMerchandise";
            this.lvAllMerchandise.Size = new System.Drawing.Size(175, 205);
            this.lvAllMerchandise.SmallImageList = this.imageListLarge;
            this.lvAllMerchandise.TabIndex = 0;
            this.lvAllMerchandise.UseCompatibleStateImageBehavior = false;
            this.lvAllMerchandise.View = System.Windows.Forms.View.List;
            this.lvAllMerchandise.SelectedIndexChanged += new System.EventHandler(this.lvAllMerchandise_SelectedIndexChanged);
            // 
            // imageListLarge
            // 
            this.imageListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLarge.ImageStream")));
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLarge.Images.SetKeyName(0, "Artdesigner-Webtoys-Download.ico");
            this.imageListLarge.Images.SetKeyName(1, "merchandise-icon.ico");
            // 
            // lvSelectedMerchandise
            // 
            this.lvSelectedMerchandise.LargeImageList = this.imageListLarge;
            this.lvSelectedMerchandise.Location = new System.Drawing.Point(386, 23);
            this.lvSelectedMerchandise.Name = "lvSelectedMerchandise";
            this.lvSelectedMerchandise.Size = new System.Drawing.Size(175, 205);
            this.lvSelectedMerchandise.SmallImageList = this.imageListLarge;
            this.lvSelectedMerchandise.TabIndex = 1;
            this.lvSelectedMerchandise.UseCompatibleStateImageBehavior = false;
            this.lvSelectedMerchandise.View = System.Windows.Forms.View.List;
            this.lvSelectedMerchandise.SelectedIndexChanged += new System.EventHandler(this.lvSelectedMerchandise_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(486, 233);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Сохранить";
            this.toolTip1.SetToolTip(this.btnOk, "Сохранить изменения.");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(386, 233);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Выход";
            this.toolTip1.SetToolTip(this.btnCancel, "Выход. Если изменения не были сохранены, они будут потеряны.");
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Весь товар:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выбраный товар:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMCost);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMName);
            this.groupBox1.Location = new System.Drawing.Point(193, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 176);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Детали";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtDLN);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDMN);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtDFN);
            this.groupBox2.Location = new System.Drawing.Point(9, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 100);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поставщик";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Фамилия:";
            // 
            // txtDLN
            // 
            this.txtDLN.Enabled = false;
            this.txtDLN.Location = new System.Drawing.Point(69, 71);
            this.txtDLN.Name = "txtDLN";
            this.txtDLN.Size = new System.Drawing.Size(97, 20);
            this.txtDLN.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Отчество:";
            // 
            // txtDMN
            // 
            this.txtDMN.Enabled = false;
            this.txtDMN.Location = new System.Drawing.Point(69, 45);
            this.txtDMN.Name = "txtDMN";
            this.txtDMN.Size = new System.Drawing.Size(97, 20);
            this.txtDMN.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Имя:";
            // 
            // txtDFN
            // 
            this.txtDFN.Enabled = false;
            this.txtDFN.Location = new System.Drawing.Point(69, 19);
            this.txtDFN.Name = "txtDFN";
            this.txtDFN.Size = new System.Drawing.Size(97, 20);
            this.txtDFN.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Цена:";
            // 
            // txtMCost
            // 
            this.txtMCost.Enabled = false;
            this.txtMCost.Location = new System.Drawing.Point(72, 43);
            this.txtMCost.Name = "txtMCost";
            this.txtMCost.Size = new System.Drawing.Size(109, 20);
            this.txtMCost.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Название:";
            // 
            // txtMName
            // 
            this.txtMName.Enabled = false;
            this.txtMName.Location = new System.Drawing.Point(72, 17);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(109, 20);
            this.txtMName.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(193, 205);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(305, 205);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Удалить";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // ManageMerchandiseInSpot
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(573, 268);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lvSelectedMerchandise);
            this.Controls.Add(this.lvAllMerchandise);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ManageMerchandiseInSpot";
            this.Text = "Товары";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvAllMerchandise;
        private System.Windows.Forms.ListView lvSelectedMerchandise;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ImageList imageListLarge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMCost;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDLN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDMN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDFN;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}