using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Threading;
using System.Security.Cryptography;
using BusinessLogicLayer;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using BusinessLogicLayer;
using System.Data;

namespace SCP
{
    class impclass
    {
        public static string username, email;
        public static bool admin;
        public static int act;

        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public async void updated(string Email, string Name, string Password, string Roll, string Level, string Group, string SITE_AREA, string CAssignment, string oldpassword, string profiledesc)
        {
            try
            {
                DataTable dt = new DataTable();
                Email = Email.ToUpper(); //getting the email to upper so it fits the DB
                if (Password != "" && oldpassword != "")
                {
                    oldpassword = ComputeSha256Hash(oldpassword);
                    dt = BLL.Employees.confirmpassword(Email, oldpassword);
                    if (dt.Rows.Count == 1)
                        BLL.Employees.alterarPerfil(Email, Password, Name, Roll, Level, Group, SITE_AREA, CAssignment, profiledesc);
                }
                else
                    BLL.Employees.alterarPerfilnonpass(Email, Name, Roll, Level, Group, SITE_AREA, CAssignment, profiledesc);
                
            }
            catch (Exception e)
            {
                getError(e);
            }
        }

        public void changingorcreate(string goiname, string goiover, string goidesc, string formername)
        { 
            try
            {
                if (formername != "")
                {
                    DataTable dt = new DataTable();
                    dt = BLL.GoI.getgoi(formername);
                    int changer = Convert.ToInt32(dt.Rows[0]["ID"]);
                    BLL.GoI.AlterarGoI(goiname, goiover, goidesc, changer);
                }
                else
                {
                    int Max = Convert.ToInt16(BLL.GoI.getMax());
                    BLL.GoI.AlterarGoI(goiname, goiover, goidesc, Max);
                }
                msgdisplayer ms = new msgdisplayer();
                ms.msg_giver("Your information was saved with success");
                ms.Show();
            }
            catch (Exception e)
            {
                getError(e);
            }
        }

        public void logging(string emailed, string pass)
        {
            admin = false;
            act = 1;
            pass = ComputeSha256Hash(pass);
            try
            {
                act = 2;
                DataTable dt = new DataTable();
                emailed = emailed.ToUpper();
                act = 3;
                dt = BLL.Employees.queryEmployee2(emailed, pass);
                if (dt.Rows.Count == 1)
                {
                    string Nome = dt.Rows[0]["Name"].ToString();
                    username = Nome;
                    if (dt.Rows[0]["Roll"].ToString() == "05")
                    {
                        admin = true;
                    }
                    act = 4;
                    Menu mu = new Menu();
                    mu.Show();
                    Login ln = new Login();
                    ln.Hide();
                    act = 5;
                    email = emailed;
                }
                else
                {
                    msgdisplayer msg = new msgdisplayer();
                    msg.msg_giver("The account has wrong creditentials or it doesn't exist...");
                    msg.Show();
                }
            }
            catch(Exception ee)
            {
                getError(ee);
            }
        }

        public void Registering(string Nome, string e, string pass)
        {
            pass = ComputeSha256Hash(pass);
            try
            {
                DataTable dt = new DataTable();
                e = e.ToUpper();
                dt = BLL.Employees.queryEmployee(e);
                if (dt.Rows.Count == 0)
                {
                    int Max = Convert.ToInt16(BLL.Employees.getMax());
                    BLL.Employees.insertEmployee(Nome, e, pass, Max, 0, "Not defined yet");
                    msgdisplayer ms = new msgdisplayer();
                    ms.msg_giver("Your account was created with success...");
                    ms.Show();
                    Login ls = new Login();
                    ls.Show();
                    Register rh = new Register();
                    rh.Close();
                }
                else
                {
                    MessageBox.Show("Username or Email, already exists!");
                }
            }
            catch(Exception ee)
            {
                getError(ee);
            }
        }

        public void getError(Exception e)
        {
            msgdisplayer msg = new msgdisplayer();
            msg.msg_giver(e.Message);
            msg.Show();
        }

        public void tec()
        {
            Process process = Process.Start(new ProcessStartInfo(
            ((Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\osk.exe"))));
        }
    }
}
