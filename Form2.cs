﻿using System;
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
        bool typing = false;

        // loadded menu
        private void Menu_Load(object sender, EventArgs e)
        {
            Usernamecont.Text = impclass.username;
            label1.Text = ("Welcome Back " + impclass.username);
            if (impclass.admin == false)
            {
                button7.Visible = false;
                button8.Visible = false;
                button9.Visible = false;
            }
            else
            {
                button7.Visible = true;
                button8.Visible = true;
                button9.Visible = true;
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
                this.Close();
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
            panelmenu.Visible = true;
            WaA.Visible = false;
            Profile.Visible = false;
            label2.Visible = false;
            Manage.Visible = false;
            GoIpanel.Visible = false;
            MaA.Visible = false;
            Article_list.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            button1.ForeColor = Color.Black;
            this.Refresh();
            panelcleanner();
            panelmenu.Visible = false;
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
            button2.ForeColor = Color.Black;
            this.Refresh();

            loadingopener();
            panelcleanner();
            Article_list.Visible = true;

            textBox3.Size = new Size(Article_list.Size.Width - 30, Article_list.Size.Height / 2);
            label22.Text = "";
            label23.Text = "";
            textBox3.Text = "";
            comboBox8.Text = "";
            comboBox6.Text = "";
            label22.Visible = false;
            label23.Visible = false;

            button2.BackColor = Color.Black;
            button2.ForeColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panelcleanner();
            button3.BackColor = Color.White;
            button3.ForeColor = Color.Black;
            this.Refresh();

            loadingopener();

            WaA.Visible = true;
            descwaa.Size = new Size(WaA.Size.Width - 30, WaA.Size.Height / 2);
            confwaa.Location = new Point(WaA.Size.Width - confwaa.Size.Width - 10, WaA.Size.Height - confwaa.Size.Height - 10);
            Article_index.Location = new Point(Type.Location.X + Type.Size.Width + 15, Type.Location.Y);
            Article.Location = new Point(Article_index.Location.X + Article_index.Size.Width + 10, Article_index.Location.Y);

            DataTable dt = new DataTable();
            dt = BLL.Article.get_article_byEmail(impclass.email);
            for(int i = 0; i < dt.Rows.Count; i++)           
                Article.Items.Insert(i, dt.Rows[i]["Name"].ToString());
            dt = BLL.website.Load();
            for (int i = 0; i < dt.Rows.Count; i++)
                comboBox2.Items.Insert(i, dt.Rows[i]["Site_Area"].ToString());

            button3.BackColor = Color.Black;
            button3.ForeColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.White;
            button4.ForeColor = Color.Black;

            try
            {
                panelcleanner();
            
                this.Refresh();

                loadingopener();

                Profile.Visible = true;
                Profile.BringToFront();

                nomeindex.Location = new Point(Profile.Location.X + 5, Profile.Location.Y + 5);
                nome.Location = new Point(nomeindex.Location.X + nomeindex.Size.Width + 15, nomeindex.Location.Y);
                profile_text.Size = new Size(Profile.Size.Width - 30, Profile.Size.Height / 2);
                profileindex.Location = new Point(nomeindex.Location.X, nomeindex.Location.Y + 30);
                profile_text.Location = new Point(profileindex.Location.X, profileindex.Location.Y + 30);
                confprof.Location = new Point(Profile.Size.Width - confprof.Size.Width - 10, Profile.Size.Height - confprof.Size.Height - 10);

                DataTable dt = new DataTable();
                dt = BLL.Employees.queryEmployee(impclass.email);

                nome.Text = dt.Rows[0]["Name"].ToString();
                profile_text.Text = dt.Rows[0]["Profile"].ToString();
            }
            catch(Exception ee)
            {
                impclass imp = new impclass();
                imp.getError(ee);
            }

            button4.BackColor = Color.Black;
            button4.ForeColor = Color.White;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.BackColor = Color.White;
            button7.ForeColor = Color.Black;
            this.Refresh();
            try
            {
                DataTable dt = new DataTable();

                loadingopener();

                panelcleanner(); //Hiding everything

                Manage.Visible = true;

                dataupdater(dt);

                dt = BLL.Employees.Load();
                label3.Location = new Point(Manage.Location.X + 5, dataGridView1.Size.Height + 5);
                comboBox1.Location = new Point(label3.Location.X + label3.Size.Width + 10, label3.Location.Y);
                comboBox1.Items.Clear();
                Apply.Location = new Point(Manage.Location.X + Manage.Size.Width - Apply.Size.Width - 10, Manage.Location.Y + Manage.Size.Height - Apply.Size.Height - 15); //Relocating the items and clearing them

                for (int i = 0; i < dt.Rows.Count; i++) //Re-entering the items information
                    comboBox1.Items.Insert(i, dt.Rows[i]["Email"].ToString());

                dt = BLL.website.Load();
                for (int i = 0; i < dt.Rows.Count; i++)
                    SITE_AREA.Items.Insert(i, dt.Rows[i]["Site_Area"].ToString());
            }
            catch(Exception ee)
            {
                msgdisplayer msg = new msgdisplayer();
                msg.msg_giver("Ocorreu um erro: " + ee.Message);
                msg.Show();
            }
            button7.BackColor = Color.Black;
            button7.ForeColor = Color.White;
        }

        private void dataupdater(DataTable dt)
        {   
            dt = BLL.Employees.Load(); //Getting the DB info

            dataGridView1.DataSource = dt;
        }

        private void combosetter(bool setter)
        {
            CAssignment.Visible = setter;
            Roll.Visible = setter;
            SITE_AREA.Visible = setter;
            nametext.Visible = setter;
            Nameindex.Visible = setter;
            Rollindex.Visible = setter;
            Levelindex.Visible = setter;
            Level.Visible = setter;
            oldPassword.Visible = setter;
            old_pass.Visible = setter;
            Password01.Visible = setter;
            Passwordchanger.Visible = setter;
            Password02.Visible = setter;
            password_conf.Visible = setter;
            CAssignmentindex.Visible = setter;
            SAindex.Visible = setter;
            GoIndex.Visible = setter;
            GoI.Visible = setter;
            profiletext.Visible = setter;
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
                    GoI.Items.Insert(i + 1, dt.Rows[i]["Name"]);

                GoIndex.Location = new Point((nametext.Location.X + nametext.Size.Width) + 15, nametext.Location.Y);
                GoI.Location = new Point(GoIndex.Location.X + GoIndex.Size.Width + 15, GoIndex.Location.Y);
                Levelindex.Location = new Point(Nameindex.Location.X , Nameindex.Location.Y + Nameindex.Size.Height + 15);
                Level.Location = new Point(Levelindex.Location.X + Levelindex.Size.Width + 15, Levelindex.Location.Y);
                oldPassword.Location = new Point(Levelindex.Location.X, Levelindex.Location.Y + Levelindex.Size.Height + 15);
                old_pass.Location = new Point(oldPassword.Location.X + oldPassword.Size.Width + 15, oldPassword.Location.Y);
                Password01.Location = new Point(oldPassword.Location.X, oldPassword.Location.Y + oldPassword.Size.Height + 15);
                Passwordchanger.Location = new Point(Password01.Location.X + Password01.Size.Width + 15, Password01.Location.Y);
                Password02.Location = new Point(Password01.Location.X, Password01.Location.Y + Password01.Size.Height + 15);
                password_conf.Location = new Point(Password02.Location.X + Password02.Size.Width + 15, Password02.Location.Y);
                Rollindex.Location = new Point(Password02.Location.X, Password02.Location.Y + Password02.Size.Height + 15);
                Roll.Location = new Point(Rollindex.Location.X + Rollindex.Size.Width + 15, Rollindex.Location.Y);
                CAssignmentindex.Location = new Point(Rollindex.Location.X, Rollindex.Location.Y + Rollindex.Size.Height + 15);
                CAssignment.Location = new Point(CAssignmentindex.Location.X + CAssignmentindex.Size.Width + 15, CAssignmentindex.Location.Y);
                SAindex.Location = new Point(CAssignmentindex.Location.X, CAssignmentindex.Location.Y + CAssignmentindex.Size.Height + 15);
                SITE_AREA.Location = new Point(SAindex.Location.X + SAindex.Size.Width + 15, SAindex.Location.Y);
                profiletext.Location = new Point(SAindex.Location.X, SAindex.Location.Y + 30);
                profiletext.Size = new Size(Screen.PrimaryScreen.Bounds.Width - panel1.Size.Width - 10, Screen.PrimaryScreen.Bounds.Height - profiletext.Location.Y - Apply.Size.Height - 10);

                //Setting more location and content for items

                dt = BLL.Employees.queryEmployee(comboBox1.Text);
                nametext.Text = dt.Rows[0]["Name"].ToString();
                Roll.Text = dt.Rows[0]["Roll"].ToString();
                SITE_AREA.Text = dt.Rows[0]["SITE_AREA"].ToString();
                CAssignment.Text = dt.Rows[0]["CAssignment"].ToString();
                profiletext.Text = dt.Rows[0]["Profile"].ToString();
            }
            else
                combosetter(false);
        }

        private async void Apply_Click(object sender, EventArgs e)
        {
            Apply.BackColor = Color.White;
            Apply.ForeColor = Color.Black;

            loadingopener();

            impclass imp = new impclass();

            if (password_conf.Text == Passwordchanger.Text)
                imp.updated(comboBox1.Text, nametext.Text, password_conf.Text, Roll.Text, Level.Text, GoI.Text, SITE_AREA.Text, CAssignment.Text, old_pass.Text, profiletext.Text);
            else
            {
                msgdisplayer msg = new msgdisplayer();
                msg.msg_giver("Passwords are not the same...");
                msg.Show();
            }

            DataTable dt = new DataTable();
            dataupdater(dt);

            Apply.BackColor = Color.Black;
            Apply.ForeColor = Color.White;
        }

        private async void loadingopener()
        {
            loadded ld = new loadded();

            ld.Show();
            ld.BringToFront();
            this.Refresh();
            await Task.Delay(3000); //loadded screen

            ld.Close(); //Closing the loadded screen
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.BackColor = Color.White;
            button8.ForeColor = Color.Black;
            this.Refresh();

            loadingopener();

            panelcleanner();

            GoIpanel.Visible = true;

            button8.BackColor = Color.Black;
            button8.ForeColor = Color.White;

            Overview.Size = new Size(Screen.PrimaryScreen.Bounds.Width - panel1.Size.Width - 30, (Screen.PrimaryScreen.Bounds.Height - Overview.Location.Y) / 2);
            info.Location = new Point(Overview.Location.X, Overview.Size.Height + Overview.Location.Y + 15);
            info_right.Location = new Point(info.Location.X, info.Location.Y + 30);
            info_right.Size = new Size(Screen.PrimaryScreen.Bounds.Width - panel1.Size.Width - 30, (Screen.PrimaryScreen.Bounds.Height - info_right.Location.Y) / 2);
            Confirmer.Location = new Point(GoIpanel.Size.Width - Confirmer.Size.Width - 30, GoIpanel.Size.Height - Confirmer.Size.Height - 30);

            DataTable dt = new DataTable();
            dt = BLL.GoI.Load();
            GoISel.Items.Clear();
            GoISel.Items.Insert(0, "");
            for (int i = 0; i < dt.Rows.Count; i++)
                GoISel.Items.Insert(i + 1, dt.Rows[i]["Name"]);
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.BackColor = Color.Black;
            button8.ForeColor = Color.White;
        }

        private void Apply_MouseHover(object sender, EventArgs e)
        {
            Apply.BackColor = Color.FromArgb(5, 103, 241);
        }

        private void Apply_MouseLeave(object sender, EventArgs e)
        {
            Apply.BackColor = Color.Black;
            Apply.ForeColor = Color.White;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.BackColor = Color.FromArgb(5, 103, 241);
        }

        private void Confirmer_MouseEnter(object sender, EventArgs e)
        {
            Confirmer.BackColor = Color.FromArgb(5, 103, 241);
        }

        private void Confirmer_MouseLeave(object sender, EventArgs e)
        {
            Confirmer.BackColor = Color.Black;
            Confirmer.ForeColor = Color.White;
        }

        private void Confirmer_Click(object sender, EventArgs e)
        {
            Confirmer.BackColor = Color.White;
            Confirmer.ForeColor = Color.Black;
            
            this.Refresh();
            loadingopener();

            try
            {
                impclass imp = new impclass();
                imp.changingorcreate(GoIname.Text, Overview.Text, info_right.Text, GoISel.Text);

                DataTable dt = new DataTable();

                if (GoISel.Text != "")
                {
                    dt = BLL.GoI.getgoi(GoISel.Text);
                    GoIname.Text = dt.Rows[0]["Name"].ToString();
                    Overview.Text = dt.Rows[0]["Overview"].ToString();
                    info_right.Text = dt.Rows[0]["Information"].ToString();//Updating information
                }

                dt = BLL.GoI.Load();
                GoISel.Items.Clear();
                GoISel.Items.Insert(0, "");
                for (int i = 0; i < dt.Rows.Count; i++)
                    GoISel.Items.Insert(i + 1, dt.Rows[i]["Name"]); //Updating the combobox items...
            }
            catch(Exception ee)
            {
                impclass imp = new impclass();
                imp.getError(ee);
            }
        }

        private void GoISel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(GoISel.Text != "")
            {
                DataTable dt = new DataTable();
                dt = BLL.GoI.getgoi(GoISel.Text);
                GoIname.Text = dt.Rows[0]["Name"].ToString();
                Overview.Text = dt.Rows[0]["Overview"].ToString();
                info_right.Text = dt.Rows[0]["Information"].ToString();
            }
            else
            {
                GoIname.Text = "";
                Overview.Text = "";
                info_right.Text = "";
            }
        }

        private void confprof_Click(object sender, EventArgs e)
        {
            try
            {
                loadingopener();
                BLL.Employees.selfchange(impclass.email, nome.Text, profile_text.Text);
                msgdisplayer ms = new msgdisplayer();
                ms.msg_giver("Account edited with success");
                ms.Show();
            }
            catch(Exception ee)
            {
                impclass imp = new impclass();
                imp.getError(ee);
            }
        }

        private void Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Type.Text != "")
                confwaa.Enabled = true;
            else
                confwaa.Enabled = false;
        }

        private void confwaa_Click(object sender, EventArgs e)
        {
            confwaa.BackColor = Color.White;
            confwaa.ForeColor = Color.Black;

            loadingopener();

            if (Article.Text == "" && textBox2.Text == "")
            {
                msgdisplayer ms = new msgdisplayer();
                ms.msg_giver("Name information must be entered...");
                ms.Show();
            }
            else
            {
                DataTable dt = new DataTable();
                impclass imp = new impclass();
                bool exist = false;
                dt = BLL.Article.Load();
                string Clas = "";
                if (comboBox3.Text == "Other")
                {
                    Clas = textBox1.Text;
                    textBox1.Enabled = true;
                }
                else
                {
                    Clas = comboBox3.Text;
                    textBox1.Enabled = false;
                }

                if(Article.Text != "")
                {
                    for (int i = 0; dt.Rows.Count < i; i++)
                    {
                        if (dt.Rows[i]["Name"].ToString() == Article.Text)
                        {
                            exist = true;
                            string Aproval = dt.Rows[i]["Aproved"].ToString();
                            imp.changing_ArticleDB(textBox2.Text, Type.Text, comboBox2.Text, descwaa.Text, Clas, comboBox4.Text, Article.Text, Aproval);
                            break;
                        }
                    }
                }
                if (exist == false)
                    imp.creating_ArticleDB(textBox2.Text, Type.Text, comboBox2.Text, descwaa.Text, Clas, comboBox4.Text);
            }

            confwaa.BackColor = Color.Black;
            confwaa.BackColor = Color.White;
        }

        private void confwaa_MouseEnter(object sender, EventArgs e)
        {
            confwaa.BackColor = Color.FromArgb(5, 103, 241);
        }

        private void confwaa_MouseLeave(object sender, EventArgs e)
        {
            confwaa.BackColor = Color.Black;
            confwaa.ForeColor = Color.White;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            for (int i = 0; dt.Rows.Count < i; i++)
            {
                if (dt.Rows[i]["Name"].ToString() == textBox2.Text)
                {
                    descwaa.Text = dt.Rows[i]["Description"].ToString();
                    break;
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Other")
                textBox1.Enabled = true;
            else
                textBox1.Enabled = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button9.BackColor = Color.White;
            button9.ForeColor = Color.Black;

            loadingopener();

            MaA.Visible = true;
            desc.Size = new Size(MaA.Size.Width - 30, MaA.Size.Height / 2);

            typed.Text = "";
            Classy.Text = "";
            Leveling.Text = "";
            SA.Text = "";

            button9.BackColor = Color.Black;
            button9.ForeColor = Color.White;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            label18.Visible = true;
            Articling.Visible = true;
            label11.Visible = true;
            typed.Visible = true;
            confirming.Visible = true;
            confirming.Location = new Point(MaA.Size.Width - confirming.Size.Width - 30, MaA.Size.Height - confirming.Size.Height - 15);
            comboBox5.Location = new Point(confirming.Location.X - comboBox5.Size.Width - 15, confirming.Location.Y);
            label12.Location = new Point(comboBox5.Location.X - label12.Size.Width - 5, comboBox5.Location.Y);
            DataTable dt = new DataTable();
            Articling.Items.Clear();
            if (comboBox7.Text == "SCP")
            {
                typing = true;
                Description.Location = new Point(Description.Location.X, label17.Location.Y + 30);
                desc.Location = new Point(desc.Location.X, Description.Location.Y + Description.Size.Height + 15);
                dt = BLL.Article.only_SCPs();
                for (int i = 0; i < dt.Rows.Count; i++)
                    Articling.Items.Insert(i, dt.Rows[i]["Name"].ToString());
                typed.Text = "SCP";
            }
            else
            {
                typing = false;
                Description.Location = new Point(label11.Location.X, label11.Location.Y + 30);
                desc.Location = new Point(desc.Location.X, Description.Location.Y + Description.Size.Height + 15);
                dt = BLL.Article.only_tales();
                for (int i = 0; i < dt.Rows.Count; i++)
                    Articling.Items.Insert(i, dt.Rows[i]["Name"].ToString());
                typed.Text = "Tale";
            }
            desc.Visible = true;
            Description.Visible = true;
        }

        private void Managementplacement(bool setter)
        {
            WritterID.Visible = setter;
            label17.Visible = setter;
            SA.Visible = setter;
            label16.Visible = setter;
            Leveling.Visible = setter;
            label15.Visible = setter;
            Classy.Visible = setter;
            label14.Visible = setter;
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            confirming.Enabled = true;
        }

        private void confirming_Click(object sender, EventArgs e)
        {
            confirming.BackColor = Color.White;
            confirming.ForeColor = Color.Black;
            this.Refresh();

            loadingopener();

            impclass imp = new impclass();
            imp.changing_ArticleDB(Articling.Text, typed.Text, SA.Text, desc.Text, Classy.Text, Leveling.Text, Articling.Text, comboBox5.Text);

            confirming.BackColor = Color.Black;
            confirming.ForeColor = Color.White;
        }

        private void Articling_SelectedIndexChanged(object sender, EventArgs e)
        {
            confirming.Visible = true;
            DataTable dt = new DataTable();
            dt = BLL.Article.get_article(Articling.Text);
            Managementplacement(typing);
            if (typing == true)
            {
                Classy.Text = dt.Rows[0]["Class"].ToString();
                Leveling.Text = dt.Rows[0]["LVL"].ToString();
                SA.Text = dt.Rows[0]["SITE_AREA"].ToString();
                WritterID.Text = dt.Rows[0]["Writter"].ToString();
                desc.Text = dt.Rows[0]["Description"].ToString();
            }
            else
            {
                desc.Text = dt.Rows[0]["Description"].ToString();
                Classy.Text = "";
                Leveling.Text = "";
                SA.Text = "";
                WritterID.Text = "";
            }
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.BackColor = Color.FromArgb(5, 103, 241);
            button9.ForeColor = Color.White;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.BackColor = Color.Black;
            button9.ForeColor = Color.White;
        }

        private void Article_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = BLL.Article.get_article(Article.Text);
            comboBox2.Text = dt.Rows[0]["Site_Area"].ToString();
            Type.Text = dt.Rows[0]["Type"].ToString();
            if (dt.Rows[0]["Class"].ToString() != "Safe" && dt.Rows[0]["Class"].ToString() != "Euclid" && dt.Rows[0]["Class"].ToString() != "Keter" && dt.Rows[0]["Class"].ToString() != "Thaumiel" && dt.Rows[0]["Class"].ToString() != "Appolyon")
                textBox1.Text = dt.Rows[0]["Class"].ToString();
            else
                comboBox3.Text = dt.Rows[0]["Class"].ToString();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            comboBox6.Items.Clear();
            if (impclass.admin == true)
            {
                if (comboBox8.Text == "SCP")
                {
                    dt = BLL.Article.only_SCPs();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        comboBox6.Items.Insert(i, dt.Rows[i]["Name"].ToString());
                    }
                }
                else
                {
                    dt = BLL.Article.only_tales();
                    for (int i = 0; i < dt.Rows.Count; i++)
                        comboBox6.Items.Insert(i, dt.Rows[i]["Name"].ToString());
                }
            }
            else
            {
                if (comboBox8.Text == "SCP")
                {
                    dt = BLL.Article.getSCPbyLVL(impclass.level);
                    for (int i = 0; i < dt.Rows.Count; i++)
                        comboBox6.Items.Insert(i, dt.Rows[i]["Name"].ToString());
                }
                else
                {
                    dt = BLL.Article.getTaleByLVL(impclass.level);
                    for (int i = 0; i < dt.Rows.Count; i++)
                        comboBox6.Items.Insert(i, dt.Rows[i]["Name"].ToString());
                }
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = BLL.Article.get_article(comboBox6.Text);
            label22.Text = dt.Rows[0]["Name"].ToString();
            label23.Text = dt.Rows[0]["Class"].ToString();
            textBox3.Text = dt.Rows[0]["Description"].ToString();
            label22.Visible = true;
            label23.Visible = true;
            textBox3.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button10.BackColor = Color.White;
            button10.ForeColor = Color.Black;
            this.Refresh();
            impclass imp = new impclass();
            imp.tec();
            button10.BackColor = Color.Black;
            button10.ForeColor = Color.White;
        }

        private void button10_MouseEnter(object sender, EventArgs e)
        {
            button10.BackColor = Color.FromArgb(5, 103, 241);
            button10.ForeColor = Color.White;
        }

        private void button10_MouseLeave(object sender, EventArgs e)
        {
            button10.BackColor = Color.Black;
            button10.ForeColor = Color.White;
        }
    }
}