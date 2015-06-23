using System.ComponentModel;
namespace Market.UI.SalespersonForms
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
            this.btnAccept = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBoxSelectedItems = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lbSelectedItems = new System.Windows.Forms.ListBox();
            this.treeViewAllMerchandise = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDealer = new System.Windows.Forms.TextBox();
            this.txtDealersCost = new System.Windows.Forms.TextBox();
            this.txtYourCost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxMerchandiseInfo = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMerchandiseName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxSelectedItems.SuspendLayout();
            this.groupBoxMerchandiseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(507, 309);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Сохранить";
            this.toolTip1.SetToolTip(this.btnAccept, "Сохранить изменения.");
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(388, 309);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Выход";
            this.toolTip1.SetToolTip(this.btnCancel, "Выйти. Изменения будут потеряны если не сохранены.");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBoxSelectedItems
            // 
            this.groupBoxSelectedItems.Controls.Add(this.lblInfo);
            this.groupBoxSelectedItems.Controls.Add(this.lbSelectedItems);
            this.groupBoxSelectedItems.Location = new System.Drawing.Point(382, 13);
            this.groupBoxSelectedItems.Name = "groupBoxSelectedItems";
            this.groupBoxSelectedItems.Size = new System.Drawing.Size(200, 290);
            this.groupBoxSelectedItems.TabIndex = 2;
            this.groupBoxSelectedItems.TabStop = false;
            this.groupBoxSelectedItems.Text = "Ваши товары";
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(6, 253);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(188, 34);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Детали";
            // 
            // lbSelectedItems
            // 
            this.lbSelectedItems.FormattingEnabled = true;
            this.lbSelectedItems.Location = new System.Drawing.Point(6, 19);
            this.lbSelectedItems.Name = "lbSelectedItems";
            this.lbSelectedItems.Size = new System.Drawing.Size(188, 225);
            this.lbSelectedItems.TabIndex = 0;
            this.lbSelectedItems.SelectedIndexChanged += new System.EventHandler(this.lbSelectedItems_SelectedIndexChanged);
            // 
            // treeViewAllMerchandise
            // 
            this.treeViewAllMerchandise.ImageIndex = 0;
            this.treeViewAllMerchandise.ImageList = this.imageList1;
            this.treeViewAllMerchandise.Location = new System.Drawing.Point(13, 13);
            this.treeViewAllMerchandise.Name = "treeViewAllMerchandise";
            this.treeViewAllMerchandise.SelectedImageIndex = 0;
            this.treeViewAllMerchandise.Size = new System.Drawing.Size(165, 290);
            this.treeViewAllMerchandise.TabIndex = 3;
            this.treeViewAllMerchandise.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeViewAllMerchandise_BeforeExpand);
            this.treeViewAllMerchandise.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewAllMerchandise_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pin-icon.ico");
            this.imageList1.Images.SetKeyName(1, "merchandise-icon.ico");
            this.imageList1.Images.SetKeyName(2, "dealer-male-icon.ico");
            this.imageList1.Images.SetKeyName(3, "dealer-female-icon.ico");
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(212, 280);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(34, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "+";
            this.toolTip1.SetToolTip(this.btnAdd, "Добавление товара.");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(319, 280);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(34, 23);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "-";
            this.toolTip1.SetToolTip(this.btnRemove, "Удаление товара");
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Поставщик:";
            // 
            // txtDealer
            // 
            this.txtDealer.Location = new System.Drawing.Point(9, 75);
            this.txtDealer.Name = "txtDealer";
            this.txtDealer.ReadOnly = true;
            this.txtDealer.Size = new System.Drawing.Size(174, 20);
            this.txtDealer.TabIndex = 7;
            // 
            // txtDealersCost
            // 
            this.txtDealersCost.Location = new System.Drawing.Point(9, 114);
            this.txtDealersCost.Name = "txtDealersCost";
            this.txtDealersCost.ReadOnly = true;
            this.txtDealersCost.Size = new System.Drawing.Size(81, 20);
            this.txtDealersCost.TabIndex = 8;
            // 
            // txtYourCost
            // 
            this.txtYourCost.Location = new System.Drawing.Point(9, 231);
            this.txtYourCost.Name = "txtYourCost";
            this.txtYourCost.Size = new System.Drawing.Size(81, 20);
            this.txtYourCost.TabIndex = 9;
            this.txtYourCost.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtYourCost_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Цена поставщика:";
            // 
            // groupBoxMerchandiseInfo
            // 
            this.groupBoxMerchandiseInfo.Controls.Add(this.label6);
            this.groupBoxMerchandiseInfo.Controls.Add(this.txtEmail);
            this.groupBoxMerchandiseInfo.Controls.Add(this.label5);
            this.groupBoxMerchandiseInfo.Controls.Add(this.txtPN);
            this.groupBoxMerchandiseInfo.Controls.Add(this.label4);
            this.groupBoxMerchandiseInfo.Controls.Add(this.txtMerchandiseName);
            this.groupBoxMerchandiseInfo.Controls.Add(this.label3);
            this.groupBoxMerchandiseInfo.Controls.Add(this.label1);
            this.groupBoxMerchandiseInfo.Controls.Add(this.label2);
            this.groupBoxMerchandiseInfo.Controls.Add(this.txtDealer);
            this.groupBoxMerchandiseInfo.Controls.Add(this.txtYourCost);
            this.groupBoxMerchandiseInfo.Controls.Add(this.txtDealersCost);
            this.groupBoxMerchandiseInfo.Location = new System.Drawing.Point(187, 13);
            this.groupBoxMerchandiseInfo.Name = "groupBoxMerchandiseInfo";
            this.groupBoxMerchandiseInfo.Size = new System.Drawing.Size(189, 261);
            this.groupBoxMerchandiseInfo.TabIndex = 11;
            this.groupBoxMerchandiseInfo.TabStop = false;
            this.groupBoxMerchandiseInfo.Text = "Детали";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(9, 192);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(174, 20);
            this.txtEmail.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Номер тел.:";
            // 
            // txtPN
            // 
            this.txtPN.Location = new System.Drawing.Point(9, 153);
            this.txtPN.Name = "txtPN";
            this.txtPN.ReadOnly = true;
            this.txtPN.Size = new System.Drawing.Size(174, 20);
            this.txtPN.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Название:";
            // 
            // txtMerchandiseName
            // 
            this.txtMerchandiseName.Location = new System.Drawing.Point(6, 36);
            this.txtMerchandiseName.Name = "txtMerchandiseName";
            this.txtMerchandiseName.ReadOnly = true;
            this.txtMerchandiseName.Size = new System.Drawing.Size(177, 20);
            this.txtMerchandiseName.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ваша цена:";
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // AddMerchandise
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(594, 343);
            this.Controls.Add(this.groupBoxMerchandiseInfo);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.treeViewAllMerchandise);
            this.Controls.Add(this.groupBoxSelectedItems);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AddMerchandise";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adding Merchandise";
            this.Load += new System.EventHandler(this.AddMerchandise_Load);
            this.groupBoxSelectedItems.ResumeLayout(false);
            this.groupBoxMerchandiseInfo.ResumeLayout(false);
            this.groupBoxMerchandiseInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBoxSelectedItems;
        private System.Windows.Forms.ListBox lbSelectedItems;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TreeView treeViewAllMerchandise;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDealer;
        private System.Windows.Forms.TextBox txtDealersCost;
        private System.Windows.Forms.TextBox txtYourCost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxMerchandiseInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMerchandiseName;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPN;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}