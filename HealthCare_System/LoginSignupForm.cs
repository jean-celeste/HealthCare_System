using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HealthCare_System
{
    public partial class LoginSignupForm : Form
    {
        //private DatabaseConnection dbConn;
        //Connection String
        private MySqlConnection conn;
        private UserAdmin_Prompt userAdminPromptInstance;



        public LoginSignupForm()
        {
            InitializeComponent();
            conn = DatabaseConnection.GetConnection();
            this.FormClosing += LoginSignupForm_FormClosing;
            // this.dbConn = dbConn;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }


                string username = usernameTextBox.Text;
                string password = passwordTextBox.Text;

                string query = $"SELECT COUNT(*) FROM user WHERE (username = '{username}' OR email = '{username}') AND password = '{password}'";

                try
                {
                    int count = 0;

                    MySqlCommand command = new MySqlCommand(query, conn);

                    count = Convert.ToInt32(command.ExecuteScalar());


                    if (count > 0)
                    {
                        // User credentials are correct
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainForm main = new MainForm(null, this);
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        // Invalid credentials
                        MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close(); // Close the connection
            }
            



        }

        private void MainForm_ExitButtonClicked(object sender, EventArgs e)
        {
            this.Show(); // Show the LoginSignupForm again
        }

        private void signInLabel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        Color select_color = Color.SandyBrown;
        private void goToLoginBtn_Click(object sender, EventArgs e)
        {
            loginPanel.BringToFront();
            goToLoginBtn.BackColor = select_color;
            //signUpBtn.BackColor = Color.DarkSlateGray;
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            signUpPanel.BringToFront();
            //signUpBtn.BackColor = select_color;
            goToLoginBtn.BackColor = Color.DarkSlateGray;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = DatabaseConnection.GetConnection(); // Obtain the connection object

            try
            {
                conn.Open();

                // Retrieve text values from custom controls
                string name = FirstName.TextValue + " " + LastName.TextValue;
                string signUpUsername = username.TextValue;
                string signUpPassword = password.TextValue;
                string signUpEmail = email.TextValue;

                // Check for null or empty values
                if (!string.IsNullOrEmpty(FirstName.TextValue) && !string.IsNullOrEmpty(signUpUsername) &&
                    !string.IsNullOrEmpty(signUpPassword) && !string.IsNullOrEmpty(signUpEmail))
                {
                    string query = "INSERT INTO user (name, username, password, email) VALUES (@name, @signUpUsername, @signUpPassword, @signUpEmail)";
                    if (signUpPassword == confirmPass.TextValue)
                    {
                        MySqlCommand command = new MySqlCommand(query, conn);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@signUpUsername", signUpUsername);
                        command.Parameters.AddWithValue("@signUpPassword", signUpPassword);
                        command.Parameters.AddWithValue("@signUpEmail", signUpEmail);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("User successfully registered!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to register user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Passwords Don't Match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }


        }


        private void customTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void LoginSignupForm_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        string randomCode;
        public static string to;
        private void button4_Click(object sender, EventArgs e)
        {
            /*Verification verifyFrm = new Verification();
            verifyFrm.ShowDialog();*/

            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();

            MailMessage message = new MailMessage();
            to = (textBox8.Text).ToString();
            from = "edptest137@gmail.com";
            pass = "bowd dghx tcsc hgsn";
            messageBody = $"Your Verification Code is: {randomCode}";
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Account Recovery Verificatio Code:";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Verification Code Sent Successfully! Please Check your Email.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountRecovery.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (randomCode == (textBox1.Text).ToString())
            {
                to = textBox8.Text;
                Recovery recovery = new Recovery();
                this.Hide();
                recovery.Show();
            }
            else
            {
                MessageBox.Show("Wrong Verification Code!");
            }
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

        private void confirmPass_Load(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
