namespace swiftDemon
{
    partial class sound
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sound));
            this.ch_on = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ch_on
            // 
            this.ch_on.AutoSize = true;
            this.ch_on.Location = new System.Drawing.Point(27, 30);
            this.ch_on.Name = "ch_on";
            this.ch_on.Size = new System.Drawing.Size(100, 17);
            this.ch_on.TabIndex = 0;
            this.ch_on.Text = "включить звук";
            this.ch_on.UseVisualStyleBackColor = true;
            this.ch_on.CheckedChanged += new System.EventHandler(this.ch_on_CheckedChanged);
            // 
            // sound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 95);
            this.Controls.Add(this.ch_on);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "sound";
            this.Text = "sound";
            this.Load += new System.EventHandler(this.sound_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ch_on;
    }
}