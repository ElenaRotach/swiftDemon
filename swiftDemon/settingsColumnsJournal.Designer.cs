namespace swiftDemon
{
    partial class settingsColumnsJournal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsColumnsJournal));
            this.gr_alignment = new System.Windows.Forms.Panel();
            this.rb_r = new System.Windows.Forms.RadioButton();
            this.rb_c = new System.Windows.Forms.RadioButton();
            this.rb_l = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_alignment = new System.Windows.Forms.Button();
            this.gr_alignment.SuspendLayout();
            this.SuspendLayout();
            // 
            // gr_alignment
            // 
            this.gr_alignment.Controls.Add(this.rb_r);
            this.gr_alignment.Controls.Add(this.rb_c);
            this.gr_alignment.Controls.Add(this.rb_l);
            this.gr_alignment.Location = new System.Drawing.Point(12, 29);
            this.gr_alignment.Name = "gr_alignment";
            this.gr_alignment.Size = new System.Drawing.Size(300, 27);
            this.gr_alignment.TabIndex = 0;
            // 
            // rb_r
            // 
            this.rb_r.AutoSize = true;
            this.rb_r.Location = new System.Drawing.Point(174, 3);
            this.rb_r.Name = "rb_r";
            this.rb_r.Size = new System.Drawing.Size(97, 17);
            this.rb_r.TabIndex = 3;
            this.rb_r.TabStop = true;
            this.rb_r.Text = "правому краю";
            this.rb_r.UseVisualStyleBackColor = true;
            // 
            // rb_c
            // 
            this.rb_c.AutoSize = true;
            this.rb_c.Location = new System.Drawing.Point(109, 3);
            this.rb_c.Name = "rb_c";
            this.rb_c.Size = new System.Drawing.Size(59, 17);
            this.rb_c.TabIndex = 2;
            this.rb_c.TabStop = true;
            this.rb_c.Text = "центру";
            this.rb_c.UseVisualStyleBackColor = true;
            // 
            // rb_l
            // 
            this.rb_l.AutoSize = true;
            this.rb_l.Location = new System.Drawing.Point(12, 3);
            this.rb_l.Name = "rb_l";
            this.rb_l.Size = new System.Drawing.Size(91, 17);
            this.rb_l.TabIndex = 1;
            this.rb_l.TabStop = true;
            this.rb_l.Text = "левому краю";
            this.rb_l.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выравнивать текст по:";
            // 
            // btn_alignment
            // 
            this.btn_alignment.Location = new System.Drawing.Point(350, 33);
            this.btn_alignment.Name = "btn_alignment";
            this.btn_alignment.Size = new System.Drawing.Size(138, 23);
            this.btn_alignment.TabIndex = 2;
            this.btn_alignment.Text = "применить";
            this.btn_alignment.UseVisualStyleBackColor = true;
            this.btn_alignment.Click += new System.EventHandler(this.btn_alignment_Click);
            // 
            // settingsColumnsJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(542, 773);
            this.Controls.Add(this.btn_alignment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gr_alignment);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(550, 800);
            this.Name = "settingsColumnsJournal";
            this.Text = "settingsColumnsJournal";
            this.Load += new System.EventHandler(this.settingsColumnsJournal_Load);
            this.gr_alignment.ResumeLayout(false);
            this.gr_alignment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel gr_alignment;
        private System.Windows.Forms.RadioButton rb_r;
        private System.Windows.Forms.RadioButton rb_c;
        private System.Windows.Forms.RadioButton rb_l;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_alignment;
    }
}