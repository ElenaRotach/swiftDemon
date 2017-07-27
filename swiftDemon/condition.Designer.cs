namespace swiftDemon
{
    partial class condition
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
            this.rb_II = new System.Windows.Forms.RadioButton();
            this.rb_OR = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_columnsName = new System.Windows.Forms.ComboBox();
            this.lab_columnName = new System.Windows.Forms.Label();
            this.lab_condition = new System.Windows.Forms.Label();
            this.cb_conditions = new System.Windows.Forms.ComboBox();
            this.cb_inversion = new System.Windows.Forms.CheckBox();
            this.lab_value = new System.Windows.Forms.Label();
            this.tb_value = new System.Windows.Forms.TextBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.lb_outCondition_test = new System.Windows.Forms.Label();
            this.tb_outCondition = new System.Windows.Forms.TextBox();
            this.btn_reflex = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rb_II
            // 
            this.rb_II.AutoSize = true;
            this.rb_II.Location = new System.Drawing.Point(16, 19);
            this.rb_II.Name = "rb_II";
            this.rb_II.Size = new System.Drawing.Size(43, 17);
            this.rb_II.TabIndex = 0;
            this.rb_II.TabStop = true;
            this.rb_II.Text = "\"И\"";
            this.rb_II.UseVisualStyleBackColor = true;
            // 
            // rb_OR
            // 
            this.rb_OR.AutoSize = true;
            this.rb_OR.Location = new System.Drawing.Point(16, 42);
            this.rb_OR.Name = "rb_OR";
            this.rb_OR.Size = new System.Drawing.Size(59, 17);
            this.rb_OR.TabIndex = 1;
            this.rb_OR.TabStop = true;
            this.rb_OR.Text = "\"ИЛИ\"";
            this.rb_OR.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_II);
            this.groupBox1.Controls.Add(this.rb_OR);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(134, 80);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "объединение";
            // 
            // cb_columnsName
            // 
            this.cb_columnsName.FormattingEnabled = true;
            this.cb_columnsName.Location = new System.Drawing.Point(175, 50);
            this.cb_columnsName.Name = "cb_columnsName";
            this.cb_columnsName.Size = new System.Drawing.Size(262, 21);
            this.cb_columnsName.TabIndex = 3;
            this.cb_columnsName.SelectedIndexChanged += new System.EventHandler(this.cb_columnsName_SelectedIndexChanged);
            // 
            // lab_columnName
            // 
            this.lab_columnName.AutoSize = true;
            this.lab_columnName.Location = new System.Drawing.Point(172, 31);
            this.lab_columnName.Name = "lab_columnName";
            this.lab_columnName.Size = new System.Drawing.Size(101, 13);
            this.lab_columnName.TabIndex = 4;
            this.lab_columnName.Text = "Выберите столбец";
            // 
            // lab_condition
            // 
            this.lab_condition.AutoSize = true;
            this.lab_condition.Location = new System.Drawing.Point(492, 31);
            this.lab_condition.Name = "lab_condition";
            this.lab_condition.Size = new System.Drawing.Size(101, 13);
            this.lab_condition.TabIndex = 6;
            this.lab_condition.Text = "Выберите условие";
            // 
            // cb_conditions
            // 
            this.cb_conditions.FormattingEnabled = true;
            this.cb_conditions.Location = new System.Drawing.Point(495, 50);
            this.cb_conditions.Name = "cb_conditions";
            this.cb_conditions.Size = new System.Drawing.Size(138, 21);
            this.cb_conditions.TabIndex = 5;
            // 
            // cb_inversion
            // 
            this.cb_inversion.AutoSize = true;
            this.cb_inversion.Location = new System.Drawing.Point(458, 52);
            this.cb_inversion.Name = "cb_inversion";
            this.cb_inversion.Size = new System.Drawing.Size(29, 17);
            this.cb_inversion.TabIndex = 7;
            this.cb_inversion.Text = "!";
            this.cb_inversion.UseVisualStyleBackColor = true;
            // 
            // lab_value
            // 
            this.lab_value.AutoSize = true;
            this.lab_value.Location = new System.Drawing.Point(641, 30);
            this.lab_value.Name = "lab_value";
            this.lab_value.Size = new System.Drawing.Size(99, 13);
            this.lab_value.TabIndex = 9;
            this.lab_value.Text = "Введите значение";
            this.lab_value.Click += new System.EventHandler(this.label3_Click);
            // 
            // tb_value
            // 
            this.tb_value.Location = new System.Drawing.Point(644, 51);
            this.tb_value.Name = "tb_value";
            this.tb_value.Size = new System.Drawing.Size(262, 20);
            this.tb_value.TabIndex = 10;
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(732, 154);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 11;
            this.btn_OK.Text = "Применить";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(831, 154);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 12;
            this.btn_exit.Text = "Выход";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // lb_outCondition_test
            // 
            this.lb_outCondition_test.AutoSize = true;
            this.lb_outCondition_test.Location = new System.Drawing.Point(172, 90);
            this.lb_outCondition_test.Name = "lb_outCondition_test";
            this.lb_outCondition_test.Size = new System.Drawing.Size(0, 13);
            this.lb_outCondition_test.TabIndex = 2;
            // 
            // tb_outCondition
            // 
            this.tb_outCondition.Location = new System.Drawing.Point(175, 87);
            this.tb_outCondition.Multiline = true;
            this.tb_outCondition.Name = "tb_outCondition";
            this.tb_outCondition.ReadOnly = true;
            this.tb_outCondition.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_outCondition.Size = new System.Drawing.Size(731, 49);
            this.tb_outCondition.TabIndex = 14;
            // 
            // btn_reflex
            // 
            this.btn_reflex.Location = new System.Drawing.Point(12, 113);
            this.btn_reflex.Name = "btn_reflex";
            this.btn_reflex.Size = new System.Drawing.Size(134, 23);
            this.btn_reflex.TabIndex = 15;
            this.btn_reflex.Text = "добавить";
            this.btn_reflex.UseVisualStyleBackColor = true;
            this.btn_reflex.Click += new System.EventHandler(this.btn_reflex_Click);
            // 
            // condition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 211);
            this.Controls.Add(this.btn_reflex);
            this.Controls.Add(this.tb_outCondition);
            this.Controls.Add(this.lb_outCondition_test);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.tb_value);
            this.Controls.Add(this.lab_value);
            this.Controls.Add(this.cb_inversion);
            this.Controls.Add(this.lab_condition);
            this.Controls.Add(this.cb_conditions);
            this.Controls.Add(this.lab_columnName);
            this.Controls.Add(this.cb_columnsName);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "condition";
            this.Text = "condition";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb_II;
        private System.Windows.Forms.RadioButton rb_OR;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cb_columnsName;
        private System.Windows.Forms.Label lab_columnName;
        private System.Windows.Forms.Label lab_condition;
        private System.Windows.Forms.ComboBox cb_conditions;
        private System.Windows.Forms.CheckBox cb_inversion;
        private System.Windows.Forms.Label lab_value;
        private System.Windows.Forms.TextBox tb_value;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label lb_outCondition_test;
        private System.Windows.Forms.TextBox tb_outCondition;
        private System.Windows.Forms.Button btn_reflex;
    }
}