namespace DesktopClient
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.carsBtn = new System.Windows.Forms.Button();
            this.usersBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // carsBtn
            // 
            this.carsBtn.Location = new System.Drawing.Point(12, 12);
            this.carsBtn.Name = "carsBtn";
            this.carsBtn.Size = new System.Drawing.Size(75, 23);
            this.carsBtn.TabIndex = 0;
            this.carsBtn.Text = "Cars";
            this.carsBtn.UseVisualStyleBackColor = true;
            this.carsBtn.Click += new System.EventHandler(this.carsBtn_click);
            // 
            // usersBtn
            // 
            this.usersBtn.Location = new System.Drawing.Point(93, 12);
            this.usersBtn.Name = "usersBtn";
            this.usersBtn.Size = new System.Drawing.Size(75, 23);
            this.usersBtn.TabIndex = 1;
            this.usersBtn.Text = "Users";
            this.usersBtn.UseVisualStyleBackColor = true;
            this.usersBtn.Click += new System.EventHandler(this.usersBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 503);
            this.Controls.Add(this.usersBtn);
            this.Controls.Add(this.carsBtn);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button carsBtn;
        private Button usersBtn;
    }
}