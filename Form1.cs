using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SCP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //Most of this functions are color changers for the program
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.White;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(5, 103, 241);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(5, 103, 241);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
            this.Refresh();
            Application.Exit();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(5, 103, 241);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.White;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - 128, Screen.PrimaryScreen.Bounds.Height / 2 - 256);
            button3.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 105 - 30, Screen.PrimaryScreen.Bounds.Height - 50 - 30);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.White;
            try
            {
                Register rs = new Register();
                rs.Show();
                this.Hide();
            }
            catch(Exception ee)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            impclass imp = new impclass();
            imp.logging(textBox1.Text, textBox2.Text);
        }
    }
}
