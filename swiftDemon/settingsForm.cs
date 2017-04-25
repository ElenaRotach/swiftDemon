using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.Design;

namespace swiftDemon
{
    class settingsForm : Form
    {
        public settingsForm()
        {
            settings param = new settings();
            this.Size = new Size(400, 210);
            //=================== dbName ===============
            Label lb_dbName = new Label();
            lb_dbName.Text = "База данных";
            lb_dbName.Location = new Point(10, 10);
            lb_dbName.Width = 90;

            TextBox tb_dbName = new TextBox();
            tb_dbName.Text = param.dbName;
            tb_dbName.Location = new Point(100, 10);
            tb_dbName.Width = 190;

            Button b_dbName = new Button();
            b_dbName.Text = "Изменить";
            b_dbName.Location = new Point(300, 10);
            b_dbName.Width = 90;
            //=================== dbPath ===============
            Label lb_dbPath = new Label();
            lb_dbPath.Text = "Расположение";
            lb_dbPath.Location = new Point(10, 50);
            lb_dbPath.Width = 90;

            TextBox tb_dbPath = new TextBox();
            tb_dbPath.Text = param.dbPath;
            tb_dbPath.Location = new Point(100, 50);
            tb_dbPath.Width = 190;

            Button b_dbPath = new Button();
            b_dbPath.Text = "Изменить";
            b_dbPath.Location = new Point(300, 50);
            b_dbPath.Width = 90;
            //=================== inMess ===============
            Label lb_inMess = new Label();
            lb_inMess.Text = "Исходящие";
            lb_inMess.Location = new Point(10, 100);
            lb_inMess.Width = 90;

            TextBox tb_inMess = new TextBox();
            tb_inMess.Text = param.inMess;
            tb_inMess.Location = new Point(100, 100);
            tb_inMess.Width = 190;

            Button b_inMess = new Button();
            b_inMess.Text = "Изменить";
            b_inMess.Location = new Point(300, 100);
            b_inMess.Width = 90;
            //=================== outMess ===============
            Label lb_outMess = new Label();
            lb_outMess.Text = "Входящие";
            lb_outMess.Location = new Point(10, 150);
            lb_outMess.Width = 90;

            TextBox tb_outMess = new TextBox();
            tb_outMess.Text = param.outMess;
            tb_outMess.Location = new Point(100, 150);
            tb_outMess.Width = 190;

            Button b_outMess = new Button();
            b_outMess.Text = "Изменить";
            b_outMess.Location = new Point(300, 150);
            b_outMess.Width = 90;

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
    }
}


