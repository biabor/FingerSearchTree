
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
            this.searchBtn_.Click += new System.EventHandler(this.searchBtn__Click);
            // 
            // addBtn_
            // 
            this.addBtn_.Location = new System.Drawing.Point(197, 41);
            this.addBtn_.Name = "addBtn_";
            this.addBtn_.Size = new System.Drawing.Size(75, 23);
            this.addBtn_.TabIndex = 2;
            this.addBtn_.Text = "Add";
            this.addBtn_.UseVisualStyleBackColor = true;
            this.addBtn_.Click += new System.EventHandler(this.addBtn__Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(197, 203);
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
            this.deleteBtn_.Click += new System.EventHandler(this.deleteBtn__Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

