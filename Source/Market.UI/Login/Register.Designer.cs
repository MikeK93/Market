using System.ComponentModel;
namespace Market.UI
{
    partial class Register
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Register));
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rcCustomer = new System.Windows.Forms.RadioButton();
            this.rbDealer = new System.Windows.Forms.RadioButton();
            this.rbSalesperson = new System.Windows.Forms.RadioButton();
            this.mtxtPwr = new System.Windows.Forms.MaskedTextBox();
            this.groupBoxSelect = new System.Windows.Forms.GroupBox();
            this.txtFName = new System.Windows.Forms.TextBox();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.txtLName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLogin
            // 
            this.txtLogin.Enabled = false;
            this.txtLogin.Location = new System.Drawing.Point(104, 128);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(137, 20);
            this.txtLogin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Логин:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Пароль:";
            // 
            // rcCustomer
            // 
            this.rcCustomer.AutoSize = true;
            this.rcCustomer.Location = new System.Drawing.Point(101, 52);
            this.rcCustomer.Name = "rcCustomer";
            this.rcCustomer.Size = new System.Drawing.Size(85, 17);
            this.rcCustomer.TabIndex = 6;
            this.rcCustomer.TabStop = true;
            this.rcCustomer.Tag = "0";
            this.rcCustomer.Text = "Покупатель";
            this.rcCustomer.UseVisualStyleBackColor = true;
            this.rcCustomer.CheckedChanged += new System.EventHandler(this.rcCustomer_CheckedChanged);
            // 
            // rbDealer
            // 
            this.rbDealer.AutoSize = true;
            this.rbDealer.Location = new System.Drawing.Point(101, 19);
            this.rbDealer.Name = "rbDealer";
            this.rbDealer.Size = new System.Drawing.Size(83, 17);
            this.rbDealer.TabIndex = 7;
            this.rbDealer.TabStop = true;
            this.rbDealer.Text = "Поставщик";
            this.rbDealer.UseVisualStyleBackColor = true;
            this.rbDealer.CheckedChanged += new System.EventHandler(this.rbDealer_CheckedChanged);
            // 
            // rbSalesperson
            // 
            this.rbSalesperson.AutoSize = true;
            this.rbSalesperson.Location = new System.Drawing.Point(101, 86);
            this.rbSalesperson.Name = "rbSalesperson";
            this.rbSalesperson.Size = new System.Drawing.Size(75, 17);
            this.rbSalesperson.TabIndex = 8;
            this.rbSalesperson.TabStop = true;
            this.rbSalesperson.Text = "Продавец";
            this.rbSalesperson.UseVisualStyleBackColor = true;
            this.rbSalesperson.CheckedChanged += new System.EventHandler(this.rbSalesperson_CheckedChanged);
            // 
            // mtxtPwr
            // 
            this.mtxtPwr.Culture = new System.Globalization.CultureInfo("");
            this.mtxtPwr.Enabled = false;
            this.mtxtPwr.Location = new System.Drawing.Point(104, 154);
            this.mtxtPwr.Name = "mtxtPwr";
            this.mtxtPwr.PasswordChar = '*';
            this.mtxtPwr.Size = new System.Drawing.Size(137, 20);
            this.mtxtPwr.TabIndex = 10;
            // 
            // groupBoxSelect
            // 
            this.groupBoxSelect.Controls.Add(this.rbDealer);
            this.groupBoxSelect.Controls.Add(this.rcCustomer);
            this.groupBoxSelect.Controls.Add(this.rbSalesperson);
            this.groupBoxSelect.Location = new System.Drawing.Point(3, 1);
            this.groupBoxSelect.Name = "groupBoxSelect";
            this.groupBoxSelect.Size = new System.Drawing.Size(279, 121);
            this.groupBoxSelect.TabIndex = 11;
            this.groupBoxSelect.TabStop = false;
            this.groupBoxSelect.Text = "Выберите роль:";
            // 
            // txtFName
            // 
            this.txtFName.Enabled = false;
            this.txtFName.Location = new System.Drawing.Point(104, 189);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(137, 20);
            this.txtFName.TabIndex = 12;
            // 
            // txtMName
            // 
            this.txtMName.Enabled = false;
            this.txtMName.Location = new System.Drawing.Point(104, 215);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(137, 20);
            this.txtMName.TabIndex = 13;
            // 
            // txtLName
            // 
            this.txtLName.Enabled = false;
            this.txtLName.Location = new System.Drawing.Point(104, 239);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(137, 20);
            this.txtLName.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(66, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Имя:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Отчество:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Фамилия:";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(45, 305);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "Выйти";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRegister.Location = new System.Drawing.Point(154, 305);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(106, 23);
            this.btnRegister.TabIndex = 19;
            this.btnRegister.Text = "Регистрировать";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // cbGender
            // 
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Location = new System.Drawing.Point(104, 265);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(137, 21);
            this.cbGender.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Пол:";
            // 
            // Register
            // 
            this.AcceptButton = this.btnRegister;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 341);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbGender);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLName);
            this.Controls.Add(this.txtMName);
            this.Controls.Add(this.txtFName);
            this.Controls.Add(this.groupBoxSelect);
            this.Controls.Add(this.mtxtPwr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.Load += new System.EventHandler(this.Register_Load);
            this.groupBoxSelect.ResumeLayout(false);
            this.groupBoxSelect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rcCustomer;
        private System.Windows.Forms.RadioButton rbDealer;
        private System.Windows.Forms.RadioButton rbSalesperson;
        private System.Windows.Forms.MaskedTextBox mtxtPwr;
        private System.Windows.Forms.GroupBox groupBoxSelect;
        private System.Windows.Forms.TextBox txtFName;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.TextBox txtLName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.Label label3;
    }
}