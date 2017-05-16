using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.Design;

namespace swiftDemon
{
    class settingsForm : Form
    {
        settings param = new settings();
        Label lb_dbName = new Label();
        TextBox tb_dbName = new TextBox();
        Button b_dbName = new Button();
        Label lb_dbPath = new Label();
        TextBox tb_dbPath = new TextBox();
        Button b_dbPath = new Button();
        Label lb_inMess = new Label();
        TextBox tb_inMess = new TextBox();
        Button b_inMess = new Button();
        Label lb_outMess = new Label();
        TextBox tb_outMess = new TextBox();
        Button b_outMess = new Button();
        public settingsForm()
        {
            
            this.Size = new Size(400, 210);
            //=================== dbName ===============
            
            lb_dbName.Text = "База данных";
            lb_dbName.Location = new Point(10, 10);
            lb_dbName.Width = 90;

            
            tb_dbName.Text = param.dbName;
            tb_dbName.Location = new Point(100, 10);
            tb_dbName.Width = 190;

            
            b_dbName.Text = "Изменить";
            b_dbName.Location = new Point(300, 10);
            b_dbName.Width = 90;
            b_dbName.Click += B_dbName_Click;
            //=================== dbPath ===============
            
            lb_dbPath.Text = "Расположение";
            lb_dbPath.Location = new Point(10, 50);
            lb_dbPath.Width = 90;

            
            tb_dbPath.Text = param.dbPath;
            tb_dbPath.Location = new Point(100, 50);
            tb_dbPath.Width = 190;

            
            b_dbPath.Text = "Изменить";
            b_dbPath.Location = new Point(300, 50);
            b_dbPath.Width = 90;
            b_dbPath.Click += B_dbPath_Click;
            //=================== inMess ===============
            
            lb_inMess.Text = "Исходящие";
            lb_inMess.Location = new Point(10, 100);
            lb_inMess.Width = 90;

            
            tb_inMess.Text = param.inMess;
            tb_inMess.Location = new Point(100, 100);
            tb_inMess.Width = 190;

            
            b_inMess.Text = "Изменить";
            b_inMess.Location = new Point(300, 100);
            b_inMess.Width = 90;
            b_inMess.Click += B_inMess_Click;
            //=================== outMess ===============
            
            lb_outMess.Text = "Входящие";
            lb_outMess.Location = new Point(10, 150);
            lb_outMess.Width = 90;

            
            tb_outMess.Text = param.outMess;
            tb_outMess.Location = new Point(100, 150);
            tb_outMess.Width = 190;

            
            b_outMess.Text = "Изменить";
            b_outMess.Location = new Point(300, 150);
            b_outMess.Width = 90;
            b_outMess.Click += B_outMess_Click;
            this.Controls.Add(lb_dbName);
            this.Controls.Add(tb_dbName);
            this.Controls.Add(b_dbName);
            this.Controls.Add(lb_dbPath);
            this.Controls.Add(tb_dbPath);
            this.Controls.Add(b_dbPath);
            this.Controls.Add(lb_inMess);
            this.Controls.Add(tb_inMess);
            this.Controls.Add(b_inMess);
            this.Controls.Add(lb_outMess);
            this.Controls.Add(tb_outMess);
            this.Controls.Add(b_outMess);
        }

        private void B_dbName_Click(object sender, EventArgs e)
        {
            param.dbName = tb_dbName.Text;
            //throw new NotImplementedException();
        }

        private void B_dbPath_Click(object sender, EventArgs e)
        {
            param.dbPath = tb_dbPath.Text;
            //throw new NotImplementedException();
        }

        private void B_inMess_Click(object sender, EventArgs e)
        {
            param.inMess = tb_inMess.Text;
            //throw new NotImplementedException();
        }

        private void B_outMess_Click(object sender, EventArgs e)
        {
            param.outMess = tb_outMess.Text;
            //ssageBox.Show("Test");
        }
    }
}


