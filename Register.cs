using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCP
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        //variables
        impclass imp = new impclass();

        private void Register_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - 93, Screen.PrimaryScreen.Bounds.Height / 2 - 145);
            button2.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 105 - 30, Screen.PrimaryScreen.Bounds.Height - 50 - 30);
            button3.Location = new Point(15, 15);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
            this.Refresh();
            try
            {
                Login lg = new Login();
                lg.Show();
                this.Close();
            }
            catch(Exception ee)
            {

            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(5, 103, 241);
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(5, 103, 241);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            this.Refresh();
            if (textBox2.Text != textBox3.Text)
            {
                msgdisplayer msg = new msgdisplayer();
                msg.msg_giver("The passwords are not the same, please try again...");
                msg.Show();
            }
            else
            {
                imp.Registering(textBox4.Text, textBox1.Text, textBox2.Text);
            }
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
            this.Refresh();
            imp.tec();
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.White;
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(5, 103, 241);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.White;
        }
    }
}