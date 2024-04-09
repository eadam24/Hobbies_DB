namespace Hobbies_DB
{
    partial class LogIn
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.username_text = new System.Windows.Forms.TextBox();
            this.password_text = new System.Windows.Forms.TextBox();
            this.submit_button = new System.Windows.Forms.Button();
            this.password_text_2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.passError = new System.Windows.Forms.ErrorProvider(this.components);
            this.usernameError = new System.Windows.Forms.ErrorProvider(this.components);
            this.signIn_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.passError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernameError)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(181, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(185, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // username_text
            // 
            this.username_text.Location = new System.Drawing.Point(355, 134);
            this.username_text.Name = "username_text";
            this.username_text.Size = new System.Drawing.Size(164, 26);
            this.username_text.TabIndex = 2;
            // 
            // password_text
            // 
            this.password_text.Location = new System.Drawing.Point(355, 207);
            this.password_text.Name = "password_text";
            this.password_text.PasswordChar = '*';
            this.password_text.Size = new System.Drawing.Size(164, 26);
            this.password_text.TabIndex = 3;
            // 
            // submit_button
            // 
            this.submit_button.Location = new System.Drawing.Point(381, 359);
            this.submit_button.Name = "submit_button";
            this.submit_button.Size = new System.Drawing.Size(116, 40);
            this.submit_button.TabIndex = 4;
            this.submit_button.Text = "Submit";
            this.submit_button.UseVisualStyleBackColor = true;
            this.submit_button.Click += new System.EventHandler(this.submit_button_Click);
            // 
            // password_text_2
            // 
            this.password_text_2.Location = new System.Drawing.Point(355, 271);
            this.password_text_2.Name = "password_text_2";
            this.password_text_2.PasswordChar = '*';
            this.password_text_2.Size = new System.Drawing.Size(164, 26);
            this.password_text_2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(185, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Password";
            // 
            // passError
            // 
            this.passError.ContainerControl = this;
            // 
            // usernameError
            // 
            this.usernameError.ContainerControl = this;
            // 
            // signIn_button
            // 
            this.signIn_button.Location = new System.Drawing.Point(248, 359);
            this.signIn_button.Name = "signIn_button";
            this.signIn_button.Size = new System.Drawing.Size(116, 40);
            this.signIn_button.TabIndex = 7;
            this.signIn_button.Text = "SignIn";
            this.signIn_button.UseVisualStyleBackColor = true;
            this.signIn_button.Click += new System.EventHandler(this.signIn_button_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 509);
            this.Controls.Add(this.signIn_button);
            this.Controls.Add(this.password_text_2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.submit_button);
            this.Controls.Add(this.password_text);
            this.Controls.Add(this.username_text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LogIn";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.passError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usernameError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username_text;
        private System.Windows.Forms.TextBox password_text;
        private System.Windows.Forms.Button submit_button;
        private System.Windows.Forms.TextBox password_text_2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider passError;
        private System.Windows.Forms.ErrorProvider usernameError;
        private System.Windows.Forms.Button signIn_button;
    }
}

