
namespace Music_Shop
{
    partial class AddForm_Buyer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.NumText = new System.Windows.Forms.TextBox();
            this.NameText = new System.Windows.Forms.TextBox();
            this.DadText = new System.Windows.Forms.TextBox();
            this.FamText = new System.Windows.Forms.TextBox();
            this.EmailText = new System.Windows.Forms.TextBox();
            this.Dad = new System.Windows.Forms.Label();
            this.Num = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.Names = new System.Windows.Forms.Label();
            this.Fam = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.NumText);
            this.panel1.Controls.Add(this.NameText);
            this.panel1.Controls.Add(this.DadText);
            this.panel1.Controls.Add(this.FamText);
            this.panel1.Controls.Add(this.EmailText);
            this.panel1.Controls.Add(this.Dad);
            this.panel1.Controls.Add(this.Num);
            this.panel1.Controls.Add(this.Email);
            this.panel1.Controls.Add(this.Names);
            this.panel1.Controls.Add(this.Fam);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 100);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(188, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Создание записи (Buyer)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // NumText
            // 
            this.NumText.Location = new System.Drawing.Point(368, 261);
            this.NumText.Name = "NumText";
            this.NumText.Size = new System.Drawing.Size(219, 20);
            this.NumText.TabIndex = 57;
            // 
            // NameText
            // 
            this.NameText.Location = new System.Drawing.Point(368, 161);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(219, 20);
            this.NameText.TabIndex = 56;
            // 
            // DadText
            // 
            this.DadText.Location = new System.Drawing.Point(368, 229);
            this.DadText.Name = "DadText";
            this.DadText.Size = new System.Drawing.Size(219, 20);
            this.DadText.TabIndex = 55;
            // 
            // FamText
            // 
            this.FamText.Location = new System.Drawing.Point(368, 197);
            this.FamText.Name = "FamText";
            this.FamText.Size = new System.Drawing.Size(219, 20);
            this.FamText.TabIndex = 54;
            // 
            // EmailText
            // 
            this.EmailText.Location = new System.Drawing.Point(368, 290);
            this.EmailText.Name = "EmailText";
            this.EmailText.Size = new System.Drawing.Size(219, 20);
            this.EmailText.TabIndex = 53;
            // 
            // Dad
            // 
            this.Dad.AutoSize = true;
            this.Dad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Dad.Location = new System.Drawing.Point(201, 231);
            this.Dad.Name = "Dad";
            this.Dad.Size = new System.Drawing.Size(88, 18);
            this.Dad.TabIndex = 51;
            this.Dad.Text = "Отчество:";
            // 
            // Num
            // 
            this.Num.AutoSize = true;
            this.Num.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Num.Location = new System.Drawing.Point(201, 263);
            this.Num.Name = "Num";
            this.Num.Size = new System.Drawing.Size(161, 18);
            this.Num.TabIndex = 50;
            this.Num.Text = "Контактный номер:";
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Email.Location = new System.Drawing.Point(201, 292);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(55, 18);
            this.Email.TabIndex = 49;
            this.Email.Text = "Email:";
            // 
            // Names
            // 
            this.Names.AutoSize = true;
            this.Names.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Names.Location = new System.Drawing.Point(201, 169);
            this.Names.Name = "Names";
            this.Names.Size = new System.Drawing.Size(46, 18);
            this.Names.TabIndex = 48;
            this.Names.Text = "Имя:";
            // 
            // Fam
            // 
            this.Fam.AutoSize = true;
            this.Fam.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Fam.Location = new System.Drawing.Point(201, 199);
            this.Fam.Name = "Fam";
            this.Fam.Size = new System.Drawing.Size(85, 18);
            this.Fam.TabIndex = 47;
            this.Fam.Text = "Фамилия:";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(277, 389);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(203, 30);
            this.button5.TabIndex = 58;
            this.button5.Text = "Сохранить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // AddForm_Buyer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "AddForm_Buyer";
            this.Text = "AddForm_Buyer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NumText;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.TextBox DadText;
        private System.Windows.Forms.TextBox FamText;
        private System.Windows.Forms.TextBox EmailText;
        private System.Windows.Forms.Label Dad;
        private System.Windows.Forms.Label Num;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label Names;
        private System.Windows.Forms.Label Fam;
        private System.Windows.Forms.Button button5;
    }
}