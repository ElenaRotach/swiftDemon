namespace swift
{
    partial class fMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.транслитерацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.журналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.системныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.столбцыЖурналаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.информацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.звукToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.транслитерацияToolStripMenuItem,
            this.журналToolStripMenuItem,
            this.выходToolStripMenuItem,
            this.информацияToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(543, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // транслитерацияToolStripMenuItem
            // 
            this.транслитерацияToolStripMenuItem.Name = "транслитерацияToolStripMenuItem";
            this.транслитерацияToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.транслитерацияToolStripMenuItem.Text = "транслитерация";
            this.транслитерацияToolStripMenuItem.Click += new System.EventHandler(this.транслитерацияToolStripMenuItem_Click);
            // 
            // журналToolStripMenuItem
            // 
            this.журналToolStripMenuItem.Name = "журналToolStripMenuItem";
            this.журналToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.журналToolStripMenuItem.Text = "журнал";
            this.журналToolStripMenuItem.Click += new System.EventHandler(this.журналToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.системныеToolStripMenuItem,
            this.столбцыЖурналаToolStripMenuItem,
            this.звукToolStripMenuItem});
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.выходToolStripMenuItem.Text = "настройки";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // системныеToolStripMenuItem
            // 
            this.системныеToolStripMenuItem.Name = "системныеToolStripMenuItem";
            this.системныеToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.системныеToolStripMenuItem.Text = "системные";
            this.системныеToolStripMenuItem.Click += new System.EventHandler(this.системныеToolStripMenuItem_Click);
            // 
            // столбцыЖурналаToolStripMenuItem
            // 
            this.столбцыЖурналаToolStripMenuItem.Name = "столбцыЖурналаToolStripMenuItem";
            this.столбцыЖурналаToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.столбцыЖурналаToolStripMenuItem.Text = "столбцы журнала";
            this.столбцыЖурналаToolStripMenuItem.Click += new System.EventHandler(this.столбцыЖурналаToolStripMenuItem_Click);
            // 
            // информацияToolStripMenuItem
            // 
            this.информацияToolStripMenuItem.Name = "информацияToolStripMenuItem";
            this.информацияToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.информацияToolStripMenuItem.Text = "информация";
            // 
            // звукToolStripMenuItem
            // 
            this.звукToolStripMenuItem.Name = "звукToolStripMenuItem";
            this.звукToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.звукToolStripMenuItem.Text = "звук";
            this.звукToolStripMenuItem.Click += new System.EventHandler(this.звукToolStripMenuItem_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 307);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "fMain";
            this.Text = "SWIFT";
            this.Load += new System.EventHandler(this.fMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem транслитерацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem журналToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem информацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem системныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem столбцыЖурналаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem звукToolStripMenuItem;
    }
}

