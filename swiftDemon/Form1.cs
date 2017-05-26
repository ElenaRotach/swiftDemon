using System;
using System.Windows.Forms;

namespace transliter_RUENGRU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void clean_Click(object sender, EventArgs e)
        {
            strIn.Text = "";
            strOut.Text = "";
            strIn.Focus();
        }

        private void translite_Click(object sender, EventArgs e)
        {
            strOut.Text = (translite.go(strIn.Text).ToString()).Replace("LfCr", "CrLf");
        }
        private void textIn_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    strOut.Text = translite.go(strIn.Text).ToString();
            //}
        }
        private void engTranslit_Click(object sender, EventArgs e)
        {
            //strIn.Text = "";
            foreach (char el in strIn.Text)
            {
                //strOut.Text += (" " + ((int)el).ToString());
                strOut.Text = translite.goEng(strIn.Text).ToString();
            }
            //strIn.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //strIn.Text
            //textBox1.Text = ((int)strIn.Text[0]).ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
