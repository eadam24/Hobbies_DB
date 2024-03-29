using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hobbies_DB
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            string sqlCon = @"Data Source=LAB108PC04\SQLEXPRESS; Initial Catalog=loginDB_eric; Integrated Security=True;";

            SqlConnection sqlConnection = new SqlConnection(sqlCon);

            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();

                string Query = $"SELECT COUNT(1) FROM SignCred WHERE Username=@Username AND Password=@Password";

                SqlCommand cmd = new SqlCommand(Query, sqlConnection);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Username", username_text.Text);

                cmd.Parameters.AddWithValue("@Password", password_text.Text);

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
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
    }
