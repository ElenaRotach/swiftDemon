using System.Windows.Forms;

namespace transliter_RUENGRU
{
    partial class Form1 : Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.strIn = new System.Windows.Forms.TextBox();
            this.strOut = new System.Windows.Forms.TextBox();
            this.clean = new System.Windows.Forms.Button();
            this.transliter = new System.Windows.Forms.Button();
            this.engTranslit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // strIn
            // 
            this.strIn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.strIn.Location = new System.Drawing.Point(35, 24);
            this.strIn.Multiline = true;
            this.strIn.Name = "strIn";
            this.strIn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.strIn.Size = new System.Drawing.Size(376, 116);
            this.strIn.TabIndex = 0;
            this.strIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textIn_KeyDown);
            // 
            // strOut
            // 
            this.strOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.strOut.Location = new System.Drawing.Point(35, 179);
            this.strOut.Multiline = true;
            this.strOut.Name = "strOut";
            this.strOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.strOut.Size = new System.Drawing.Size(376, 116);
            this.strOut.TabIndex = 1;
            // 
            // clean
            // 
            this.clean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.clean.Location = new System.Drawing.Point(191, 329);
            this.clean.Name = "clean";
            this.clean.Size = new System.Drawing.Size(94, 23);
            this.clean.TabIndex = 2;
            this.clean.Text = "очистить";
            this.clean.UseVisualStyleBackColor = true;
            this.clean.Click += new System.EventHandler(this.clean_Click);
            // 
            // transliter
            // 
            this.transliter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.transliter.Location = new System.Drawing.Point(317, 329);
            this.transliter.Name = "transliter";
            this.transliter.Size = new System.Drawing.Size(94, 23);
            this.transliter.TabIndex = 3;
            this.transliter.Text = "RU -> ENG";
            this.transliter.UseVisualStyleBackColor = true;
            this.transliter.Click += new System.EventHandler(this.translite_Click);
            // 
            // engTranslit
            // 
            this.engTranslit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.engTranslit.Location = new System.Drawing.Point(317, 360);
            this.engTranslit.Name = "engTranslit";
            this.engTranslit.Size = new System.Drawing.Size(94, 23);
            this.engTranslit.TabIndex = 4;
            this.engTranslit.Text = "ENG -> RU";
            this.engTranslit.UseVisualStyleBackColor = true;
            this.engTranslit.Click += new System.EventHandler(this.engTranslit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 395);
            this.Controls.Add(this.engTranslit);
            this.Controls.Add(this.transliter);
            this.Controls.Add(this.clean);
            this.Controls.Add(this.strOut);
            this.Controls.Add(this.strIn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Транслитерация";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox strIn;
        private System.Windows.Forms.TextBox strOut;
        private System.Windows.Forms.Button clean;
        private System.Windows.Forms.Button transliter;
        private System.Windows.Forms.Button engTranslit;
    }
}

