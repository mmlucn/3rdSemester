namespace DesktopClient
{
    partial class Cars
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
            this.searchTxt = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.brandTxt = new System.Windows.Forms.TextBox();
            this.modelTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.yearTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.descTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.doorsTxt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.milageTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.elecConTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fuelConTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.regTxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.hkTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.colorTxt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.carTypeBox = new System.Windows.Forms.ComboBox();
            this.gearTypeBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.fuelTypeBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchTxt
            // 
            this.searchTxt.Location = new System.Drawing.Point(12, 12);
            this.searchTxt.Name = "searchTxt";
            this.searchTxt.PlaceholderText = "Enter email for user";
            this.searchTxt.Size = new System.Drawing.Size(362, 23);
            this.searchTxt.TabIndex = 0;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(380, 12);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(75, 23);
            this.searchBtn.TabIndex = 1;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 41);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(443, 334);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(480, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Brand:";
            // 
            // brandTxt
            // 
            this.brandTxt.Location = new System.Drawing.Point(480, 59);
            this.brandTxt.Name = "brandTxt";
            this.brandTxt.Size = new System.Drawing.Size(149, 23);
            this.brandTxt.TabIndex = 4;
            // 
            // modelTxt
            // 
            this.modelTxt.Location = new System.Drawing.Point(658, 59);
            this.modelTxt.Name = "modelTxt";
            this.modelTxt.Size = new System.Drawing.Size(149, 23);
            this.modelTxt.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(658, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Model:";
            // 
            // yearTxt
            // 
            this.yearTxt.Location = new System.Drawing.Point(658, 103);
            this.yearTxt.Name = "yearTxt";
            this.yearTxt.Size = new System.Drawing.Size(149, 23);
            this.yearTxt.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(658, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Year:";
            // 
            // descTxt
            // 
            this.descTxt.Location = new System.Drawing.Point(480, 103);
            this.descTxt.Name = "descTxt";
            this.descTxt.Size = new System.Drawing.Size(149, 23);
            this.descTxt.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(480, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Description:";
            // 
            // doorsTxt
            // 
            this.doorsTxt.Location = new System.Drawing.Point(658, 147);
            this.doorsTxt.Name = "doorsTxt";
            this.doorsTxt.Size = new System.Drawing.Size(149, 23);
            this.doorsTxt.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(658, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Doors:";
            // 
            // milageTxt
            // 
            this.milageTxt.Location = new System.Drawing.Point(480, 147);
            this.milageTxt.Name = "milageTxt";
            this.milageTxt.Size = new System.Drawing.Size(149, 23);
            this.milageTxt.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(480, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mileage:";
            // 
            // elecConTxt
            // 
            this.elecConTxt.Location = new System.Drawing.Point(658, 191);
            this.elecConTxt.Name = "elecConTxt";
            this.elecConTxt.Size = new System.Drawing.Size(149, 23);
            this.elecConTxt.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(658, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Electricity consumption:";
            // 
            // fuelConTxt
            // 
            this.fuelConTxt.Location = new System.Drawing.Point(480, 191);
            this.fuelConTxt.Name = "fuelConTxt";
            this.fuelConTxt.Size = new System.Drawing.Size(149, 23);
            this.fuelConTxt.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(480, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "Fuel consumption:";
            // 
            // regTxt
            // 
            this.regTxt.Location = new System.Drawing.Point(658, 235);
            this.regTxt.Name = "regTxt";
            this.regTxt.Size = new System.Drawing.Size(149, 23);
            this.regTxt.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(658, 217);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "Registration number:";
            // 
            // hkTxt
            // 
            this.hkTxt.Location = new System.Drawing.Point(480, 235);
            this.hkTxt.Name = "hkTxt";
            this.hkTxt.Size = new System.Drawing.Size(149, 23);
            this.hkTxt.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(480, 217);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 15);
            this.label10.TabIndex = 19;
            this.label10.Text = "HK:";
            // 
            // colorTxt
            // 
            this.colorTxt.Location = new System.Drawing.Point(480, 279);
            this.colorTxt.Name = "colorTxt";
            this.colorTxt.Size = new System.Drawing.Size(149, 23);
            this.colorTxt.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(480, 261);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 15);
            this.label11.TabIndex = 23;
            this.label11.Text = "Color:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(658, 261);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = "Type:";
            // 
            // carTypeBox
            // 
            this.carTypeBox.FormattingEnabled = true;
            this.carTypeBox.Location = new System.Drawing.Point(658, 279);
            this.carTypeBox.Name = "carTypeBox";
            this.carTypeBox.Size = new System.Drawing.Size(149, 23);
            this.carTypeBox.TabIndex = 26;
            // 
            // gearTypeBox
            // 
            this.gearTypeBox.FormattingEnabled = true;
            this.gearTypeBox.Location = new System.Drawing.Point(480, 323);
            this.gearTypeBox.Name = "gearTypeBox";
            this.gearTypeBox.Size = new System.Drawing.Size(149, 23);
            this.gearTypeBox.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(480, 305);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 15);
            this.label13.TabIndex = 27;
            this.label13.Text = "Gear type:";
            // 
            // fuelTypeBox
            // 
            this.fuelTypeBox.FormattingEnabled = true;
            this.fuelTypeBox.Location = new System.Drawing.Point(656, 323);
            this.fuelTypeBox.Name = "fuelTypeBox";
            this.fuelTypeBox.Size = new System.Drawing.Size(149, 23);
            this.fuelTypeBox.TabIndex = 30;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(656, 305);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 15);
            this.label14.TabIndex = 29;
            this.label14.Text = "Fuel type:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(480, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(327, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Cars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 386);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fuelTypeBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.gearTypeBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.carTypeBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.colorTxt);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.regTxt);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.hkTxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.elecConTxt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.fuelConTxt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.doorsTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.milageTxt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.yearTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.descTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.modelTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.brandTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchTxt);
            this.Name = "Cars";
            this.Text = "Cars";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox searchTxt;
        private Button searchBtn;
        private ListView listView1;
        private Label label1;
        private TextBox brandTxt;
        private TextBox modelTxt;
        private Label label2;
        private TextBox yearTxt;
        private Label label3;
        private TextBox descTxt;
        private Label label4;
        private TextBox doorsTxt;
        private Label label5;
        private TextBox milageTxt;
        private Label label6;
        private TextBox elecConTxt;
        private Label label7;
        private TextBox fuelConTxt;
        private Label label8;
        private TextBox regTxt;
        private Label label9;
        private TextBox hkTxt;
        private Label label10;
        private TextBox colorTxt;
        private Label label11;
        private Label label12;
        private ComboBox carTypeBox;
        private ComboBox gearTypeBox;
        private Label label13;
        private ComboBox fuelTypeBox;
        private Label label14;
        private Button button1;
    }
}