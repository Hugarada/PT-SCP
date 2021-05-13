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
    public partial class msgdisplayer : Form
    {
        public msgdisplayer()
        {
            InitializeComponent();
        }

        private void msgdisplayer_Load(object sender, EventArgs e)
        {
            panel1.Location = new Point(0, 0);
            panel1.Size = new Size(this.Width, this.Height);
            button1.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 135, Screen.PrimaryScreen.Bounds.Height - 80);
            label1.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 10, Screen.PrimaryScreen.Bounds.Height - 60);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
        }

        public void msg_giver(string messaging)
        {
            label1.Text = messaging;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            this.Refresh();
            this.Close();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(5, 103, 241);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }
    }
}
