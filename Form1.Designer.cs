namespace ConsoleApp1
{
    partial class Form1
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
            this.txt_Search_By_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_searchByName = new System.Windows.Forms.Button();
            this.FindAllPatients_Btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_identity = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_fname = new System.Windows.Forms.TextBox();
            this.txt_LastName = new System.Windows.Forms.TextBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Search_By_Name
            // 
            this.txt_Search_By_Name.Location = new System.Drawing.Point(174, 55);
            this.txt_Search_By_Name.Name = "txt_Search_By_Name";
            this.txt_Search_By_Name.Size = new System.Drawing.Size(215, 20);
            this.txt_Search_By_Name.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Patient_Name";
            // 
            // btn_searchByName
            // 
            this.btn_searchByName.Location = new System.Drawing.Point(408, 53);
            this.btn_searchByName.Name = "btn_searchByName";
            this.btn_searchByName.Size = new System.Drawing.Size(75, 23);
            this.btn_searchByName.TabIndex = 2;
            this.btn_searchByName.Text = "Search";
            this.btn_searchByName.UseVisualStyleBackColor = true;
            this.btn_searchByName.Click += new System.EventHandler(this.Find_Patient_Btn_Click);
            // 
            // FindAllPatients_Btn
            // 
            this.FindAllPatients_Btn.Location = new System.Drawing.Point(96, 119);
            this.FindAllPatients_Btn.Name = "FindAllPatients_Btn";
            this.FindAllPatients_Btn.Size = new System.Drawing.Size(587, 23);
            this.FindAllPatients_Btn.TabIndex = 3;
            this.FindAllPatients_Btn.Text = "List_Patients";
            this.FindAllPatients_Btn.UseVisualStyleBackColor = true;
            this.FindAllPatients_Btn.Click += new System.EventHandler(this.Find_All_Patients_Btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(96, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(587, 220);
            this.dataGridView1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 392);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "FirstName";
            // 
            // txt_identity
            // 
            this.txt_identity.AutoSize = true;
            this.txt_identity.Location = new System.Drawing.Point(94, 464);
            this.txt_identity.Name = "txt_identity";
            this.txt_identity.Size = new System.Drawing.Size(31, 13);
            this.txt_identity.TabIndex = 6;
            this.txt_identity.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(94, 428);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "LastName";
            // 
            // txt_fname
            // 
            this.txt_fname.Location = new System.Drawing.Point(205, 389);
            this.txt_fname.Name = "txt_fname";
            this.txt_fname.Size = new System.Drawing.Size(139, 20);
            this.txt_fname.TabIndex = 8;
            // 
            // txt_LastName
            // 
            this.txt_LastName.Location = new System.Drawing.Point(205, 421);
            this.txt_LastName.Name = "txt_LastName";
            this.txt_LastName.Size = new System.Drawing.Size(139, 20);
            this.txt_LastName.TabIndex = 9;
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(205, 461);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(139, 20);
            this.txt_Email.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(369, 389);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "Add_Patient";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Add_Patient_Btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(489, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Update_Patient_Btn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(588, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Delete_Patient_Btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 500);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.txt_LastName);
            this.Controls.Add(this.txt_fname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_identity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.FindAllPatients_Btn);
            this.Controls.Add(this.btn_searchByName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Search_By_Name);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Search_By_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_searchByName;
        private System.Windows.Forms.Button FindAllPatients_Btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txt_identity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_fname;
        private System.Windows.Forms.TextBox txt_LastName;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}