namespace MyApartment
{
    partial class LoginForm
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
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.txtLoginTC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlRegister = new System.Windows.Forms.Panel();
            this.btnRegisterPerson = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPersonLastName = new System.Windows.Forms.TextBox();
            this.txtPersonPasswordRepeat = new System.Windows.Forms.TextBox();
            this.txtPersonPassword = new System.Windows.Forms.TextBox();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.txtPersonTC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlLogin.SuspendLayout();
            this.pnlRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.label3);
            this.pnlLogin.Controls.Add(this.label2);
            this.pnlLogin.Controls.Add(this.txtLoginPassword);
            this.pnlLogin.Controls.Add(this.txtLoginTC);
            this.pnlLogin.Controls.Add(this.label1);
            this.pnlLogin.Location = new System.Drawing.Point(404, 168);
            this.pnlLogin.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(393, 322);
            this.pnlLogin.TabIndex = 0;
            this.pnlLogin.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.IndianRed;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(131, 190);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(217, 41);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Giriş Yap";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Şifre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kimlik No:";
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoginPassword.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLoginPassword.Location = new System.Drawing.Point(131, 154);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '*';
            this.txtLoginPassword.Size = new System.Drawing.Size(217, 30);
            this.txtLoginPassword.TabIndex = 1;
            // 
            // txtLoginTC
            // 
            this.txtLoginTC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoginTC.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtLoginTC.Location = new System.Drawing.Point(131, 118);
            this.txtLoginTC.MaxLength = 11;
            this.txtLoginTC.Name = "txtLoginTC";
            this.txtLoginTC.Size = new System.Drawing.Size(217, 30);
            this.txtLoginTC.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(130, 15, 130, 15);
            this.label1.Size = new System.Drawing.Size(398, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yönetici Girişi";
            // 
            // pnlRegister
            // 
            this.pnlRegister.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlRegister.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRegister.Controls.Add(this.btnRegisterPerson);
            this.pnlRegister.Controls.Add(this.label8);
            this.pnlRegister.Controls.Add(this.label9);
            this.pnlRegister.Controls.Add(this.label4);
            this.pnlRegister.Controls.Add(this.label7);
            this.pnlRegister.Controls.Add(this.label5);
            this.pnlRegister.Controls.Add(this.txtPersonLastName);
            this.pnlRegister.Controls.Add(this.txtPersonPasswordRepeat);
            this.pnlRegister.Controls.Add(this.txtPersonPassword);
            this.pnlRegister.Controls.Add(this.txtPersonName);
            this.pnlRegister.Controls.Add(this.txtPersonTC);
            this.pnlRegister.Controls.Add(this.label6);
            this.pnlRegister.Location = new System.Drawing.Point(404, 146);
            this.pnlRegister.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRegister.Name = "pnlRegister";
            this.pnlRegister.Size = new System.Drawing.Size(393, 366);
            this.pnlRegister.TabIndex = 0;
            this.pnlRegister.Visible = false;
            // 
            // btnRegisterPerson
            // 
            this.btnRegisterPerson.BackColor = System.Drawing.Color.MediumBlue;
            this.btnRegisterPerson.FlatAppearance.BorderSize = 0;
            this.btnRegisterPerson.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegisterPerson.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRegisterPerson.ForeColor = System.Drawing.Color.White;
            this.btnRegisterPerson.Location = new System.Drawing.Point(142, 282);
            this.btnRegisterPerson.Name = "btnRegisterPerson";
            this.btnRegisterPerson.Size = new System.Drawing.Size(217, 41);
            this.btnRegisterPerson.TabIndex = 5;
            this.btnRegisterPerson.Text = "Kayıt Ol";
            this.btnRegisterPerson.UseVisualStyleBackColor = false;
            this.btnRegisterPerson.Click += new System.EventHandler(this.btnRegisterPerson_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(78, 137);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 19);
            this.label8.TabIndex = 2;
            this.label8.Text = "Soyad:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(31, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 19);
            this.label9.TabIndex = 2;
            this.label9.Text = "Şifre(Tekrar):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "Şifre:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(101, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "Ad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "Kimlik No:";
            // 
            // txtPersonLastName
            // 
            this.txtPersonLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPersonLastName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPersonLastName.Location = new System.Drawing.Point(142, 131);
            this.txtPersonLastName.Name = "txtPersonLastName";
            this.txtPersonLastName.Size = new System.Drawing.Size(217, 30);
            this.txtPersonLastName.TabIndex = 1;
            // 
            // txtPersonPasswordRepeat
            // 
            this.txtPersonPasswordRepeat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPersonPasswordRepeat.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPersonPasswordRepeat.Location = new System.Drawing.Point(142, 245);
            this.txtPersonPasswordRepeat.Name = "txtPersonPasswordRepeat";
            this.txtPersonPasswordRepeat.PasswordChar = '*';
            this.txtPersonPasswordRepeat.Size = new System.Drawing.Size(217, 30);
            this.txtPersonPasswordRepeat.TabIndex = 4;
            // 
            // txtPersonPassword
            // 
            this.txtPersonPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPersonPassword.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPersonPassword.Location = new System.Drawing.Point(142, 207);
            this.txtPersonPassword.Name = "txtPersonPassword";
            this.txtPersonPassword.PasswordChar = '*';
            this.txtPersonPassword.Size = new System.Drawing.Size(217, 30);
            this.txtPersonPassword.TabIndex = 3;
            // 
            // txtPersonName
            // 
            this.txtPersonName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPersonName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPersonName.Location = new System.Drawing.Point(142, 93);
            this.txtPersonName.MaxLength = 11;
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(217, 30);
            this.txtPersonName.TabIndex = 0;
            // 
            // txtPersonTC
            // 
            this.txtPersonTC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPersonTC.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPersonTC.Location = new System.Drawing.Point(142, 169);
            this.txtPersonTC.MaxLength = 11;
            this.txtPersonTC.Name = "txtPersonTC";
            this.txtPersonTC.Size = new System.Drawing.Size(217, 30);
            this.txtPersonTC.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(-3, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(130, 15, 130, 15);
            this.label6.Size = new System.Drawing.Size(397, 55);
            this.label6.TabIndex = 0;
            this.label6.Text = "Yönetici Kayıt";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 658);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlRegister);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlRegister.ResumeLayout(false);
            this.pnlRegister.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.TextBox txtLoginTC;
        private System.Windows.Forms.Panel pnlRegister;
        private System.Windows.Forms.Button btnRegisterPerson;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPersonLastName;
        private System.Windows.Forms.TextBox txtPersonPasswordRepeat;
        private System.Windows.Forms.TextBox txtPersonPassword;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.TextBox txtPersonTC;
        private System.Windows.Forms.Label label6;
    }
}

