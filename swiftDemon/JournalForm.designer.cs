﻿namespace swift
{
    partial class JournalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JournalForm));
            this.tabMess = new System.Windows.Forms.DataGridView();
            this.export = new System.Windows.Forms.Button();
            this.reshow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabMess)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMess
            // 
            this.tabMess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabMess.Location = new System.Drawing.Point(31, 58);
            this.tabMess.Name = "tabMess";
            this.tabMess.Size = new System.Drawing.Size(1352, 517);
            this.tabMess.TabIndex = 0;
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(89, 12);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(75, 23);
            this.export.TabIndex = 1;
            this.export.Text = "export";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // reshow
            // 
            this.reshow.Location = new System.Drawing.Point(12, 12);
            this.reshow.Name = "reshow";
            this.reshow.Size = new System.Drawing.Size(75, 23);
            this.reshow.TabIndex = 2;
            this.reshow.Text = "reshow";
            this.reshow.UseVisualStyleBackColor = true;
            this.reshow.Click += new System.EventHandler(this.reshow_Click);
            // 
            // JournalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 636);
            this.Controls.Add(this.reshow);
            this.Controls.Add(this.export);
            this.Controls.Add(this.tabMess);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JournalForm";
            this.Text = "JournalForm";
            this.Load += new System.EventHandler(this.JournalForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabMess)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button export;
        public System.Windows.Forms.DataGridView tabMess;
        private System.Windows.Forms.Button reshow;
    }
}