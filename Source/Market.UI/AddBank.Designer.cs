using System.ComponentModel;
namespace Market.UI
{
    partial class AddBank
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(AddBank));
            this.lvAllBanks = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbYourBanks = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddBank = new System.Windows.Forms.Button();
            this.btnRemoveBank = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvAllBanks
            // 
            this.lvAllBanks.LargeImageList = this.imageList1;
            this.lvAllBanks.Location = new System.Drawing.Point(12, 21);
            this.lvAllBanks.Name = "lvAllBanks";
            this.lvAllBanks.Size = new System.Drawing.Size(424, 172);
            this.lvAllBanks.SmallImageList = this.imageList1;
            this.lvAllBanks.TabIndex = 0;
            this.lvAllBanks.UseCompatibleStateImageBehavior = false;
            this.lvAllBanks.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvAllBanks_ItemSelectionChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Artdesigner-Webtoys-Visa.ico");
            // 
            // lbYourBanks
            // 
            this.lbYourBanks.FormattingEnabled = true;
            this.lbYourBanks.Location = new System.Drawing.Point(6, 18);
            this.lbYourBanks.Name = "lbYourBanks";
            this.lbYourBanks.Size = new System.Drawing.Size(143, 108);
            this.lbYourBanks.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Доступные банки:";
            // 
            // btnAddBank
            // 
            this.btnAddBank.Location = new System.Drawing.Point(17, 132);
            this.btnAddBank.Name = "btnAddBank";
            this.btnAddBank.Size = new System.Drawing.Size(33, 23);
            this.btnAddBank.TabIndex = 4;
            this.btnAddBank.Text = "+";
            this.toolTip1.SetToolTip(this.btnAddBank, "Добавить банк.");
            this.btnAddBank.UseVisualStyleBackColor = true;
            this.btnAddBank.Click += new System.EventHandler(this.btnAddBank_Click);
            // 
            // btnRemoveBank
            // 
            this.btnRemoveBank.Location = new System.Drawing.Point(105, 132);
            this.btnRemoveBank.Name = "btnRemoveBank";
            this.btnRemoveBank.Size = new System.Drawing.Size(33, 23);
            this.btnRemoveBank.TabIndex = 5;
            this.btnRemoveBank.Text = "-";
            this.toolTip1.SetToolTip(this.btnRemoveBank, "Удалить банк.");
            this.btnRemoveBank.UseVisualStyleBackColor = true;
            this.btnRemoveBank.Click += new System.EventHandler(this.btnRemoveBank_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbYourBanks);
            this.groupBox1.Controls.Add(this.btnRemoveBank);
            this.groupBox1.Controls.Add(this.btnAddBank);
            this.groupBox1.Location = new System.Drawing.Point(442, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 172);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбранные банки:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(513, 197);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(78, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "Сохранить";
            this.toolTip1.SetToolTip(this.btnOk, "Сохранить изменения.");
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(442, 197);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(65, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Выход";
            this.toolTip1.SetToolTip(this.btnCancel, "Выход без сохранения.");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Enabled = false;
            this.txtAddress.Location = new System.Drawing.Point(66, 199);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(370, 20);
            this.txtAddress.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Адресс:";
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // AddBank
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(601, 230);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvAllBanks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "AddBank";
            this.Text = "Добавление банка";
            this.Load += new System.EventHandler(this.AddBank_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvAllBanks;
        private System.Windows.Forms.ListBox lbYourBanks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnAddBank;
        private System.Windows.Forms.Button btnRemoveBank;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}