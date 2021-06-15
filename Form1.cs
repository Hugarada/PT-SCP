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
using System.Windows.Input;

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
                impclass imp = new impclass();
                imp.getError(ee);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            funcrepper();//will call the function either by clicking on the button or (see line 112)
        }

        //whole function
        private async void funcrepper()
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            impclass imp = new impclass();
            loadded ld = new loadded();
            ld.Show();
            ld.BringToFront();
            this.Refresh();
            await Task.Delay(3000);
            imp.logging(textBox1.Text, textBox2.Text);
            await Task.Delay(3000);
            ld.Close();
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;
        }

        private void buttonpren(KeyPressEventArgs keypresssed)
        {
            if (keypresssed.KeyChar == (char)Keys.Enter) //... if the key pressed is enter
                funcrepper();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            buttonpren(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            buttonpren(e);
        }
    }
}