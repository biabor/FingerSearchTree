
namespace FingerSearchTree
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
            this.searchBtn_ = new System.Windows.Forms.Button();
            this.addBtn_ = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.deleteBtn_ = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchBtn_
            // 
            this.searchBtn_.Location = new System.Drawing.Point(37, 41);
            this.searchBtn_.Name = "searchBtn_";
            this.searchBtn_.Size = new System.Drawing.Size(75, 23);
            this.searchBtn_.TabIndex = 1;
            this.searchBtn_.Text = "Search";
            this.searchBtn_.UseVisualStyleBackColor = true;
            this.searchBtn_.Click += new System.EventHandler(this.SearchBtn__Click);
            // 
            // addBtn_
            // 
            this.addBtn_.Location = new System.Drawing.Point(197, 41);
            this.addBtn_.Name = "addBtn_";
            this.addBtn_.Size = new System.Drawing.Size(75, 23);
            this.addBtn_.TabIndex = 2;
            this.addBtn_.Text = "Add";
            this.addBtn_.UseVisualStyleBackColor = true;
            this.addBtn_.Click += new System.EventHandler(this.AddBtn__Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(102, 101);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(251, 20);
            this.textBox1.TabIndex = 3;
            // 
            // deleteBtn_
            // 
            this.deleteBtn_.Location = new System.Drawing.Point(373, 41);
            this.deleteBtn_.Name = "deleteBtn_";
            this.deleteBtn_.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn_.TabIndex = 4;
            this.deleteBtn_.Text = "Delete";
            this.deleteBtn_.UseVisualStyleBackColor = true;
            this.deleteBtn_.Click += new System.EventHandler(this.DeleteBtn__Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Insert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RandomInsert__Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(182, 161);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.RamdomDelete__Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(373, 160);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Random";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.RamdomUpdate__Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 245);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.deleteBtn_);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.addBtn_);
            this.Controls.Add(this.searchBtn_);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button searchBtn_;
        private System.Windows.Forms.Button addBtn_;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button deleteBtn_;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

