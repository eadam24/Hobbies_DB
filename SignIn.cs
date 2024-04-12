using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Hobbies_DB
{
    public partial class SignIn : Form
    {
        string sqlConnection = @"Data Source=LAB108PC04\SQLEXPRESS; Initial Catalog=loginDB_eric; Integrated Security=True";
       

        public SignIn()
        {
            InitializeComponent();
        }

        private void register_button_Click(object sender, EventArgs e)
        {
            string date = System.DateTime.Now.ToString();
            byte[] bytes = Encoding.UTF8.GetBytes(date);
            string hashed = HashPassword(password.Text, bytes);
            try
            {


                if (CheckUsername() && CheckNames() && CheckEmail() && CheckPassword())
                {

                    SqlConnection conn = new SqlConnection(sqlConnection);
                    conn.Open();
                    string query = $"Insert into SignCred(Username, FirstName, LastName, Email, Password, Date) values " +
                        $"('{username.Text}', '{fname.Text}', '{lname.Text}', '{email.Text}', '{hashed}', '{date}')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();

                }
                else
                {
                    MessageBox.Show("Not succesfull");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private bool CheckUsername()
        {
            if (username.Text == string.Empty)
            {
                MessageBox.Show("Username Not Complete", "Incorrect Username!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool CheckEmail()
        {
            if (email.Text == string.Empty || !email.Text.Contains("@"))
            {
                MessageBox.Show("Email Not Complete", "Incorrect Email!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CheckNames()
        {
            if (fname.Text == string.Empty || lname.Text == string.Empty)
            {
                MessageBox.Show("Enter Names", "Incorrect Names!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool CheckPassword()
        {
            string text = password.Text;

            if (text.Length < 5 || !PasswordContainsChar())
            {
                MessageBox.Show("Try New Password", "Password Not Correct!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool PasswordContainsChar()
        {
            char[] arr = { '@', '!', '#', '$', '%', '^', '&', '*' };


            foreach (char c in arr)
            {
                if (password.Text.Contains(c.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            LogIn loginWindow = new LogIn();

            loginWindow.Show();

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

        private void browse_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
            }
        }
        private byte[] saveImage()
        {
            MemoryStream memoryStream = new MemoryStream();
            pictureBox1.Image.Save(memoryStream, pictureBox1.Image.RawFormat);
            return memoryStream.GetBuffer();
        }

        private void save_photo_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(sqlConnection);
            conn.Open();
            string query = $"Update SignCred Set Image=@photo where Username =@Username";
            
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@photo", saveImage());
            cmd.Parameters.AddWithValue("@Username", username.Text);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
