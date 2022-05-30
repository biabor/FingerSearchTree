
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
            this.createBtn_ = new System.Windows.Forms.Button();
            this.searchBtn_ = new System.Windows.Forms.Button();
            this.addBtn_ = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createBtn_
            // 
            this.createBtn_.Location = new System.Drawing.Point(89, 42);
            this.createBtn_.Name = "createBtn_";
            this.createBtn_.Size = new System.Drawing.Size(75, 23);
            this.createBtn_.TabIndex = 0;
            this.createBtn_.Text = "Create";
            this.createBtn_.UseVisualStyleBackColor = true;
            this.createBtn_.Click += new System.EventHandler(this.createBtn__Click);
            // 
            // searchBtn_
            // 
            this.searchBtn_.Location = new System.Drawing.Point(249, 41);
            this.searchBtn_.Name = "searchBtn_";
            this.searchBtn_.Size = new System.Drawing.Size(75, 23);
            this.searchBtn_.TabIndex = 1;
            this.searchBtn_.Text = "Search";
            this.searchBtn_.UseVisualStyleBackColor = true;
            this.searchBtn_.Click += new System.EventHandler(this.searchBtn__Click);
            // 
            // addBtn_
            // 
            this.addBtn_.Location = new System.Drawing.Point(429, 41);
            this.addBtn_.Name = "addBtn_";
            this.addBtn_.Size = new System.Drawing.Size(75, 23);
            this.addBtn_.TabIndex = 2;
            this.addBtn_.Text = "Add";
            this.addBtn_.UseVisualStyleBackColor = true;
            this.addBtn_.Click += new System.EventHandler(this.addBtn__Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addBtn_);
            this.Controls.Add(this.searchBtn_);
            this.Controls.Add(this.createBtn_);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createBtn_;
        private System.Windows.Forms.Button searchBtn_;
        private System.Windows.Forms.Button addBtn_;
    }
}

