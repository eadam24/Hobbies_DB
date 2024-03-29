using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hobbies_DB
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void add_button_country_Click(object sender, EventArgs e)
        {
            string sqlConnection = @"Data Source=LAB108PC04\SQLEXPRESS; Initial Catalog=Tourism_Eric; Integrated Security=True";


            try
            {
                SqlConnection conn = new SqlConnection(sqlConnection);
                conn.Open();
                string query = $"Insert into Countries(ID,Country) values " +
                    $"('{id_country.Text}', '{country_text.Text}')";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Added {country_text.Text} with ID {id_country.Text} to Countries");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void add_button_town_Click(object sender, EventArgs e)
        {
            string sqlConnection = @"Data Source=LAB108PC04\SQLEXPRESS; Initial Catalog=Tourism_Eric; Integrated Security=True";


            try
            {
                SqlConnection conn = new SqlConnection(sqlConnection);
                conn.Open();
                string query = $"Insert into Towns(ID,Town, Countries_ID) values " +
                    $"('{id_town.Text}', '{town_text.Text}', '{country_id.Text}')";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Added {town_text.Text} with ID {id_town.Text} and Country ID {country_id.Text} to Towns");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void return_button_Click(object sender, EventArgs e)
        {
            Main mainWindow = new Main();

            mainWindow.Show();
            this.Hide();
        }

        private void remove_button_country_Click(object sender, EventArgs e)
        {
            string sqlConnection = @"Data Source=LAB108PC04\SQLEXPRESS; Initial Catalog=Tourism_Eric; Integrated Security=True";

            try
            {
                SqlConnection conn = new SqlConnection(sqlConnection);
                conn.Open();
                string query = $"DELETE FROM Countries where Country = '{country_text.Text}'";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.ExecuteNonQuery();
                MessageBox.Show($"Deleted {country_text.Text} from Countries");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void remove_button_town_Click(object sender, EventArgs e)
        {
            string sqlConnection = @"Data Source=LAB108PC04\SQLEXPRESS; Initial Catalog=Tourism_Eric; Integrated Security=True";

            try
            {
                SqlConnection conn = new SqlConnection(sqlConnection);
                conn.Open();
                string query = $"DELETE FROM Towns where Town = '{town_text.Text}'";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.ExecuteNonQuery();

                MessageBox.Show($"Deleted {town_text.Text} from Towns");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
