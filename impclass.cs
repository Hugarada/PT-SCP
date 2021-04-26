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
        msgdisplayer msg = new msgdisplayer();

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
            pass = ComputeSha256Hash(pass);
            try
            {
                DataTable dt = new DataTable();
                dt = BLL.Employees.queryEmployee2(email, pass);
                if (dt.Rows.Count == 1)
                {
                    string Nome = dt.Rows[0]["Name"].ToString();
                    username = Nome;
                    Login lg = new Login();
                    lg.Show();
                }
                else
                {
                    msg.msg_giver("Conta tem as credencias erradas ou não existe...");
                    msg.Show();
                }
            }
            catch(Exception ee)
            {
                msg.msg_giver("Ocorreu um erro: " + ee.Message);
                msg.Show();
            }
        }

        public void Registering(string Nome, string e, string pass)
        {
            pass = ComputeSha256Hash(pass);
            try
            {
                DataTable dt = new DataTable();
                dt = BLL.Employees.queryEmployee(e);
                if (dt.Rows.Count == 0)
                {
                    BLL.Employees.insertEmployee(Nome, e, pass);
                    MessageBox.Show("A sua conta foi criada com sucesso");
                    Login ls = new Login();
                    ls.Show();
                    Register rh = new Register();
                    rh.Close();
                }
                else
                {
                    MessageBox.Show("Username ou Email, já existem...");
                }
            }
            catch(Exception ee)
            {
                msg.msg_giver(ee.Message);
                msg.Show();
            }
        }

        public void tec()
        {
            Process process = Process.Start(new ProcessStartInfo(
            ((Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\osk.exe"))));
        }
    }
}
