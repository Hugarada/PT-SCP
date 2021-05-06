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
        public static string username;
        public static bool admin;

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

        public void logging(string email, string pass)
        {
            admin = false;
            pass = ComputeSha256Hash(pass);
            try
            {
                DataTable dt = new DataTable();
                email = email.ToUpper();
                dt = BLL.Employees.queryEmployee2(email, pass);
                if (dt.Rows.Count == 1)
                {
                    string Nome = dt.Rows[0]["Name"].ToString();
                    username = Nome;
                    if (dt.Rows[0]["Roll"].ToString() == "05")
                    {
                        admin = true;
                    }
                    Menu mu = new Menu();
                    mu.Show();
                    Login ln = new Login();
                    ln.Hide();
                }
                else
                {
                    msgdisplayer msg = new msgdisplayer();
                    msg.msg_giver("A conta tem as credenciais erradas ou não existe...");
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
                    MessageBox.Show("A sua conta foi criada com sucesso");
                    Login ls = new Login();
                    ls.Show();
                    Register rh = new Register();
                    rh.Close();
                }
                else
                {
                    MessageBox.Show("Username ou email ja existem!");
                }
            }
            catch(Exception ee)
            {
                getError(ee);
            }
        }

        private void getError(Exception e)
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
