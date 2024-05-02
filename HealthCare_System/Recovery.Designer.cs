namespace HealthCare_System
{
    partial class Recovery
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.confirmPassword = new System.Windows.Forms.TextBox();
            this.loginBtn2 = new System.Windows.Forms.Button();
            this.emailLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.GhostWhite;
            this.panel3.Location = new System.Drawing.Point(51, 145);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(295, 3);
            this.panel3.TabIndex = 10;
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.BackColor = System.Drawing.Color.DarkSlateGray;
            this.newPasswordTextBox.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPasswordTextBox.ForeColor = System.Drawing.Color.White;
            this.newPasswordTextBox.Location = new System.Drawing.Point(52, 119);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.PasswordChar = '*';
            this.newPasswordTextBox.Size = new System.Drawing.Size(294, 23);
            this.newPasswordTextBox.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.GhostWhite;
            this.panel1.Location = new System.Drawing.Point(51, 248);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 3);
            this.panel1.TabIndex = 12;
            // 
            // confirmPassword
            // 
            this.confirmPassword.BackColor = System.Drawing.Color.DarkSlateGray;
            this.confirmPassword.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPassword.ForeColor = System.Drawing.Color.White;
            this.confirmPassword.Location = new System.Drawing.Point(52, 222);
            this.confirmPassword.Name = "confirmPassword";
            this.confirmPassword.PasswordChar = '*';
            this.confirmPassword.Size = new System.Drawing.Size(294, 23);
            this.confirmPassword.TabIndex = 11;
            this.confirmPassword.TextChanged += new System.EventHandler(this.confirmPassword_TextChanged);
            // 
            // loginBtn2
            // 
            this.loginBtn2.BackColor = System.Drawing.Color.SandyBrown;
            this.loginBtn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginBtn2.FlatAppearance.BorderSize = 0;
            this.loginBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn2.Font = new System.Drawing.Font("Montserrat", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn2.ForeColor = System.Drawing.Color.White;
            this.loginBtn2.Location = new System.Drawing.Point(144, 281);
            this.loginBtn2.Name = "loginBtn2";
            this.loginBtn2.Size = new System.Drawing.Size(109, 39);
            this.loginBtn2.TabIndex = 13;
            this.loginBtn2.Text = "Reset";
            this.loginBtn2.UseVisualStyleBackColor = false;
            this.loginBtn2.Click += new System.EventHandler(this.loginBtn2_Click);
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.Color.White;
            this.emailLabel.Location = new System.Drawing.Point(48, 198);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(150, 21);
            this.emailLabel.TabIndex = 14;
            this.emailLabel.Text = "Confirm Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(48, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "New Password:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Recovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(404, 371);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.loginBtn2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.confirmPassword);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.newPasswordTextBox);
            this.Name = "Recovery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recovery";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox confirmPassword;
        private System.Windows.Forms.Button loginBtn2;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label label1;
    }
}