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
using System.Net;
using BusinessLogicLayer;


namespace SCP
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        int actualmenu;
        Random rnd = new Random();

        // loadded menu
        private void Menu_Load(object sender, EventArgs e)
        {
            Usernamecont.Text = impclass.username;
            label1.Text = ("Welcome Back " + impclass.username);
            if (impclass.admin == false)
            {
                button7.Visible = false;
            }
            else
            {
                button7.Visible = true;
            }
        }

        //Menu button
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(5, 103, 241);
        }

        //Articles button
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(5, 103, 241);
        }


        //Write an article
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(5, 103, 241);
        }

        //Profile button
        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(5, 103, 241);
        }

        //Log Out button
        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.FromArgb(5, 103, 241);
        }

        //Exit button
        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(5, 103, 241);
        }

        // Manage profiles
        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.BackColor = Color.FromArgb(5, 103, 241);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Black;
            button2.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Black;
            button2.ForeColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Black;
            button3.ForeColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Black;
            button4.ForeColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Black;
            button5.ForeColor = Color.White;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.Black;
            button6.ForeColor = Color.White;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.BackColor = Color.Black;
            button7.ForeColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.BackColor = Color.White;
            button5.ForeColor = Color.Black;
            this.Refresh();
            try
            {
                Login li = new Login();
                li.Show();
                this.Hide();
            }
            catch (Exception ee)
            {

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.BackColor = Color.White;
            button6.ForeColor = Color.Black;
            this.Refresh();
            Application.Exit();
        }

        private void panelcleanner ()
        {
            //panelmenu.Visible = false;
            //Articles.Visible = false;
            //WaA.Visible = false;
            //Profile.Visible = false;
            label2.Visible = false;
            Manage.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panelcleanner();
        }

        private void button2_Click(object sender, EventArgs e)
        {
             panelcleanner();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelcleanner();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panelcleanner();
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            try
            {
                loadded ld = new loadded();

                ld.Show();
                ld.BringToFront();
                this.Refresh();
                await Task.Delay(3000); //loadded screen

                panelcleanner(); //Hiding everything

                Manage.Visible = true;

                DataTable dt = new DataTable();
                dt = BLL.Employees.Load(); //Getting the DB info

                dataGridView1.DataSource = dt;

                label3.Location = new Point(Manage.Location.X + 5, dataGridView1.Size.Height + 5);
                comboBox1.Location = new Point(label3.Location.X + label3.Size.Width + 10, label3.Location.Y);
                comboBox1.Items.Clear();
                Apply.Location = new Point(Manage.Location.X + Manage.Size.Width - Apply.Size.Width - 10, Manage.Location.Y + Manage.Size.Height - Apply.Size.Height - 15); //Relocating the items and clearing them

                for (int i = 0; i < dt.Rows.Count; i++) //Re-entering the items information
                {
                    comboBox1.Items.Insert(i, dt.Rows[i]["Email"]);
                }

                this.Refresh();
                await Task.Delay(3000);
                ld.Close(); //Closing the loadded screen
            }
            catch(Exception ee)
            {
                msgdisplayer msg = new msgdisplayer();
                msg.msg_giver("Ocorreu um erro: " + ee.Message);
                msg.Show();
            }
        }

        private void combosetter(bool setter)
        {
            Level.Visible = setter;
            CAssignment.Visible = setter;
            Roll.Visible = setter;
            SITE_AREA.Visible = setter;
            nametext.Visible = setter;
            Nameindex.Visible = setter;
            Rollindex.Visible = setter;
            Levelindex.Visible = setter;
            CAssignmentindex.Visible = setter;
            SAindex.Visible = setter;
            GoIndex.Visible = setter;
            GoI.Visible = setter;
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                combosetter(true);

                Nameindex.Location = new Point(label3.Location.X, label3.Location.Y + label3.Size.Height + 5);
                nametext.Location = new Point(Nameindex.Location.X + Nameindex.Size.Width + 10, Nameindex.Location.Y);

                DataTable dt = new DataTable();
                dt = BLL.GoI.Load();
                GoI.Items.Clear();
                GoI.Items.Insert(0, "");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    GoI.Items.Insert(i + 1, dt.Rows[i]["Name"]);
                }

                GoIndex.Location = new Point((nametext.Location.X + nametext.Size.Width) + 15, nametext.Location.Y);
                GoI.Location = new Point(GoIndex.Location.X + GoIndex.Size.Width + 15, GoIndex.Location.Y);
                Levelindex.Location = new Point(Nameindex.Location.X, Nameindex.Location.Y + 15);
                Level.Location = new Point(Levelindex.Location.X, Levelindex.Location.X);
                oldPassword.Location = new Point(Levelindex.Location.X, Levelindex.Location.Y + 15);
                old_pass.Location = new Point(oldPassword.Location.X + oldPassword.Size.Width + 15, oldPassword.Location.Y);
                Password01.Location = new Point(oldPassword.Location.X, oldPassword.Location.Y + 15);
                Passwordchanger.Location = new Point(Password01.Location.X + Password01.Size.Width + 15, Password01.Location.Y);
                Password02.Location = new Point(Password01.Location.X, Password01.Location.Y + Password01.Size.Height + 15);
                password_conf.Location = new Point(Password02.Location.X + Password02.Size.Width + 15, Password02.Location.Y);

                //Setting more location and content for items

                dt = BLL.Employees.queryEmployee(comboBox1.Text);
                nametext.Text = dt.Rows[0]["Name"].ToString();
                Roll.Text = dt.Rows[0]["Roll"].ToString();
                SITE_AREA.Text = dt.Rows[0]["SITE_AREA"].ToString();
                CAssignment.Text = dt.Rows[0]["CAssignment"].ToString();
            }
            else
            {
                combosetter(false);
            }
        }

        private async void Apply_Click(object sender, EventArgs e)
        {
            loadded ld = new loadded();

            ld.Show();
            ld.BringToFront();
            this.Refresh();
            await Task.Delay(3000); //loadded screen

            impclass imp = new impclass();

            if (old_pass.Text != "" && password_conf.Text !="" && Passwordchanger.Text !="")//getting the data to update itself
            {
                if (password_conf.Text == Passwordchanger.Text)
                    imp.updated(comboBox1.Text, nametext.Text, password_conf.Text, Roll.Text, Level.Text, GoI.Text, SITE_AREA.Text, CAssignment.Text, old_pass.Text);
                else
                {
                    msgdisplayer msg = new msgdisplayer();
                    msg.msg_giver("Passwords are not the same...");
                    msg.Show();
                }
            }
            else
            {

            }

            await Task.Delay(3000);
            ld.Close(); //Closing the loadded screen
        }
    }
}