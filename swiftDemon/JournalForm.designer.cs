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
            this.tb_condition = new System.Windows.Forms.TextBox();
            this.btn_condition = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tabMess)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMess
            // 
            this.tabMess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabMess.Location = new System.Drawing.Point(31, 55);
            this.tabMess.Name = "tabMess";
            this.tabMess.Size = new System.Drawing.Size(1352, 554);
            this.tabMess.TabIndex = 0;
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(935, 12);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(75, 23);
            this.export.TabIndex = 1;
            this.export.Text = "export";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // reshow
            // 
            this.reshow.Location = new System.Drawing.Point(839, 12);
            this.reshow.Name = "reshow";
            this.reshow.Size = new System.Drawing.Size(75, 23);
            this.reshow.TabIndex = 2;
            this.reshow.Text = "reshow";
            this.reshow.UseVisualStyleBackColor = true;
            this.reshow.Click += new System.EventHandler(this.reshow_Click);
            // 
            // tb_condition
            // 
            this.tb_condition.Location = new System.Drawing.Point(31, 12);
            this.tb_condition.Name = "tb_condition";
            this.tb_condition.Size = new System.Drawing.Size(615, 20);
            this.tb_condition.TabIndex = 3;
            // 
            // btn_condition
            // 
            this.btn_condition.Location = new System.Drawing.Point(677, 12);
            this.btn_condition.Name = "btn_condition";
            this.btn_condition.Size = new System.Drawing.Size(138, 23);
            this.btn_condition.TabIndex = 4;
            this.btn_condition.Text = "добавить условие";
            this.btn_condition.UseVisualStyleBackColor = true;
            this.btn_condition.Click += new System.EventHandler(this.btn_condition_Click);
            // 
            // JournalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 636);
            this.Controls.Add(this.btn_condition);
            this.Controls.Add(this.tb_condition);
            this.Controls.Add(this.reshow);
            this.Controls.Add(this.export);
            this.Controls.Add(this.tabMess);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JournalForm";
            this.Text = "JournalForm";
            this.Load += new System.EventHandler(this.JournalForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabMess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button export;
        public System.Windows.Forms.DataGridView tabMess;
        private System.Windows.Forms.Button reshow;
        private System.Windows.Forms.Button btn_condition;
        public System.Windows.Forms.TextBox tb_condition;
    }
}