using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HealthCare_System
{
    public partial class Recovery : Form
    {
        private MySqlConnection conn;
        string email = LoginSignupForm.to;
        public Recovery()
        {
            InitializeComponent();
            conn = DatabaseConnection.GetConnection();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginBtn2_Click(object sender, EventArgs e)
        {
            string newPassword = newPasswordTextBox.Text;

            if (newPasswordTextBox.Text == confirmPassword.Text) // Compare with confirm password
            {
                try
                {
                    using (conn = DatabaseConnection.GetConnection())
                    {
                        conn.Open();

                        string query = "UPDATE `books_db`.`user` SET `password` = @password WHERE `email` = @email";

                        MySqlCommand command = new MySqlCommand(query, conn);
                        command.Parameters.AddWithValue("@password", newPassword);
                        command.Parameters.AddWithValue("@email", email);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No records were updated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            LoginSignupForm loginfrm = new LoginSignupForm();
            this.Hide();
            loginfrm.Show();
        }

        private void confirmPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

