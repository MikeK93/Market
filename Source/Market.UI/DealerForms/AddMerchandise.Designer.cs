using System.ComponentModel;
namespace Market.UI.DealerForms
{
    partial class AddMerchandise
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(AddMerchandise));
            this.lvAllMerchandise = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSaveCost = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtYourCost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbTags = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStorage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbMyMerchandise = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvAllMerchandise
            // 
            this.lvAllMerchandise.LargeImageList = this.imageList1;
            this.lvAllMerchandise.Location = new System.Drawing.Point(12, 25);
            this.lvAllMerchandise.Name = "lvAllMerchandise";
            this.lvAllMerchandise.Size = new System.Drawing.Size(247, 281);
            this.lvAllMerchandise.SmallImageList = this.imageList1;
            this.lvAllMerchandise.TabIndex = 0;
            this.lvAllMerchandise.UseCompatibleStateImageBehavior = false;
            this.lvAllMerchandise.View = System.Windows.Forms.View.List;
            this.lvAllMerchandise.SelectedIndexChanged += new System.EventHandler(this.lvAllMerchandise_SelectedIndexChanged);
            this.lvAllMerchandise.Click += new System.EventHandler(this.lvAllMerchandise_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "merchandise-icon.ico");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Товары:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSaveCost);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtYourCost);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCost);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.lbTags);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtStorage);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.lbMyMerchandise);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Location = new System.Drawing.Point(265, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 265);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Детали";
            // 
            // btnSaveCost
            // 
            this.btnSaveCost.Enabled = false;
            this.btnSaveCost.Location = new System.Drawing.Point(171, 209);
            this.btnSaveCost.Name = "btnSaveCost";
            this.btnSaveCost.Size = new System.Drawing.Size(80, 23);
            this.btnSaveCost.TabIndex = 5;
            this.btnSaveCost.Text = "Сохранить";
            this.toolTip1.SetToolTip(this.btnSaveCost, "Сохранить указанную цену.");
            this.btnSaveCost.UseVisualStyleBackColor = true;
            this.btnSaveCost.Click += new System.EventHandler(this.btnSaveCost_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Моя цена:";
            // 
            // txtYourCost
            // 
            this.txtYourCost.Font = new System.Drawing.Font("Moire", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYourCost.Location = new System.Drawing.Point(74, 211);
            this.txtYourCost.Name = "txtYourCost";
            this.txtYourCost.Size = new System.Drawing.Size(91, 22);
            this.txtYourCost.TabIndex = 14;
            this.txtYourCost.TextChanged += new System.EventHandler(this.txtYourCost_TextChanged);
            this.txtYourCost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtYourCost_KeyDown);
            this.txtYourCost.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtYourCost_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Цена:";
            // 
            // txtCost
            // 
            this.txtCost.Enabled = false;
            this.txtCost.Location = new System.Drawing.Point(74, 185);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(91, 20);
            this.txtCost.TabIndex = 12;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "+";
            this.toolTip1.SetToolTip(this.btnAdd, "Добавить товар.");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbTags
            // 
            this.lbTags.Location = new System.Drawing.Point(6, 239);
            this.lbTags.Name = "lbTags";
            this.lbTags.Size = new System.Drawing.Size(245, 17);
            this.lbTags.TabIndex = 9;
            this.lbTags.Text = "Категории:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Склад:";
            // 
            // txtStorage
            // 
            this.txtStorage.Enabled = false;
            this.txtStorage.Location = new System.Drawing.Point(74, 159);
            this.txtStorage.Name = "txtStorage";
            this.txtStorage.Size = new System.Drawing.Size(177, 20);
            this.txtStorage.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Название:";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(74, 133);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(177, 20);
            this.txtName.TabIndex = 6;
            // 
            // lbMyMerchandise
            // 
            this.lbMyMerchandise.FormattingEnabled = true;
            this.lbMyMerchandise.Location = new System.Drawing.Point(36, 19);
            this.lbMyMerchandise.Name = "lbMyMerchandise";
            this.lbMyMerchandise.Size = new System.Drawing.Size(215, 108);
            this.lbMyMerchandise.TabIndex = 5;
            this.lbMyMerchandise.SelectedIndexChanged += new System.EventHandler(this.lbMyMerchandise_SelectedIndexChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(6, 48);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(24, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "-";
            this.toolTip1.SetToolTip(this.btnRemove, "Удалить товар.");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(421, 283);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Сохранить";
            this.toolTip1.SetToolTip(this.btnOK, "Сохранить изменения.");
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(285, 283);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Выйти";
            this.toolTip1.SetToolTip(this.btnCancel, "Выход без сохранения.");
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // AddMerchandise
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(528, 317);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvAllMerchandise);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddMerchandise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление товара";
            this.Load += new System.EventHandler(this.AddMerchandise_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvAllMerchandise;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lbMyMerchandise;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStorage;
        private System.Windows.Forms.Label lbTags;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtYourCost;
        private System.Windows.Forms.Button btnSaveCost;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}