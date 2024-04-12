using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hobbies_DB
{
    public partial class LogIn : Form
    {
        public string currentUser = "";
        public string hashed = "";
        public LogIn()
        {
            InitializeComponent();
        }
        public string GetCurrentUser()
        {
            return currentUser;
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            string sqlCon = @"Data Source=LAB108PC04\SQLEXPRESS; Initial Catalog=loginDB_eric; Integrated Security=True;";



            SqlConnection sqlConnection = new SqlConnection(sqlCon);
            try
            {

                
                if (CheckUsernameErrors() && CheckPasswordErrors())
                {
                    usernameError.SetError(username_text, "");
                    passError.SetError(password_text, "");

                    if (password_text.Text == password_text_2.Text)
                    {

                        if (sqlConnection.State == ConnectionState.Closed)
                            sqlConnection.Open();

                        string Query1 = $"SELECT Date FROM SignCred WHERE Username=@Username";

                        SqlCommand cmd = new SqlCommand(Query1, sqlConnection);

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Username", username_text.Text);

                        using (SqlDataReader oReader = cmd.ExecuteReader())
                        {
                            while (oReader.Read())
                            {
                                String date = (String)oReader["Date"];
                                

                                byte[] bytes = Encoding.UTF8.GetBytes(date);
                                hashed = HashPassword(password_text.Text, bytes);
                            }
                            oReader.Close();

                            string Query = $"SELECT COUNT(1) FROM SignCred WHERE Username=@Username AND Password=@Password";

                                cmd = new SqlCommand(Query, sqlConnection);

                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@Username", username_text.Text);

                                cmd.Parameters.AddWithValue("@Password", hashed);

                                int count = Convert.ToInt32(cmd.ExecuteScalar());
                                if (count == 1)
                                {

                                    Main mainWindow = new Main();

                                    mainWindow.Show();
                                    this.Hide();


                                }
                                else
                                {
                                    MessageBox.Show("Try again!");
                                }
                            
                        }

                    }
                    else
                    {
                        MessageBox.Show("Passwords should match!");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            }

        private bool CheckPasswordErrors()
        {
            string pass = password_text.Text;
            char[] special = { '!', '@', '#', '$', '%', '^' };
            bool containsSpec = false ;
            bool corrLenght = false ;


            foreach (char c in special)
            {
                if (pass.Contains(c))
                {
                    containsSpec = true ;
                }
                else
                {
                    passError.SetError(password_text, "Pass has to contain special character");
                }
            }
            if(pass.Length >= 5)
            {
                corrLenght = true ;
               
            }
            else 
            {
                passError.SetError(password_text, "Pass has to be 5 chars");

                corrLenght = false;                 
            }

            if (corrLenght && containsSpec)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool CheckUsernameErrors()
        {
     
            bool corrLenght = false;
            string username = username_text.Text;


            if (username.Length >= 5)
            {
                corrLenght = true;

            }
            else
            {
                usernameError.SetError(username_text, "Username cannot be empty!");

                corrLenght = false;
            }

            if (corrLenght)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void signIn_button_Click(object sender, EventArgs e)
        {
            SignIn signWindow = new SignIn();

            signWindow.Show();
            this.Hide();

        }
        static string HashPassword(string password, byte[] salt)
        {
            using (var sha256 = new SHA256Managed())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] saltedPassword = new byte[passwordBytes.Length + salt.Length];

                // Concatenate password and salt
                Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

                // Hash the concatenated password and salt
                byte[] hashedBytes = sha256.ComputeHash(saltedPassword);

                // Concatenate the salt and hashed password for storage
                byte[] hashedPasswordWithSalt = new byte[hashedBytes.Length + salt.Length];
                Buffer.BlockCopy(salt, 0, hashedPasswordWithSalt, 0, salt.Length);
                Buffer.BlockCopy(hashedBytes, 0, hashedPasswordWithSalt, salt.Length, hashedBytes.Length);

                return Convert.ToBase64String(hashedPasswordWithSalt);
            }
        }

 
    }
    }
