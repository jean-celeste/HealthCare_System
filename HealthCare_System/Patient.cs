using HealthCare_System;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HealthCare_System
{
    public partial class Patient : UserControl
    {
        private MySqlConnection conn;
        private health_info healthInfoFrm;
        public Patient()
        {
            InitializeComponent();
            conn = DatabaseConnection.GetConnection();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void Rental_Load(object sender, EventArgs e)
        {
            LoadData();
            clear();
        }
        private void Rental_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            clear();
        }

        public void LoadData()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Create a DataTable to hold the data
            DataTable dataTable = new DataTable();

            string query = @"
                    SELECT p.patient_id, p.patient_name, p.age, p.gender, p.address, p.phone, p.email
                    FROM healthcare_db.patient AS p";

            MySqlCommand command = new MySqlCommand(query, conn);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                // Load data into the DataTable
                dataTable.Load(reader);
                
            }

            // Clear the DataGridView
            dataGridView1.Rows.Clear();

            // Populate the DataGridView with data from the DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                dataGridView1.Rows.Add(
                    row["patient_id"].ToString(),
                    row["patient_name"].ToString(),
                    row["age"].ToString(),
                    row["gender"].ToString(),
                    row["address"].ToString(),
                    row["phone"].ToString(),
                    row["email"].ToString()
                   
                );
            }

            // Close the connection after loading data
            conn.Close();
        }




        public void clear()
        {
            dataGridView1.ClearSelection();
            cust_name.Clear();
            cust_email.Clear();
            cust_phone.Clear();
            cust_address.Clear();
            patientPhone.Clear();
            patientEmail.Clear();
        }

        
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            // Check if there is at least one row selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //saveBtn.Enabled = false;
                updateBtn.Enabled = true;
                deleteBtn.Enabled = true;
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Populate textboxes with data from the selected row
                cust_name.Text = selectedRow.Cells["Column1"].Value.ToString();
                cust_email.Text = selectedRow.Cells["Column2"].Value.ToString();
                cust_phone.Text = selectedRow.Cells["Column3"].Value.ToString();
                cust_address.Text = selectedRow.Cells["Column4"].Value.ToString();
                patientPhone.Text = selectedRow.Cells["Column5"].Value.ToString();
                patientEmail.Text = selectedRow.Cells["Column5"].Value.ToString();
                //book.Text = selectedRow.Cells["Column6"].Value.ToString();

                /*

                string customer_id = selectedRow.Cells["Column0"].Value.ToString();

                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    // Construct the query to fetch the borrowed books for the selected customer
                    string query = "SELECT borrowed_books FROM books_db.customers WHERE customer_id = @customer_id";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("@customer_id", customer_id);

                    // Execute the query and read the borrowed_books value
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Fetch the value of the 'borrowed_books' column
                            string borrowedBooks = reader["borrowed_books"].ToString();
                            // Display the borrowed books in the textbox
                            book.Text = borrowedBooks;

                        }
                        //reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close(); // Close the connection after using it
                }
*/

            }
            else
            {
                //saveBtn.Enabled = true;
                updateBtn.Enabled = false;
                deleteBtn.Enabled = false;
            }
        }

        private void udpateBtn_Click(object sender, EventArgs e)
        {
            // Get the selected customer_id from the DataGridView
            string patient_id = dataGridView1.CurrentRow.Cells["Column0"].Value.ToString();

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string query = "UPDATE `healthcare_db`.`patient`" +
                               " SET `patient_name` = @patient_name," +
                               " `age` = @age," +
                               " `gender` = @gender," +
                               " `address` = @address," +
                               " `phone` = @phone," +
                               " `email` = @email" +
                               " WHERE `patient_id` = @patient_id"; // Use parameter for customer_id

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@patient_id", patient_id);
                command.Parameters.AddWithValue("@patient_name", cust_name.Text);
                command.Parameters.AddWithValue("@age", cust_email.Text);
                command.Parameters.AddWithValue("@gender", cust_phone.Text);
                command.Parameters.AddWithValue("@address", cust_address.Text);
                command.Parameters.AddWithValue("@phone", patientPhone.Text);
                command.Parameters.AddWithValue("@email", patientEmail.Text);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No records were updated!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadData(); // Reload data after the operation
                conn.Close(); // Close the connection
                clear(); // Clear the form fields
            }
        }


        private void cancelBtn_Click(object sender, EventArgs e)
        {
            string patient_id = dataGridView1.CurrentRow.Cells["Column0"].Value.ToString();
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Delete health records associated with the patient
                        string healthRecordQuery = "DELETE FROM `healthcare_db`.`health_records` WHERE `patient_id` = @patient_id";
                        MySqlCommand healthRecordCommand = new MySqlCommand(healthRecordQuery, conn, transaction);
                        healthRecordCommand.Parameters.AddWithValue("@patient_id", patient_id);
                        int healthRecordRowsAffected = healthRecordCommand.ExecuteNonQuery();

                        // Delete the patient record
                        string patientQuery = "DELETE FROM `healthcare_db`.`patient` WHERE `patient_id` = @patient_id";
                        MySqlCommand patientCommand = new MySqlCommand(patientQuery, conn, transaction);
                        patientCommand.Parameters.AddWithValue("@patient_id", patient_id);
                        int patientRowsAffected = patientCommand.ExecuteNonQuery();

                        // Commit the transaction if both delete operations are successful
                        transaction.Commit();

                        if (healthRecordRowsAffected > 0 && patientRowsAffected > 0)
                        {
                            MessageBox.Show("Patient record and associated health records successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No records were deleted!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Rollback the transaction if an error occurs
                        transaction.Rollback();
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadData(); // Reload data after the operation
                conn.Close(); // Close the connection
                clear(); // Clear the form fields
            }
        }

        private void cust_search_TextChanged(object sender, EventArgs e)
        {
            // Clear the DataGridView before adding new rows
            dataGridView1.Rows.Clear();

            // Check if the connection is not open, then open it
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Get the search pattern from the TextBox
            string searchPattern = cust_search.Text;

            // Construct the SQL query with parameterized search pattern
            string query = "SELECT * FROM healthcare_db.patient " +
                            "WHERE patient_id LIKE @searchPattern OR " +
                            "patient_name LIKE @searchPattern OR " +
                            "address LIKE @searchPattern";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@searchPattern", "%" + searchPattern + "%");

            // Create a DataTable to hold the results
            DataTable dataTable = new DataTable();

            // Create a DataAdapter to fill the DataTable
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            // Fill the DataTable with results from the query
            adapter.Fill(dataTable);

            // Populate the DataGridView with data from the DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                dataGridView1.Rows.Add(
                    row["patient_id"].ToString(),
                    row["patient_name"].ToString(),
                    row["age"].ToString(),
                    row["gender"].ToString(),
                    row["address"].ToString(),
                    row["phone"].ToString(),
                    row["email"].ToString()
                    
                );
            }

            // Clear form fields after populating DataGridView
            clear();

            // Close the connection
            conn.Close();
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void book_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string patient_id = dataGridView1.CurrentRow.Cells["Column0"].Value.ToString();

            healthInfoFrm = new health_info();
            healthInfoFrm.LoadData(patient_id);
            Controls.Add(healthInfoFrm);
            healthInfoFrm.Location = new Point(0, 0);
            healthInfoFrm.BringToFront();

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void patientPhone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
