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
    public partial class RecoveryUser : Form
    {
        private MySqlConnection conn;
        string email = LoginSignupForm.to;
        public RecoveryUser()
        {
            InitializeComponent();
            conn = DatabaseConnection.GetConnection();
            this.FormClosing += LoginSignupForm_FormClosing;
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

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    string query = "UPDATE `healthcare_db`.`patient` SET `password` = @password WHERE `email` = @email";

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
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Passwords do not match!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            LoginUser loginfrm = new LoginUser();
            this.Hide();
            loginfrm.Show();
        }
        private void LoginSignupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ask the user for confirmation before closing the form
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Cancel the closing event
            }
            else
            {
                UserAdmin_Prompt prompt = new UserAdmin_Prompt();
                prompt.Show();

            }
        }


        private void confirmPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

