using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hobbies_DB
{
    public partial class Main : Form
    {
        List<string> Countries = new List<string>();
        private LogIn logIn;

        public Main()
        {
            InitializeComponent();
            GetCountries();

            foreach(string s in Countries)
            countries_combobox.Items.Add(s);
           
        }

        private void GetCountries()
        {
            string sqlCon = @"Data Source=LAB108PC04\SQLEXPRESS; Initial Catalog=Tourism_Eric; Integrated Security=True;";

            SqlConnection sqlConnection = new SqlConnection(sqlCon);

            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();

                string Query = $"SELECT Country FROM Countries";

                SqlCommand cmd = new SqlCommand(Query, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Countries.Add(reader["Country"].ToString());
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void PopulateTowns(int id)
        {
            string sqlCon = @"Data Source=LAB108PC04\SQLEXPRESS; Initial Catalog=Tourism_Eric; Integrated Security=True;";

            SqlConnection sqlConnection = new SqlConnection(sqlCon);

            try
            {
                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();

                string Query = $"SELECT Town FROM Towns Where Countries_ID = @id";

                SqlCommand cmd = new SqlCommand(Query, sqlConnection);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                List<string> Towns = new List<string>();


                while (reader.Read()) 
                {
                    Towns.Add(reader["Town"].ToString());
                }

                towns_combobox.DataSource = Towns;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void countries_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(countries_combobox.SelectedIndex != null)
            {
                int selectedCountryId = Convert.ToInt32(countries_combobox.SelectedIndex+1);

                PopulateTowns(selectedCountryId);
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void admin_button_Click(object sender, EventArgs e)
        {
            Admin adminWindow = new Admin();

            adminWindow.Show();
            this.Hide();
        }
    }
    }
