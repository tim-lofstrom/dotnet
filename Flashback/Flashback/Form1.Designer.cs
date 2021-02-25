namespace Flashback
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
            this.button_sort = new System.Windows.Forms.Button();
            this.person_box = new System.Windows.Forms.RichTextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_length = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_sort
            // 
            this.button_sort.Location = new System.Drawing.Point(13, 13);
            this.button_sort.Name = "button_sort";
            this.button_sort.Size = new System.Drawing.Size(111, 23);
            this.button_sort.TabIndex = 0;
            this.button_sort.Text = "Sortera Personer";
            this.button_sort.UseVisualStyleBackColor = true;
            this.button_sort.Click += new System.EventHandler(this.button1_Click);
            // 
            // person_box
            // 
            this.person_box.Location = new System.Drawing.Point(10, 78);
            this.person_box.Name = "person_box";
            this.person_box.Size = new System.Drawing.Size(257, 164);
            this.person_box.TabIndex = 1;
            this.person_box.Text = "";
            this.person_box.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(21, 50);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(100, 20);
            this.textBox_name.TabIndex = 2;
            // 
            // textBox_length
            // 
            this.textBox_length.Location = new System.Drawing.Point(127, 50);
            this.textBox_length.Name = "textBox_length";
            this.textBox_length.Size = new System.Drawing.Size(100, 20);
            this.textBox_length.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.textBox_length);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.person_box);
            this.Controls.Add(this.button_sort);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_sort;
        private System.Windows.Forms.RichTextBox person_box;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_length;
    }
}

