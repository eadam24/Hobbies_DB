namespace Hobbies_DB
{
    partial class Main
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
            this.countries_combobox = new System.Windows.Forms.ComboBox();
            this.towns_combobox = new System.Windows.Forms.ComboBox();
            this.admin_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // countries_combobox
            // 
            this.countries_combobox.FormattingEnabled = true;
            this.countries_combobox.Location = new System.Drawing.Point(117, 144);
            this.countries_combobox.Name = "countries_combobox";
            this.countries_combobox.Size = new System.Drawing.Size(121, 28);
            this.countries_combobox.TabIndex = 0;
            this.countries_combobox.SelectedIndexChanged += new System.EventHandler(this.countries_combobox_SelectedIndexChanged);
            // 
            // towns_combobox
            // 
            this.towns_combobox.FormattingEnabled = true;
            this.towns_combobox.Location = new System.Drawing.Point(426, 144);
            this.towns_combobox.Name = "towns_combobox";
            this.towns_combobox.Size = new System.Drawing.Size(121, 28);
            this.towns_combobox.TabIndex = 1;
            // 
            // admin_button
            // 
            this.admin_button.Location = new System.Drawing.Point(317, 236);
            this.admin_button.Name = "admin_button";
            this.admin_button.Size = new System.Drawing.Size(97, 61);
            this.admin_button.TabIndex = 2;
            this.admin_button.Text = "Admin";
            this.admin_button.UseVisualStyleBackColor = true;
            this.admin_button.Click += new System.EventHandler(this.admin_button_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.admin_button);
            this.Controls.Add(this.towns_combobox);
            this.Controls.Add(this.countries_combobox);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox countries_combobox;
        private System.Windows.Forms.ComboBox towns_combobox;
        private System.Windows.Forms.Button admin_button;
    }
}